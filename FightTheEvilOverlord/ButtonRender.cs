using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class ButtonRender :  Component
    {
        public Texture2D Image;
        public int ImageWidth;
        public int ImageHeight;

        Transform transform;

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;

        }

        public void Setimage(Texture2D image, int width, int height)
        {
            this.Image = image;
            this.ImageHeight = height;
            this.ImageWidth = width;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, new Rectangle((int)transform.Position.X, (int)transform.Position.Y, ImageWidth, ImageHeight), Color.White);
        }


    }
}
