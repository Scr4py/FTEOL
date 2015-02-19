using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Menue 
    {

        public Background background;

        public Button play;
        public Button option;
        public Button credits;
        public Button exit;

        public Menue()
        {
            //this.background = new Background(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\MenueBackground"));
            //this.play = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), GameState.GameStart, "parallax");
            //this.play.GetComponent<Transform>().Position = new Vector2(700, 400);
            //this.option = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), GameState.Options, "parallax");
            //this.option.GetComponent<Transform>().Position = new Vector2(700, 500);
            //this.credits = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), GameState.Credits, "parallax");
            //this.credits.GetComponent<Transform>().Position = new Vector2(700, 600);
            //this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), GameState.Exit, "parallax");
            //this.exit.GetComponent<Transform>().Position = new Vector2(700, 700);

            this.background = new Background(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\MenueBackground"));
            this.play = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), GameState.GameStart);
            this.play.GetComponent<Transform>().Position = new Vector2(700, 400);
            this.option = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), GameState.Options);
            this.option.GetComponent<Transform>().Position = new Vector2(700, 500);
            this.credits = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), GameState.Credits);
            this.credits.GetComponent<Transform>().Position = new Vector2(700, 600);
            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), GameState.Exit);
            this.exit.GetComponent<Transform>().Position = new Vector2(700, 700);


            //Utility.parallaxManager = new ParallaxManager();
            //Utility.parallaxManager.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\MenueBackground"), 8.0f, 29.5f, 0.2f, 0.35f, new Vector2(700, 0)));
            //Utility.parallaxManager.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), 8.0f, 47.8f, 1.0f, 1.0f, new Vector2(700, 400)));
            //Utility.parallaxManager.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), 8.0f, 47.8f, 1.0f, 1.0f, new Vector2(700, 500)));
            //Utility.parallaxManager.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), 8.0f, 47.8f, 1.0f, 1.0f, new Vector2(700, 600)));
            //Utility.parallaxManager.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), 8.0f, 47.8f, 1.0f, 1.0f, new Vector2(700, 700)));

            
            EventManager.OnUpdate += Update;
        }

        public void Update(GameTime gt)
        {
            if (Utility.map != null)
            {
                Utility.destroyMenue(this);
            }
        }
    }
}
