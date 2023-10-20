namespace GildedRoseKata.Items
{
    public class AgedBrieItem : Item
    {

        public AgedBrieItem(int sellIn, int quality)
        {
            Name = "Aged Brie";
            SellIn = sellIn;
            Quality = quality;
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
