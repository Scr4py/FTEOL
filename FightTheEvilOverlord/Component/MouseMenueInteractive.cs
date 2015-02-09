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
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                Point mousePos = mouseState.Position;
                
                if (this.mouseRectangle.Contains(mousePos))
                {
                    OnClick();
                }
            }
            prevMouseState = mouseState;
        }
    }
}
