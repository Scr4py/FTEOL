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
        Archer[] archerArray;
        flyingPigs[] pigArray;
        swordsMen[] swordArray;
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
            this.render = this.AddComponent<Renderer>();
            //TODO: replace int 10 with half of screen rest size
            this.transform.Position = new Vector2(tile.transform.Position.X, tile.transform.Position.Y);
            this
            this.render.start();
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
