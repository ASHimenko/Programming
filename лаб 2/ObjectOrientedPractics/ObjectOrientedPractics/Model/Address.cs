using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет адрес с почтовым индексом, страной, городом, улицей, домом и квартирой.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        private string _index;

        /// <summary>
        /// Страна или регион.
        /// </summary>
        private string _country;

        /// <summary>
        /// Город.
        /// </summary>
        private string _city;

        /// <summary>
        /// Улица.
        /// </summary>
        private string _street;

        /// <summary>
        /// Номер дома.
        /// </summary>
        private string _building;

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        private string _apartment;

        /// <summary>
        /// Возвращает или задает почтовый индекс.
        /// </summary>
        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Возвращает или задает страну или регион.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Возвращает или задает город.
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Возвращает или задает улицу.
        /// </summary>
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        /// <summary>
        /// Возвращает или задает номер дома.
        /// </summary>
        public string Building
        {
            get { return _building; }
            set { _building = value; }
        }

        /// <summary>
        /// Возвращает или задает номер квартиры.
        /// </summary>
        public string Apartment
        {
            get { return _apartment; }
            set { _apartment = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Address"/> с указанными параметрами.
        /// </summary>
        /// <param name="index">Почтовый индекс.</param>
        /// <param name="country">Страна или регион.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="building">Номер дома.</param>
        /// <param name="apartment">Номер квартиры.</param>
        public Address(string index, string country, string city, string street, string building, string apartment)
        {
            _index = index;
            _country = country;
            _city = city;
            _street = street;
            _building = building;
            _apartment = apartment;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Address"/> с пустыми значениями.
        /// </summary>
        public Address()
        {
            _index = string.Empty;
            _country = string.Empty;
            _city = string.Empty;
            _street = string.Empty;
            _building = string.Empty;
            _apartment = string.Empty;
        }

        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, содержащая полный адрес.</returns>
        public override string ToString()
        {
            return $"{_index}, {_country}, {_city}, {_street}, {_building}, {_apartment}";
        }
    }
}