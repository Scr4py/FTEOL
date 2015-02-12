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
        IntRenderer intRenderer;

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
            this.intRenderer = new IntRenderer();
            this.intRenderer.Update(new Vector2(this.transform.Position.X + 15, this.transform.Position.Y + 15), ToMoveSoldiers);
            this.intRenderer.Start();
            EventManager.OnUpdate += Update;
        }

        void Update(GameTime gameTime)
        {
            this.intRenderer.Update(new Vector2(this.transform.Position.X + 15, this.transform.Position.Y + 15), ToMoveSoldiers);
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
                float g = MaxToMoveSoldiers;
                float a = (g / 100);
                float b = (transform.Position.X - SliderBar.Transform.Position.X + 12);
                if (b > 85)
                {
                    b = 100;
                }
                float c = a * b;
                ToMoveSoldiers = (int)c;
                //ToMoveSoldiers = (int)(a * b);
                Selected = true;
            }
        }

        public void Destroy(Slider slider)
        {
            SliderBar.Destroy();
            EventManager.OnUpdate -= Update;
            intRenderer.Destroy();
            transform.Destroy();
            renderer.Destroy();
            slider = null;
        }
    }
}
