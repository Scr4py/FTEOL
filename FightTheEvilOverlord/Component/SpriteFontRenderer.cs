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
        Transform transform;
        SpriteFont font;
        string text;
        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += SpriteFontRender;
        }

        private void SpriteFontRender(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, this.transform.Position, Color.White);
        }

        public void SetFont(SpriteFont spriteFont)
        {
            this.font = spriteFont;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public void SetVector(Vector2 transform)
        {
            this.transform.Position = transform;
        }

    }
}
