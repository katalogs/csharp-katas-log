using Moq;
using NUnit.Framework;
using StrategyCSharp.src;

namespace StrategyCSharp.test
{
    public class WidgetTest
    {
        [Test]
        public void AWidgetCanBeCreated()
        {
            // ReSharper disable once UnusedVariable
            var w = new Widget();
        }

        [Test]
        public void AWidgetCanDescribeItself()
        {
            var w = new Widget();
            w.Describe();
        }

        [Test]
        public void AWidgetStartsAsATriangle()
        {
            var w = new Widget();
            Assert.AreEqual("Triangle", w.Describe());
        }

        [Test]
        public void AWidgetSTypeCanBeChangedAtRunTime()
        {
            var w = new Widget();
            Assert.AreEqual("Triangle", w.Describe());
            w.SetStrategy(new SquareStrategy());

            Assert.AreEqual("Square", w.Describe());
        }

        [Test]
        public void AWidgetCanSetToBeATriangle()
        {
            var w = new Widget();
            w.SetStrategy(new TriangleStrategy());
        }

        [Test]
        public void ATriangularWidgetDescribesItselfAsATriangle()
        {
            var w = new Widget();
            w.SetStrategy(new TriangleStrategy());

            Assert.AreEqual("Triangle", w.Describe());
        }

        [Test]
        public void ATriangularWidgetDrawsAsATriangle()
        {
            VerifyCorrectNumberOfVertices(new TriangleStrategy(), 3);
        }

        [Test]
        public void AWidgetCanSetToBeASquare()
        {
            var w = new Widget();
            w.SetStrategy(new SquareStrategy());
        }

        [Test]
        public void ASquareWidgetDescribesItselfAsASquare()
        {
            var w = new Widget();
            w.SetStrategy(new SquareStrategy());

            Assert.AreEqual("Square", w.Describe());
        }

        [Test]
        public void ASquareWidgetDrawsAsASquare()
        {
            VerifyCorrectNumberOfVertices(new SquareStrategy(), 4);
        }

        [Test]
        public void AWidgetCanSetToBeAPentagon()
        {
            var w = new Widget();
            w.SetStrategy(new PentagonStrategy());
        }

        [Test]
        public void APentagonWidgetDescribesItselfAsAPentagon()
        {
            var w = new Widget();
            w.SetStrategy(new PentagonStrategy());

            Assert.AreEqual("Pentagon", w.Describe());
        }

        [Test]
        public void APentagonWidgetDrawsAsAPentagon()
        {
            VerifyCorrectNumberOfVertices(new PentagonStrategy(), 5);
        }

        [Test]
        public void AWidgetCanSetToBeAHexagon()
        {
            var w = new Widget();
            w.SetStrategy(new HexagonStrategy());
        }

        [Test]
        public void AHexagonWidgetDescribesItselfAsAHexagon()
        {
            var w = new Widget();
            w.SetStrategy(new HexagonStrategy());

            Assert.AreEqual("Hexagon", w.Describe());
        }

        [Test]
        public void AHexagonWidgetDrawsAsAHexagon()
        {
            VerifyCorrectNumberOfVertices(new HexagonStrategy(), 6);
        }

        private static void VerifyCorrectNumberOfVertices(IStrategy strategy, int vertices)
        {
            var w = new Widget();
            w.SetStrategy(strategy);

            var c = new Mock<ICanvas>();

            w.Draw(c.Object);

            c.Verify(mock => mock.DrawVertex(It.IsAny<Point>()), Times.Exactly(vertices));
        }
    }
}
