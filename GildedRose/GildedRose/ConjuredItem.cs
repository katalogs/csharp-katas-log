namespace GildedRoseKata
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(string name, int sellIn, int quality)
            : base(name, sellIn, quality)
        { }

        public override void DecrementQuality()
        {
            base.DecrementQuality();
            base.DecrementQuality();
        }
    }
}
