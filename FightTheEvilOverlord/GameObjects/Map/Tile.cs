using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Tile : GameObject
    {
        public string Type;

        public FlyingPigs pigs;
        public SwordsMen swords;
        public Archer archer;

        public List<Tile> nextTiles = new List<Tile>();
        public List<Village> nextVillages = new List<Village>();

        public bool isActive;

        public int owner = 4;

        public float tileWidth;
        public float tileHeight;

        public Texture2D image;

        CheckButtonPress checkPress;

        public int mapX;
        public int mapY;

        int moveX;

        public Renderer render;
        public Transform transform;
        public Tile(Texture2D image, int x, int y, string Type, int moveX)
        {
            this.moveX = moveX;
            this.mapX = x;
            this.mapY = y;
            this.image = image;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<Renderer>();

            //TODO: replace int 10 with half of screen rest size
            this.transform.Position = new Vector2(x * 1065 * Renderer.scale + moveX, getPosition(x, y) * Renderer.scale);
            this.render.SetImage(image);
            this.render.Start();

            this.Type = Type;

            tileHeight = 1252 * Renderer.scale;
            tileWidth = 1065 * Renderer.scale;

            checkPress = new CheckButtonPress();
            checkPress.SetBounds((int)this.transform.Position.X, (int)this.transform.Position.Y, (int)tileHeight, (int)tileWidth);
        }

        void OnClick(int mouseX, int mouseY)
        {

        }

        public int getPosition(int x, int y)
        {
            if (x % 2 == 0)
            {
                return y * 1252;
            }

            else
            {
                return (y * 1252) + 628;
            }
        }

        public void RemoveTile()
        {
            render.Destroy();
        }
    }
}
