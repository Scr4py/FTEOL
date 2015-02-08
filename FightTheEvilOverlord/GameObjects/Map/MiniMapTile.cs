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

            int x = (int)(tile.transform.Position.X/ tile.tileWidth * 20);
            int y = (int)(tile.transform.Position.Y / tile.tileHeight * 20);
            this.transform.Position = new Vector2(x + 850, y + 50);
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
