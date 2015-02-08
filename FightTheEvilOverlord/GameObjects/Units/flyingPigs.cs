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
        public Player owner;
        public int playerNumber;
        public int activeSoldiers;
        public int totalSoldiers;

        MouseState currentState;
        MouseState lastState;

        Texture2D image;

        Transform transform;
        public UnitRenderer render;

        public FlyingPigs(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber, Texture2D image, Player player, FlyingPigs lastPig)
        {
            removeLastPig(lastPig);
            this.owner = player;
            this.image = image;
            currentState = new MouseState();
            this.tile = Spawntile;
            this.playerNumber = PlayerNumber;
            this.activeSoldiers = ActiveSoldiers;
            this.totalSoldiers = SoldiersNumber;
            EventManager.OnUpdate += Draw;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<UnitRenderer>();
            this.transform.Position = this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
            this.render.SetImage(image);
            this.render.start();
        }

        private void Draw(GameTime gameTime)
        {
            render.SetInteger(totalSoldiers);
            render.SetSecInteger(activeSoldiers);

            lastState = currentState;
            currentState = Mouse.GetState();

            checkInput();
        }

        private void checkInput()
        {
            // if mouse is on a unit the player owns and is pressed
            if (currentState.LeftButton == ButtonState.Pressed &&
                Utility.isColliding(this.transform, currentState, image) &&
                Utility.activePlayerNumber == owner.playerNumber &&
                activeSoldiers != 0)
            {
                foreach (var nextTile in tile.nextTiles)
                {
                    if (nextTile.owner == 4 || nextTile.owner == 1)
                    {
                        nextTile.render.drawColor = Color.DodgerBlue;
                    }
                    if (Utility.isColliding(nextTile, currentState))
                    {
                        if (nextTile.owner == 4 || nextTile.owner == 1)
                        {
                            nextTile.render.drawColor = Color.Green;
                        }
                    }
                }
                foreach (var nextVillage in tile.nextVillages)
                {
                    if (nextVillage.owner == 4 || nextVillage.owner == 1)
                    {
                        nextVillage.render.drawColor = Color.DodgerBlue;
                    }
                    if (Utility.isColliding(nextVillage, currentState))
                    {
                        if (nextVillage.owner == 4 || nextVillage.owner == 1)
                        {
                            nextVillage.render.drawColor = Color.OrangeRed;
                        }
                    }
                }
                this.transform.Position = new Vector2(currentState.Position.X - ((image.Width / 2) * UnitRenderer.scale), currentState.Position.Y - (image.Height / 2) * UnitRenderer.scale);
                
            }

            //Player released leftMouse button
            else if (currentState.LeftButton == ButtonState.Released &&
                lastState.LeftButton == ButtonState.Pressed &&
                Utility.activePlayerNumber == owner.playerNumber &&
                Utility.isColliding(this.transform, currentState, image))
            {
                foreach (var nextVillage in tile.nextVillages)
                {
                    nextVillage.render.drawColor = Color.White;
                }
                foreach (var nextTile in tile.nextTiles)
                {
                    nextTile.render.drawColor = Color.White;

                    if (Utility.isColliding(nextTile, currentState) &&
                        activeSoldiers != 0 && nextTile.owner == 4)
                    {
                        activeSoldiers = 0;
                        this.lastTile = tile;
                        this.tile.owner = 4;
                        this.tile = nextTile;
                        this.tile.owner = 1;
                        nextTile.pigs = new FlyingPigs(nextTile, 0, 0, totalSoldiers, image, owner, this);
                    }
                    else if (Utility.isColliding(nextTile, currentState) &&
                        activeSoldiers != 0 && nextTile.owner == 1)
                    {
                        activeSoldiers = 0;
                        this.tile.owner = 4;
                        nextTile.pigs.totalSoldiers += totalSoldiers;
                        nextTile.pigs.removeLastPig(this);
                    }
                    else
                    {
                        this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                    }
                }
            }
        }

        public void removeLastPig(FlyingPigs pig)
        {
            if (pig != null)
            {
                pig.render.Destroy();
                pig = null;
            }
        }
    }
}
