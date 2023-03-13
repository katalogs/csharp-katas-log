namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private const int qualityMin = 0;
        private const int qualityMax = 50;

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
            if (Quality < qualityMax)
            {
                Quality++;
            }
        }

        public void DecreaseQuality()
        {
            if (Quality > qualityMin)
            {
                Quality--;
            }
        }

        public void ResetQuality()
        {
            Quality = qualityMin;
        }
    }
}
