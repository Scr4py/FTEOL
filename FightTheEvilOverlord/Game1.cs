#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace FightTheEvilOverlord
{
  
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;
        Menue play;
        Menue startImage;
        Menue option;
        Menue credits;
        Menue exit;
        Transform transform;
        Map map;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

    
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.background = new Background(Content.Load<Texture2D>("Background-Test"), new Rectangle(0,0,800,600));
            this.map = new Map(Content.Load<Texture2D>("berg_tile"));
            this.play = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.play.GetComponent<Transform>().Position = new Vector2(300, 150);
            this.startImage = new Menue(Content.Load<Texture2D>("Start"), new Rectangle(0, 0, 200, 75));
            this.startImage.GetComponent<Transform>().Position = new Vector2(300, 150);
            this.option = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.option.GetComponent<Transform>().Position = new Vector2(300,250);
            this.credits = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.credits.GetComponent<Transform>().Position = new Vector2(300, 350);
            this.exit = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.exit.GetComponent<Transform>().Position = new Vector2(300, 450);
        }

      
        protected override void UnloadContent()
        {
            
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            EventManager.InVokeUpdate(gameTime);

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //EventManager.InvokeRender(spriteBatch);
            this.map.generateAndDrawTiles(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
