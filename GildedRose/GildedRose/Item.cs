namespace GildedRoseKata
{
    public class Item
    {
        private const int QualityThresholdMax = 50;
        private const int QualityThresholdMin = 0;
        

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string? Name { get; }
        public int SellIn { get; private set; }
        public int Quality { get; private set; }

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

        protected virtual void ManageQualityWhenExpired()
        {
            DecrementQuality();
        }

        protected void ManageSellIn()
        {
            SellIn--;
        }

        protected virtual void ManageQuality()
        {
            DecrementQuality();
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
