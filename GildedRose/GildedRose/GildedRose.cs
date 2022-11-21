using System.Collections.Generic;

namespace GildedRoseKata
{

    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        IncrementQuality(item);

                        item.SellIn--;

                        if (IsExpired(item))
                        {
                            IncrementQuality(item);
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        
                        IncrementQuality(item);

                        if (item.SellIn < 11)
                        {
                            IncrementQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncrementQuality(item);
                        }

                        item.SellIn--;

                        if (IsExpired(item))
                        {
                            item.Quality = 0;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        DecreaseQuality(item);

                        item.SellIn--;

                        if (IsExpired(item))
                        {
                            DecreaseQuality(item);
                        }
                        break;
                }
            }
        }

        private static void IncrementQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        private static bool IsExpired(Item item)=> item.SellIn < 0;
    }
}
