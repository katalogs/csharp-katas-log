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

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        Items[i].IncreaseQuality();

                        Items[i].SellIn--;

                        if (Items[i].IsExpired())
                        {
                            Items[i].IncreaseQuality();
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i].IncreaseQuality();
                        if (Items[i].SellIn < 11)
                        {
                            Items[i].IncreaseQuality();
                        }

                        if (Items[i].SellIn < 6)
                        {
                            Items[i].IncreaseQuality();
                        }

                        Items[i].SellIn--;

                        if (Items[i].IsExpired())
                        {
                            Items[i].Quality = 0;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        Items[i].DecreaseQuality();

                        Items[i].SellIn--;

                        if (Items[i].IsExpired())
                        {
                            Items[i].DecreaseQuality();
                        }
                        break;
                }
            }
        }
    }
}
