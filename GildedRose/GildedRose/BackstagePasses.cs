namespace GildedRoseKata;

internal class BackstagePasses : Item
{
    public BackstagePasses(int sellIn, int quality, string band)
    {
        Name = "Backstage passes to a "+ band + " concert";
        SellIn = sellIn;
        Quality = quality;
    }

    public override void UpdateQuality()
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

        DecreaseSellIn();

        if (IsExpired())
        {
            DropQuality();
        }
    }

}
