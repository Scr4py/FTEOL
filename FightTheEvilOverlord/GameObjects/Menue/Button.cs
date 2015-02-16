using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    enum GameState
    {
        GameStart,
        Menue,
        Options,
        Cancel,
        Exit,
        Credits,
        NextPlayer
    }

    class Button : GameObject
    {
        private ButtonRender render;
        private Transform transform;
        private MouseMenueInteractive mouse;

        public Button(Texture2D image, Rectangle source, GameState gameState)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<ButtonRender>();
            this.render.AddInLists(image, source);
            this.render.start();
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.mouse.SetSize(source.Width,source.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
            

            
        }

        private void OnClick(int x, int y)
        {
            Console.WriteLine("Test");
        }
    }
}
