using GildedRoseKata;

namespace GildedRoseTests
{
    public class EventTicketTests
    {
        [Fact]
        public void Item_WhenUpdated_Should()
        {
            var item = new EventTicket("stuff", 0, 10);
            item.Update();
            Assert.Equal(9, item.Quality);
        }
    }
}
