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
        MouseState prevMouseState;
        MouseState mouseState = new MouseState();

        public void ButtonClick(Rectangle source)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                Point mousePos = new Point(mouseState.X, mouseState.Y);
                if (source.Contains(mousePos))
                {
                    OnClick();
                }
            }
            prevMouseState = mouseState;
        }
    }
}
