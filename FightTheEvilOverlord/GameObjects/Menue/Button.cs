using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

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
        public Audio audio;
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
            this.audio = AddComponent<Audio>();
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
            this.audio = AddComponent<Audio>();
            this.mouse.SetSize(image.Width, image.Height);
            this.mouse.OnClick += OnClick;
            this.mouse.start();
        }

        private void OnClick(int x, int y)
        {

           
            if(this.state == GameState.GameStart)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));
                Utility.startGame();
            }
            else if(this.state == GameState.HowTo)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));
                pm.goDown();
                pm.HowTo();
            }
            else if (this.state == GameState.Accept)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Console.WriteLine("Accept Test");
            }
            else if (this.state == GameState.Menue)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Menue menu = new Menue();
            }
            else if (this.state == GameState.Options)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                pm.goUp();
            }
            else if (this.state == GameState.Cancel)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Console.WriteLine("Cancel Test");
            }
            else if (this.state == GameState.Exit)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Environment.Exit(0);
            }
            else if (this.state == GameState.Credits)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Console.WriteLine("Credits Test");
            }
            else if (this.state == GameState.Field)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.RemoveAt(0);
                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\BoardLayout"), 0.35f, 0.35f, 2.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100*scale), -25)));
            }
            else if (this.state == GameState.Fight)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 3.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100 * scale), 1500)));
            }
            else if (this.state == GameState.Villages)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 4.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100 * scale), 1500)));
            }
            else if (this.state == GameState.Move)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 5.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100 * scale), 1500)));
            }
            else if (this.state == GameState.TileColor)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 6.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100 * scale), 1500)));
            }
            else if (this.state == GameState.Slider)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 7.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + (100 * scale), 1500)));
            }
            else if (this.state == GameState.NextPlayer)
            {
                this.audio.SetAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\button_click"));

                Utility.GameManager.NextPlayer();
            }
        }
    }
}
