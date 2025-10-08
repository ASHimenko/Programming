using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObjectOrientedPractics.Services.IdGenerator;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет покупателя с уникальным идентификатором, полным именем и адресом.
    /// </summary>
    public class Customer
    {
        private readonly int _id;
        private string _fullName;
        private Address _address= new Address();

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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Полное имя покупателя не может быть пустым");

                ValueValidator.AssertStringOnLength(value, 200, nameof(FullName));
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
                _address = value ?? throw new ArgumentNullException(nameof(Address), "Адрес не может быть пустым");
            }
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