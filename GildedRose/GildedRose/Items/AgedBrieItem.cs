namespace GildedRoseKata.Items
{
    public class AgedBrieItem : Item
    {

        public AgedBrieItem(int sellIn, int quality) :base ( "Aged Brie", sellIn, quality)
        {

        }

        public override void UpdateQuality()
        {
            IncreaseQuality();

            SellIn--;

            if (IsExpired())
            {
                IncreaseQuality();
            }
        }
    }
}
