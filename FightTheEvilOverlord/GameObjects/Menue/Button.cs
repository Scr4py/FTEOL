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
        Accept,
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
        private GameState state;
        public bool start = false;

        public Button(Texture2D image, GameState gameState)
        {
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<ButtonRender>();
            this.render.start();
            this.render.AddInLists(image);
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.mouse.SetSize(image.Width,image.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
        }

        private void OnClick(int x, int y)
        {
            if (state == GameState.GameStart)
            {
                this.start = true;
            }
            
        }
    }
}
