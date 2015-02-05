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

        public Player(int playerNumber, int unitNumber, UnitSpawner unitSpawn, Tile tile, Texture2D image)
        {
            this.playerNumber = playerNumber;
            this.unitNumber = unitNumber;
            this.startTile = tile;

            getStartSoldier();

            this.transform = this.AddComponent<Transform>();
            this.unitRender = this.AddComponent<UnitRenderer>();
            //TODO: replace int 10 with half of screen rest size
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
                    UnitSpawner.addArcher(startTile, this, unitNumber);
                }
            }
            else if (playerNumber == 1)
            {
                for (int i = 0; i < unitNumber; i++)
                {
                    UnitSpawner.addPigToTile(startTile, this, unitNumber);
                }
            }
            else if (playerNumber == 2)
            {
                for (int i = 0; i < unitNumber; i++)
                {
                    UnitSpawner.addSowrdsMen(startTile, this, unitNumber);
                }
            }
        }

    }
}
