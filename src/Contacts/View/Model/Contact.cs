using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    /// <summary>
    /// Представляет модель данных для контакта.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Имя контакта.
        /// </summary>
        private string _name;

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        private string _email;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Уникальный идентификатор контакта.
        /// </summary>
        private int _id;

        /// <summary>
        /// Возвращает или задает имя контакта.
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Возвращает или задает адрес электронной почты.
        /// </summary>
        public string Email { get { return _email; } set { _email = value; } }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор контакта.
        /// </summary>
        public int Id { get { return _id; } set { _id = value; } }

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        /// <summary>
        /// Создает экземпляр класса <see cref="Contact"/> с заданными параметрами.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="email">Электронная почта.</param>
        /// <param name="phoneNumber">Номер телефона.</param>
        public Contact(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Создает пустой экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact() { }
    }
}