using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class UnitMovement : Component
    {

        public void initilateMovement (Tile beginningTile, Tile destinationTile, int toMoveSoldiers, Player player)
        {
            if (beginningTile.isActive)
            {
                Console.WriteLine("dritter");
                if (beginningTile.archer != null)
                {
                    beginningTile.archer.activeSoldiers -= toMoveSoldiers;
                    beginningTile.archer.totalSoldiers -= toMoveSoldiers;

                    if (destinationTile.archer != null)
                    {
                        destinationTile.archer.totalSoldiers += toMoveSoldiers;
                    }
                    else
                    {
                        //destinationTile.archer = new Archer(destinationTile, player.playerNumber, 0, toMoveSoldiers, );
                    }
                }
            }
        }


        void Move(string unitType)
        {
        }

    }
}
