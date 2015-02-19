using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class Camera
    {
        private const float ViewMargin = 0.2f;

        public float X { get; set; }

        public void ScrollView(Viewport viewport)
        {
            float marginWidth = viewport.Width * ViewMargin;
            float marginLeft = this.X + marginWidth;
            float marginRight = this.X + viewport.Width - marginWidth;

            float cameraTranslation = 0f;

            //cameraTranslation = this.target.Position.X - marginLeft;

            this.X = MathHelper.Clamp(this.X + cameraTranslation, 0f, 1920 - viewport.Width);
        }
    }
}
