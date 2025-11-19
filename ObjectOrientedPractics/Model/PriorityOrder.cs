using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class PriorityOrder : Order
    {
        /// <summary>
        /// Возвращает или задает желаемую дату доставки.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Возвращает или задает желаемый диапазон времени доставки.
        /// </summary>
        public DeliveryTimeSlot DeliveryTime { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса без параметров.
        /// Требуется для поддержки десериализации и наследования.
        /// </summary>
        public PriorityOrder() : base()
        {
            this.DeliveryDate = DateTime.Now.Date; 
            this.DeliveryTime = DeliveryTimeSlot.Time_0900_1100; 
        }

        /// <summary>
        /// Конструктор по всем полям класса PriorityOrder.
        /// Наследуется от конструктора Order.
        /// </summary>
        //public PriorityOrder(
        //    DateTime deliveryDate,
        //    DeliveryTimeSlot timeSlot,
        //    int id,
        //    DateTime date,
        //    OrderStatus status,
        //    Address deliveryAddress,
        //    Cart cart,
        //    Customer customer)
        //    // Вызываем конструктор базового класса для инициализации унаследованных полей
        //    : base(id, date, status, deliveryAddress, cart, customer)
        //{
        //    // Инициализация только тех полей, которые объявлены в PriorityOrder
        //    this.DeliveryDate = deliveryDate;
        //    this.DeliveryTime = timeSlot;
        //}



    }
}

