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
        HowTo,
        Accept,
        Menue,
        Options,
        Cancel,
        Exit,
        Credits,
        Field,
        Villages,
        Fight,
        Move,
        TileColor,
        Slider,
        NextPlayer
    }

    class Button : GameObject
    {

        public Texture2D image;
        private Transform transform;
        private MouseMenueInteractive mouse;
        public GameState state;

        float scale;

        ParallaxManager pm;
        
        public Button(Texture2D image, GameState gameState)
        {
            this.scale = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920.0f;
            this.image = image;
            this.state = gameState;
            this.transform = this.AddComponent<Transform>();
            this.mouse = this.AddComponent<MouseMenueInteractive>();
            this.mouse.SetSize(image.Width, image.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            if (this.mouse.onMouse)
            {
                spriteBatch.Draw(this.image, this.transform.Position, null, Color.Yellow, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(this.image, this.transform.Position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
        }

        public Button(Texture2D image, GameState gameState, string ksduhg, ParallaxManager pm)
        {
            this.pm = pm;
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
            else if(this.state == GameState.HowTo)
            {
                pm.goDown();
            }
            else if (this.state == GameState.Accept)
            {
                Console.WriteLine("Accept Test");
            }
            else if (this.state == GameState.Menue)
            {
                Menue menu = new Menue();
            }
            else if (this.state == GameState.Options)
            {
                pm.goUp();
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
            else if (this.state == GameState.Field)
            {
                Console.WriteLine("BoardLayout");
            }
            else if (this.state == GameState.Fight)
            {
                Console.WriteLine("Fight");
            }
            else if (this.state == GameState.Villages)
            {
                Console.WriteLine("Villages");
            }
            else if (this.state == GameState.Move)
            {
                Console.WriteLine("move");
            }
            else if (this.state == GameState.TileColor)
            {
                Console.WriteLine("TileColor");
            }
            else if (this.state == GameState.Slider)
            {
                Console.WriteLine("slider");
            }
            else if (this.state == GameState.NextPlayer)
            {
                Utility.GameManager.NextPlayer();
            }
        }
    }
}
