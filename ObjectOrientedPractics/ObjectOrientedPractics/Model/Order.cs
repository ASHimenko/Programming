using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ObjectOrientedPractics.Model
{
    [Serializable]
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        private readonly DateTime _date;

        /// <summary>
        /// Адрес доставки заказа.
        /// </summary>
        private Address _deliveryAddress;

        /// <summary>
        /// Список товаров в заказе.
        /// </summary>
        private Cart _cart;

        /// <summary>
        /// Возвращает уникальный идентификатор заказа.
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime Date => _date;

        /// <summary>
        /// Возвращает или задает адрес доставки заказа.
        /// </summary>
        public Address DeliveryAddress
        {
            get { return _deliveryAddress; }
            set { _deliveryAddress = value; }
        }

        /// <summary>
        /// Возвращает или задает список товаров в заказе.
        /// </summary>
        public Cart Cart
        {
            get => _cart;
            set => _cart = value ?? new Cart();
        }

        /// <summary>
        /// Возвращает общую стоимость всех товаров в заказе.
        /// </summary>
        public double Amount => _cart.Amount;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="deliveryAddress">Адрес доставки заказа.</param>
        /// <param name="items">Список товаров в заказе.</param>
        public Order(Address deliveryAddress, Cart cart)
        {
            _id = IdGenerator.GetNextId();
            _date = DateTime.Now;
            DeliveryAddress = deliveryAddress;
            Cart = cart ?? new Cart();
        }

        /// <summary>
        /// Возвращает строковое представление заказа.
        /// </summary>
        /// <returns>Строка с информацией о заказе.</returns>
        public override string ToString()
        {
            return $"Order #{_id} - {Date:dd.MM.yyyy} - {Amount:C}";
        }
    }
}

