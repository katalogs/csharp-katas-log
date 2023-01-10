namespace GildedRoseKata
{
    public class GildedRose
    {
        internal const string AgedBrie = "Aged Brie";
        internal const string TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";
        internal const string SulfurasHandRagnaros = "Sulfuras, Hand of Ragnaros";
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != AgedBrie && item.Name != TAFKAL80ETC)
                {
                    if (item.Name != SulfurasHandRagnaros)
                    {
                        item.DecrementQuality();
                    }
                }
                else
                {
                    item.IncrementQuality();

                    if (item.Name == TAFKAL80ETC)
                    {
                        if (item.SellIn < 11)
                        {
                            item.IncrementQuality();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncrementQuality();
                        }
                    }
                }

                if (item.Name != SulfurasHandRagnaros)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != TAFKAL80ETC)
                        {
                            if (item.Name != SulfurasHandRagnaros)
                            {
                                item.DecrementQuality();
                            }
                        }
                        else
                        {
                            item.Quality = Item.QualityThreasholdMin;
                        }
                    }
                    else
                    {
                        item.IncrementQuality();
                    }
                }
            }
        }

        
    }
}
