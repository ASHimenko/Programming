using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model.Orders
{
    public class PriorityOrder : Order
    {
        /// <summary>
        /// Возвращает или задает желаемую дату доставки.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса без параметров.
        /// Требуется для поддержки десериализации и наследования.
        /// </summary>
        public PriorityOrder() : base()
        {
            this.DeliveryDate = DateTime.Now.Date; 
        }

    }
}

