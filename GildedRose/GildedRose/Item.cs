namespace GildedRoseKata
{
    public class Item
    {
        public const int QualityThreasholdMax = 50;
        public const int QualityThreasholdMin = 0;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public void DecrementQuality()
        {
            if (Quality > QualityThreasholdMin)
            {
                Quality--;
            }
        }
    }
}
