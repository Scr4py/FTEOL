using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Menue :  GameObject
    {
        private CompoundRenderer render;
        private Transform transform;
        public bool isPlayed = false;

        public Menue(Texture2D image, Rectangle source)
        {
            this.transform = this.AddComponent<Transform>();

            this.render = this.AddComponent<CompoundRenderer>();
            this.render.AddInLists(image, source);
            this.render.start();
        }
    }
}
