using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class GameManager : GameObject
    {
        Player pig;
        Player archer;
        Player swords;
        Player overlord;
        Player activeplayer;

        Tile firstTile;
        Tile secondTile;

        bool firstIsSet = false;
        bool lastPressed = false;

        public Map map;

        UnitMovement uM;

        public GameManager(Player pig, Player archer, Player swords, Player overlord, Map map)
        {
            this.pig = pig;
            this.archer = archer;
            this.swords = swords;
            this.overlord = overlord;
            this.uM = this.AddComponent<UnitMovement>();
            this.map = map;
            EventManager.OnUpdate += OnUpdate;

        }

        private void OnUpdate(GameTime gameTime)
        {

        }

        public void NextPlayer()
        {
            if (Utility.activePlayerNumber == 0)
            {
                activeplayer = this.archer;
                //setSoldiersToActive();
                Utility.activePlayerNumber++;
            }
            else if (Utility.activePlayerNumber == 1)
            {
                activeplayer = this.pig;
                //setSoldiersToActive();
                Utility.activePlayerNumber++;
            }
            else if (Utility.activePlayerNumber == 2)
            {
                activeplayer = this.swords;
                //setSoldiersToActive();
                Utility.activePlayerNumber++;
            }
            else if (Utility.activePlayerNumber == 3)
            {
                activeplayer = this.overlord;
                //setSoldiersToActive();
                Utility.activePlayerNumber = 0;
            }
        }

        public void setSoldiersToActive()
        {
            foreach (var tile in map.tilesArray)
            {
                if (Utility.activePlayerNumber == 0 && tile.owner == 0)
                {
                    tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                    tile.isActive = true;
                }

                else if (Utility.activePlayerNumber == 1 && tile.owner == 1)
                {
                    tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                    tile.isActive = true;
                }

                else if (Utility.activePlayerNumber == 2 && tile.owner == 2)
                {
                    tile.swords.activeSoldiers = tile.swords.totalSoldiers;
                    tile.isActive = true;
                }

                else if (Utility.activePlayerNumber == 3 && tile.owner == 3)
                {
                    tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                    tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                    tile.swords.activeSoldiers = tile.swords.totalSoldiers;
                    tile.isActive = true;
                }
            }
        }
    }
}
