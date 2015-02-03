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
        Renderer render;
        Transform transform;
        public enum Types { plaines, mountain, forest, village };
        public Types Type { get; private set; }
        public Tile(Texture2D image, int x, int y)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<Renderer>();
            this.transform.Position = new Vector2(x * 169 * Renderer.scale, getPosition(x, y) * Renderer.scale);
            this.render.Render(image);
            this.render.start();
        }
        public Tile(String village)
        {

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
