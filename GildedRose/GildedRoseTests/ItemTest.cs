using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class ItemTest
{
    [Theory]
    [InlineData(-1, true)]
    [InlineData(0, false)]
    [InlineData(1, false)]
    public void IsExpired_whenSellInIsNegative(int sellIn, bool expectedIsExpired)
    {
        var item = new Item
        {
            Name = "Mon Object",
            Quality = 30,
            SellIn = sellIn
        };

        Assert.Equal(expectedIsExpired, item.IsExpired());
    }

    [Theory]
    [InlineData(49, 50)]
    [InlineData(50, 50)]
    [InlineData(51, 51)]
    public void IncreaseQuality_whenQualityIsLowerThan50(int quality, int expectedQuality)
    {
        var item = new Item
        {
            Name = "Mon Object",
            Quality = quality,
            SellIn = 10
        };

        item.IncreaseQuality();

        Assert.Equal(expectedQuality, item.Quality);
    }
}
