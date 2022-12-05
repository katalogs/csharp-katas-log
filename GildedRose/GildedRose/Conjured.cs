namespace GildedRoseKata;

public class Conjured : Item
{
    public Conjured(string name, int sellIn, int quality) : base("Conjured " + name, sellIn, quality)
    {
    }

    internal override void DecreaseQuality()
    {
        if (Quality > 1)
        {
            Quality -=2;
        }
        else if (Quality == 1)
        {
            Quality--;
        }
    }
}
