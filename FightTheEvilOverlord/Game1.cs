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
        Button startImage;
        Button option;
        Button credits;
        Button exit;

        UnitSpawner spawner;

        Player pigPlayer;
        Player archerPlayer;
        Player swordPlayer;
        Player evilOverLord;

        GameManager gameManager;

        Map map;

        SpriteFont Font;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

    
        protected override void LoadContent()
        {
            Font = Content.Load<SpriteFont>("Font");
            Utility.Font = Font;
            //Utility.Font = Font;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.background = new Background(Content.Load<Texture2D>("Background-Test"), new Rectangle(0, 0, 800, 600));
            //this.play = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75),GameState.GameStart);
            //this.play.GetComponent<Transform>().Position = new Vector2(300, 150);
            //this.option = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75),GameState.Options);
            //this.option.GetComponent<Transform>().Position = new Vector2(300, 250);
            //this.credits = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75),GameState.Credits);
            //this.credits.GetComponent<Transform>().Position = new Vector2(300, 350);
            //this.exit = new Button(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75),GameState.Exit);
            //this.exit.GetComponent<Transform>().Position = new Vector2(300, 450);

            this.map = new Map(Content.Load<Texture2D>("mountain_tile"), Content.Load<Texture2D>("forest_tile"), Content.Load<Texture2D>("plains_tile"), Content.Load<Texture2D>("village_tile_wip"), Content.Load<Texture2D>("wheat_tile"), Content.Load<Texture2D>("MiniMapTexture"), Content.Load<Texture2D>("pig_unit"), Content.Load<Texture2D>("bow_unit"), Content.Load<Texture2D>("sword_unit"));
            spawner = new UnitSpawner(Content.Load<Texture2D>("pig_unit"), Content.Load<Texture2D>("sword_unit"), Content.Load<Texture2D>("bow_unit"));
            this.pigPlayer = new Player(1, 2, spawner, this.map.tilesArray[1, map.mapHeight / 2], Content.Load<Texture2D>("pig_unit"), map);
            this.archerPlayer = new Player(0, 2, spawner, this.map.tilesArray[1, 1], Content.Load<Texture2D>("bow_unit"), map);
            this.swordPlayer = new Player(2, 2, spawner, this.map.tilesArray[1, map.mapHeight - 2], Content.Load<Texture2D>("sword_unit"), map);
            this.evilOverLord = new Player(3, 3, spawner, this.map.tilesArray[ map.mapWidth - 2, map.mapHeight / 2], Content.Load<Texture2D>("sword_unit"), map);
            this.gameManager = new GameManager(pigPlayer, archerPlayer, swordPlayer, swordPlayer, map);
            Utility.ArchPlayer = this.archerPlayer;
            Utility.PigPlayer = this.pigPlayer;
            Utility.SwordPlayer = this.swordPlayer;
            Utility.EvilOverLord = this.evilOverLord;
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
            //this.map.generateAndDrawTiles(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
