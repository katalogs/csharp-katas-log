using FluentAssertions;
using Xunit;

namespace Tennis.Tests
{
    public class BestTennisTests
    {
        [Fact]
        public void Should_announce_score_with_love_all_when_game_begins()
        {
            var game = new BestTennisGame("Federer", "Nadal");
            game.GetScore().Should().Be("Love-All");
        }

        [Fact]
        public void Should_announce_score_with_fifteen_love_when_server_scores_one_point()
        {
            var game = new BestTennisGame("Federer", "Nadal");
            game.WonPoint("Federer");
            game.GetScore().Should().Be("Fifteen-Love");
        }
    }
}
