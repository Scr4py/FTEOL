using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Map : GameObject
    {
        public const int TileWidth = 32;
        public const int TileHeight = 32;

        int mapHeight = 13;
        int mapWidth = 23;

        public Texture2D Tiles;

        Tile[,] tilesArray;
        public Map(Texture2D tex)
        {
            //this.mapHeight = y;
            //this.mapWidth = x;
            this.Tiles = tex;

            tilesArray = new Tile[mapWidth, mapHeight];
        }

        public void generateAndDrawTiles(SpriteBatch spritebatch)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Tile tile = new Tile();
                    this.tilesArray[x, y] = tile;
                    Vector2 position = new Vector2(x * TileWidth, y * TileHeight);
                    Rectangle sourceRect = new Rectangle((int)tile.Type * TileWidth, 0, TileWidth, TileHeight);
                    spritebatch.Draw(this.Tiles, position, sourceRect, Color.White);
                }
            }
        }
    }
}
