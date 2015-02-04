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

        public static void addPigToTile(Tile tile, Player player, int unitNumber)
        {
            if (tile.pigs != null && player.playerNumber == tile.pigs.player.playerNumber)
            {
                tile.pigs.number += unitNumber;
            }
        }

        public static void addSowrdsMen(Tile tile, Player player, int unitNumber)
        {
            if (tile.swords != null && player.playerNumber == tile.pigs.player.playerNumber)
            {
                tile.swords.number += unitNumber;
            }
        }

        public static void addArcher(Tile tile, Player player, int unitNumber)
        {
            if(tile.archer != null && player.playerNumber == tile.archer.player.playerNumber)
            {
                tile.archer.number += unitNumber;
            }
        }
    }
}
