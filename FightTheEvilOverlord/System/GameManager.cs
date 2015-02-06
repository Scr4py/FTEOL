﻿using System;
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

        KeyboardState currentState;
        KeyboardState lastState;
        public GameManager(Player pig, Player archer, Player swords, Player overlord, Map map)
        {
            currentState = new KeyboardState();
            this.pig = pig;
            this.archer = archer;
            this.swords = swords;
            this.overlord = overlord;
            this.uM = this.AddComponent<UnitMovement>();
            this.map = map;
            EventManager.OnUpdate += OnUpdate;

            setSoldiersToActive();
        }

        private void OnUpdate(GameTime gameTime)
        {
            lastState = currentState;
            currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.N) && !lastState.IsKeyDown(Keys.N))
            {
                NextPlayer();
            }
        }

        public void NextPlayer()
        {
            if (Utility.activePlayerNumber == 0)
            {
                activeplayer = this.pig;
                Utility.activePlayerNumber++;
                setSoldiersToActive();
            }
            else if (Utility.activePlayerNumber == 1)
            {
                activeplayer = this.swords;
                Utility.activePlayerNumber++;
                setSoldiersToActive();
            }
            else if (Utility.activePlayerNumber == 2)
            {
                activeplayer = this.overlord;
                Utility.activePlayerNumber++;
                setSoldiersToActive();
            }
            else if (Utility.activePlayerNumber == 3)
            {
                activeplayer = this.archer;
                Utility.activePlayerNumber = 0;
                setSoldiersToActive();
            }
        }

        public void setSoldiersToActive()
        {
            foreach (var tile in map.tilesArray)
            {
                if (Utility.activePlayerNumber == 0 && tile.owner == 0 && tile.archer != null)
                {
                    tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                    tile.isActive = true;
                }

                else if (Utility.activePlayerNumber == 1 && tile.owner == 1 && tile.pigs != null)
                {
                    tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                    tile.isActive = true;
                }

                else if (Utility.activePlayerNumber == 2 && tile.owner == 2 && tile.swords != null)
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
