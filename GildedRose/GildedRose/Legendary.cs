namespace GildedRoseKata;

internal class Legendary : Item
{
    public Legendary(int sellIn, int quality, string name)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public override void UpdateQuality()
    {
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    }
}
