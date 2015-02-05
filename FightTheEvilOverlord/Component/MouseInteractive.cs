using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class MouseInteractive : Component
    {
        int mouseX;
        int mouseY;

        public delegate void OnClickEventHandler(int mouseX, int mouseY);
        public static event OnClickEventHandler OnClick = delegate { };

      public void Start()
      {
          EventManager.OnUpdate += OnUpdate;
      }

      void OnUpdate(GameTime gameTime)
      {
          this.getMouseInput();
      }

      void getMouseInput()
      {
          MouseState mouseState = Mouse.GetState();

          if(mouseState.LeftButton == ButtonState.Pressed)
          {
              OnClick(mouseState.Position.X, mouseState.Position.Y);
          }
      }

      public override void Destroy()
      {
          EventManager.OnUpdate -= OnUpdate;
          base.Destroy();
      }
    }
}
