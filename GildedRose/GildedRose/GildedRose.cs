using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseQuality(Items[i]);
                }
                else
                {
                    IncreaseQuality(Items[i]);
                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            IncreaseQuality(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            IncreaseQuality(Items[i]);
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (IsExpired(Items[i]))
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            DecreaseQuality(Items[i]);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        IncreaseQuality(Items[i]);
                    }
                }
            }
        }

        private bool IsExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > MinQuality && item.Name != "Sulfuras, Hand of Ragnaros")
            {
                    item.Quality = item.Quality - 1;
            }
        }
    }
}
