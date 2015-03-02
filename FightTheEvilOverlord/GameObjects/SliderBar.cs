using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class SliderBar : GameObject
    {
        public Texture2D SliderTex;
        public Transform Transform;
        public float scale = 1;
        Renderer renderer;

        public SliderBar(MouseState currentState)
        {
            SliderTex = Utility.CurrentContent.Load<Texture2D>("Slider");
            Transform = this.AddComponent<Transform>();
            Transform.Position = new Vector2(currentState.Position.X + 50, currentState.Position.Y + 50);
            renderer = this.AddComponent<Renderer>();
            renderer.SetImage(SliderTex);
            renderer.Start();
            renderer.SecScale = scale;


        }

        public void Destroy(SliderBar sliderBar)
        {
            renderer.Destroy();
            Transform.Destroy();
            sliderBar = null;
        }


    }
}
