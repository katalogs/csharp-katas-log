namespace GildedRoseKata.Items
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public bool IsExpired()
        {
            return SellIn < 0;
        }

        public void IncreaseQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality ++;
            }
        }

        public void DecreaseQuality()
        {
            if (Quality > MinQuality)
            {
                Quality--;
            }
        }

        public void UpdateQuality()
        {
            switch (Name)
            {
                case "Aged Brie":
                    IncreaseQuality();

                    SellIn--;

                    if (IsExpired())
                    {
                        IncreaseQuality();
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    IncreaseQuality();
                    if (SellIn < 11)
                    {
                        IncreaseQuality();
                    }

                    if (SellIn < 6)
                    {
                        IncreaseQuality();
                    }

                    SellIn--;

                    if (IsExpired())
                    {
                        Quality = 0;
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    DecreaseQuality();

                    SellIn--;

                    if (IsExpired())
                    {
                        DecreaseQuality();
                    }
                    break;
            }
        }
    }
}
