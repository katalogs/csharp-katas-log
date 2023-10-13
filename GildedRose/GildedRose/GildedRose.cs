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
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        IncreaseQuality(Items[i]);

                        Items[i].SellIn--;

                        if (IsExpired(Items[i]))
                        {
                            IncreaseQuality(Items[i]);
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        IncreaseQuality(Items[i]);
                        if (Items[i].SellIn < 11)
                        {
                            IncreaseQuality(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            IncreaseQuality(Items[i]);
                        }

                        Items[i].SellIn--;

                        if (IsExpired(Items[i]))
                        {
                            Items[i].Quality = 0;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        DecreaseQuality(Items[i]);

                        Items[i].SellIn--;

                        if (IsExpired(Items[i]))
                        {
                            DecreaseQuality(Items[i]);
                        }
                        break;
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
            if (item.Quality > MinQuality)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}
