namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string agedBrie = "Aged Brie";
        private const string sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string backstage = "Backstage passes to a TAFKAL80ETC concert";
        private readonly IList<Item> items;

        public GildedRose(IList<Item> Items)
        {
            this.items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                switch (item.Name)
                {
                    case agedBrie:
                        item.IncreaseQuality();
                        break;
                    case backstage:
                        item.IncreaseQuality();
                        if (item.SellIn < 11)
                        {
                            item.IncreaseQuality();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncreaseQuality();
                        }
                        break;
                    case sulfuras:
                        break;
                    default:
                        item.DecreaseQuality();
                        break;
                }

                switch (item.Name)
                {
                    case sulfuras:
                        break;
                    case agedBrie:
                    case backstage:
                    default:
                        item.SellIn--;
                        break;
                }

                if (item.IsExpired())
                {
                    switch (item.Name)
                    {
                        case agedBrie:
                            item.IncreaseQuality();
                            break;
                        case backstage:
                            item.ResetQuality();
                            break;
                        case sulfuras:
                            break;
                        default:
                            item.DecreaseQuality();
                            break;
                    }
                }
            }
        }
    }
}
