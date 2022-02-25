using System;
using Xunit;

namespace Bowling.Test
{
    public class BowlingTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 20)]
        [InlineData(2, 40)]
        [InlineData(3, 60)]
        [InlineData(4, 80)]
        public void WhenXPinsFallEachRoll_ShouldReturnTheCorrectScore(int scorePerRoll, int expectedScore)
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(scorePerRoll);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(expectedScore, total);
        }

        [Fact]
        public void WhenASpareHappensDuringAGame_ShouldReturnTheCorrectScoreWithBonus()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            bowling.Roll(9);
            bowling.Roll(1);
            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(29, total);
        }

        [Fact]
        public void WhenTwoSpareHappensSuccessivelyDuringAGame_ShouldReturnTheCorrectScoreWithBonus()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            bowling.Roll(9);
            bowling.Roll(1);
            bowling.Roll(9);
            bowling.Roll(1);
            for (int i = 0; i < 16; i++)
            {
                bowling.Roll(1);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(46, total);
        }

        [Fact]
        public void WhenAStrikeHappensDuringAGame_ShouldReturnTheCorrectScoreWithBonus()
        {
            // Arrange
            Bowling bowling = new Bowling();
            
            // Act
            bowling.Roll(10);
            bowling.Roll(0);
            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(30, total);
        }

        [Fact]
        public void WhenASpareThatStartsWithAgutterHappensDuringAGame_ShouldReturnTheCorrectScoreWithBonus()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            bowling.Roll(0);
            bowling.Roll(10);

            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(29, total);
        }

        [Fact]
        public void WhenTwoStrikesHappensSuccessibelyDuringAGame_ShouldReturnTheCorrectScoreWithBonus()
        {
            // Arrange
            Bowling bowling = new Bowling();
            
            // Act
            bowling.Roll(10);
            bowling.Roll(0);
            bowling.Roll(10);
            bowling.Roll(0);
            for (int i = 0; i < 16; i++)
            {
                bowling.Roll(1);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(49, total);
        }

        [Fact]
        public void WhenASpareHappensAtTheEndOfAGame_ShouldReturnTheCorrectScoreWithBonusRound()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            bowling.Roll(0);
            bowling.Roll(10);
            bowling.Roll(1);

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(29, total);
        }

        [Fact]
        public void WhenAStrikeHappensAtTheEndOfAGame_ShouldReturnTheCorrectScoreWithBonusRound()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            bowling.Roll(10);
            bowling.Roll(0);
            bowling.Roll(1);
            bowling.Roll(1);

            int total = bowling.GetScore();

            // Then
            Assert.Equal(30, total);
        }

        [Fact]
        public void WhenAStrikeHappensAtTheEndOfAGame_ShouldReturnTheCorrectScoreWithBonusRoundAndStrike()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            bowling.Roll(10);
            bowling.Roll(0);
            bowling.Roll(10);
            bowling.Roll(10);

            int total = bowling.GetScore();

            // Then
            Assert.Equal(48, total);
        }

        [Fact]
        public void WhenWeDoThePerfectScore_ShouldReturnTheCorrectScore()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 9; i++)
            {
                bowling.Roll(10);
                bowling.Roll(0);
            }

            bowling.Roll(10);
            bowling.Roll(0);
            bowling.Roll(10);
            bowling.Roll(10);

            int total = bowling.GetScore();

            // Then
            Assert.Equal(300, total);
        }

        // [Fact]
        // public void WhenWeDoSparesOnAllRound_ShouldReturnTheCorrectScore()
        // {
        //     // Arrange
        //     Bowling bowling = new Bowling();

        //     // Act
        //     for (int i = 0; i < 10; i++)
        //     {
        //         bowling.Roll(5);
        //         bowling.Roll(5);
        //     }

        //     bowling.Roll(5);

        //     int total = bowling.GetScore();

        //     // Then
        //     Assert.Equal(150, total);
        // }

        [Fact]
        public void WhenWeDoSparesOnAllRound_ShouldReturnTheCorrectScore()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 10; i++)
            {
                bowling.Roll(5);
                bowling.Roll(5);
            }

            bowling.Roll(5);

            int total = bowling.GetScore();

            // Then
            Assert.Equal(150, total);
        }
    }
}
