using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Buttons :  GameObject
    {
        private Renderer render;
        private Transform transform;

        public Buttons(Texture2D image)
        {
            this.transform = this.AddComponent<Transform>();
            
        }
    }
}
