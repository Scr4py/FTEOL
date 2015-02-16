using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace FightTheEvilOverlord
{
    class Background : GameObject
    {
        Transform transform;
        ButtonRender render;

        public Background(Texture2D image, Rectangle source)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<ButtonRender>();
            this.render.AddInLists(image, source);
            this.render.start();
        }
    }
}
