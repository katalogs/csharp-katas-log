namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string agedBrie = "Aged Brie";
        private const string sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string backstage = "Backstage passes to a TAFKAL80ETC concert";

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name != agedBrie && item.Name != backstage)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (item.Name == backstage)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
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

                if (item.SellIn < 0)
                {
                    if (item.Name != agedBrie)
                    {
                        if (item.Name != backstage)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
