using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata;

internal class AgedBrie : Item
{
    public AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
    {
    }

    public override void UpdateQuality()
    {
        IncrementQuality();

        DecreaseSellIn();

        if (IsExpired())
        {
            IncrementQuality();
        }
    }
}
