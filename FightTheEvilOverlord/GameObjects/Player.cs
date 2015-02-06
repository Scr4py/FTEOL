using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Player : GameObject
    {
        public int playerNumber;
        int unitNumber;
        //Archer[] archerArray;
        //FlyingPigs[] pigArray;
        //SwordsMen[] swordArray;
        Tile startTile;
        Transform transform;
        UnitRenderer unitRender;
        UnitSpawner unitSpawn;

        Map map;
        public Player(int playerNumber, int unitNumber, UnitSpawner unitSpawn, Tile tile, Texture2D image, Map map)
        {
            this.map = map;

            this.playerNumber = playerNumber;
            this.unitNumber = unitNumber;
            this.startTile = tile;
            this.unitSpawn = unitSpawn;
            
            getStartSoldier();

            this.transform = this.AddComponent<Transform>();
            this.unitRender = this.AddComponent<UnitRenderer>();
            this.transform.Position = new Vector2((tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
            this.unitRender.SetImage(image);
            this.unitRender.start();
        }

        void getStartSoldier()
        {
            if (playerNumber == 0)
            {
                for (int i = 0; i < unitNumber; i++)
                {
                    unitSpawn.addArcher(map.tilesArray[7,7], this, unitNumber);
                }
            }
            else if (playerNumber == 1)
            {
                for (int i = 0; i < unitNumber; i++)
                {
                    unitSpawn.addPigToTile(startTile, this, unitNumber);
                }
            }
            else if (playerNumber == 2)
            {
                for (int i = 0; i < unitNumber; i++)
                {
                    unitSpawn.addSowrdsMen(startTile, this, unitNumber);
                }
            }
        }

    }
}
