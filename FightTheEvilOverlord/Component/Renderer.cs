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
        public const float scale = 0.085f;
        public float SecScale = 0.085f;
        Transform transform;
        Texture2D image;
        public Color drawColor = Color.White;
        public void Start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            if (this.image != null)
            {
                spriteBatch.Draw(this.image, this.transform.Position, null, drawColor, 0, Vector2.Zero, SecScale, SpriteEffects.None, 0);
            }
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            base.Destroy();
        }
    }
}
