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
    [Serializable]
    /// <summary>
    /// Представляет покупателя с уникальным идентификатором, полным именем и адресом.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Уникальный идентификатор покупателя.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Адрес покупателя.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Корзина товаров покупателя.
        /// </summary>
        private Cart _cart;

        /// <summary>
        /// Список заказов покупателя.
        /// </summary>
        private List<Order> _orders;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullName">Полное имя покупателя.</param>
        /// <param name="address">Адрес покупателя.</param>
        public Customer(string fullName, Address address)
        {
            _id = IdGenerator.GetNextId();
            FullName = fullName;
            Address = address;
            Cart = new Cart();
            Orders = new List<Order>();
        }

        /// <summary>
        /// Возвращает уникальный идентификатор покупателя.
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Возвращает или задает полное имя покупателя. Не может быть пустым и не превышает 200 символов.
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set
            {
                if (value.Length > 200)
                {
                    MessageBox.Show("Имя покупателя не должно превышать 200 символов", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
                _fullName = value;
            }
        }

        /// <summary>
        /// Возвращает или задает адрес покупателя. Не может быть null.
        /// </summary>
        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }

        /// <summary>
        /// Возвращает или задает корзину товаров покупателя.
        /// </summary>
        public Cart Cart
        {
            get => _cart;
            set
            {
                _cart = value ?? new Cart();
            }
        }

        /// <summary>
        /// Возвращает или задает список заказов покупателя.
        /// </summary>
        public List<Order> Orders
        {
            get => _orders;
            set => _orders = value ?? new List<Order>();
        }

        /// <summary>
        /// Возвращает строковое представление покупателя.
        /// </summary>
        /// <returns>Строка с информацией о покупателе.</returns>
        public override string ToString()
        {
            return $"{FullName}, {_address}";
        }
    }
}