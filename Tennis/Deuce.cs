namespace Tennis
{
    public class Deuce : IScore
    {
        public string GetScore()
        {
            return $"{Scores.Deuce}";
        }

        public IScore WonPoint(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
