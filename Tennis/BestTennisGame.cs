using Tennis.Player;

namespace Tennis
{
    public class BestTennisGame
    {
        private Server _server;
        private Receiver _receiver;

        private IScore _score;

        public BestTennisGame(Server server, Receiver receiver)
        {
            _server = server;
            _receiver = receiver;
            _score = new Score();

        }

        public string GetScore()
        {
            return _score.GetScore();
        }

        public void WonPoint(IPlayer player)
        {
            _score = _score.WonPoint(player);
        }
    }

}
