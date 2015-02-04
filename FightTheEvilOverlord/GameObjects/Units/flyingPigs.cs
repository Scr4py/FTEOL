using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class flyingPigs : GameObject
    {
        public int number;
        public Player player;
        public Tile tile;
        public flyingPigs(Tile tile)
        {
            this.tile = tile;
        }
    }
}
