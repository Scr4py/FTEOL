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

        Map map;

        int playerNumber;

        UnitMovement uM;

        MouseState currentState;
        MouseState lastState;

        public GameManager(Player pig, Player archer, Player swords, Player overlord, Map map)
        {
            this.pig = pig;
            this.archer = archer;
            this.swords = swords;
            this.overlord = overlord;
            this.uM = this.AddComponent<UnitMovement>();
            this.map = map;
            EventManager.OnUpdate += OnUpdate;

            currentState = new MouseState();
        }

        private void OnUpdate(GameTime gameTime)
        {
            input();
        }

        public void NextPlayer()
        {
            if (playerNumber == 0)
            {
                activeplayer = this.archer;
                setSoldiersToActive();
                playerNumber++;
            }
            else if (playerNumber == 1)
            {
                activeplayer = this.pig;
                setSoldiersToActive();
                playerNumber++;
            }
            else if (playerNumber == 2)
            {
                activeplayer = this.swords;
                setSoldiersToActive();
                playerNumber++;
            }
            else if (playerNumber == 3)
            {
                activeplayer = this.overlord;
                setSoldiersToActive();
                playerNumber = 0;
            }
        }



        void input()
        {
            if (currentState.LeftButton == ButtonState.Pressed)
            {
                lastPressed = true;
            }
            else
            {
                lastPressed = false;
            }
            currentState = new MouseState();

            if (!lastPressed && currentState.LeftButton == ButtonState.Pressed)
            {
                foreach (var tile in map.tilesArray)
                {
                    if (tile.transform.Position.X <= currentState.Position.X && tile.transform.Position.X + tile.tileWidth >= currentState.Position.X)
                    {
                        if (tile.transform.Position.Y <= currentState.Position.Y && tile.transform.Position.Y + tile.tileHeight >= currentState.Position.Y)
                        {
                            if (!firstIsSet)
                            {
                                firstTile = tile;
                                firstIsSet = true;
                                Console.WriteLine("erster");
                            }
                            else
                            {
                                secondTile = tile;
                                uM.initilateMovement(firstTile, secondTile, 1, activeplayer);
                                Console.WriteLine("zweiter");
                            }
                        }
                    }
                }
            }
        }

        public void setSoldiersToActive()
        {
            foreach (var tile in map.tilesArray)
            {
                if (playerNumber == 0 && tile.owner == 0)
                {
                    tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                    tile.isActive = true;
                }

                else if (playerNumber == 1 && tile.owner == 1)
                {
                    tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                    tile.isActive = true;
                }

                else if (playerNumber == 2 && tile.owner == 2)
                {
                    tile.swords.activeSoldiers = tile.swords.totalSoldiers;
                    tile.isActive = true;
                }

                else if (playerNumber == 3 && tile.owner == 3)
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
