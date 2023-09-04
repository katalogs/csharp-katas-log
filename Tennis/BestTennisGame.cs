namespace Tennis
{
    public class BestTennisGame
    {
        private string server;
        private string receiver;
        private int serverScore;
        private int receiverScore;

        public BestTennisGame(string server, string receiver)
        {
            this.server = server;
            this.receiver = receiver;
        }

        public string GetScore()
        {
            if (receiverScore == 1 && serverScore == 1)
            {
                return $"{Scores.Fifteen}-{Scores.All}";
            }
            if (serverScore == 1)
                return $"{Scores.Fifteen}-{Scores.Love}";
            if (receiverScore == 1)
            {
                return $"{Scores.Love}-{Scores.Fifteen}";
            }
            return $"{Scores.Love}-All";
        }

        public void WonPoint(string player)
        {
            if (player == receiver)
            {
                receiverScore = +1;
            }
            else
            {
                serverScore += 1;
            }
        }
    }

    public class Scores
    {

        public const string Love = "Love";

        public const string Fifteen = "Fifteen";

        public const string All = "All";
    }

}
