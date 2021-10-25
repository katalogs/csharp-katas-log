namespace Tennis.Points
{

    public class Deuce: IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Deuce";
        }

        public IPoint ScoreP1()
        {
            return new Advantage(Player.P�1);
        }

        public IPoint ScoreP2()
        {
            return new Advantage(Player.P�2);
        }
    }

}
