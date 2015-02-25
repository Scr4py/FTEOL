using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FightTheEvilOverlord
{
    class HudRender : Component
    {
        Texture2D image;
        SpriteFont font;
        Transform transform;

        float scale = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920.0f;
        List<Texture2D> imageList = new List<Texture2D>();
        public List<string> textList = new List<string>();
        List<Vector2> vectorList = new List<Vector2>();
        List<Vector2> imageVectorList = new List<Vector2>();

        public void start()
        {
            this.transform = this.GameObject.GetComponent<Transform>();
            EventManager.OnRender += hudRender;
            EventManager.OnRender += UnitPic;
        }

        private void UnitPic(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < imageList.Count; i++)
            {
                spriteBatch.Draw(imageList[i], imageVectorList[i], null, Color.White, 0, Vector2.Zero, scale / 13, SpriteEffects.None, 0);
            }

        }


        private void hudRender(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, new Vector2(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (76 * scale)), null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            for (int i = 0; i < this.textList.Count; i++)
            {
                    spriteBatch.DrawString(font, textList[i], vectorList[i], Color.White);
                
            }
            
        }

        public void SetFont(SpriteFont spriteFont)
        {
            this.font = spriteFont;
        }

        public void SetText(string text, Vector2 position)
        {
            this.textList.Add(text);
            this.vectorList.Add(position);
            
        }

        public void setImage(Texture2D image,Vector2 imagePosition)
        {
            this.imageList.Add(image);
            this.imageVectorList.Add(imagePosition);
        }

        public void SetBackGroundImage(Texture2D image)
        {
            this.image = image;
        }


        public override void Destroy()
        {
            EventManager.OnRender -= hudRender;
            EventManager.OnRender -= UnitPic;
        }
    }
}
