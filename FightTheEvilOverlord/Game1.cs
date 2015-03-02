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

        UnitSpawner spawner;

        GameManager gameManager;

        Menue menue;

        Cursor cursor;
        Map map;
        Hud hud;
        SpriteFont Font;

        float fps;
        float currentFps;
        float currentTime = 0f;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

    
        protected override void LoadContent()
        {
            Font = Content.Load<SpriteFont>("Font");
            Utility.Font = Font;
            spriteBatch = new SpriteBatch(GraphicsDevice); 

            Utility.CurrentGraphicsDevice = this.GraphicsDevice;
            Utility.CurrentContent = this.Content;

            Utility.menue = new Menue();

            Utility.map = this.map;
            Utility.hud = this.hud;
            Utility.GameManager = this.gameManager;
            spawner = new UnitSpawner(Content.Load<Texture2D>("pig_unit"), Content.Load<Texture2D>("sword_unit"), Content.Load<Texture2D>("bow_unit"));
            Utility.spawner = this.spawner;

            this.cursor = new Cursor(Content.Load<Texture2D>("cursor"));
            graphics.IsFullScreen = true;
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
            currentTime += (float)gameTime.ElapsedGameTime.Milliseconds;
            if (currentTime >= 2000)
            {
                currentTime = 0.0f;
                fps = currentFps / 2;
                currentFps = 0.0f;
            }
            currentFps++;
            if (Utility.map != null)
            {
                GraphicsDevice.Clear(Color.White);
            }
            else
            {
                GraphicsDevice.Clear(Color.DarkGray);
            }

            spriteBatch.Begin();
            EventManager.InvokeRender(spriteBatch);
            spriteBatch.Draw(Content.Load<Texture2D>("cursor"), new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), Color.White);
            spriteBatch.DrawString(Font, string.Format("{0}", fps), new Vector2(10, 10), Color.Red, 0.0f, Vector2.Zero, 30, SpriteEffects.None, 1);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
