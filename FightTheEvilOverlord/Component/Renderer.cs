using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FightTheEvilOverlord
{
    class Renderer : Component
    {
        Transform transform;
        Texture2D image;

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, Color.White);
        }

        public void Render(Texture2D image)
        {
            this.image = image;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
        }
    }
}
