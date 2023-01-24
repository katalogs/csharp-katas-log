using GildedRoseKata;
using Moq;

namespace GildedRoseTests
{
    public class EventTicketTests
    {
        private static readonly Random _rdm = new();

        [Theory]
        [InlineData(1000, 1)]
        [InlineData(11, 1)]
        [InlineData(10, 2)]
        [InlineData(6, 2)]
        [InlineData(5, 3)]
        [InlineData(1, 3)]
        public void Item_WhenUpdated_BeforeEvent_ShouldIncreaseTheQualityAppropriately(int sellIn, int pas)
        {
            var quality = GetValidRandomQuality();
            var item = new EventTicket("stuff", sellIn, quality);

            item.Update();

            Assert.Equal(pas + quality, item.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Item_WhenUpdated_AndAfterEvent_ResetTo0(int sellIn)
        {
            var item = new EventTicket("stuff", sellIn, GetValidRandomQuality());

            item.Update();

            Assert.Equal(0, item.Quality);
        }

        private static int GetValidRandomQuality()
        {
            return _rdm.Next(0, 45);
        }
    }
}
