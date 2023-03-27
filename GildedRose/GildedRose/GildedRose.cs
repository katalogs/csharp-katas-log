namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> items;

        public GildedRose(IList<Item> Items)
        {
            items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                item.ManageQuality();
            }
        }
    }
}
