
using Argon;

using GildedRoseKata;
using System.Text;

namespace GildedRoseTests
{
    [UsesVerify]
    public class GildedRoseTest
    {
        public GildedRoseTest()
        {
            VerifierSettings.AddExtraSettings(serializerSettings =>
                serializerSettings.DefaultValueHandling = DefaultValueHandling.Include);
        }

        [Fact]
        public Task UpdateQuality_WithNominalItem_ShouldHaveCorrectValue()
        {
            IList<Item> Items = new List<Item> {new() {Name = "foo", SellIn = 0, Quality = 0}};
            var gildedRose = new GildedRose(Items);
            gildedRose.UpdateQuality();
            return Verify(Items);
            /*Assert.Equal("foo", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);*/
        }

        [Fact]
        public Task GoldenMasterOnMain_WithNominalItem_ShouldSucced()
        {
            StringBuilder builder = new();
            StringWriter sw = new StringWriter(builder);
            Console.SetOut(sw);
            Program.Main(new String[] { });
            var result = builder.ToString();
            
            return Verify(result);
        }
    }
}
