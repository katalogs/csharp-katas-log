namespace GildedRoseKata;

internal class Legendary : Item
{
    public Legendary(string name,int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void UpdateQuality()
    {
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    }
}
