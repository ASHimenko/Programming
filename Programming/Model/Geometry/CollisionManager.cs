using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    public class CollisionManager
    {
        /// <summary>
        /// Проверяет пересечение двух прямоугольников.
        /// </summary>
        public static bool IsCollision(Rectangle a, Rectangle b)
        {
            return Math.Abs(a.Center.X - b.Center.X) < (a.Width + b.Width) / 2 &&
                   Math.Abs(a.Center.Y - b.Center.Y) < (a.Length + b.Length) / 2;
        }
    }
}
