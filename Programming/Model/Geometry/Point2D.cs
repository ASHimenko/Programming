using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    public class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Point2D(Model.Point2D v)
        {
            throw new NotImplementedException();
        }
    }
}
