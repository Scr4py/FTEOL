using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class Archer : GameObject
    {
        public int number;
        public int owner;
        public Tile tile;
        public Archer(Tile tile)
        {
            this.tile = tile;
        }
    }
}
