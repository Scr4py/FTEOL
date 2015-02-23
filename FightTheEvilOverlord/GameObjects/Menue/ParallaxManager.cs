using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class ParallaxManager
    {
        public List<ParallaxLayer> Layers { get; private set; }

        int alpha;
        int alphaCha;
        int alphaCha2;
        int menuePosition;
        int ch1Position;
        int ch2Position;
        int iCounter;

        bool hasToFuckUp;

        public ParallaxManager()
        {
            alpha = 0;
            alphaCha = 0;
            alphaCha2 = 0;
            menuePosition = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            ch1Position = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ch2Position = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 2;
            this.Layers = new List<ParallaxLayer>();
            hasToFuckUp = false;
            EventManager.OnRender += Draw;
        }

        public void AddLayer(ParallaxLayer layer)
        {
            this.Layers.Add(layer);
        }

        public void Destroy()
        {
            EventManager.OnRender -= Draw;
        }

        public void Draw(SpriteBatch spriteBach)
        {
            iCounter++;

            if (alpha <= 255 && iCounter >= 300 && !hasToFuckUp)
            {
                alpha++;
            }

            if (menuePosition >= 10 && !hasToFuckUp)
            {
                menuePosition -= 9;
            }

            if (ch1Position >= 10 && !hasToFuckUp)
            {
                ch1Position -= 9;
            }

            if (ch2Position >= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 650 && !hasToFuckUp)
            {
                ch2Position -= 9;
            }
            foreach (var layer in this.Layers)
            {
                if (alphaCha <= 255 && iCounter >= 200)
                {
                    alphaCha++;
                }

                if (alphaCha2 <= 255 && iCounter >= 270)
                {
                    alphaCha2++;
                }

                if (layer.speed == 3.0f && iCounter >= 300)
                {
                    float multiplierX = Mouse.GetState().Position.X - (layer.Position.X + layer.Image.Width / 2);
                    float multiplierY = Mouse.GetState().Position.Y - (layer.Position.Y + layer.Image.Height / 2);
                    Vector2 newPosition = new Vector2(layer.Position.X + (multiplierX / 200 * layer.speed), layer.Position.Y + (multiplierY / 200 * layer.speed));
                    spriteBach.Draw(layer.Image, newPosition, null, new Color(255, 255, 255, alpha), 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
                else if (layer.speed == 0.0f)
                {
                    spriteBach.Draw(layer.Image, new Vector2(layer.Position.X, 0 - menuePosition), null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
                else if (layer.speed == 1.0f)
                {
                    spriteBach.Draw(layer.Image, new Vector2(0 - ch1Position, layer.Position.Y), null, new Color(255, 255, 255, alphaCha), 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
                else if (layer.speed == 2.0f)
                {
                    spriteBach.Draw(layer.Image, new Vector2(0 + ch2Position, layer.Position.Y), null, new Color(255, 255, 255, alphaCha2), 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBach.Draw(layer.Image, layer.Position, null, new Color(255, 255, 255, 0), 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
            }
        }

        public void goAway()
        {
            hasToFuckUp = true;
            EventManager.OnRender -= Draw;
            EventManager.OnRender += DrawTheFuckUp;
        }

        private void DrawTheFuckUp(SpriteBatch spriteBatch)
        {
            foreach (var layer in this.Layers)
            {
                if (layer.speed == 1.0f)
                {
                    if (layer.Position.Y <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2)
                    {
                        layer.Position = new Vector2(layer.Position.X, layer.Position.Y + 7);
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                    else
                    {
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                }
                else if (layer.speed == 2.0f)
                {
                    if (layer.Position.Y <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2)
                    {
                        layer.Position = new Vector2(layer.Position.X, layer.Position.Y + 7);
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                    else
                    {
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                }
                else if (layer.speed == 94.0f)
                {
                    if (layer.Position.Y <= -10)
                    {
                        layer.Position = new Vector2(layer.Position.X, layer.Position.Y + 13);
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                    else
                    {
                        spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                    }
                }
                else
                {
                    layer.Position = new Vector2(layer.Position.X, layer.Position.Y + 13);
                    spriteBatch.Draw(layer.Image, layer.Position, null, Color.White, 0.0f, Vector2.Zero, layer.scale, SpriteEffects.None, 1);
                }
            }
        }
    }
}