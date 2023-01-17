namespace GildedRoseKata
{
    public class LegendaryItem : Item
    {
        public const string SulfurasHandRagnaros = "Sulfuras, Hand of Ragnaros";

        public LegendaryItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
            // does nothing
        }
    }
}
