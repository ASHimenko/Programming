using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    public class RectangleFactory
    {
        static RectangleFactory()
        {
            Rectangle.ResetCounter();
        }

        private static Random _random = new Random();
        private static string[] _colors = { "Red", "Green", "Blue", "Yellow", "Purple" };

        /// <summary>
        /// Создает прямоугольник со случайными значениями.
        /// </summary>
        public static Rectangle Randomize(int maxWidth, int maxHeight)
        {
            int margin = 15;
            double length = _random.Next(30, 100);
            double width = _random.Next(30, 100);

            int centerX = _random.Next(margin + (int)width / 2,
                                    Math.Max(margin + (int)width / 2 + 1, maxWidth - (int)width / 2 - margin));
            int centerY = _random.Next(margin + (int)length / 2,
                                    Math.Max(margin + (int)length / 2 + 1, maxHeight - (int)length / 2 - margin));

            string color = _colors[_random.Next(_colors.Length)];

            return new Rectangle(length, width, color, new Point2D(centerX, centerY));
        }
    }
}
