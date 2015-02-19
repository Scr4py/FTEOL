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

        Player pigPlayer;
        Player archerPlayer;
        Player swordPlayer;
        Player evilOverLord;

        GameManager gameManager;

        Menue menue;

        Cursor cursor;
        Map map;
        Hud hud;
        SpriteFont Font;

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

            Utility.parallaxManager = new ParallaxManager();
            menue = new Menue();

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
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            EventManager.InvokeRender(spriteBatch);
            spriteBatch.Draw(Content.Load<Texture2D>("cursor"), new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
