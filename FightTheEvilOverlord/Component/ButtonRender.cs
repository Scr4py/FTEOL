using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class ButtonRender : Component
    {
        public float Scale = 1f;
        Rectangle source;
        private List<Texture2D> textureList = new List<Texture2D>();
        private List<Rectangle> rectangleList = new List<Rectangle>();

        Transform transform;

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < textureList.Count ; i++)
            {
                spriteBatch.Draw(textureList[i],this.transform.Position,rectangleList[i],Color.White,0,Vector2.Zero,Scale,SpriteEffects.None,0);
            }
        }

        public void AddInLists(Texture2D image)
        {
            this.source = new Rectangle((int)this.transform.Position.X,(int)this.transform.Position.Y, image.Width, image.Height);
            textureList.Add(image);
            rectangleList.Add(source);
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            base.Destroy();
        }
        
    }
}
