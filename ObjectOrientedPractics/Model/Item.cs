using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class Item
    {
        private readonly int _id;
        private string _name;
        private string _info;
        private double _cost;

        public static class IdGenerator
        {
            private static int _currentId = 0;

            public static int GetNextId()
            {
                return ++_currentId;
            }

        }

        public Item(string name, string info, double cost)
        {
            _id = IdGenerator.GetNextId();
            Name = name;
            Info = info;
            Cost = cost;

        }

        public int Id => _id;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название товара не может быть пустым");

                ValueValidator.AssertStringOnLength(value, 200, nameof(Name));
                _name = value;
            }
        }

        public string Info
        {
            get => _info;
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, nameof(Info));
                _info = value;
            }
        }

        public double Cost
        {
            get => _cost;
            set
            {
                if (value < 0 || value > 100000)
                    throw new ArgumentException("Стоимость товара должна быть в диапазоне от 0 до 100000");
                _cost = value;
            }
        }
    }
}
