using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class SetToMoveUnits : Component
    {
        Renderer render;
        Transform transform;

        Texture2D slider;
        Texture2D sliderButton;

        public void Start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            this.render = GameObject.GetComponent<Renderer>();

        }

        void getSlider()
        {
        }

        void drawSlider()
        {

        }



    }
}
