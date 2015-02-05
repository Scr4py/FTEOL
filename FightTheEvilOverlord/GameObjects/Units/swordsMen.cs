using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class SwordsMen : GameObject
    {
        public int number;
        public Tile tile;
        public Player player;
        public int playerNumber;
        public int activeSoldiers;
        public int soldiersNumber;

        public SwordsMen(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber)
        {
            this.tile = Spawntile;
            this.playerNumber = PlayerNumber;
            this.activeSoldiers = ActiveSoldiers;
            this.soldiersNumber = SoldiersNumber;
        }


    }
}
