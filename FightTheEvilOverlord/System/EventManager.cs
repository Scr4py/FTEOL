using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class EventManager
    {
        public delegate void RenderEventHandler(SpriteBatch spriteBatch);
        public static event RenderEventHandler OnRender = delegate { };

        public delegate void UpdateEventhandler(GameTime gameTime);
        public static event UpdateEventhandler OnUpdate = delegate { };

        public static void InvokeRender(SpriteBatch spriteBatch)
        {
            OnRender(spriteBatch);
        }

        public static void InVokeUpdate(GameTime gameTime)
        {
            OnUpdate(gameTime);
        }
    }
}
