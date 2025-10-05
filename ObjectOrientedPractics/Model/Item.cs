using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectOrientedPractics.Services.IdGenerator;

namespace ObjectOrientedPractics.Model
{
    public class Item
    {
        private readonly int _id;
        public string Name;
        public string Info;
        public double Cost;
        public int Id => _id;
        public string name
        {
            get => Name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название товара не может быть пустым");

                ValueValidator.AssertStringOnLength(value, 200, nameof(name));
                Name = value;
            }
        }

        public string info
        {
            get => Info;
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, nameof(info));
                Info = value;
            }
        }

        public double cost
        {
            get => Cost;
            set
            {
                if (value < 0 || value > 100000)
                    throw new ArgumentException("Стоимость товара должна быть в диапазоне от 0 до 100000");
                Cost = value;
            }
        }
        
        public string DisplayInfo => $"ID: {Id} - {Name} - {Cost:C}";
        public Item(string _name, string _info, double _cost)
        {
            _id = IdGenerator.GetNextId();
            name = _name;
            info = _info;
            cost = _cost;

        }

        public override string ToString()
        {
            return DisplayInfo;
        }
    }
}
