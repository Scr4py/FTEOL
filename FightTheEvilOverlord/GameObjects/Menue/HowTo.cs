using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class HowTo :  GameObject
    {
        Transform transform;
        BackgroundRender background;
        Texture2D image;
        SpriteFont font;

        public HowTo(Texture2D background)
        {
            this.transform = this.AddComponent<Transform>();
            this.background = this.AddComponent<BackgroundRender>();
            this.background.SetImage(background);
        }
    }
}
