using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    public class Validator
    {
        public static void AssertValueInRange(int value, int min, int max, string propertyName)
        {
            if (value < min || value > max)
    {
                throw new ArgumentException($"{propertyName} должен быть в диапазоне от {min} до {max}.");
            }
        }

        public static void AssertValueInRange(double value, double min, double max, string propertyName)
        {
            if (value < min || value > max)
    {
                throw new ArgumentException($"{propertyName} должен быть в диапазоне от {min} до {max}.");
            }
        }

        public static void AssertOnPositiveValue(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} должен быть положительным числом.");
            }
        }
        public static void AssertOnPositiveValue(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} должен быть положительным числом.");
            }
        }
    }
}
