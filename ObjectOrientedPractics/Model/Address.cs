using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Model
{
    [Serializable]
    /// <summary>
    /// Представляет адрес с почтовым индексом, страной, городом, улицей, домом и квартирой.
    /// </summary>
    public class Address: ICloneable, IEquatable<object>
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
        /// Общее событие, возникающее при изменении любого из свойств адреса.
        /// </summary>
        public event EventHandler<EventArgs> AddressChanged;

        /// <summary>
        /// Возвращает или задает почтовый индекс.
        /// </summary>
        public string Index
        {
            get { return _index; }
            set 
            {
                if (_index != value)
                {
                    _index = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задает страну или регион.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set 
            {
                if (_country != value)
                {
                    _country = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задает город.
        /// </summary>
        public string City
        {
            get { return _city; }
            set 
            {
                if (_city != value)
                {
                    _city = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задает улицу.
        /// </summary>
        public string Street
        {
            get { return _street; }
            set 
            {
                if (_street != value)
                {
                    _street = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задает номер дома.
        /// </summary>
        public string Building
        {
            get { return _building; }
            set 
            {
                if (_building != value)
                {
                    _building = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задает номер квартиры.
        /// </summary>
        public string Apartment
        {
            get { return _apartment; }
            set 
            {
                if (_apartment != value)
                {
                    _apartment = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
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

        /// <summary>
        /// Создает глубокую копию текущего экземпляра <see cref="Address"/>.
        /// </summary>
        /// <returns>Глубокая копия объекта <see cref="Address"/>.</returns>
        public object Clone()
        {
            return new Address(this.Index, this.Country, this.City, this.Street, this.Building, this.Apartment);
        }

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="Address"/> другому объекту <see cref="Address"/>.
        /// Сравнение производится по всем полям адреса.
        /// </summary>
        /// <param name="other">Другой объект <see cref="Address"/> для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (!(other is Address))
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            var address = (Address)other;

            return (this.Index == address.Index) &&
                   (this.Country == address.Country) &&
                   (this.City == address.City) &&
                   (this.Street == address.Street) &&
                   (this.Building == address.Building) &&
                   (this.Apartment == address.Apartment);
        }


        /// <summary>
        /// Безопасный вызов события AddressChanged.
        /// </summary>
        protected virtual void OnAddressChanged(EventArgs e)
        {
            AddressChanged?.Invoke(this, e);
        }
    }
}