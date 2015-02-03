using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Tile : GameObject
    {
        public enum Types { plaines, mountain, forest, village };
        public Types Type { get; private set; }
        public Tile()
        {
            Random rnd = new Random();
            int random = rnd.Next(2);
        }
        public Tile(String village)
        {

        }
    }
}
