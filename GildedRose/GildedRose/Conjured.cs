namespace GildedRoseKata;

internal class Conjured : Item
{
    public Conjured(string name, int sellIn, int quality) : base("Conjured " + name, sellIn, quality)
    {
    }

    internal override void DecreaseQuality()
    {
        if (Quality > 0)
        {
            Quality -=2;
        }
    }
}
