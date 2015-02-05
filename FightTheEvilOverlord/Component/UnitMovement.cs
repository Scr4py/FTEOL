using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class UnitMovement : Component
    {
        Tile tile;
        int movedSoldiers;
        int activeSoldiers;
        string unitType;

        void Start (Tile tile, int movedSoldiers)
        {
            this.tile = tile;
            this.movedSoldiers = movedSoldiers;
        }

        string getUnitType()
        {
            if(tile.archer.activeSoldiers != 0)
            {
                this.activeSoldiers = tile.archer.activeSoldiers;
                return "archer";
            }

            else if (tile.pigs.activeSoldiers != 0)
            {
                this.activeSoldiers = tile.archer.activeSoldiers;
                return "pigs";
            }

            else if (tile.swords.activeSoldiers != 0)
            {
                this.activeSoldiers = tile.swords.activeSoldiers;
                return "swords";
            }
            else
            {
                return null;
            }
        }

        void Move(string unitType)
        {
        }

    }
}
