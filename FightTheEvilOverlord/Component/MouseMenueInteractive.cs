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
        public delegate void MouseEventHandler(int x, int y);
        public event MouseEventHandler OnClick = delegate{ };
        Transform transform;
        Rectangle mouseRectangle;
        MouseState prevMouseState;
        MouseState mouseState;
        

        public void start()
        {
            this.transform = this.GameObject.GetComponent<Transform>();
            EventManager.OnUpdate += Update;
        }

        private void Update(GameTime gameTime)
        {
            UpdatePosition();
            ButtonClick();
        }
        
        public void ButtonClick()
        {
            mouseState = Mouse.GetState();
            Point point = mouseState.Position;
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (this.mouseRectangle.Contains(point))
                {
                    OnClick(mouseState.X,mouseState.Y);
                }
            }
            prevMouseState = mouseState;
        }

        public override void Destroy()
        {
            EventManager.OnUpdate -= Update;
            base.Destroy();
        }

        private void UpdatePosition()
        {
            this.mouseRectangle.X = (int)transform.Position.X;
            this.mouseRectangle.Y = (int)transform.Position.Y;
        }

        public void SetSize(int width, int height)
        {
            mouseRectangle.Width = width;
            mouseRectangle.Height = height;
        }
    }
}
