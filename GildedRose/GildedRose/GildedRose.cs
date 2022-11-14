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
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }

                    item.SellIn--;

                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
                else
                {
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;

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

                        item.SellIn--;

                        if (item.SellIn < 0)
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if(item.Name == "Sulfuras, Hand of Ragnaros")
                        {
                            
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                item.Quality--;
                            }

                            item.SellIn--;

                            if (item.SellIn < 0)
                            {
                                if (item.Quality > 0)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        
                    }
                }
            }
        }
    }
}
