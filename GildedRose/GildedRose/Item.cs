namespace GildedRoseKata
{
    public class Item
    {
        private const int QualityThresholdMax = 50;
        private const int QualityThresholdMin = 0;

        public const string AgedBrie = "Aged Brie";
        public const string TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

        public Item(string name)
        {
            Name = name;
        }

        public string? Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }

        public void DecrementQuality()
        {
            if (Quality > QualityThresholdMin)
            {
                Quality--;
            }
        }

        public void IncrementQuality()
        {
            if (Quality < QualityThresholdMax)
            {
                Quality++;
            }
        }

        public void SetMinimalQuality()
        {
            Quality = QualityThresholdMin;
        }

        public void ManageQualityWhenExpired()
        {
            switch (Name)
            {
                case AgedBrie:
                    IncrementQuality();
                    break;
                case TAFKAL80ETC:
                    SetMinimalQuality();
                    break;
                default:
                    DecrementQuality();
                    break;
            }
        }

        public void ManageSellIn()
        {
            SellIn--;
        }

        public void ManageQuality()
        {
            switch (Name)
            {
                case AgedBrie:
                    IncrementQuality();
                    break;
                case TAFKAL80ETC:
                    IncrementQuality();

                    if (SellIn < 11)
                    {
                        IncrementQuality();
                    }

                    if (SellIn < 6)
                    {
                        IncrementQuality();
                    }
                    break;
                default:
                    DecrementQuality();
                    break;
            }
        }

        public virtual void Update()
        {
            ManageQuality();

            ManageSellIn();

            if (SellIn < 0)
            {
                ManageQualityWhenExpired();
            }
        }
    }
}
