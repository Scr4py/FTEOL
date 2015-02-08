﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class Archer : GameObject
    {
        public int number;
        public Tile tile;
        Tile lastTile;
        public Player owner;
        public int playerNumber;
        public int activeSoldiers;
        public int totalSoldiers;

        MouseState currentState;
        MouseState lastState;

        Texture2D image;

        Transform transform;
        public UnitRenderer render;

        public Archer(Tile Spawntile, int PlayerNumber, int ActiveSoldiers, int SoldiersNumber, Texture2D image, Player player, Archer lastArcher)
        {
            removeLastArcher(lastArcher);
            this.owner = player;
            this.image = image;
            currentState = new MouseState();
            this.tile = Spawntile;
            this.playerNumber = PlayerNumber;
            this.activeSoldiers = ActiveSoldiers;
            this.totalSoldiers = SoldiersNumber;
            EventManager.OnUpdate += Draw;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<UnitRenderer>();
            this.transform.Position = this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
            this.render.SetImage(image);
            this.render.start();
        }

        private void Draw(GameTime gameTime)
        {
            render.SetInteger(totalSoldiers);
            render.SetSecInteger(activeSoldiers);
            lastState = currentState;
            currentState = Mouse.GetState();

            render.SetInteger(totalSoldiers);

            checkIfToMoveOnTile();
        }

        private void checkIfToMoveOnTile()
        {
            if (currentState.LeftButton == ButtonState.Pressed &&
                Utility.isColliding(this.transform, currentState, image) &&
                Utility.activePlayerNumber == owner.playerNumber &&
                activeSoldiers != 0)
            {
                if (Utility.activePlayerNumber == owner.playerNumber)
                {
                    foreach (var nextTile in tile.nextTiles)
                    {
                        if (nextTile.owner == 4 || nextTile.owner == 0)
                        {
                            nextTile.render.drawColor = Color.DodgerBlue;
                        }
                        if (Utility.isColliding(nextTile, currentState))
                        {
                            if (nextTile.owner == 4 || nextTile.owner == 0)
                            {
                                nextTile.render.drawColor = Color.Green;
                            }
                        }
                    }
                    foreach (var nextVillage in tile.nextVillages)
                    {
                        if (nextVillage.owner == 4 || nextVillage.owner == 0)
                        {
                            nextVillage.render.drawColor = Color.DodgerBlue;
                        }
                        if (Utility.isColliding(nextVillage, currentState))
                        {
                            if (nextVillage.owner == 4 || nextVillage.owner == 0)
                            {
                                nextVillage.render.drawColor = Color.OrangeRed;
                            }
                        }
                    }
                    this.transform.Position = new Vector2(currentState.Position.X - ((image.Width / 2) * UnitRenderer.scale), currentState.Position.Y - (image.Height / 2) * UnitRenderer.scale);
                }
            }
            else if (currentState.LeftButton == ButtonState.Released &&
                lastState.LeftButton == ButtonState.Pressed &&
                Utility.activePlayerNumber == owner.playerNumber &&
                Utility.isColliding(this.transform, currentState, image))
            {
                if (!checkIfToMoveOnVillage())
                {
                    foreach (var nextTile in tile.nextTiles)
                    {
                        nextTile.render.drawColor = Color.White;

                        if (Utility.isColliding(nextTile, currentState) &&
                            activeSoldiers != 0 && nextTile.owner == 4)
                        {
                            activeSoldiers = 0;
                            this.lastTile = tile;
                            this.tile.owner = 4;
                            this.tile = nextTile;
                            this.tile.owner = 0;
                            nextTile.archer = new Archer(nextTile, 0, 0, totalSoldiers, image, owner, this);
                        }
                        else if (Utility.isColliding(nextTile, currentState) &&
                            activeSoldiers != 0 && nextTile.owner == 0)
                        {
                            activeSoldiers = 0;
                            this.tile.owner = 4;
                            nextTile.archer.totalSoldiers += totalSoldiers;
                            nextTile.archer.removeLastArcher(this);
                        }
                        else
                        {
                            this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                        }
                    }
                }
            }
        }

        private bool checkIfToMoveOnVillage()
        {
            foreach (var nextTile in tile.nextTiles)
            {
                nextTile.render.drawColor = Color.White;
            }
            foreach (var nextVillage in tile.nextVillages)
            {
                if (nextVillage.render.drawColor == Color.OrangeRed)
                {
                    nextVillage.owner = 0;
                    this.activeSoldiers = 0;
                    nextVillage.render.drawColor = Color.White;
                    this.transform.Position = new Vector2((this.tile.transform.Position.X) + ((1448 * Renderer.scale) / 2) - ((image.Width * UnitRenderer.scale) / 2), (this.tile.transform.Position.Y) + ((1252 * Renderer.scale) / 2) - ((image.Height * UnitRenderer.scale) / 2));
                    return true;
                }
            }
            return false;
        }

        public void removeLastArcher(Archer archer)
        {
            if (archer != null)
            {
                archer.render.Destroy();
                archer = null;
            }
        }
    }
}
