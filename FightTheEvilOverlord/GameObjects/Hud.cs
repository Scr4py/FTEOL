using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Hud : GameObject
    {
        Button menue;
        Button exit;
        Button nextPlayer;
        Archer archer;
        HudRenderer render;
        SpriteFontRenderer fontRender;
        Transform transform;
        Texture2D hudTex;
        SpriteFont font;
        int placeholder = 0;
        int placeholder1 = 100;

        public Hud(Texture2D hudTex, SpriteFont font)
        {
            this.font = font;
            this.hudTex = hudTex;
            this.transform = AddComponent<Transform>();
            this.render = AddComponent<HudRenderer>();
            this.fontRender = AddComponent<SpriteFontRenderer>();
            this.render.SetImage(hudTex);
            this.render.start();
            fontRender.SetFont(font);
            fontRender.start();
            hudRender();
            
        }

        private void hudRender()
        {
            fontRender.SetText(string.Format("Bow {0} / {1}", placeholder, placeholder1), new Vector2(20, 1038));
            fontRender.SetText(string.Format("Pig {0} / {1}", placeholder, placeholder1), new Vector2(150, 1038));
            fontRender.SetText(string.Format("Swords {0} / {1}", placeholder, placeholder1), new Vector2(280, 1038));
            render.SetDisctanceImage(Utility.CurrentContent.Load<Texture2D>("abstand"),new Vector2(505, 1025));
            this.menue = new Button(Utility.CurrentContent.Load<Texture2D>("HudButton"), new Rectangle(225, 75, 225, 75), GameState.Menue);
            this.menue.GetComponent<Transform>().Position = new Vector2(600, 1025);
            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("HudButton"), new Rectangle(225, 75, 225, 75), GameState.Exit);
            this.exit.GetComponent<Transform>().Position = new Vector2(850, 1025);
            this.nextPlayer = new Button(Utility.CurrentContent.Load<Texture2D>("HudButton"), new Rectangle(225, 75, 225, 75), GameState.NextPlayer);
            this.nextPlayer.GetComponent<Transform>().Position = new Vector2(1100, 1025);
            render.SetDisctanceImage(Utility.CurrentContent.Load<Texture2D>("abstand"), new Vector2(1400, 1025));
            fontRender.SetText(string.Format("Bow {0} / {1}",placeholder,placeholder1), new Vector2(1500,1038));
            fontRender.SetText(string.Format("Pig {0} / {1}", placeholder, placeholder1), new Vector2(1630, 1038));
            fontRender.SetText(string.Format("Swords {0} / {1}", placeholder, placeholder1), new Vector2(1760, 1038));
        }

        public void SetVector(Vector2 position)
        {
            this.transform.Position = position;
        }
    }
}
