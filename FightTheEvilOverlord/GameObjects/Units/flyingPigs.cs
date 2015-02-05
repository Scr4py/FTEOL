using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class FlyingPigs : GameObject
    {
        public int number;
        public Tile tile;
        public Player player;
        public int playerNumber;
        public int activeSoldiers;
        public int totalSoldiers;

        public FlyingPigs(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber)
        {
            this.tile = Spawntile;
            this.playerNumber = PlayerNumber;
            this.activeSoldiers = ActiveSoldiers;
            this.totalSoldiers = SoldiersNumber;
        }
    }
}
