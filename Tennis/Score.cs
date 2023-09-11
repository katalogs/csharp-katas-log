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
        if (_receiverScore == 1 && _serverScore == 1)
        {
            return $"{Scores.Fifteen}-{Scores.All}";
        }
        if (_serverScore == 1)
            return $"{Scores.Fifteen}-{Scores.Love}";
        if (_receiverScore == 1)
        {
            return $"{Scores.Love}-{Scores.Fifteen}";
        }
        return $"{Scores.Love}-All";
    }
}
