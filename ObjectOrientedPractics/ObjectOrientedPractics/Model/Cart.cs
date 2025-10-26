using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    [Serializable]
    public class Cart
    {
        /// <summary>
        /// Список товаров в корзине.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Возвращает или задает список товаров в корзине.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// Возвращает общую стоимость всех товаров в корзине.
        /// </summary>
        public double Amount
        {
            get
            {
                if (_items == null)
                {
                    return 0.0;
                }

                double total = 0.0;
                foreach (var item in _items)
                {
                    total += double.Parse(item.Cost);
                }
                return total;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Cart"/> с пустым списком товаров.
        /// </summary>
        public Cart()
        {
            _items = new List<Item>();
        }
    }
}
