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
        HudRender hudRenderer;
        Transform transform;
        Texture2D hudTex;
        SpriteFont font;
        float scale;
        
        public Hud(Texture2D hudTex, SpriteFont font)
        {
            this.scale = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920.0f;
            this.font = font;
            this.hudTex = hudTex;
            this.transform = AddComponent<Transform>();
            this.hudRenderer = AddComponent<HudRender>();
            this.hudRenderer.SetBackGroundImage(hudTex);
            hudRenderer.SetFont(font);
            hudRenderer.start();
            prepareHud();
            EventManager.OnUpdate += hudRender;
        }

        private void prepareHud()
        {
            this.menue = new Button(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\button_hud"), GameState.Menue);
            this.menue.GetComponent<Transform>().Position = new Vector2(600, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 55);
            this.exit = new Button(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\button_hud"), GameState.Exit);
            this.exit.GetComponent<Transform>().Position = new Vector2(850, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 55);
            this.nextPlayer = new Button(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\button_hud"), GameState.NextPlayer);
            this.nextPlayer.GetComponent<Transform>().Position = new Vector2(1100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 55);
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\bow_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 27.0f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (55 * scale)));
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\pig_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 8.0f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (50 * scale)));
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\sword_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4.7f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (55 * scale)));
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\bow_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.3f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (55 * scale)));
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\pig_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.2f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (50 * scale)));
            hudRenderer.setImage(Utility.CurrentContent.Load<Texture2D>("HudGraphics\\sword_unit_hud"), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.1f, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (55 * scale)));
            
        }

        private void hudRender(GameTime gt)
        {
            hudRenderer.textList.RemoveRange(0, hudRenderer.textList.Count());
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersGoodArch, Utility.totalSoldiersGoodArch), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 27.0f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersGoodPig, Utility.totalSoldiersGoodPig), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 8.0f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersGoodSword, Utility.totalSoldiersGoodSword), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4.7f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersBadArch, Utility.totalSoldiersBadArch), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.3f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersBadPig, Utility.totalSoldiersBadPig), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.2f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
            hudRenderer.SetText(string.Format("{0} / {1}", Utility.activeSoldiersBadSword, Utility.totalSoldiersBadSword), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.1f + (60 * scale), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 38));
          
        }

        public void SetVector(Vector2 position)
        {
            this.transform.Position = position;
        }
    }
}
