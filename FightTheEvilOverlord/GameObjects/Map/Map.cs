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
        int mapHeight = 13;
        int mapWidth = 23;

        Tiles[,] tilesArray;
        public Map(int x, int y)
        {
            this.mapHeight = y;
            this.mapWidth = x;
            tilesArray = new Tiles[mapWidth, mapHeight];
        }

        public void generateTiles()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    tilesArray[x, y] = new Tiles();
                    
                    
                       return new Tiles(Tiles.Type.)
                    }
                }
            }
        }
    }
}
