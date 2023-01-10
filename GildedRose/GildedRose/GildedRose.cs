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
                switch (item.Name)
                {
                    case AgedBrie:
                        item.IncrementQuality();
                        break;
                    case TAFKAL80ETC:
                        item.IncrementQuality();

                        if (item.SellIn < 11)
                        {
                            item.IncrementQuality();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncrementQuality();
                        }
                        break;
                    case SulfurasHandRagnaros:
                        break;
                    default:
                        item.DecrementQuality();
                        break;
                }

                switch (item.Name)
                {
                    case SulfurasHandRagnaros:
                        break;
                    default:
                        item.SellIn--;
                        break;
                }

                if (item.SellIn < 0)
                {
                    switch (item.Name)
                    {
                        case AgedBrie:
                            item.IncrementQuality();
                            break;
                        case TAFKAL80ETC:
                            item.SetMinimalQuality();
                            break;
                        case SulfurasHandRagnaros:
                            break;
                        default:
                            item.DecrementQuality();
                            break;
                    }
                }
            }
        }
    }
}
