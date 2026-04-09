using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    /// <summary>
    /// Представляет модель данных для контакта.
    /// </summary>
    public class Contact : INotifyPropertyChanged, IDataErrorInfo
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

        private bool _isValidationActive = false;

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
                _name = value;
                _isValidationActive = true;
                OnPropertyChanged();
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
                _email = value;
                _isValidationActive = true;
                OnPropertyChanged();
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
                _id = value;
                OnPropertyChanged();
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
                _phoneNumber = value;
                _isValidationActive = true;
                OnPropertyChanged();
            }
        }

        public string Error => null;

        public void ActivateValidation()
        {
            _isValidationActive = true;
            OnPropertyChanged("");
        }

        public string this[string columnName]
        {
            get
            {
                if (!_isValidationActive) return string.Empty;

                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            error = "Имя не может быть пустым";
                        break;

                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            error = "Номер телефона обязателен";
                        else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneNumber, @"^[\d\+\-\(\) ]+$"))
                            error = "Номер содержит недопустимые символы";
                        break;

                    case nameof(Email):
                        if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
                            error = "Некорректный Email";
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

        /// <summary>
        /// Событие, возникающее при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомляет систему привязок об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}