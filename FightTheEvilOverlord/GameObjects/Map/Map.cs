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

        int mapHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (200 * Renderer.scale));
        int mapWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (169 * Renderer.scale));

        public Texture2D texMountain;
        public Texture2D texForrest;
        public Texture2D texPlaines;
        Tile[,] tilesArray;
        public Map(Texture2D texMountain, Texture2D texForrest, Texture2D texPlaines,Texture2D texVillage)
        {
            this.texForrest = texForrest;
            this.texMountain = texMountain;
            this.texPlaines = texPlaines;
            tilesArray = new Tile[mapWidth, mapHeight];
            generateTiles();
        }

        public void generateTiles()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Tile tile = new Tile(getTileTexture(), x, y);
                    this.tilesArray[x, y] = tile;
                    System.Threading.Thread.Sleep(1);
                }
            }
        }

        public Texture2D getTileTexture()
        {
            Random rnd = new Random();
            int i = rnd.Next(0,3);
            if (i == 1)
            {
                return texForrest;
            }
            else if (i == 2)
            {
                return texMountain;
            }
            else
            {
                return texPlaines;
            }
        }
    }
}
