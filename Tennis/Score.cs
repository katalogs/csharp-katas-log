using System.Collections.Generic;
using Tennis.Player;

namespace Tennis;

public record Score
{
    private readonly int _serverScore;
    private readonly int _receiverScore;

    private Score(int serverScore, int receiverScore)
    {
        _serverScore = serverScore;
        _receiverScore = receiverScore;
    }

    public Score(): this(serverScore: 0, 0)
    {
    }

    public Score WonPoint(IPlayer player)
    {
        return player is Server
            ? new Score(serverScore: _serverScore + 1, _receiverScore)
            : new Score(serverScore: _serverScore, _receiverScore + 1);
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
