using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class ParallaxLayer
    {
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }
        public float ScrollSpeed { get; set; }
        public float speed { get; set; }
        public float scale { get; set; }

        public ParallaxLayer(Texture2D image, float scrollSpeed, float scale, float speed, Vector2 position)
        {
            this.Image = image;
            this.ScrollSpeed = scrollSpeed;
            this.scale = scale;
            this.speed = speed;
            this.Position = position;
        }
    }
}