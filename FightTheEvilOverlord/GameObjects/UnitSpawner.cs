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

        public void addPig(Tile spawnTile, Player player, int unitNumber)
        {
            if (spawnTile.pigs != null)
            {
                spawnTile.pigs.number += unitNumber;
            }
            else
            {
                spawnTile.pigs = new FlyingPigs(spawnTile, player.playerNumber, 0, unitNumber, pigTex, player, null);
            }
        }

        public void addSowrdsMen(Tile spawnTile, Player player, int unitNumber)
        {
            if (spawnTile.swords != null)
            {
                spawnTile.swords.number += unitNumber;
            }
            else
            {
                spawnTile.swords = new SwordsMen(spawnTile, player.playerNumber, 0, unitNumber, swordTex, player, null);
            }
        }

        public void addArcher(Tile spawnTile, Player player, int unitNumber)
        {
            if(spawnTile.archer != null)
            {
                spawnTile.archer.number += unitNumber;
            }
            else
            {
                spawnTile.archer = new Archer(spawnTile, player.playerNumber, 0, unitNumber, archTex, player, null);
            }
        }
    }
}
