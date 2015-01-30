using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class SpriteAnimation : Component
    {
        private Dictionary<string, Rectangle[]> dictionary = new Dictionary<string, Rectangle[]>();
        private string atlasName;
        private int frame;
        public float AnimationSpeed = 100;
        private float timer;
        private Texture2D atlas;
        public Rectangle[] CurFrames;
        Transform transform;

        public void Start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
            EventManager.OnUpdate += Update;
        }

        private void Update(GameTime gameTime)
        {
            this.timer += gameTime.ElapsedGameTime.Milliseconds;
            if (this.timer >= this.AnimationSpeed)
            {
                this.timer = 0;
                if (this.frame < CurFrames.Length - 1)
                {
                    frame++;
                }
                else
                {
                    this.frame = 0;
                }
            }
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.atlas, this.transform.Position, CurFrames[frame], Color.White);
        }

        private void Render(Texture2D atlas)
        {
            this.atlas = atlas;
        }

        private void UseAnimation(string atlas)
        {
            dictionary.TryGetValue(atlas, out CurFrames);
        }

        private void AddInDictionary(string path, string spriteName)
        {
            XmlReader reader = XmlReader.Create(path);
            List<Rectangle> spriteRectangle = new List<Rectangle>();
            while(reader.Read())
            {
                if (reader.IsStartElement("sprite"))
                {
                    string name = reader.GetAttribute("n");

                    if (name.Contains(spriteName))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = Convert.ToInt32(reader.GetAttribute("x"));
                        rectangle.Y = Convert.ToInt32(reader.GetAttribute("y"));
                        rectangle.Height = Convert.ToInt32(reader.GetAttribute("h"));
                        rectangle.Width = Convert.ToInt32(reader.GetAttribute("w"));

                        spriteRectangle.Add(rectangle);
                    }
                }
            }
            dictionary.Add(spriteName, spriteRectangle.ToArray());
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            EventManager.OnUpdate -= Update;
        }

    }
}
