namespace GildedRoseKata
{
    public class Item
    {
        private const int QualityThresholdMax = 50;
        private const int QualityThresholdMin = 0;

        public string? Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
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
    }
}
