using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Transform : Component
    {
        private Vector2 position = Vector2.Zero;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public void Translate(float x, float y)
        {
            this.position += new Vector2(x, y);
        }

        public void Translate(Vector2 translation)
        {
            this.position += translation;
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
