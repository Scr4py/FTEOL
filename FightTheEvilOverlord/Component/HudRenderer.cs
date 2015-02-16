using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FightTheEvilOverlord
{
    class HudRenderer : Component
    {
        Transform transform;
        Texture2D image;

        public float Scale = 0.85f;
        List<Texture2D> distanceImageList = new List<Texture2D>();
        List<Vector2> distanceVectorList = new List<Vector2>();

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += HudRender;
            EventManager.OnRender += DistanceRender;
        }

        private void DistanceRender(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < distanceImageList.Count; i++)
            {
              spriteBatch.Draw(distanceImageList[i], distanceVectorList[i], Color.White);
            }
            
        }

        private void HudRender(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, Color.White);
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }

        public void SetDisctanceImage(Texture2D distanceImage, Vector2 position)
        {
            distanceImageList.Add(distanceImage);
            distanceVectorList.Add(position);
        }

        public void SetPosition(Vector2 position)
        {
            this.transform.Position = position;
        }
    }
}
