using System.Collections.Generic;
using GildedRoseKata;
using Xunit;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Combinations;
using System.Linq;

namespace GildedRoseTests;

[UseReporter(typeof(DiffReporter))]
public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        var name = "foo";
        var sellIn = 0;
        var quality = 0;

        string actual = RunApp(name, sellIn, quality);

        Assert.Equal("foo, -1, 0", actual);
    }

    private static string RunApp(string name, int sellIn, int quality)
    {
        IList<Item> Items = new List<Item> { CreateItem(name, sellIn, quality) };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        return Items[0].ToString();
    }

    private static Item CreateItem(string name, int sellIn, int quality)
    {
        if (name == "Sulfuras, Hand of Ragnaros")
        {
            return new Sulfuras { SellIn = sellIn, Quality = quality };
        }
        return new() { Name = name, SellIn = sellIn, Quality = quality };
    }

    [Fact]
    public void bulk_test()
    {
        var names = new[] { "foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros",  } ;
        var sellIns = Enumerable.Range(-5, 20);
        var qualities = Enumerable.Range(-5, 55);

        CombinationApprovals.VerifyAllCombinations(RunApp, names, sellIns, qualities);
    }
}
