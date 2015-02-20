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
        private Transform transform;
        private MouseMenueInteractive mouse;
        public GameState state;

        public Button(Texture2D image, GameState gameState)
        {
            this.state = gameState;
            this.transform = this.AddComponent<Transform>();
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.mouse.SetSize(image.Width, image.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
        }

        public Button(Texture2D image, GameState gameState, string ksduhg)
        {
            this.state = gameState;
            this.transform = this.AddComponent<Transform>();
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.mouse.SetSize(image.Width, image.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
        }

        private void OnClick(int x, int y)
        {
            
            if(this.state == GameState.GameStart)
            {
                Utility.startGame();
            }
            else if (this.state == GameState.Accept)
            {
                Console.WriteLine("Accept Test");
            }
            else if (this.state == GameState.Menue)
            {
                Console.WriteLine("Menu Test");
            }
            else if (this.state == GameState.Options)
            {
                Console.WriteLine("Option Test");
            }
            else if (this.state == GameState.Cancel)
            {
                Console.WriteLine("Cancel Test");
            }
            else if (this.state == GameState.Exit)
            {
                Environment.Exit(0);
            }
            else if (this.state == GameState.Credits)
            {
                Console.WriteLine("Credits Test");
            }
            else if (this.state == GameState.NextPlayer)
            {
                Utility.GameManager.NextPlayer();
            }
        }
    }
}
