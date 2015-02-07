using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Village : GameObject
    {
        public Renderer render;
        public Transform transform;
        public int owner = 4;
        public Texture2D image;
        public Village(Texture2D image, int x, int y)
        {
            this.image = image;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<Renderer>();
            //TODO: replace int 10 with half of screen rest size
            this.transform.Position = new Vector2(x * 1065 * Renderer.scale, getPosition(x, y) * Renderer.scale);
            this.render.SetImage(image);
            this.render.start();
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
    }
}
