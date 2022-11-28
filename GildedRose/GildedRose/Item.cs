namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }

        public virtual void UpdateQuality()
        {
            DecreaseQuality();

            DecreaseSellIn();

            if (IsExpired())
            {
                DecreaseQuality();
            }
        }

        internal void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }

        internal void IncrementQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }

        internal bool IsExpired() => this.SellIn < 0;

        internal void DecreaseSellIn() => this.SellIn--;

        internal void DropQuality() => this.Quality=0;
    }
}
