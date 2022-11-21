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
                item.UpdateQuality();
            }
        }
    }
}
