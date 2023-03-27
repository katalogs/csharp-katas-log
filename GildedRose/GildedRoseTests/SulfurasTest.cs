using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class SulfurasTest
{
    [Fact]
    public void Sulfuras_ManageQuality_ShouldDoNothing()
    {
        var sulfuras = new Sulfuras
        {
            Quality = 15,
            SellIn = 4
        };

        sulfuras.ManageQuality();

        Assert.Equal(15, sulfuras.Quality);
        Assert.Equal(4, sulfuras.SellIn);
        Assert.Equal("Sulfuras, Hand of Ragnaros", sulfuras.Name);
    }
}
