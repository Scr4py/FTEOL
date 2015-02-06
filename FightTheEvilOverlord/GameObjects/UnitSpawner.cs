using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class UnitSpawner : GameObject
    {
        Texture2D pigTex;
        Texture2D swordTex;
        Texture2D archTex;

        public UnitSpawner(Texture2D pigTex, Texture2D swordTex, Texture2D archTex)
        {
            this.archTex = archTex;
            this.swordTex = swordTex;
            this.pigTex = pigTex;
        }

        public void addPigToTile(Tile tile, Player player, int unitNumber)
        {
            if (tile.pigs != null)
            {
                tile.pigs.number += unitNumber;
            }
            else
            {
                tile.pigs = new FlyingPigs(tile, player.playerNumber, 0, unitNumber, pigTex, player, null);
            }
        }

        public void addSowrdsMen(Tile tile, Player player, int unitNumber)
        {
            if (tile.swords != null)
            {
                tile.swords.number += unitNumber;
            }
            else
            {
                tile.swords = new SwordsMen(tile, player.playerNumber, 0, unitNumber, swordTex, player, null);
            }
        }

        public void addArcher(Tile tile, Player player, int unitNumber)
        {
            if(tile.archer != null)
            {
                tile.archer.number += unitNumber;
            }
            else
            {
                tile.archer = new Archer(tile, player.playerNumber, 0, unitNumber, archTex, player, null);
            }
        }
    }
}
