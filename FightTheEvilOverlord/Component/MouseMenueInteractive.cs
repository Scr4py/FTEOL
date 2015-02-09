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
            MouseState = new MouseState();
        }

        private void Update(GameTime gameTime)
        {
            ButtonClick();
        }
        public void ButtonClick()
        {
            prevMouseState = MouseState;
            MouseState = Mouse.GetState();
            if (MouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                Point mousePos = MouseState.Position;
                
                if (this.mouseRectangle.Contains(mousePos))
                {
                    OnClick();
                }
            }
        }
    }
}
