using Moq;
using StrategyCSharp.src;

namespace StrategyCSharp
{
    public class Widget
    {
        private IStrategy _strategy = new TriangleStrategy();

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public string Describe()
        {
            return _strategy.Describe();
        }


        public void Draw(ICanvas canvas)
        {
            _strategy.Draw(canvas);
        }
    }
}
