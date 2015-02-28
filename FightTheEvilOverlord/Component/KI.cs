using System;
using System.Collections.Generic;

namespace FightTheEvilOverlord
{
    class KI : Component
    {
        Map map;
        List<Tile> activeTiles;

        int matchUpRelevance;
        int outnumberingRelevance;
        int groundRelevance;
        int nearbyVillageRelevance;
        int distanceRelevance;

        
        

        public void start()
        {
            activeTiles = new List<Tile>();
        }

        public void GetActiveTiles(Map map)
        {
            this.map = map;

            foreach (var tile in map.tilesArray)
            {
                if (tile.isActive)
                {
                    activeTiles.Add(tile);
                }
            }
        }

        void getToRateTiles()
        {
            foreach (var tiles in activeTiles)
            {
                foreach (var tile in tiles.nextTiles)
                {
                    getFightRating(tiles, tile, 1);
                    foreach (var remoteTile in tile.nextTiles)
                    {
                        if (!activeTiles.Contains(remoteTile))
                        {
                            getFightRating(tiles, remoteTile, 2);
                        }
                    }
                }
            }
        }

        void getFightRating(Tile baseTile,Tile toRateTile, int distance)
        {
            if (baseTile.archer != null)
            {
                if (toRateTile.archer != null)
                {
                    if (toRateTile.archer.totalSoldiers > baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.archer.totalSoldiers < baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.pigs != null)
                {
                    toRateTile.KIRelevance += matchUpRelevance;
                    if (toRateTile.pigs.totalSoldiers > baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance; 
                    }
                    else if (toRateTile.pigs.totalSoldiers < baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.swords != null)
                {
                    toRateTile.KIRelevance -= matchUpRelevance;
                    if (toRateTile.swords.totalSoldiers > baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.swords.totalSoldiers < baseTile.archer.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
            }
            else if (baseTile.pigs != null)
            {
                if (toRateTile.archer != null)
                {
                    toRateTile.KIRelevance -= matchUpRelevance;
                    if (toRateTile.archer.totalSoldiers > baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.archer.activeSoldiers < baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.pigs != null)
                {
                    if (toRateTile.pigs.totalSoldiers > baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.pigs.totalSoldiers < baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.swords != null)
                {
                    toRateTile.KIRelevance += matchUpRelevance;
                    if (toRateTile.archer.totalSoldiers > baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.archer.totalSoldiers < baseTile.pigs.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
            }
            else if (baseTile.swords != null)
            {
                if (toRateTile.archer != null)
                {
                    toRateTile.KIRelevance += matchUpRelevance;
                    if (toRateTile.archer.totalSoldiers > baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.archer.totalSoldiers < baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.pigs != null)
                {
                    toRateTile.KIRelevance -= matchUpRelevance;
                    if (toRateTile.pigs.totalSoldiers > baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.pigs.totalSoldiers < baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
                else if (toRateTile.swords != null)
                {
                    if (toRateTile.swords.totalSoldiers > baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance -= outnumberingRelevance;
                    }
                    else if (toRateTile.swords.totalSoldiers < baseTile.swords.activeSoldiers)
                    {
                        toRateTile.KIRelevance += outnumberingRelevance;
                    }
                }
            }
        }

        void checkOnNearVillages(Tile baseTile)
        {
            if (baseTile.nextVillages.Count == 1 && baseTile.nextVillages[0].owner != Utility.ActivePlayerNumber)
            {
                baseTile.KIRelevance += nearbyVillageRelevance;
            }
        }

        bool checkIfVillageConquerable(Tile baseTile)
        {
            if (baseTile.nextVillages.Count == 1)
            {
                if (((baseTile.nextVillages[0].owner == 0 || baseTile.nextVillages[0].owner == 1 || baseTile.nextVillages[0].owner == 2) && Utility.ActivePlayerNumber == 3) || ((Utility.ActivePlayerNumber == 0 || Utility.ActivePlayerNumber == 1 || Utility.ActivePlayerNumber == 2) && baseTile.nextVillages[0].owner == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        void rateGround(Tile toRateTile, Tile baseTile)
        {
            if (toRateTile.Type == "wald")
            {
                if (baseTile.archer != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    { 

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
                else if (baseTile.pigs != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }

                else if (baseTile.swords != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
            }

            else if (toRateTile.Type == "berg")
            {
                if (baseTile.archer != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
                else if (baseTile.pigs != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }

                else if (baseTile.swords != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
            }

            else if (toRateTile.Type == "feld")
            {
                if (baseTile.archer != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
                else if (baseTile.pigs != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }

                else if (baseTile.swords != null)
                {
                    if (toRateTile.archer != null)
                    {

                    }
                    else if (toRateTile.pigs != null)
                    {

                    }
                    else if (toRateTile.swords != null)
                    {

                    }
                    else if (toRateTile.archer == null && toRateTile.pigs == null && toRateTile.swords == null)
                    {

                    }
                }
            }
        }
    }
}
