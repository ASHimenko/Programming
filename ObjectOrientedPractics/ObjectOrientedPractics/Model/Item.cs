using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectOrientedPractics.Services.IdGenerator;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет товар с уникальным идентификатором, названием, описанием, стоимостью и категорией.
    /// </summary>
    public class Item
    {
        private readonly int _id;
        private string _name;
        private string _info;
        private double _cost;

        /// <summary>
        /// Возвращает или задает категорию товара.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает уникальный идентификатор товара.
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Возвращает или задает название товара. Не может быть пустым и не превышает 200 символов.
        /// </summary>
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

        /// <summary>
        /// Возвращает или задает описание товара. Не превышает 1000 символов.
        /// </summary>
        public string Info
        {
            get => _info;
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, nameof(Info));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает или задает стоимость товара. Должна быть в диапазоне от 0 до 100000.
        /// </summary>
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

        /// <summary>
        /// Возвращает строковое представление товара.
        /// </summary>
        public string DisplayInfo => $"ID: {_id} - {Name} - {Cost:C}, {Category}";

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="name">Название товара.</param>
        /// <param name="info">Описание товара.</param>
        /// <param name="cost">Стоимость товара.</param>
        /// <param name="category">Категория товара.</param>
        public Item(string name, string info, double cost, Category category)
        {
            _id = IdGenerator.GetNextId();
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
        }

        /// <summary>
        /// Возвращает строковое представление товара.
        /// </summary>
        /// <returns>Строка с информацией о товаре.</returns>
        public override string ToString()
        {
            return DisplayInfo;
        }
    }
}