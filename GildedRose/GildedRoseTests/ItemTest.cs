using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class ItemTest
{
    [Theory]
    [InlineData(-1, true)]
    [InlineData(0, false)]
    [InlineData(1, false)]
    public void isExpired_whenSellInIsNegative(int sellIn, bool expectedIsExpired)
    {
        var item = new Item
        {
            Name = "Mon Object",
            Quality = 30,
            SellIn = sellIn
        };

        Assert.Equal(expectedIsExpired, item.isExpired());
    }
}
