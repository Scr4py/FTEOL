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
            prepareHud();
            EventManager.OnUpdate += hudRender;
        }

        private void prepareHud()
        {
            this.menue = new Button(Utility.CurrentContent.Load<Texture2D>("button_endturn"), new Rectangle(225, 60, 225, 60), GameState.Menue);
            this.menue.GetComponent<Transform>().Position = new Vector2(600, 1025);
            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("button_hud"), new Rectangle(225, 75, 225, 75), GameState.Exit);
            this.exit.GetComponent<Transform>().Position = new Vector2(850, 1025);
            this.nextPlayer = new Button(Utility.CurrentContent.Load<Texture2D>("button_hud"), new Rectangle(225, 75, 225, 75), GameState.NextPlayer);
            this.nextPlayer.GetComponent<Transform>().Position = new Vector2(1100, 1025);
        }

        private void hudRender(GameTime gt)
        {
            fontRender.textList.RemoveRange(0, fontRender.textList.Count());
            fontRender.SetText(string.Format("Bow {0} / {1}", Utility.activeSoldiersGoodArch, Utility.totalSoldiersGoodArch), new Vector2(20, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
            fontRender.SetText(string.Format("Pig {0} / {1}", Utility.activeSoldiersGoodPig, Utility.totalSoldiersGoodPig), new Vector2(150, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
            fontRender.SetText(string.Format("Swords {0} / {1}", Utility.activeSoldiersGoodSword, Utility.totalSoldiersGoodSword), new Vector2(280, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
            fontRender.SetText(string.Format("Bow {0} / {1}", Utility.totalSoldiersGoodArch, Utility.totalSoldiersGoodArch), new Vector2(1500, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
            fontRender.SetText(string.Format("Pig {0} / {1}", Utility.totalSoldiersGoodArch, Utility.totalSoldiersGoodArch), new Vector2(1630, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
            fontRender.SetText(string.Format("Swords {0} / {1}", Utility.totalSoldiersGoodArch, Utility.totalSoldiersGoodArch), new Vector2(1760, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 42));
        }

        public void SetVector(Vector2 position)
        {
            this.transform.Position = position;
        }
    }
}
