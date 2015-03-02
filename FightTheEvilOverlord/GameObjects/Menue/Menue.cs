using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace FightTheEvilOverlord
{
    class Menue : GameObject
    {
        public ParallaxManager pm;
        public Audio audio;
        public Button play;
        public Button howTo;
        public Button option;
        public Button credits;
        public Button exit;
        public Button Field;
        public Button Fight;
        public Button Village;
        public Button Movement;
        public Button TileColor;
        public Button Slider;
        public Button Menu;

        float scale;
        public Menue()
        {
            this.audio = AddComponent<Audio>();
            this.audio.SetMenuMusicAndPlay(Utility.CurrentContent.Load<SoundEffect>("Audio\\MenuMusic"));

            this.scale = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920.0f;

            this.pm = new ParallaxManager();

            //Menue Background
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\MenueBackground"), 1.0f, 0.35f, 0.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 350 * (scale), 0)));
            //How to backgrounds
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\OptionBackground"), 1.0f, 0.35f, 94.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 350, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 65)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\OptionBackground"), 1.0f, 0.2f, 38.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.38f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 65)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\OptionBackground"), 1.0f, 0.2f, 38.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 18, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 65)));
            //How to Buttons
            this.Field = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_boardlayout"), GameState.Field, "Field", pm);
            this.Field.GetComponent<Transform>().Position = new Vector2(200, 700);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_boardlayout"), 1.0f, 1.0f, 39.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 6 - 120, 2000)));
            this.Fight = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_fight"), GameState.Fight, "Fight", pm);
            this.Fight.GetComponent<Transform>().Position = new Vector2(200, 750);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_fight"), 1.0f, 1.0f, 40.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 6 - 120, 2000)));
            this.Village = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_village"), GameState.Villages, "village", pm);
            this.Village.GetComponent<Transform>().Position = new Vector2(200, 800);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_village"), 1.0f, 1.0f, 41.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 6 - 120, 2000)));

            this.Movement = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_movement"), GameState.Move, "Movement", pm);
            this.Movement.GetComponent<Transform>().Position = new Vector2(1500, 700);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_movement"), 1.0f, 1.0f, 39.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.28f, 2000)));
            this.TileColor = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_tilecolor"), GameState.TileColor, "TileColor", pm);
            this.TileColor.GetComponent<Transform>().Position = new Vector2(1500, 750);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_tilecolor"), 1.0f, 1.0f, 40.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.28f, 2000)));
            this.Slider = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_slider"), GameState.Slider, "Slider", pm);
            this.Slider.GetComponent<Transform>().Position = new Vector2(1500, 800);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_slider"), 1.0f, 1.0f, 41.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.28f, 2000)));
            this.pm.HowToLayer.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\HowTo\\Test1"), 0.35f, 0.35f, 1.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (100 * scale), 1800)));
            //Options Background
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\OptionBackground"), 1.0f, 0.35f, 94.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (350 * scale), -GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)));
            //Characters
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\charac1"), 1.0f, 1.0f, 1.0f, new Vector2(0, 100)));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\charac2"), 1.0f, 1.0f, 2.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - (650 * scale), 100)));
            //tile
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("wheat_tile"), 1.0f, Utility.scale, 42.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 75, -1000)));
            //Option Button
            this.Menu = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu"), GameState.Menue, "Menu", pm);
            this.Menu.GetComponent<Transform>().Position = new Vector2(860, 790);
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu"), 1.0f, 1.0f, 43.0f, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 100, -800)));

            this.play = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), GameState.GameStart, "play", pm);
            this.play.GetComponent<Transform>().Position = new Vector2((730 * scale), (400 * scale));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_start"), 1.0f, 1.0f, 3.0f, new Vector2((730 * scale), (400 * scale))));

            this.howTo = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_howto"), GameState.HowTo, "howTo", pm);
            this.howTo.GetComponent<Transform>().Position = new Vector2((730 * scale), (500 * scale));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_howto"), 1.0f, 1.0f, 3.0f, new Vector2((730 * scale), (500 * scale))));

            this.option = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), GameState.Options, "option", pm);
            this.option.GetComponent<Transform>().Position = new Vector2((730 * scale), (600 * scale));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_option"), 1.0f, 1.0f, 3.0f, new Vector2((730 * scale), (600 * scale))));

            this.credits = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), GameState.Credits, "Credits", pm);
            this.credits.GetComponent<Transform>().Position = new Vector2((730 * scale), (700 * scale));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_credits"), 1.0f, 1.0f, 3.0f, new Vector2((730 * scale), (700 * scale))));

            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), GameState.Exit, "exit", pm);
            this.exit.GetComponent<Transform>().Position = new Vector2((730 * scale), (800 * scale));
            this.pm.Layers.Add(new ParallaxLayer(Utility.CurrentContent.Load<Texture2D>("MenuGraphics\\button_menu_exit"), 1.0f, 1.0f, 3.0f, new Vector2((730 * scale), (800 * scale))));


            EventManager.OnUpdate += Update;
        }


        public void Update(GameTime gt)
        {
            if (Utility.map != null)
            {
                this.audio.StopMusic();
                Utility.destroyMenue(this);
            }
        }
    }
}
