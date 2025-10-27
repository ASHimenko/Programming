using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    [Serializable]
    public class Store
    {
        /// <summary>
        /// Товары магазина.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Покупатели магазина.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Возвращает или задает список товаров магазина.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// Возвращает или задает список покупателей магазина.
        /// </summary>
        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Store"/> с пустыми списками товаров и покупателей.
        /// </summary>
        public Store()
        {
            _items = new List<Item>();
            _customers = new List<Customer>();
        }
    }
}
