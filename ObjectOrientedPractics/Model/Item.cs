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
        /// Событие, возникающее при изменении названия товара.
        /// </summary>
        public event EventHandler<EventArgs> NameChanged;

        /// <summary>
        /// Событие, возникающее при изменении стоимости товара.
        /// </summary>
        public event EventHandler<EventArgs> CostChanged;

        /// <summary>
        /// Событие, возникающее при изменении информации о товаре.
        /// </summary>
        public event EventHandler<EventArgs> InfoChanged;

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
                if (_name != value)
                {
                    _name = value;
                    OnNameChanged(EventArgs.Empty);
                }
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
                if (_info != value)
                {
                    _info = value;
                    OnInfoChanged(EventArgs.Empty);
                }
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
                if (_cost != value)
                {
                    _cost = value;
                    OnCostChanged(EventArgs.Empty);
                }
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
            return new Item(this.Name, this.Info, this.Cost, this.Category);
        }

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="Item"/> другому объекту <see cref="Item"/>.
        /// Сравнение производится по всем значимым свойствам.
        /// </summary>
        /// <param name="other">Другой объект <see cref="Item"/> для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (!(other is Item))
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            var item2 = (Item)other;

            return (this.Name == item2.Name) &&
                   (this.Cost == item2.Cost) &&
                   (this.Category == item2.Category);
        }

        /// <summary>
        /// Сравнивает текущий товар с другим товаром по стоимости (Cost).
        /// </summary>
        /// <param name="other">Другой объект <see cref="Item"/> для сравнения.</param>
        /// <returns>Целое число, указывающее, превышает ли, равен ли или меньше ли 
        /// по стоимости текущий товар объект <paramref name="other"/>.</returns>
        public int CompareTo(Item other)
        {
            if (other == null)
            {
                return 1; 
            }

            return this.Cost.CompareTo(other.Cost);
        }

        /// <summary>
        /// Безопасный вызов события NameChanged.
        /// </summary>
        protected virtual void OnNameChanged(EventArgs e)
        {
            NameChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Безопасный вызов события InfoChanged.
        /// </summary>
        protected virtual void OnInfoChanged(EventArgs e)
        {
            InfoChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Безопасный вызов события CostChanged.
        /// </summary>
        protected virtual void OnCostChanged(EventArgs e)
        {
            CostChanged?.Invoke(this, e);
        }
    }
}