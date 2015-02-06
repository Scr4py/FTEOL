using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class SwordsMen : GameObject
    {
        public int number;
        Tile lastTile;
        public Tile tile;
        public Player owner;
        public int playerNumber;
        public int activeSoldiers;
        public int totalSoldiers;

        MouseState currentState;
        MouseState lastState;

        Texture2D image;

        Transform transform;
        UnitRenderer render;

        public SwordsMen(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber, Texture2D image, Player player, SwordsMen lastSwordsMen)
        {
            removeLastSwordsMen(lastSwordsMen);
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
            lastState = currentState;
            currentState = Mouse.GetState();

            if (currentState.LeftButton == ButtonState.Pressed && isColliding(this.transform) && Utility.activePlayerNumber == owner.playerNumber && activeSoldiers != 0)
            {
                if (Utility.activePlayerNumber == owner.playerNumber)
                {
                    foreach (var nextTile in tile.nextTiles)
                    {
                        if (nextTile.owner == 4 || nextTile.owner == 2)
                        {
                            nextTile.render.drawColor = Color.DodgerBlue;
                        }
                        if (isColliding(nextTile))
                        {
                            if (nextTile.owner == 4 || nextTile.owner == 2)
                            {
                                nextTile.render.drawColor = Color.Green;
                            }
                        }
                    }
                    this.transform.Position = new Vector2(currentState.Position.X - ((image.Width / 2) * UnitRenderer.scale), currentState.Position.Y - (image.Height / 2) * UnitRenderer.scale);
                }
            }
            else if (currentState.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed && Utility.activePlayerNumber == owner.playerNumber && isColliding(this.transform))
            {
                foreach (var nextTile in tile.nextTiles)
                {
                    nextTile.render.drawColor = Color.White;

                    if (isColliding(nextTile) && activeSoldiers != 0 && nextTile.owner == 4)
                    {
                        activeSoldiers = 0;
                        this.lastTile = tile;
                        this.tile.owner = 4;
                        this.tile = nextTile;
                        this.tile.owner = 2;
                        nextTile.swords = new SwordsMen(nextTile, 0, 0, totalSoldiers, image, owner, this);
                    }
                    else
                    {
                        this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                    }
                }
            }
        }

        private bool isColliding(Tile toCheckTile)
        {
            if (currentState.Position.X >= toCheckTile.transform.Position.X + ((toCheckTile.image.Width * Renderer.scale) * 0.25) &&
                currentState.Position.Y >= toCheckTile.transform.Position.Y)
            {
                if (currentState.Position.X <= toCheckTile.transform.Position.X + ((toCheckTile.image.Width * Renderer.scale) * 0.75) &&
                    currentState.Position.Y <= toCheckTile.transform.Position.Y + (toCheckTile.image.Height * Renderer.scale))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isColliding(Transform toCheckTransform)
        {
            if (currentState.Position.X >= toCheckTransform.Position.X &&
                currentState.Position.Y >= toCheckTransform.Position.Y)
            {
                if (currentState.Position.X <= toCheckTransform.Position.X + (image.Width * UnitRenderer.scale) &&
                    currentState.Position.Y <= toCheckTransform.Position.Y + (image.Height * UnitRenderer.scale))
                {
                    return true;
                }
            }
            return false;
        }

        public void removeLastSwordsMen(SwordsMen swordsMen)
        {
            if (swordsMen != null)
            {
                swordsMen.render.Destroy();
                swordsMen = null;
            }
        }
    }
}
