using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class Hud :  GameObject
    {
        Renderer render;
        SpriteFontRenderer fontRender;
        Transform transform;
        Texture2D hudTex;
        SpriteFont font;

        public Hud(Texture2D hudTex, SpriteFont font, Vector2 transform)
        {
            this.hudTex = hudTex;
            this.font = font;
            this.fontRender = AddComponent<SpriteFontRenderer>();
            this.transform = AddComponent<Transform>();
            this.transform.Position = transform;
            this.render = AddComponent<Renderer>();
            EventManager.OnRender += hudRender;
            fontRender.SetFont(font);
            fontRender.start();
            this.render.SetImage(hudTex);
            this.render.Start();
            
        }

        private void hudRender(SpriteBatch spriteBatch)
        {
            fontRender.SetText("Yolo");
        }

    }
}
