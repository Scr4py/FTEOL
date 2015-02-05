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
        public int mapHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (1252 * Renderer.scale));
        public int mapWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (1065 * Renderer.scale));

        string Type;

        public Texture2D texMountain;
        public Texture2D texForrest;
        public Texture2D texPlaines;
        public Texture2D texVillage;
        public Texture2D texField;

        public Tile[,] tilesArray;
        public Village[,] villageArray;
        public Map(Texture2D texMountain, Texture2D texForrest, Texture2D texPlaines, Texture2D texVillage, Texture2D texField)
        {
            this.texForrest = texForrest;
            this.texMountain = texMountain;
            this.texPlaines = texPlaines;
            this.texVillage = texVillage;
            this.texField = texField;
            tilesArray = new Tile[mapWidth, mapHeight];
            villageArray = new Village[mapWidth, mapHeight];
            generateTiles();
            generateVillages();
        }

        public void generateTiles()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Tile tile = new Tile(getTileTexture(), x, y, Type);
                    this.tilesArray[x, y] = tile;
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        public Texture2D getTileTexture()
        {
            Random rnd = new Random();
            int i = rnd.Next(0,4);
            if (i == 1)
            {
                this.Type = "wald";
                return texForrest;
            }
            else if (i == 2)
            {
                this.Type = "berg";
                return texMountain;
            }
            else if (i == 3)
            {
                this.Type = "feld";
                return texField;
            }
            else
            {
                this.Type = "wiese";
                return texPlaines;
            }
        }

        public void generateVillages()
        {
            tilesArray[mapWidth / 5, mapHeight / 5] = null;
            villageArray[mapWidth / 5, mapHeight / 5] = new Village(texVillage, mapWidth / 5, mapHeight / 5);

            tilesArray[mapWidth / 2, mapHeight / 2] = null;
            villageArray[mapWidth / 2, mapHeight / 2] = new Village(texVillage, mapWidth / 2, mapHeight / 2);

            tilesArray[mapWidth / 3 + 3, mapHeight / 4] = null;
            villageArray[mapWidth / 3 + 3, mapHeight / 4] = new Village(texVillage, mapWidth / 3 + 3, mapHeight / 4);

            tilesArray[mapWidth - 5, mapHeight - 4] = null;
            villageArray[mapWidth - 5, mapHeight - 4] = new Village(texVillage, mapWidth - 5, mapHeight - 4);

            tilesArray[mapWidth / 5, mapHeight - 4] = null;
            villageArray[mapWidth / 5, mapHeight - 4] = new Village(texVillage, mapWidth / 5, mapHeight - 4);

            tilesArray[mapWidth - 6, mapHeight / 2 - 2] = null;
            villageArray[mapWidth - 6, mapHeight / 2 - 2] = new Village(texVillage, mapWidth - 6, mapHeight / 2 - 2);
        }
    }
}
