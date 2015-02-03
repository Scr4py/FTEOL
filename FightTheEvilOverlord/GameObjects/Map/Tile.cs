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
        string Type;

        Renderer render;
        Transform transform;
        public Tile(Texture2D image, int x, int y, string Type)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<Renderer>();
            //TODO: replace int 10 with half of screen rest size
            this.transform.Position = new Vector2(x * 169 * Renderer.scale + 10, getPosition(x, y) * Renderer.scale + 10);
            this.render.Render(image);
            this.render.start();

            this.Type = Type;
        }

        public int getPosition(int x, int y)
        {
            if (x % 2 == 0)
            {
                return y * 200;
            }

            else
            {
                return (y * 200) + 100;
            }
        }
    }
}
