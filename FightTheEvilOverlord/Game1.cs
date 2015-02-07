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
            //Font = Content.Load<SpriteFont>("Courier New");
            //Utility.Font = Font;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //this.background = new Background(Content.Load<Texture2D>("Background-Test"), new Rectangle(0,0,800,600));
            this.map = new Map(Content.Load<Texture2D>("mountain_tile"), Content.Load<Texture2D>("forest_tile"), Content.Load<Texture2D>("plains_tile"), Content.Load<Texture2D>("village_tile_wip"), Content.Load<Texture2D>("wheat_tile"));
            //this.spawner = new UnitSpawner();
            //this.play = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            //this.play.GetComponent<Transform>().Position = new Vector2(300, 150);
            //this.startImage = new Menue(Content.Load<Texture2D>("Start"), new Rectangle(0, 0, 200, 75));
            //this.startImage.GetComponent<Transform>().Position = new Vector2(300, 150);
            //this.option = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            //this.option.GetComponent<Transform>().Position = new Vector2(300,250);
            //this.credits = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            //this.credits.GetComponent<Transform>().Position = new Vector2(300, 350);
            //this.exit = new Menue(Content.Load<Texture2D>("Button"), new Rectangle(0, 0, 200, 75));
            //this.exit.GetComponent<Transform>().Position = new Vector2(300, 450);
            spawner = new UnitSpawner(Content.Load<Texture2D>("pig_unit"), Content.Load<Texture2D>("sword_unit"), Content.Load<Texture2D>("bow_unit"));
            this.pigPlayer = new Player(1, 2, spawner, this.map.tilesArray[1, map.mapHeight / 2], Content.Load<Texture2D>("pig_unit"), map);
            this.archerPlayer = new Player(0, 2, spawner, this.map.tilesArray[1, 1], Content.Load<Texture2D>("bow_unit"), map);
            this.swordPlayer = new Player(2, 2, spawner, this.map.tilesArray[1, map.mapHeight - 2], Content.Load<Texture2D>("sword_unit"), map);
            this.gameManager = new GameManager(pigPlayer, archerPlayer, swordPlayer, swordPlayer, map);
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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            EventManager.InvokeRender(spriteBatch);
            //this.map.generateAndDrawTiles(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
