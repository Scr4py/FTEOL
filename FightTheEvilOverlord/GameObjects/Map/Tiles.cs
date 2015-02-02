using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Tiles
    {
        private enum Types { plaines, mountain, forest, village };

        public Types type { get; set; }

        public Tiles()
        {
            Random rnd = new Random();
            int random = rnd.Next(2);
        }
        public Tiles(String village)
        {

        }
    }
}
