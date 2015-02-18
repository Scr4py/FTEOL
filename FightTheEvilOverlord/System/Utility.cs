using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FightTheEvilOverlord
{
    static class Utility
    {
        public static int ActivePlayerNumber = 0;

        public static int activeSoldiersGoodArch;
        public static int totalSoldiersGoodArch;
        public static int activeSoldiersBadArch;
        public static int totalSoldiersBadArch;
        public static int activeSoldiersGoodPig;
        public static int totalSoldiersGoodPig;
        public static int activeSoldiersBadPig;
        public static int totalSoldiersBadPig;
        public static int activeSoldiersGoodSword;
        public static int totalSoldiersGoodSword;
        public static int activeSoldiersBadSword;
        public static int totalSoldiersBadSword;

        public static SpriteFont Font;
        public static Player ArchPlayer;
        public static Player PigPlayer;
        public static Player SwordPlayer;
        public static Player EvilOverLord;
        public static GameManager GameManager;

        public static bool movementEngaged;

        public static ContentManager CurrentContent;
        public static GraphicsDevice CurrentGraphicsDevice;

        public static bool isColliding(Tile toCheckTile, MouseState currentState)
        {
            if (currentState.Position.X >= toCheckTile.transform.Position.X + ((toCheckTile.image.Width * Renderer.scale) * 0.25) &&
                currentState.Position.Y >= toCheckTile.transform.Position.Y)
            {
                if (currentState.Position.X <= toCheckTile.transform.Position.X + ((toCheckTile.image.Width * Renderer.scale) * 0.75) &&
                    currentState.Position.Y <= toCheckTile.transform.Position.Y + (toCheckTile.image.Height * Renderer.scale))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isColliding(Village toCheckVillage, MouseState currentState)
        {
            if (currentState.Position.X >= toCheckVillage.transform.Position.X + ((toCheckVillage.image.Width * Renderer.scale) * 0.25) &&
                currentState.Position.Y >= toCheckVillage.transform.Position.Y)
            {
                if (currentState.Position.X <= toCheckVillage.transform.Position.X + ((toCheckVillage.image.Width * Renderer.scale) * 0.75) &&
                    currentState.Position.Y <= toCheckVillage.transform.Position.Y + (toCheckVillage.image.Height * Renderer.scale))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isColliding(Transform toCheckTransform, MouseState currentState, Texture2D image)
        {
            if (currentState.Position.X >= toCheckTransform.Position.X &&
                currentState.Position.Y >= toCheckTransform.Position.Y)
            {
                if (currentState.Position.X <= toCheckTransform.Position.X + (image.Width * UnitRenderer.scale) &&
                    currentState.Position.Y <= toCheckTransform.Position.Y + (image.Height * UnitRenderer.scale))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isCollidingWithNoUnit(Transform toCheckTransform, MouseState currentState, Texture2D image)
        {
            if (currentState.Position.X >= toCheckTransform.Position.X &&
                currentState.Position.Y >= toCheckTransform.Position.Y)
            {
                if (currentState.Position.X <= toCheckTransform.Position.X + (image.Width) &&
                    currentState.Position.Y <= toCheckTransform.Position.Y + (image.Height))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
