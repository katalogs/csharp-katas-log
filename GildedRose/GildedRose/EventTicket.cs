namespace GildedRoseKata
{
    public class EventTicket : Item
    {
        public const string TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

        public EventTicket(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        protected override void ManageQuality()
        {
            IncrementQuality();

            if (SellIn < 11)
            {
                IncrementQuality();
            }

            if (SellIn < 6)
            {
                IncrementQuality();
            }
        }

        protected override void ManageQualityWhenExpired()
        {
            SetMinimalQuality();
        }
    }
}
