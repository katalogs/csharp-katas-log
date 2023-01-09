namespace StrategyCSharp.src
{
    public interface IStrategy
    {
        public string Describe();
        public void Draw(ICanvas canvas);
    }
}
