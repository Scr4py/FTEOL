using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class MouseInteractive : Component
    {
      public delegate void OnClickEventHandler();
      public static event OnClickEventHandler OnClick = delegate { };

      Rectangle mouseRectangle;

      public void start()
      {
          EventManager.OnUpdate += Update;
      }

      private void Update(GameTime gameTime)
      {
          
      }
    }
}
