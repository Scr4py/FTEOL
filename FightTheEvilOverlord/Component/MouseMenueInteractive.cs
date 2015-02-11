using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace FightTheEvilOverlord
{
    class MouseMenueInteractive : Component
    {
        public delegate void MouseEventHandler();
        public event MouseEventHandler OnClick = delegate{ };
        Rectangle mouseRectangle;
        MouseState prevMouseState;
        MouseState MouseState;
        

        public void start()
        {
            EventManager.OnUpdate += Update;
        }

        private void Update(GameTime gameTime)
        {
            ButtonClick();
        }
        public void ButtonClick()
        {
            MouseState = Mouse.GetState();
            if (MouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                Point mousePos = MouseState.Position;
                
                if (this.mouseRectangle.Contains(mousePos))
                {
                    OnClick();
                }
            }
            prevMouseState = MouseState;
        }

        public override void Destroy()
        {
            EventManager.OnUpdate -= Update;
            base.Destroy();
        }

        public void SetRectangle(int width, int height)
        {
            mouseRectangle.Width = width;
            mouseRectangle.Height = height;
        }
    }
}
