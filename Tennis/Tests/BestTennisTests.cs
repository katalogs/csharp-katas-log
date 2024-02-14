using FluentAssertions;
using Tennis.Player;
using Xunit;

namespace Tennis.Tests
{
    public class BestTennisTests
    {
        [Fact]
        public void Should_announce_score_with_love_all_when_game_begins()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.GetScore().Should().Be("Love-All");
        }

        [Fact]
        public void Should_announce_score_with_fifteen_love_when_server_scores_one_point()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(federer);

            game.GetScore().Should().Be("Fifteen-Love");
        }

        [Fact]
        public void Should_announce_score_with_love_fifteen_when_receiver_scores_one_point()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(nadal);
            game.GetScore().Should().Be("Love-Fifteen");
        }

        [Fact]
        public void Should_announce_score_with_fifteen_all_when_receiver_and_server_scores_one_point()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(nadal);
            game.WonPoint(federer);

            game.GetScore().Should().Be("Fifteen-All");
        }
        
        [Fact]
        public void Should_announce_score_with_thirty_love()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(federer);
            game.WonPoint(federer);

            game.GetScore().Should().Be("Thirty-Love");
        }
        
        [Fact]
        public void Should_announce_score_with_Forty_love()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(federer);
            game.WonPoint(federer);
            game.WonPoint(federer);

            game.GetScore().Should().Be("Forty-Love");
        }

        [Fact]
        public void Should_announce_score_with_deuce_by_receiver()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

            game.WonPoint(federer);
            game.WonPoint(federer);
            game.WonPoint(federer);
            game.WonPoint(nadal);
            game.WonPoint(nadal);
            game.WonPoint(nadal);

            game.GetScore().Should().Be("Deuce");
        }

        [Fact]
        public void Should_announce_score_with_deuce_by_server()
        {
            var federer = new Server("Federer");
            var nadal = new Receiver("Nadal");
            var game = new BestTennisGame(federer, nadal);

           
            game.WonPoint(federer);
            game.WonPoint(federer);
            game.WonPoint(nadal);
            game.WonPoint(nadal);
            game.WonPoint(nadal);
            game.WonPoint(federer);

            game.GetScore().Should().Be("Deuce");
        }
    }
}
