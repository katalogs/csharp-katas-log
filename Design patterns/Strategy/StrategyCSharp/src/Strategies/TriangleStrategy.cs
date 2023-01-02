using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyCSharp.src
{
    internal class TriangleStrategy : IStrategy
    {
        public string Describe()
        {
            return "Triangle";
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawVertex(new Point(0, 0));
            canvas.DrawVertex(new Point(2, 0));
            canvas.DrawVertex(new Point(1, 2));
        }
    }
}
