namespace Tennis
{
    public class BestTennisGame
    {
        private string server;
        private string receiver;
        private int serverScore;

        public BestTennisGame(string server, string receiver)
        {
            this.server = server;
            this.receiver = receiver;
        }

        public string GetScore()
        {
            if (serverScore == 1)
                return "Fifteen-Love";
            return "Love-All";
        }

        public void WonPoint(string player)
        {
            serverScore += 1;
        }
    }
}
