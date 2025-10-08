using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                if (value.Length > 200)
                    MessageBox.Show("Название товара должно содержать до 200 символов", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (value.Length > 1000)
                {
                    MessageBox.Show("Описание товара должно содержать до 1000 символов", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                {
                    MessageBox.Show("Стоимость товара должна быть в диапазоне от 0 до 100000", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!double.TryParse(value.ToString(), out _))
                {
                    MessageBox.Show("Стоимость товара должна быть вещественным числом", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
                _cost = value;
            }
        }

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
        public string DisplayInfo => $"ID: {_id} - {Name} - {Cost:C}, {Category}";

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