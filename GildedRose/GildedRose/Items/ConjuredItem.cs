namespace GildedRoseKata.Items
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(String name, int sellIn, int quality) : base(name, sellIn, quality)
        {

        }

        public override void DecreaseQuality()
        {
                Quality = Math.Max(Quality - 2 , MinQuality);
        }
    }
}
