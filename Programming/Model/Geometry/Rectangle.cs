using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    public class Rectangle
    {
        private static int _idCounter = 1;

        public int Id { get; }
        public double Length { get; set; }
        public double Width { get; set; }
        public Point2D Center { get; set; }
        public string Color { get; set; }

        public Rectangle(double length, double width, string color, Point2D center)
        {
            Id = _idCounter++;
            Length = length;
            Width = width;
            Color = color;
            Center = center;
        }

        // Метод для сброса счетчика (добавьте этот метод)
        public static void ResetCounter()
        {
            _idCounter = 1;
        }

        public void UpdateCenter(int x, int y)
        {
            Center = new Point2D(x, y);
        }
    }
}
