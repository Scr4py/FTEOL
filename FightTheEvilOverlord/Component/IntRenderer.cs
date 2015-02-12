using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class IntRenderer : Component
    {
        int toRenderInt;
        Vector2 renderPosition;

        public void Start()
        {
            EventManager.OnRender += render;
        }

        void render(SpriteBatch spriteBatch)
        {
            if (Utility.Font != null)
            {
                spriteBatch.DrawString(Utility.Font, toRenderInt.ToString(), renderPosition, Color.Red);
            }
        }

        public void Update(Vector2 renderPosition, int toRenderInt)
        {
            this.renderPosition = renderPosition;
            this.toRenderInt = toRenderInt;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= render;
            base.Destroy();
        }
    }
}
