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
        Options,
        Cancel,
        Exit,
        Credits,
        NextPlayer
    }

    class Button : GameObject
    {
        private CompoundRenderer render;
        private Transform transform;
        private MouseMenueInteractive mouse;

        public Button(Texture2D image, Rectangle source, GameState gameState)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<CompoundRenderer>();
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
