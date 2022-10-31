using System.Collections.Generic;
using System.Threading.Tasks;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> {new() {Name = "foo", SellIn = 0, Quality = 0}};
            var gildedRose = new GildedRose(Items);
            gildedRose.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);*/
        }
    }
}
