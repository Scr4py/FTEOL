using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FightTheEvilOverlord
{
    class SpriteFontRenderer : Component
    {
        
        SpriteFont font;
        List<string> textList = new List<string>();
        List<Vector2> vectorList = new List<Vector2>();
        public void start()
        {
            EventManager.OnRender += SpriteFontRender;
        }

        private void SpriteFontRender(SpriteBatch spriteBatch)
        {
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

        public override void Destroy()
        {
            EventManager.OnRender -= SpriteFontRender;
        }
    }
}
