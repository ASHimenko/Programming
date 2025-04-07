using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    public class Rectangle
    {
        private double _length;
        private double _width;
        private string _color;
        private Point2D _center;
        private static int _allRectanglesCount = 0;
        private int _id;

        public double Length
        {
            get { return _length; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Length));
                _length = value;
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Length));
                _width = value;
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Цвет не может быть пустым.");
                }
                _color = value;
            }
        }

        public Point2D Center
        {
            get { return _center; }
            private set { _center = value; }
        }

        public static int AllRectanglessCount()
        {
            return _allRectanglesCount;
        }
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public Rectangle(double length, double width, string color, Point2D center)
        {
            Length = length;
            Width = width;
            Color = color;
            Center = center;

            _allRectanglesCount++;
            Id = _allRectanglesCount;
        }

        public Rectangle() { }
    }
}
