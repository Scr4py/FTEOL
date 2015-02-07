﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Map : GameObject
    {
        public int mapHeight = (int)((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (1252 * Renderer.scale)) / 2.5) - 1;
        public int mapWidth = (int)((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (1084 * Renderer.scale)) / 2.5) - 1;

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
            getNextTiles();
            getNextVillages();
        }

        public void generateTiles()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Tile tile = new Tile(getTileTexture(), x, y, Type);
                    this.tilesArray[x, y] = tile;
                    System.Threading.Thread.Sleep(2);
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
            RemoveTile(mapWidth / 5, mapHeight / 5);
            villageArray[mapWidth / 5, mapHeight / 5] = new Village(texVillage, mapWidth / 5, mapHeight / 5);

            RemoveTile(mapWidth / 2, mapHeight / 2);
            villageArray[mapWidth / 2, mapHeight / 2] = new Village(texVillage, mapWidth / 2, mapHeight / 2);

            RemoveTile(mapWidth / 3 + 3, mapHeight / 4);
            villageArray[mapWidth / 3 + 3, mapHeight / 4] = new Village(texVillage, mapWidth / 3 + 3, mapHeight / 4);

            RemoveTile(mapWidth - 5, mapHeight - 4);
            villageArray[mapWidth - 5, mapHeight - 4] = new Village(texVillage, mapWidth - 5, mapHeight - 4);

            RemoveTile(mapWidth / 5, mapHeight - 4);
            villageArray[mapWidth / 5, mapHeight - 4] = new Village(texVillage, mapWidth / 5, mapHeight - 4);

            RemoveTile(mapWidth - 6, mapHeight / 2 - 2);
            villageArray[mapWidth - 6, mapHeight / 2 - 2] = new Village(texVillage, mapWidth - 6, mapHeight / 2 - 2);
        }

        void RemoveTile(int tileX,int tileY)
        {
            tilesArray[tileX, tileY].RemoveTile();
            tilesArray[tileX, tileY] = null;
        }

        void getNextTiles()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (tilesArray[x,y] != null)
                    {
                        if (x % 2 == 0)
                        {
                            if (y - 1 >= 0 && y + 1 <= mapHeight - 1 && x - 1 >= 0 && x + 1 <= mapWidth - 1)
                            {
                                if (tilesArray[x - 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y - 1]);
                                }
                                if (tilesArray[x + 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y - 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                            }
                            else if (y == 0 && x != 0 && x < 16)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                            }
                            else if (x == 0 && y != 0 && y < mapHeight - 1)
                            {
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x + 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y - 1]);
                                }
                            }
                            else if (x == 0 && y == 0)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                            }
                            else if (y == mapHeight - 1 && x != 0 && x < 16 )
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y - 1]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y - 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y != 0 && y < 7)
                            {
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x - 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y - 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y == 0)
                            {
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y == mapHeight - 1)
                            {
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x - 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y - 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                            else if (x == 0 && y == mapHeight - 1)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x + 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y - 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                        }
                        else
                        {
                            if (y - 1 >= 0 && y + 1 <= mapHeight - 1 && x - 1 >= 0 && x + 1 <= mapWidth - 1)
                            {
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x + 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y + 1]);
                                }
                                if (tilesArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y + 1]);
                                }
                            }
                            else if (y == 0 && x != 0 && x < mapWidth - 1)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x + 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y + 1]);
                                }
                                if (tilesArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y + 1]);
                                }
                            }
                            else if (y == mapHeight - 1 && x != 0 && x < mapWidth - 1)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y != 0 && y < mapHeight - 1)
                            {
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y + 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y == 0)
                            {
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y + 1]);
                                }
                                if (tilesArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y + 1]);
                                }
                            }
                            else if (x == mapWidth - 1 && y == mapHeight - 1)
                            {
                                if (tilesArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x - 1, y]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                            else if (x == 0 && y == mapHeight - 1)
                            {
                                if (tilesArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y]);
                                }
                                if (tilesArray[x + 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x + 1, y - 1]);
                                }
                                if (tilesArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextTiles.Add(tilesArray[x, y - 1]);
                                }
                            }
                        }
                    }
                }
            }
        }

        void getNextVillages()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (tilesArray[x, y] != null)
                    {
                        if (x % 2 == 0)
                        {
                            if (y - 1 >= 0 && y + 1 <= mapHeight - 1 && x - 1 >= 0 && x + 1 <= mapWidth - 1)
                            {
                                if (villageArray[x - 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y - 1]);
                                }
                                if (villageArray[x + 1, y - 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y - 1]);
                                }
                                if (villageArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x, y - 1]);
                                }
                                if (villageArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                                }
                                if (villageArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                                }
                                if (villageArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y]);
                                }
                            }
                        }

                        else if (y == 0 && x != 0 && x < mapWidth - 1)
                        {
                            if (villageArray[x + 1, y] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                            }
                            if (villageArray[x - 1, y] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y]);
                            }
                            if (villageArray[x, y + 1] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                            }
                        }
                        else if (x == 0 && y != 0 && y < 7)
                        {
                            if (villageArray[x, y + 1] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                            }
                            if (villageArray[x, y - 1] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x, y - 1]);
                            }
                            if (villageArray[x + 1, y] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                            }
                            if (villageArray[x + 1, y - 1] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y - 1]);
                            }
                        }
                        
                        else if (x == 0 && y == 0)
                        {
                            if (villageArray[x + 1, y] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                            }
                            if (villageArray[x, y + 1] != null)
                            {
                                tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                            }
                        }
                        else
                        {
                            if (y - 1 >= 0 && y + 1 <= mapHeight - 1 && x - 1 >= 0 && x + 1 <= mapWidth - 1)
                            {
                                if (villageArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y]);
                                }
                                if (villageArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                                }
                                if (villageArray[x, y - 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x, y - 1]);
                                }
                                if (villageArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                                }
                                if (villageArray[x + 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y + 1]);
                                }
                                if (villageArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y + 1]);
                                }
                            }
                            else if (y == 0 && x != 0 && x < mapWidth - 1)
                            {
                                if (villageArray[x + 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y]);
                                }
                                if (villageArray[x - 1, y] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y]);
                                }
                                if (villageArray[x, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x, y + 1]);
                                }
                                if (villageArray[x + 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x + 1, y + 1]);
                                }
                                if (villageArray[x - 1, y + 1] != null)
                                {
                                    tilesArray[x, y].nextVillages.Add(villageArray[x - 1, y + 1]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
