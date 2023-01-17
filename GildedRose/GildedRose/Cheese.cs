namespace GildedRoseKata
{
    public class Cheese : Item
    {
        public const string AgedBrie = "Aged Brie";

        public Cheese(string name) : base(name)
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
