using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheEvilOverlord
{
    class FightManager : Component
    {
        Tile attackerTile;
        Tile defenderTile;

        int attackerNumber;
        int defenderNumber;
        int attackerType;
        int defenderType;
        int attackerPower;
        int defenderPower;
        int attackerBonus = 1;
        int defenderBonus = 1;
        float remainingAttackers;
        float remainingDefenders;

        public void Start()
        {
        }

        public void Attack(Tile attackerTile, Tile defenderTile)
        {
            this.attackerTile = attackerTile;
            this.defenderTile = defenderTile;
            getFighter();
            getFighterPower();
            fight();
            fightResults();
        }

        void getFighter()
        {
            if (attackerTile.archer != null)
            {
                attackerNumber = attackerTile.archer.activeSoldiers;
                attackerType = 0;
            }
            else if (attackerTile.pigs != null)
            {
                attackerNumber = attackerTile.pigs.activeSoldiers;
                attackerType = 1;
            }
            else if(attackerTile.swords != null)
            {
                attackerNumber = attackerTile.swords.activeSoldiers;
                attackerType = 2;
            }

            if (defenderTile.archer != null)
            {
                defenderNumber = defenderTile.archer.totalSoldiers;
                defenderType = 0;
            }
            else if (defenderTile.pigs != null)
            {
                defenderNumber = defenderTile.pigs.totalSoldiers;
                defenderType = 1;
            }
            else if (defenderTile.swords != null)
            {
                defenderNumber = defenderTile.swords.totalSoldiers;
                defenderType = 2;
            }
        }

        void getFighterPower()
        {
            if (attackerType == 0 && defenderType == 1)
            {
                attackerBonus++;
            }
            else if (attackerType == 0 && defenderType == 2)
            {
                defenderPower++;
            }
            else if (attackerType == 1 && defenderType == 0)
            {
                defenderBonus++;
            }
            else if (attackerType == 1 && defenderType == 2)
            {
                attackerBonus++;
            }
            else if (attackerType == 2 && defenderType == 0)
            {
                attackerBonus++;
            }
            else if (attackerType == 2 && defenderType == 1)
            {
                defenderBonus++;
            }

            if (defenderTile.Type == "wald")
            {
                if (attackerType == 0)
                {
                    attackerBonus++;
                }
                if (defenderType == 0)
                {
                    defenderBonus++;
                }
            }
            else if (defenderTile.Type == "berg")
            {
                if (attackerType == 1)
                {
                    attackerBonus++;
                }
                if (defenderType == 1)
                {
                    defenderBonus++;
                }
            }
            else if (defenderTile.Type == "feld")
            {
                if (attackerType == 2)
                {
                    attackerBonus++;
                }
                if (defenderType == 2)
                {
                    defenderBonus++;
                }
            }
        }

        void fight()
        {
            attackerPower = attackerNumber * attackerBonus;
            defenderPower = defenderNumber * defenderBonus;

            if (attackerPower > defenderPower)
            {
                remainingAttackers = attackerPower - defenderPower;
                remainingAttackers = remainingAttackers / attackerBonus;

                if (remainingAttackers % 1 != 0)
                {
                    remainingAttackers++;
                }
            }

            if (defenderPower > attackerPower)
            {
                remainingDefenders = defenderPower - attackerPower;
                remainingDefenders = remainingDefenders / defenderBonus;

                if (remainingDefenders % 1 != 0)
                {
                    remainingDefenders++;
                }
            }
        }

        void fightResults()
        {
            if (remainingAttackers != 0)
            {
                if (attackerType == 0)
                {
                    attackerTile.archer.totalSoldiers = (int)remainingAttackers;
                }
                else if (attackerType == 1)
                {
                    attackerTile.pigs.totalSoldiers = (int)remainingAttackers;
                }
                else if(attackerType == 2)
                {
                    attackerTile.swords.totalSoldiers = (int)remainingAttackers;
                }
                if (defenderType == 0)
                {
                    defenderTile.archer.removeLastArcher(defenderTile.archer);
                }
                else if (defenderType == 1)
                {
                    defenderTile.pigs.removeLastPig(defenderTile.pigs);
                }
                else if (defenderType == 2)
                {
                    defenderTile.swords.removeLastSwordsMen(defenderTile.swords);
                }
            }

            else if (remainingDefenders != 0)
            {
                if (defenderType == 0)
                {
                    defenderTile.archer.totalSoldiers = (int)remainingDefenders;
                }
                else if (defenderType == 1)
                {
                    defenderTile.pigs.totalSoldiers = (int)remainingDefenders;
                }
                else if (defenderType == 2)
                {
                    defenderTile.swords.totalSoldiers = (int)remainingDefenders;
                }
                if (attackerType == 0)
                {
                    attackerTile.archer.removeLastArcher(attackerTile.archer);
                }
                else if (attackerType == 1)
                {
                    attackerTile.pigs.removeLastPig(attackerTile.pigs);
                }
                else if (attackerType == 2)
                {
                    attackerTile.swords.removeLastSwordsMen(attackerTile.swords);
                }
            }
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
