using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model;

namespace View.ViewModel
{
    /// <summary>
    /// Главная ViewModel приложения. 
    /// Связывает модель данных Contact с графическим интерфейсом (View).
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Закрытое поле для хранения текущего контакта
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Свойство для доступа к объекту контакта.
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(PhoneNumber));
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Прокси-свойство для Имени. Связывает TextBox с Contact.Name.
        /// </summary>
        public string Name
        {
            get => Contact.Name;
            set
            {
                Contact.Name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Прокси-свойство для Номера телефона.
        /// </summary>
        public string PhoneNumber
        {
            get => Contact.PhoneNumber;
            set
            {
                Contact.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Прокси-свойство для Электронной почты.
        /// </summary>
        public string Email
        {
            get => Contact.Email;
            set
            {
                Contact.Email = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда, которая будут привязана к кнопке "Сохранить".
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Команда, которая будут привязана к кнопке "Загрузить".
        /// </summary>
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Конструктор MainVM. 
        /// </summary>
        public MainVM()
        {
            Contact = new Contact();

            SaveCommand = new SaveCommand();
            LoadCommand = new LoadCommand();
        }

        /// <summary>
        /// Событие, которое сообщает интерфейсу, что какое-то свойство изменилось.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события обновления интерфейса.
        /// [CallerMemberName] автоматически подставляет имя свойства, из которого вызван метод.
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}