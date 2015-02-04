using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FightTheEvilOverlord
{
    class UnitSpawner
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

        public static void addPigToTile(Tile tile, string adderPerson)
        {
            if (tile.pigs != null && adderPerson == tile.pigs.owner)
            {
                
            }
        }
    }
}
