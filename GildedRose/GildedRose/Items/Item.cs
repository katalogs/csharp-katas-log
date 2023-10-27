namespace GildedRoseKata.Items
{
    public class Item
    {
        public Item(string name,int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private const int MaxQuality = 50;
        protected const int MinQuality = 0;

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

        public virtual void DecreaseQuality()
        {
            if (Quality > MinQuality)
            {
                Quality--;
            }
        }

        public virtual void UpdateQuality()
        {
            DecreaseQuality();

            SellIn--;

            if (IsExpired())
            {
                DecreaseQuality();
            }
        }
    }
}
