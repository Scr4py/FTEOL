using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class UnitRenderer : Component
    {
        public const float scale = 0.15f;
        Transform transform;
        Texture2D image;
        SpriteFont Font;
        int intToDisplay;

        public void start()
        {
            Font = Utility.Font;
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
            EventManager.OnRender += RenderInteger;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        private void RenderInteger(SpriteBatch spriteBatch)
        {
            if (this.Font != null)
            {
                spriteBatch.DrawString(Font, intToDisplay.ToString(), this.transform.Position, Color.White);
            }
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }
        public void SetInteger(int integer)
        {
            this.intToDisplay = integer;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            base.Destroy();
        }

    }
}
