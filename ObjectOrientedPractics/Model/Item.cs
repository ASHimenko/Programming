using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ObjectOrientedPractics.Services.IdGenerator;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model
{
    [Serializable]
    /// <summary>
    /// Представляет товар с уникальным идентификатором, названием, описанием, стоимостью и категорией.
    /// </summary>
    public class Item: ICloneable, IEquatable<Item>, IComparable<Item>
    {
        private readonly int _id;
        private string _name;
        private string _info;
        private string _cost;

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
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает или задает стоимость товара. Должна быть в диапазоне от 0 до 100000.
        /// </summary>
        public string Cost
        {
            get => _cost;
            set
            {
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
        public Item(string name, string info, string cost, Category category)
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

        /// <summary>
        /// Создает глубокую копию текущего экземпляра <see cref="Item"/>.
        /// </summary>
        /// <returns>Глубокая копия объекта <see cref="Item"/>.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="Item"/> другому объекту <see cref="Item"/>.
        /// Сравнение производится по всем значимым свойствам.
        /// </summary>
        /// <param name="other">Другой объект <see cref="Item"/> для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public bool Equals(Item other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name &&
                   this.Cost == other.Cost &&
                   this.Category == other.Category;
        }

        /// <summary>
        /// Перегруженный метод для сравнения с объектом.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public override bool Equals(object obj) => Equals(obj as Item);

        /// <summary>
        /// Перегрузка метода GetHashCode для корректной работы в коллекциях.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + Cost.GetHashCode();
                hash = hash * 23 + Category.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Сравнивает текущий товар с другим товаром по стоимости (Cost).
        /// </summary>
        /// <param name="other">Другой объект <see cref="Item"/> для сравнения.</param>
        /// <returns>Целое число, указывающее, превышает ли, равен ли или меньше ли 
        /// по стоимости текущий товар объект <paramref name="other"/>.</returns>
        public int CompareTo(Item other)
        {
            if (other is null)
            {
                return 1; 
            }

            return this.Cost.CompareTo(other.Cost);
        }
    }
}