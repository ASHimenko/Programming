using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Orders
{
    [Serializable]
    public class Order : IEquatable<Order>
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
        /// Статус заказа.
        /// </summary>
        private OrderStatus _orderStatus;

        /// <summary>
        /// Покупатель, сделавший заказ.
        /// </summary>
        private Customer _customer;

        /// <summary>
        /// Возвращает уникальный идентификатор заказа.
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime Date => _date;

        /// <summary>
        /// Возвращает или задает желаемый диапазон времени доставки.
        /// </summary>
        public string DeliveryTime { get; set; }

        /// <summary>
        /// Размер скидки в денежном эквиваленте, примененной к данному заказу.
        /// Задается при создании заказа.
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Возвращает или задает адрес доставки заказа.
        /// </summary>
        public Address DeliveryAddress
        {
            get { return _deliveryAddress; }
            set { _deliveryAddress = value; }
        }

        /// <summary>
        /// Возвращает или задает статус заказа.
        /// </summary>
        public OrderStatus OrderStatus
        {
            get => _orderStatus;
            set => _orderStatus = value;
        }

        /// <summary>
        /// Возвращает или задает покупателя, сделавшего заказ.
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        /// <summary>
        /// Возвращает полное имя покупателя.
        /// </summary>
        public string CustomerFullName => Customer.FullName;

        /// <summary>
        /// Возвращает строковое представление адреса доставки.
        /// </summary>
        public string DeliveryAddressString
        {
            get => $"{DeliveryAddress.Index}, {DeliveryAddress.Country}, г.{DeliveryAddress.City}, ул.{DeliveryAddress.Street}, д.{DeliveryAddress.Building}, кв.{DeliveryAddress.Apartment}";
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
        /// Возвращает конечную стоимость заказа с учетом примененной скидки.
        /// Вычисляется как: Amount - DiscountAmount.
        /// </summary>
        public double Total
        {
            get
            {
                return Math.Max(0, Amount - DiscountAmount);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="deliveryAddress">Адрес доставки заказа.</param>
        /// <param name="items">Список товаров в заказе.</param>
        public Order()
        {
            _id = IdGenerator.GetNextId();
            _date = DateTime.Now;
            DeliveryAddress = new Address();
            Cart = new Cart();
            _orderStatus = OrderStatus.New;
        }

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="Order"/> другому объекту <see cref="Order"/>.
        /// Сравнение производится по уникальному идентификатору Id.
        /// </summary>
        /// <param name="other">Другой объект <see cref="Order"/> для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public bool Equals(Order other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id;
        }

        /// <summary>
        /// Перегруженный метод для сравнения с объектом.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public override bool Equals(object obj) => Equals(obj as Order);

        /// <summary>
        /// Перегрузка метода GetHashCode для корректной работы в коллекциях.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}

