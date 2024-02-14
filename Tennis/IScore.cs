namespace Tennis
{
    public interface IScore
    {
        string GetScore();
        IScore WonPoint(IPlayer player);
    }
}
