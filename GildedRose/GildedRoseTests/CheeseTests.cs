﻿using GildedRoseKata;

namespace GildedRoseTests
{
    public class CheeseTests
    {
        [Fact]
        public void Update_IncreaseQuality_By_One()
        {
            var cheese = new Cheese("name", 5, 2);

            cheese.Update();

            Assert.Equal(3, cheese.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Update_IncreaseQuality_WhenExpired_Twice(int sellIn)
        {
            var cheese = new Cheese("name", sellIn, 2);

            cheese.Update();

            Assert.Equal(4, cheese.Quality);
        }
    }
}
