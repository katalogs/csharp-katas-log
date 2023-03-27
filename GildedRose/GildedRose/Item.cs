namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private const int qualityMin = 0;
        private const int qualityMax = 50;

        private const string agedBrie = "Aged Brie";
        private const string backstage = "Backstage passes to a TAFKAL80ETC concert";

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

        public virtual void ManageQuality()
        {
            UpdateBeforeExpired();
            UpdateSellIn();

            if (IsExpired())
            {
                UpdateExpired();
            }
        }

        private void UpdateExpired()
        {
            switch (Name)
            {
                case agedBrie:
                    IncreaseQuality();
                    break;
                case backstage:
                    ResetQuality();
                    break;
                default:
                    DecreaseQuality();
                    break;
            }
        }

        private void UpdateSellIn()
        {
            SellIn--;
        }

        private void UpdateBeforeExpired()
        {
            switch (Name)
            {
                case agedBrie:
                    IncreaseQuality();
                    break;
                case backstage:
                    IncreaseQuality();
                    if (SellIn < 11)
                    {
                        IncreaseQuality();
                    }

                    if (SellIn < 6)
                    {
                        IncreaseQuality();
                    }
                    break;
                default:
                    DecreaseQuality();
                    break;
            }
        }
    }
}
