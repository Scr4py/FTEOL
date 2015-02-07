using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class MiniMapTile : GameObject
    {
        Transform transform;

        Tile tile;

        Renderer renderer;

        public MiniMapTile(Tile tile, Texture2D texture)
        {
            this.transform = this.AddComponent<Transform>();
            this.renderer = this.AddComponent<Renderer>();
            this.renderer.SetImage(texture);
            this.tile = tile;
            getPosition();
            getDrawColor();
            renderer.Start();
            
        }

        void getPosition()
        {
            int f = 0;

            if (tile.transform.Position.Y % (int)tile.tileHeight != 0)
            {
                f = 12;
            }
            int x = (int)(tile.transform.Position.X/ tile.tileWidth * 30) + f;
            int y = (int)(tile.transform.Position.Y / tile.tileHeight * 30) - f;
            this.transform.Position = new Vector2(x + 650, y + 10);
        }
        
        void getDrawColor()
        {
            if(tile.owner == 0)
            {
                renderer.drawColor = Color.Green;
            }
            else if(tile.owner == 1)
            {
                renderer.drawColor = Color.Pink;
            }
            else if(tile.owner == 2)
            {
                renderer.drawColor = Color.Blue;
            }
            else if(tile.owner == 3)
            {
                renderer.drawColor = Color.Black;
            }
        }
    }
}
