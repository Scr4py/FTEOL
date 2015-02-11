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
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.render = this.AddComponent<CompoundRenderer>();
            this.render.AddInLists(image, source);
            this.render.start();
            this.mouse.OnClick += OnClick;
            this.mouse.SetRectangle(source.Width, source.Height);
            this.mouse.ButtonClick();
            this.mouse.start();
            
        }

        private void OnClick()
        {
            Console.WriteLine("Test");
        }
    }
}
