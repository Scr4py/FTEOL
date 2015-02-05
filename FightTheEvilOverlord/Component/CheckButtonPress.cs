using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class CheckButtonPress : Component
    {
        int buttonX;
        int buttonY;
        int buttonHeight;
        int buttonWidth;

        public void Start()
        {
        }

        public void SetBounds(int ButtonX, int ButtonY, int ButtonHeight, int ButtonWidth)
        {
            this.buttonX = ButtonX;
            this.buttonY = ButtonY;
            this.buttonHeight = ButtonHeight;
            this.buttonWidth = ButtonWidth;
        }

        public void SetBounds(Rectangle ButtonArea)
        {
            this.buttonX = ButtonArea.X;
            this.buttonY = ButtonArea.Y;
            this.buttonWidth = ButtonArea.Width;
            this.buttonHeight = ButtonArea.Height;
        }

        public bool CheckPress(int mouseX, int mouseY)
        {
            if (buttonX < mouseX && buttonY < mouseY && buttonX + buttonWidth > mouseX && buttonY + buttonHeight > mouseY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPress(Vector2 mousePosition)
        {
            if (buttonX < mousePosition.X && buttonY < mousePosition.Y && buttonX + buttonWidth > mousePosition.X && buttonHeight + buttonY > mousePosition.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
