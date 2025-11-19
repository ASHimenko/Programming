using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public enum DeliveryTimeSlot
    {
        /// <summary>
        /// Время доставки: 9:00 – 11:00.
        /// </summary>
        Time_0900_1100,

        /// <summary>
        /// Время доставки: 11:00 – 13:00.
        /// </summary>
        Time_1100_1300,

        /// <summary>
        /// Время доставки: 13:00 – 15:00.
        /// </summary>
        Time_1300_1500,

        /// <summary>
        /// Время доставки: 15:00 – 17:00.
        /// </summary>
        Time_1500_1700,

        /// <summary>
        /// Время доставки: 17:00 – 19:00.
        /// </summary>
        Time_1700_1900,

        /// <summary>
        /// Время доставки: 19:00 – 21:00.
        /// </summary>
        Time_1900_2100
    }
}
