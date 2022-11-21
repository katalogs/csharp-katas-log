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
                        item.IncrementQuality();

                        item.DecreaseSellIn();

                        if (item.IsExpired())
                        {
                            item.IncrementQuality();
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":

                        item.IncrementQuality();

                        if (item.SellIn < 11)
                        {
                            item.IncrementQuality();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncrementQuality();
                        }

                        item.DecreaseSellIn();

                        if (item.IsExpired())
                        {
                            item.DropQuality();
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        item.DecreaseQuality();

                        item.DecreaseSellIn();

                        if (item.IsExpired())
                        {
                            item.DecreaseQuality();
                        }
                        break;
                }
            }
        }
    }
}
