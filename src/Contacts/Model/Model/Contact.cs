using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Model
{
    /// <summary>
    /// Представляет модель данных для контакта.
    /// </summary>
    public class Contact : ObservableObject, IDataErrorInfo
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
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                SetProperty(ref _name, value);
            }
        }

        /// <summary>
        /// Возвращает или задает адрес электронной почты.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetProperty(ref _email, value);
            }
        }

        /// <summary>
        /// Возвращает или задает уникальный идентификатор контакта.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                SetProperty(ref _id, value);
            }
        }

        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                SetProperty(ref _phoneNumber, value);
            }
        }

        /// <summary>
        /// Свойство Error
        /// </summary>
        public string Error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Получает сообщение об ошибке для свойства с указанным именем.
        /// </summary>
        /// <param name="columnName">Имя проверяемого свойства.</param>
        /// <returns>Строка с текстом ошибки или пустая строка, если данные верны.</returns>
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            error = "Имя не может быть пустым";
                        else if (Name.Length > 100)
                            error = "Имя не должно превышать 100 символов";
                        break;

                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            error = "Номер телефона обязателен";
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneNumber, @"^[\d\+\-\(\) ]+$"))
                            error = "Номер содержит недопустимые символы";
                        else if (PhoneNumber.Length > 100)
                            error = "Номер телефона не должен превышать 100 символов";
                        break;

                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email))
                            error = "Почта обязательна";
                        else if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
                            error = "Некорректный Email";
                        else if (Email.Length > 100)
                            error = "Почта не должна превышать 100 символов";
                        break;
                }
                return error;
            }
        }

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