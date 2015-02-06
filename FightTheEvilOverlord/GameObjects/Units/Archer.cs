using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class Archer : GameObject
    {
        public int number;
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

        public Archer(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber, Texture2D image, Player player)
        {
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
            this.transform.Position = new Vector2((tile.transform.Position.X) + ((470 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (tile.transform.Position.Y) + ((550 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
            this.render.SetImage(image);
            this.render.start();
        }

        private void Draw(GameTime gameTime)
        {
            lastState = currentState;
            currentState = Mouse.GetState();

            if (currentState.LeftButton == ButtonState.Pressed && isColliding())
            {
                if (Utility.activePlayerNumber == owner.playerNumber)
                {
                    foreach (var nextTile in tile.nextTiles)
                    {
                        nextTile.render.drawColor = Color.Green;
                    }
                    this.transform.Position = new Vector2(currentState.Position.X - ((image.Width / 2) * UnitRenderer.scale), currentState.Position.Y - (image.Height / 2) * UnitRenderer.scale);
                }
            }
            else if (currentState.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed)
            {
                foreach (var nextTile in tile.nextTiles)
                {
                    nextTile.render.drawColor = Color.White;
                }
                if (isInsideTile(tile))
                {
                    this.transform.Position = new Vector2((tile.transform.Position.X) + ((470 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (tile.transform.Position.Y) + ((550 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                }
                foreach (var nextTile in tile.nextTiles)
                {
                    if (isInsideTile(nextTile))
                    {
                        this.tile = nextTile;
                        this.transform.Position = new Vector2((tile.transform.Position.X) + ((470 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (tile.transform.Position.Y) + ((550 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                    }
                }
            }
        }

        private bool isColliding()
        {
            if (currentState.Position.X >= this.transform.Position.X && currentState.Position.Y >= this.transform.Position.Y)
            {
                if (currentState.Position.X <= this.transform.Position.X + (image.Width * UnitRenderer.scale) && currentState.Position.Y <= this.transform.Position.Y + (image.Height * UnitRenderer.scale))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isInsideTile(Tile tile)
        {
            Vector2 Position = new Vector2(this.transform.Position.X + ((image.Width / 2) * UnitRenderer.scale), this.transform.Position.Y + ((image.Height / 2) * UnitRenderer.scale));
            if (Position.X >= tile.transform.Position.X && 
                Position.X <= tile.transform.Position.X + tile.image.Width && 
                Position.Y >= tile.transform.Position.Y && 
                Position.Y <= tile.transform.Position.Y + tile.image.Height)
            {
                return true;
            }
            return false;
        }
    }
}
