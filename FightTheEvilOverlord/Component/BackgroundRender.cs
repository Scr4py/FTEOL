using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class BackgroundRender :  Component
    {
        Texture2D image;
        Transform transform;
        float scale = 0.35f;

        public void start()
        {
            this.transform = this.GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image,this.transform.Position,null,Color.White,0,Vector2.Zero,scale,SpriteEffects.None,0);
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }

        public void SetPosition(Vector2 position)
        {
            this.transform.Position = position;
        }
    }
}
