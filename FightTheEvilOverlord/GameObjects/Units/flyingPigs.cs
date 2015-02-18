using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class FlyingPigs : GameObject
    {
        public int number;
        public Tile tile;
        Tile lastTile;
        Tile nextTile;
        public Player owner;
        public int playerNumber;
        public int activeSoldiers;
        public int totalSoldiers;

        bool moveToEmptyTile;
        bool moveToOwnedTile;
        bool moveToEnemyTile;

        MouseState currentState;
        MouseState lastState;

        Texture2D image;

        Transform transform;
        public UnitRenderer render;
        FightManager fightManager;
        Slider slider;

        public FlyingPigs(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber, Texture2D image, Player player)
        {
            this.owner = player;
            this.image = image;
            currentState = new MouseState();
            this.tile = Spawntile;
            this.tile.owner = PlayerNumber;
            this.playerNumber = PlayerNumber;
            this.activeSoldiers = ActiveSoldiers;
            this.totalSoldiers = SoldiersNumber;
            EventManager.OnUpdate += Draw;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<UnitRenderer>();
            this.transform.Position = this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
            this.render.SetImage(image);
            this.render.start();
            this.fightManager = this.AddComponent<FightManager>();
        }

        private void Draw(GameTime gameTime)
        {
            if (Utility.ActivePlayerNumber == 1 && Utility.ActivePlayerNumber == this.tile.owner)
            {
                render.PicColor = Color.DarkOrange;
                render.SetInteger(totalSoldiers);
                render.SetSecInteger(activeSoldiers);
            }
            else if (Utility.ActivePlayerNumber == 3 && Utility.ActivePlayerNumber == this.tile.owner)
            {
                render.PicColor = Color.Red;
                render.SetInteger(totalSoldiers);
                render.SetSecInteger(activeSoldiers);
            }
            else
            {
                render.PicColor = Color.LightPink;
                render.SetSecInteger(0);
            }

            lastState = currentState;
            currentState = Mouse.GetState();

            checkIfToMoveOnTile();
            moveSoldiers();
        }

        private void checkIfToMoveOnTile()
        {
            if (Utility.movementEngaged == false)
            {
                if (currentState.LeftButton == ButtonState.Pressed &&
                    Utility.isColliding(this.transform, currentState, image) &&
                    Utility.ActivePlayerNumber == owner.playerNumber &&
                    activeSoldiers != 0)
                {
                    if (Utility.ActivePlayerNumber == owner.playerNumber)
                    {
                        foreach (var nextTile in tile.nextTiles)
                        {
                            if (nextTile.owner == 4 || nextTile.owner == playerNumber)
                            {
                                nextTile.render.drawColor = Color.DodgerBlue;
                            }
                            if (Utility.isColliding(nextTile, currentState))
                            {
                                if (nextTile.owner == 4 || nextTile.owner == playerNumber)
                                {
                                    nextTile.render.drawColor = Color.Green;
                                }
                            }
                            if ((nextTile.owner == 3 && (Utility.ActivePlayerNumber == 0 || Utility.ActivePlayerNumber == 1 || Utility.ActivePlayerNumber == 2)) || ((nextTile.owner == 0 || nextTile.owner == 1 || nextTile.owner == 2) && Utility.ActivePlayerNumber == 3))
                            {
                                nextTile.render.drawColor = Color.OrangeRed;
                            }
                        }
                        foreach (var nextVillage in tile.nextVillages)
                        {
                            if (nextVillage.owner == 4 || nextVillage.owner == playerNumber)
                            {
                                nextVillage.render.drawColor = Color.OrangeRed;
                            }
                            if (Utility.isColliding(nextVillage, currentState))
                            {
                                if (nextVillage.owner == 4 || nextVillage.owner == playerNumber)
                                {
                                    nextVillage.render.drawColor = Color.OrangeRed;
                                }
                            }
                        }
                        this.transform.Position = new Vector2(currentState.Position.X - ((image.Width / 2) * UnitRenderer.scale), currentState.Position.Y - (image.Height / 2) * UnitRenderer.scale);
                    }
                }
                else if (currentState.LeftButton == ButtonState.Released &&
                    lastState.LeftButton == ButtonState.Pressed &&
                    Utility.ActivePlayerNumber == owner.playerNumber &&
                    Utility.isColliding(this.transform, currentState, image))
                {
                    if (!checkIfToMoveOnVillage())
                    {
                        foreach (var nextTile in tile.nextTiles)
                        {
                            nextTile.render.drawColor = Color.White;

                            if (Utility.isColliding(nextTile, currentState) &&
                                activeSoldiers != 0 && nextTile.owner == 4)
                            {
                                this.nextTile = nextTile;
                                slider = new Slider(activeSoldiers);
                                Utility.movementEngaged = true;
                                moveToEmptyTile = true;

                            }
                            else if (Utility.isColliding(nextTile, currentState) &&
                                activeSoldiers != 0 && nextTile.owner == this.playerNumber &&
                                nextTile.archer == null && nextTile.swords == null)
                            {
                                this.nextTile = nextTile;
                                slider = new Slider(activeSoldiers);
                                Utility.movementEngaged = true;
                                moveToOwnedTile = true;
                            }

                            else if (Utility.isColliding(nextTile, currentState) &&
                                activeSoldiers != 0 &&
                                (((tile.owner == 0 || tile.owner == 1 || tile.owner == 2) && nextTile.owner == 3) ||
                                (nextTile.owner == 0 || nextTile.owner == 1 || nextTile.owner == 2) && tile.owner == 3))
                            {
                                this.nextTile = nextTile;
                                slider = new Slider(activeSoldiers);
                                Utility.movementEngaged = true;
                                moveToEnemyTile = true;
                            }

                            else
                            {
                                this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                            }
                        }
                    }
                }
            }
        }

        void moveSoldiers()
        {
            if (Utility.movementEngaged == true)
            {
                if (moveToEmptyTile == true)
                {
                    if (slider.Selected == true)
                    {
                        totalSoldiers = activeSoldiers - slider.ToMoveSoldiers;
                        activeSoldiers = activeSoldiers - slider.ToMoveSoldiers;
                        if (totalSoldiers == 0)
                        {
                            this.tile.owner = 4;
                            this.tile.pigs.Destroy();
                            this.tile.pigs = null;
                        }

                        if (slider.ToMoveSoldiers > 0)
                        {
                            nextTile.pigs = new FlyingPigs(nextTile, playerNumber, 0, slider.ToMoveSoldiers, image, owner);
                        }
                        slider.SliderBar.Destroy();
                        slider.Destroy();
                        moveToEmptyTile = false;
                        Utility.movementEngaged = false;
                    }
                }

                else if (moveToOwnedTile == true)
                {
                    if (slider.Selected == true)
                    {
                        totalSoldiers = totalSoldiers - slider.ToMoveSoldiers;
                        activeSoldiers = activeSoldiers - slider.ToMoveSoldiers;
                        if (totalSoldiers == 0)
                        {
                            this.tile.owner = 4;
                            this.tile.pigs.Destroy();
                            this.tile.pigs = null;
                        }
                        nextTile.pigs.totalSoldiers += slider.ToMoveSoldiers;
                        slider.SliderBar.Destroy();
                        slider.Destroy();
                        moveToOwnedTile = false;
                        Utility.movementEngaged = false;
                    }
                }
                else if (moveToEnemyTile == true)
                {
                    if (slider.Selected == true)
                    {
                        fightManager.Attack(this.tile, nextTile);
                        slider.SliderBar.Destroy();
                        slider.Destroy();
                        moveToEnemyTile = false;
                        Utility.movementEngaged = false;
                    }
                }
            }
        }

        private bool checkIfToMoveOnVillage()
        {
            foreach (var nextTile in tile.nextTiles)
            {
                nextTile.render.drawColor = Color.White;
            }
            foreach (var nextVillage in tile.nextVillages)
            {
                if (Utility.isColliding(nextVillage, currentState))
                {
                    nextVillage.owner = playerNumber;
                    this.activeSoldiers = 0;
                    nextVillage.render.drawColor = Color.White;
                    if (playerNumber == 3)
                    {
                        if (this.tile.archer != null)
                        {
                            nextVillage.conquerUnit = 0;
                        }
                        else if (this.tile.pigs != null)
                        {
                            nextVillage.conquerUnit = 1;
                        }
                        else if (this.tile.swords != null)
                        {
                            nextVillage.conquerUnit = 2;
                        }
                    }
                    this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                    return true;
                }
            }
            return false;
        }

        public void removeLastPig(FlyingPigs pig)
        {
            if (pig != null)
            {
                pig.transform.Destroy();
                pig.fightManager.Destroy();
                pig.render.Destroy();
                //pig.tile.owner = 4;
                //pig.tile.pigs = null;
                pig = null;
            }
        }
    }
}
