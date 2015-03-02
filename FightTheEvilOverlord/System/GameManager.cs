using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FightTheEvilOverlord
{
    class GameManager : GameObject
    {
        Player pig;
        Player archer;
        Player swords;
        Player overlord;
        Player activeplayer;

        public Map map;

        FightManager fightManager;
        KI ki;
        KITrigger kit;

        MouseState mouseState;

        KeyboardState currentState;
        KeyboardState lastState;
        public GameManager(Player pig, Player archer, Player swords, Player overlord, Map map)
        {
            fightManager = this.AddComponent<FightManager>();
            mouseState = new MouseState();
            currentState = new KeyboardState();
            this.pig = pig;
            this.archer = archer;
            this.swords = swords;
            this.overlord = overlord;
            this.map = map;
            this.ki = this.AddComponent<KI>();
            this.kit = this.AddComponent<KITrigger>();
            this.kit.Start();
            this.fightManager = this.AddComponent<FightManager>();
            EventManager.OnUpdate += OnUpdate;

            setSoldiersToActive();
        }

        private void OnUpdate(GameTime gameTime)
        {
            setHudSoldiers();

            mouseState = Mouse.GetState();
            lastState = currentState;
            currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.N) && !lastState.IsKeyDown(Keys.N) && mouseState.LeftButton == ButtonState.Released && Utility.movementEngaged == false)
            {
                NextPlayer();
            }
        }

        public void NextPlayer()
        {
            if (Utility.ActivePlayerNumber == 0)
            {
                setTilesInactive();
                activeplayer = this.pig;
                Utility.ActivePlayerNumber++;
                setSoldiersToActive();
                setVillagesToActive();

                if (pig.KIControlled)
                {
                    ki.GetActiveTiles(map);
                }
            }
            else if (Utility.ActivePlayerNumber == 1)
            {
                setTilesInactive();
                activeplayer = this.swords;
                Utility.ActivePlayerNumber++;
                setSoldiersToActive();
                setVillagesToActive();

                if (swords.KIControlled)
                {
                    ki.GetActiveTiles(map);
                }
            }
            else if (Utility.ActivePlayerNumber == 2)
            {
                setTilesInactive();

                activeplayer = this.overlord;
                Utility.ActivePlayerNumber++;
                setSoldiersToActive();
                setVillagesToActive();
                kit.checkNextTiles(map);
                if (overlord.KIControlled)
                {
                    ki.GetActiveTiles(map);
                }
            }
            else if (Utility.ActivePlayerNumber == 3)
            {
                setTilesInactive();
                activeplayer = this.archer;
                Utility.ActivePlayerNumber = 0;
                setSoldiersToActive();
                setVillagesToActive();

                if (archer.KIControlled)
                {
                    ki.GetActiveTiles(map);
                }
            }
        }

        public void setSoldiersToActive()
        {
            foreach (var tile in map.tilesArray)
            {
                if (tile != null)
                {
                    if (Utility.ActivePlayerNumber == 0 && tile.owner == 0 && tile.archer != null)
                    {
                        tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                        tile.isActive = true;
                    }

                    else if (Utility.ActivePlayerNumber == 1 && tile.owner == 1 && tile.pigs != null)
                    {
                        tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                        tile.isActive = true;
                    }

                    else if (Utility.ActivePlayerNumber == 2 && tile.owner == 2 && tile.swords != null)
                    {
                        tile.swords.activeSoldiers = tile.swords.totalSoldiers;
                        tile.isActive = true;
                    }

                    else if (Utility.ActivePlayerNumber == 3 && tile.owner == 3)
                    {
                        if (tile.archer != null)
                        {
                            tile.archer.activeSoldiers = tile.archer.totalSoldiers;
                            tile.isActive = true;
                        }
                        if (tile.pigs != null)
                        {
                            tile.pigs.activeSoldiers = tile.pigs.totalSoldiers;
                            tile.isActive = true;
                        }
                        if (tile.swords != null)
                        {
                            tile.swords.activeSoldiers = tile.swords.totalSoldiers;
                            tile.isActive = true;
                        }
                        tile.isActive = true;
                    }
                }
            }
        }

        void setTilesInactive()
        {
            foreach (var tile in map.tilesArray)
            {
                if (tile != null)
                {
                    if (tile.isActive)
                    {
                        if (tile.archer != null)
                        {
                            tile.archer.activeSoldiers = 0;
                        }
                        else if (tile.pigs != null)
                        {
                            tile.pigs.activeSoldiers = 0;
                        }
                        else if (tile.swords != null)
                        {
                            tile.swords.activeSoldiers = 0;
                        }

                        tile.isActive = false;
                    }
                }
            }
        }

        public void setVillagesToActive()
        {
            foreach (var village in map.villageArray)
            {
                if (village != null)
                {
                    if (village.owner != 4)
                    {
                        village.isActive = true;
                    }
                }
            }
        }

        public void setHudSoldiers()
        {
            Utility.activeSoldiersGoodArch = 0;
            Utility.totalSoldiersGoodArch = 0;
            Utility.activeSoldiersBadArch = 0;
            Utility.totalSoldiersBadArch = 0;
            Utility.activeSoldiersGoodPig = 0;
            Utility.totalSoldiersGoodPig = 0;
            Utility.activeSoldiersBadPig = 0;
            Utility.totalSoldiersBadPig = 0;
            Utility.activeSoldiersGoodSword = 0;
            Utility.totalSoldiersGoodSword = 0;
            Utility.activeSoldiersBadSword = 0;
            Utility.totalSoldiersBadSword = 0;

            foreach (var tile in map.tilesArray)
            {
                if (tile != null)
                {
                    if (tile.archer != null && tile.owner == 3)
                    {
                        Utility.activeSoldiersBadArch += tile.archer.activeSoldiers;
                        Utility.totalSoldiersBadArch += tile.archer.totalSoldiers;
                    }
                    else if (tile.swords != null && tile.owner == 3)
                    {
                        Utility.activeSoldiersBadSword += tile.swords.activeSoldiers;
                        Utility.totalSoldiersBadSword += tile.swords.totalSoldiers;
                    }
                    else if (tile.pigs != null && tile.owner == 3)
                    {
                        Utility.activeSoldiersBadPig += tile.pigs.activeSoldiers;
                        Utility.totalSoldiersBadPig += tile.pigs.totalSoldiers;
                    }
                    else if (tile.archer != null && tile.owner != 3)
                    {
                        Utility.activeSoldiersGoodArch += tile.archer.activeSoldiers;
                        Utility.totalSoldiersGoodArch += tile.archer.totalSoldiers;
                    }
                    else if (tile.swords != null && tile.owner != 3)
                    {
                        Utility.activeSoldiersGoodSword += tile.swords.activeSoldiers;
                        Utility.totalSoldiersGoodSword += tile.swords.totalSoldiers;
                    }
                    else if (tile.pigs != null && tile.owner != 3)
                    {
                        Utility.activeSoldiersGoodPig += tile.pigs.activeSoldiers;
                        Utility.totalSoldiersGoodPig += tile.pigs.totalSoldiers;
                    }
                }
            }
        }
    }
}
