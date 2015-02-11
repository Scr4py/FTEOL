using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class Slider : GameObject
    {
        Texture2D buttonTex;
        public SliderBar SliderBar;
        Transform transform;
        Renderer renderer;

        MouseState currentState;
        MouseState lastState;

        public int ToMoveSoldiers;
        public int MaxToMoveSoldiers;

        public bool Selected;

        public Slider(int maxToMoveSoldiers)
        {
            buttonTex = Utility.CurrentContent.Load<Texture2D>("Slider_Button");
            this.MaxToMoveSoldiers = maxToMoveSoldiers;
            currentState = new MouseState();
            currentState = Mouse.GetState();
            SliderBar = new SliderBar(currentState);
            transform = this.AddComponent<Transform>();
            transform.Position = new Vector2(SliderBar.Transform.Position.X -17, SliderBar.Transform.Position.Y - 5);
            renderer = this.AddComponent<Renderer>();
            renderer.SetImage(buttonTex);
            renderer.Start();
            renderer.SecScale = 0.5f;
            EventManager.OnUpdate += Update;
        }

        void Update(GameTime gameTime)
        {
            moveSliderButton();
            lastState = currentState;
            currentState = Mouse.GetState();
        }

        void moveSliderButton()
        {
            if (currentState.LeftButton == ButtonState.Pressed && Utility.isCollidingWithNoUnit(this.transform, currentState, buttonTex))
            {
                if (currentState.Position.X >= SliderBar.Transform.Position.X + 13 && currentState.Position.X <= SliderBar.Transform.Position.X + (SliderBar.SliderTex.Width * SliderBar.scale) - 12)
                {
                    transform.Position = new Vector2(currentState.Position.X - ((buttonTex.Width / 2) * renderer.SecScale), SliderBar.Transform.Position.Y - 5);
                    ToMoveSoldiers = (int)((MaxToMoveSoldiers / 100) * (transform.Position.X - SliderBar.Transform.Position.X - 12));
                }
            }
            else if (currentState.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed)
            {
                float a = MaxToMoveSoldiers / 100;
                float b = (transform.Position.X - SliderBar.Transform.Position.X + 12);
                ToMoveSoldiers = (int)(a * b);
                Selected = true;
            }
        }

        public void Destroy(Slider slider)
        {
            SliderBar.Destroy();
            EventManager.OnUpdate -= Update;
            transform.Destroy();
            renderer.Destroy();
            slider = null;
        }
    }
}
