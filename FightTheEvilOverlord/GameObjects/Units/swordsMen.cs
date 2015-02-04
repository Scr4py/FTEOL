using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class swordsMen : GameObject
    {
        public int number;
        public Tile tile;
        public Player player;
        public swordsMen(Tile tile)
        {
            this.tile = tile;
        }
    }
}
