using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class ButtonRender : Component
    {
        private List<Texture2D> textureList = new List<Texture2D>();
        private List<Rectangle> rectangleList = new List<Rectangle>();

        Transform transform;

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < textureList.Count ; i++)
            {
                spriteBatch.Draw(textureList[i],this.transform.Position,rectangleList[i],Color.White);
            }
        }

        public void AddInLists(Texture2D image, Rectangle source)
        {
            textureList.Add(image);
            rectangleList.Add(source);
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
            base.Destroy();
        }
        
    }
}
