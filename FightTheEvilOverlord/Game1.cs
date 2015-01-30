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
        Button play;
        Button option;
        Button credits;
        Transform transform;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

    
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.background = new Background(Content.Load<Texture2D>("Background-Test"), new Rectangle(0,0,800,600));
            
            this.play = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.play.GetComponent<Transform>().Position = new Vector2(300, 150);
            this.option = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.option.GetComponent<Transform>().Position = new Vector2(300,250);
            this.credits = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            this.credits.GetComponent<Transform>().Position = new Vector2(300, 350);
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
            EventManager.InvokeRender(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
