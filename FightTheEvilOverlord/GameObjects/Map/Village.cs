using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class Village : GameObject
    {
        public Renderer render;
        public Transform transform;
        public int owner = 4;
        public int conquerUnit;
        public Texture2D image;
        Texture2D pig;
        Texture2D archer;
        Texture2D sword;

        public bool isActive = false;

        public int mapX;
        public int mapY;

        Random rnd;

        public Tile lastTile; 

        public List<Tile> nextTiles = new List<Tile>();
        public Village(Texture2D image, int x, int y, Texture2D pig, Texture2D archer, Texture2D sword)
        {
            rnd = new Random();
            this.mapX = x;
            this.mapY = y;
            this.image = image;
            this.pig = pig;
            this.archer = archer;
            this.sword = sword;
            this.transform = this.AddComponent<Transform>();
            this.render = this.AddComponent<Renderer>();
            //TODO: replace int 10 with half of screen rest size
            this.transform.Position = new Vector2(x * 1065 * Renderer.scale, getPosition(x, y) * Renderer.scale);
            this.render.SetImage(image);
            this.render.Start();
            EventManager.OnUpdate += Update;
        }

        public void Update(GameTime gameTime)
        {
            if (isActive && owner != 4)
            {
                int random = rnd.Next(0, 5);
                if (owner == 0 && Utility.ActivePlayerNumber == 0)
                {
                    {
                        if (nextTiles[random].archer != null)
                        {
                            nextTiles[random].archer.activeSoldiers++;
                            nextTiles[random].archer.totalSoldiers++;
                            isActive = false;
                        }
                        else
                        {
                            nextTiles[random].archer = new Archer(nextTiles[random], 0, 1, 1, archer, Utility.ArchPlayer, null);
                            isActive = false;
                        }
                    }
                }
                else if (owner == 1 && Utility.ActivePlayerNumber == 1)
                { 
                    if (nextTiles[random].pigs != null)
                    {
                        nextTiles[random].pigs.activeSoldiers++;
                        nextTiles[random].pigs.totalSoldiers++;
                        isActive = false;
                    }
                    else
                    {
                        nextTiles[random].pigs = new FlyingPigs(nextTiles[random], 1, 1, 1, pig, Utility.PigPlayer, null);
                        isActive = false;
                    }
                }
                else if (owner == 2 && Utility.ActivePlayerNumber == 2)
                {
                    if (nextTiles[random].swords != null)
                    {
                        nextTiles[random].swords.activeSoldiers++;
                        nextTiles[random].swords.totalSoldiers++;
                        isActive = false;
                    }
                    else
                    {
                        nextTiles[random].swords = new SwordsMen(nextTiles[random], 2, 1, 1, sword, Utility.SwordPlayer, null);
                        isActive = false;
                    }
                }
                else if (owner == 3 && Utility.ActivePlayerNumber == 3)
                {
                    if (conquerUnit == 0)
                    {
                        if (nextTiles[random].archer != null)
                        {
                            nextTiles[random].archer.activeSoldiers++;
                            nextTiles[random].archer.totalSoldiers++;
                            isActive = false;
                        }
                        else if (nextTiles[random].archer == null && nextTiles[random].pigs == null && nextTiles[random].swords == null)
                        {
                            nextTiles[random].archer = new Archer(nextTiles[random], 3, 1, 1, archer, Utility.EvilOverLord, null);
                            isActive = false;
                        }
                    }
                    else if (conquerUnit == 1)
                    {
                        if (nextTiles[random].pigs != null)
                        {
                            nextTiles[random].pigs.activeSoldiers++;
                            nextTiles[random].pigs.totalSoldiers++;
                            isActive = false;
                        }
                        else if (nextTiles[random].archer == null && nextTiles[random].pigs == null && nextTiles[random].swords == null)
                        {
                            nextTiles[random].pigs = new FlyingPigs(nextTiles[random], 3, 1, 1, pig, Utility.EvilOverLord, null);
                            isActive = false;
                        }
                    }
                    else if (conquerUnit == 2)
                    {
                        if (nextTiles[random].swords != null)
                        {
                            nextTiles[random].swords.activeSoldiers++;
                            nextTiles[random].swords.totalSoldiers++;
                            isActive = false;
                        }
                        else if (nextTiles[random].archer == null && nextTiles[random].pigs == null && nextTiles[random].swords == null)
                        {
                            nextTiles[random].swords = new SwordsMen(nextTiles[random], 3, 1, 1, sword, Utility.EvilOverLord, null);
                            isActive = false;
                        }
                    }
                }
            }
        }

        public int getPosition(int x, int y)
        {
            if (x % 2 == 0)
            {
                return y * 1252;
            }

            else
            {
                return (y * 1252) + 628;
            }
        }
    }
}
