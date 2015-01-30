using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class MouseInteractive
    {
      public delegate void OnClickEventHandler();
      public static event OnClickEventHandler OnClick = delegate { };
    }
}
