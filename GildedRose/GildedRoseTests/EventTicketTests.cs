using GildedRoseKata;
using Moq;

namespace GildedRoseTests
{
    public class EventTicketTests
    {
        private static readonly Random _rdm = new Random();

        [Theory]
        [InlineData(11)]
        [InlineData(1000)]
        public void Item_WhenUpdated_AndEarlyFromEvent_ShouldIncreaseQualityOnce(int sellIn)
        {
            int quality = GetValidRandomQuality();

            var item = new EventTicket("stuff", sellIn, quality);
            item.Update();
            Assert.Equal(quality + 1, item.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(6)]
        public void Item_WhenUpdated_AndBetween10And6DaysFromEvent_ShouldIncreaseQualityTwice(int sellIn)
        {
            int quality = GetValidRandomQuality();

            var item = new EventTicket("stuff", sellIn, quality);
            item.Update();
            Assert.Equal(quality + 2, item.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        public void Item_WhenUpdated_AndBetween5And1DayFromEvent_ShouldIncreaseQualityThreeTimes(int sellIn)
        {
            int quality = GetValidRandomQuality();

            var item = new EventTicket("stuff", sellIn, quality);
            item.Update();
            Assert.Equal(quality + 3, item.Quality);
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
