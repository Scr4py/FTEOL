﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightTheEvilOverlord
{
    class UnitRenderer : Component
    {
        public const float scale = 0.15f;
        Transform transform;
        Texture2D image;

        public void start()
        {
            this.transform = GameObject.GetComponent<Transform>();
            EventManager.OnRender += Render;
        }

        private void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.transform.Position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }

        public override void Destroy()
        {
            EventManager.OnRender -= Render;
        }

    }
}