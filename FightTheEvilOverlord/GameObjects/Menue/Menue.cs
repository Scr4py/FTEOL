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
        public ParallaxManager pm;

        public Button play;
        public Button option;
        public Button credits;
        public Button exit;

        public Menue()
        {
            this.pm = new ParallaxManager();
           
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\MenueBackground"), 1.0f, 0.35f, 0.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 350, 0)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\OptionBackground"), 1.0f, 0.35f, 94.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 350, -GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 65)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\charac1"), 1.0f, 1.0f, 1.0f, new Vector2(0, 100)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\charac2"), 1.0f, 1.0f, 2.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 650, 100)));
            //this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("wheat_tile"), 1.0f, 1.0f, 93.0f, new Vector2(800, 400)));

            this.play = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), GameState.GameStart,"play", pm);
            this.play.GetComponent<Transform>().Position = new Vector2(700, 400);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), 1.0f, 1.0f, 3.0f, new Vector2(730, 400)));

            this.option = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), GameState.Options, "option", pm);
            this.option.GetComponent<Transform>().Position = new Vector2(700, 500);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), 1.0f, 1.0f, 3.0f, new Vector2(730, 500)));

            this.credits = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), GameState.Credits, "Credits", pm);
            this.credits.GetComponent<Transform>().Position = new Vector2(700, 600);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), 1.0f, 1.0f, 3.0f, new Vector2(730, 600)));

            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), GameState.Exit, "exit", pm);
            this.exit.GetComponent<Transform>().Position = new Vector2(700, 700);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), 1.0f, 1.0f, 3.0f, new Vector2(730, 700)));

       
            
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
