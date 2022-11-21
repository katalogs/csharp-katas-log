namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
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

        internal bool IsExpired() => SellIn < 0;

        internal void DecreaseSellIn() => SellIn--;

        internal void DropQuality() => Quality=0;
    }
}
