using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class Cursor :  GameObject
    {
        Renderer render;
        Transform transform;

        public Cursor(Texture2D image)
        {
            this.transform = this.AddComponent<Transform>();
            
            EventManager.OnUpdate += Update;
        }

        public void Update(GameTime gt)
        {
            transform.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }
    }
}
