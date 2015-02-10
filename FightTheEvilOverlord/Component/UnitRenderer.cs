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
        int intToDisplay;
        int secIntToDisplay;
        Color intColor = Color.White;
        public Color PicColor = Color.White;
        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
            EventManager.OnRender += RenderInteger;
            EventManager.OnRender += RenderSecInteger;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, null, PicColor, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        private void RenderInteger(SpriteBatch spriteBatch)
        {
            if (Utility.Font != null)
            {
                spriteBatch.DrawString(Utility.Font, intToDisplay.ToString(), this.transform.Position, Color.Red);
            }
        }
        private void RenderSecInteger(SpriteBatch spriteBatch)
        {
            if (Utility.Font != null)
            {
                spriteBatch.DrawString(Utility.Font, secIntToDisplay.ToString(), new Vector2(this.transform.Position.X, this.transform.Position.Y + 20), Color.DarkGreen);
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

        public void SetSecInteger(int integer)
        {
            this.secIntToDisplay = integer;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            EventManager.OnRender -= RenderInteger;
            EventManager.OnRender -= RenderSecInteger;
            base.Destroy();
        }

    }
}
