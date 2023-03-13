﻿namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string agedBrie = "Aged Brie";
        private const string sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const int qualityMin = 0;
        private readonly IList<Item> items;

        public GildedRose(IList<Item> Items)
        {
            this.items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                if (item.Name != agedBrie && item.Name != backstage)
                {
                    if (item.Quality > qualityMin)
                    {
                        if (item.Name != sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    item.IncreaseQuality();
                    if (item.Name == backstage)
                    {
                        if (item.SellIn < 11)
                        {
                            item.IncreaseQuality();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncreaseQuality();
                        }
                    }
                }

                if (item.Name != sulfuras)
                {
                    item.SellIn--;
                }

                if (item.IsExpired())
                {
                    if (item.Name != agedBrie)
                    {
                        if (item.Name != backstage)
                        {
                            if (item.Quality > qualityMin)
                            {
                                if (item.Name != sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = qualityMin;
                        }
                    }
                    else
                    {
                        item.IncreaseQuality();
                    }
                }
            }
        }
    }
}
