﻿namespace GildedRoseKata;

internal class BackstagePasses : Item
{
    public BackstagePasses(int sellIn, int quality, string band) : base("Backstage passes to a " + band + " concert", sellIn, quality)
    {
    }

    public override void UpdateQuality()
    {
        IncrementQuality();

        if (SellIn < 11)
        {
            IncrementQuality();
        }

        if (SellIn < 6)
        {
            IncrementQuality();
        }

        DecreaseSellIn();

        if (IsExpired())
        {
            DropQuality();
        }
    }

}
