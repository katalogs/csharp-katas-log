using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyCSharp.src
{
    internal class HexagonStrategy : IStrategy
    {
        public string Describe()
        {
            return "Hexagon";
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawVertex(new Point(0, 0));
            canvas.DrawVertex(new Point(2, 0));
            canvas.DrawVertex(new Point(0, 2));
            canvas.DrawVertex(new Point(2, 2));
            canvas.DrawVertex(new Point(3, 1));
            canvas.DrawVertex(new Point(-1, 1));
        }
    }
}
