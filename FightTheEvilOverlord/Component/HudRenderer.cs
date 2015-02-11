using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FightTheEvilOverlord
{
    class HudRenderer : Component
    {
        Transform transform;
        Texture2D image;
        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += HudRender;
        }

        private void HudRender(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, Color.White);
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }
    }
}
