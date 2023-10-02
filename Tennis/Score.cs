using System.Collections.Generic;
using Tennis.Player;

namespace Tennis;

public record Score : IScore
{
    private readonly int _serverScore;
    private readonly int _receiverScore;

    private Score(int serverScore, int receiverScore)
    {
        _serverScore = serverScore;
        _receiverScore = receiverScore;
    }

    public Score() : this(serverScore: 0, 0)
    {
    }

    public IScore WonPoint(IPlayer player)
    {
        if (PlayerEqualsToDeuce(player))
            return new Deuce();

        return player is Server
            ? ServerWonPoint()
            : ReceiverWonPoint();
    }

    private bool PlayerEqualsToDeuce(IPlayer player)
    {
        return (_serverScore == 3 && _receiverScore == 2 && player is Receiver)
            || (_serverScore == 2 && _receiverScore == 3 && player is Server);
    }

    private Score ReceiverWonPoint()
    {
        return new Score(serverScore: _serverScore, _receiverScore + 1);
    }

    private Score ServerWonPoint()
    {
        return new Score(serverScore: _serverScore + 1, _receiverScore);
    }

    public string GetScore()
    {
        Dictionary<int, string> scores = new Dictionary<int, string>
        {
            {0, Scores.Love},
            {1, Scores.Fifteen},
            {2, Scores.Thirty},
            {3, Scores.Forty}
        };

        if (_receiverScore == _serverScore)
        {
            return $"{scores[_serverScore]}-{Scores.All}";
        }
        return $"{scores[_serverScore]}-{scores[_receiverScore]}";
    }
}
