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
        public static float scale = 0.085f;
        public static float globalScale = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920.0f;
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
        public static Menue menue;

        public static Map map;
        public static Hud hud;
        public static UnitSpawner spawner;

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

        public static void startGame()
        {
            Utility.map = new Map(CurrentContent.Load<Texture2D>("mountain_tile"), CurrentContent.Load<Texture2D>("forest_tile"), CurrentContent.Load<Texture2D>("plains_tile"), CurrentContent.Load<Texture2D>("village_tile_wip"), CurrentContent.Load<Texture2D>("wheat_tile"), CurrentContent.Load<Texture2D>("MiniMapTexture"), CurrentContent.Load<Texture2D>("pig_unit"), CurrentContent.Load<Texture2D>("bow_unit"), CurrentContent.Load<Texture2D>("sword_unit"));
            Utility.PigPlayer = new Player(1, 2, Utility.spawner, Utility.map.tilesArray[1, map.mapHeight / 2], CurrentContent.Load<Texture2D>("pig_unit"), map);
            Utility.ArchPlayer = new Player(0, 2, Utility.spawner, Utility.map.tilesArray[1, 1], CurrentContent.Load<Texture2D>("bow_unit"), map);
            Utility.SwordPlayer = new Player(2, 2, Utility.spawner, Utility.map.tilesArray[1, map.mapHeight - 2], CurrentContent.Load<Texture2D>("sword_unit"), map);
            Utility.EvilOverLord = new Player(3, 3, Utility.spawner, Utility.map.tilesArray[map.mapWidth - 2, map.mapHeight / 2], CurrentContent.Load<Texture2D>("sword_unit"), map);
            Utility.GameManager = new GameManager(Utility.PigPlayer, Utility.ArchPlayer, Utility.SwordPlayer, Utility.EvilOverLord, Utility.map);
            Utility.hud = new Hud(CurrentContent.Load<Texture2D>("HudGraphics\\hudTex"), CurrentContent.Load<SpriteFont>("Arial"));
            Utility.hud.SetVector(new Vector2(0, 1005));
        }


        public static void destroyMenue(Menue menu)
        {
            if (menu != null && menu.pm != null)
            {
                menu.credits.Destroy();
                menu.exit.Destroy();
                menu.option.Destroy();
                menu.play.Destroy();
                menu.pm.Destroy();
                menu.pm = null;
                menu = null;
            }
        }
    }
}
