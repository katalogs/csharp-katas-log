using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GildedRoseKata.Items;

namespace GildedRose.Items;

public class BackstagePass : Item
{

    public BackstagePass (String bandName, int sellIn, int quality) :base (String.Format("Backstage passes to a {0} concert", bandName), sellIn, quality)
    {
        
    }

    public override void UpdateQuality()
    {
        IncreaseQuality();
        if (SellIn < 11)
        {
            IncreaseQuality();
        }

        if (SellIn < 6)
        {
            IncreaseQuality();
        }

        SellIn--;

        if (IsExpired())
        {
            Quality = 0;
        }
    }
}
