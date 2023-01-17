namespace GildedRoseKata
{
    public class Cheese : Item
    {
        public const string AgedBrie = "Aged Brie";

        public Cheese(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        protected override void ManageQuality()
        {
            IncrementQuality();
        }

        protected override void ManageQualityWhenExpired()
        {
            IncrementQuality();
        }
    }
}
