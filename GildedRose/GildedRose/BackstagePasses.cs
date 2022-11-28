namespace GildedRoseKata;

internal class BackstagePasses : Item
{
    public BackstagePasses(int sellIn, int quality)
    {
        Name = "Backstage passes to a TAFKAL80ETC concert";
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
