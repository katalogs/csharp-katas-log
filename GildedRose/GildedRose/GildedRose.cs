namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string agedBrie = "Aged Brie";
        private const string sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const int qualityMin = 0;
        private const int qualityMax = 50;
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
                    if (item.Quality < qualityMax)
                    {
                        item.Quality++;

                        if (item.Name == backstage)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < qualityMax)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < qualityMax)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != sulfuras)
                {
                    item.SellIn--;
                }

                if (item.isExpired())
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
                        if (item.Quality < qualityMax)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
