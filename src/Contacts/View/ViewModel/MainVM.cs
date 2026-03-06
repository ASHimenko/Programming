using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        /// Поле для хранения коллекции контактов.
        /// </summary>
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Поле для хранения текущего выбранного контакта.
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Поле, определяющее, доступны ли поля для редактирования.
        /// </summary>
        private bool _isReadOnly = true;

        /// <summary>
        /// Поле, управляющее видимостью кнопки Apply.
        /// </summary>
        private Visibility _applyButtonVisibility = Visibility.Collapsed;

        /// <summary>
        /// Флаг, указывающий, находится ли приложение в режиме добавления нового контакта.
        /// </summary>
        private bool _isAdding = false;

        /// <summary>
        /// Коллекция контактов для отображения в списке слева.
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set { _contacts = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Текущий контакт, выбранный в ListBox.
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_isAdding)
                {
                    _isAdding = false;
                }

                _selectedContact = value;
                OnPropertyChanged();

                IsReadOnly = true;
                ApplyButtonVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Свойство для привязки к IsReadOnly текстовых полей.
        /// </summary>
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set { _isReadOnly = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство для привязки к Visibility кнопки Apply.
        /// </summary>
        public Visibility ApplyButtonVisibility
        {
            get => _applyButtonVisibility;
            set { _applyButtonVisibility = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Команда для инициации добавления нового контакта.
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// Команда для подтверждения добавления или редактирования контакта.
        /// </summary>
        public ICommand ApplyCommand { get; }

        /// <summary>
        /// Конструктор MainVM.
        /// </summary>
        public MainVM()
        {
            Contacts = new ObservableCollection<Contact>();

            AddCommand = new RelayCommand(obj => ExecuteAdd());

            ApplyCommand = new RelayCommand(obj => ExecuteApply());
        }

        /// <summary>
        /// Логика нажатия кнопки Add. Сбрасывает выделение и готовит пустые поля.
        /// </summary>
        private void ExecuteAdd()
        {
            _isAdding = true;
            SelectedContact = null;

            _selectedContact = new Contact();
            OnPropertyChanged(nameof(SelectedContact));

            IsReadOnly = false;
            ApplyButtonVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Логика нажатия кнопки Apply. Сохраняет новый контакт в список.
        /// </summary>
        private void ExecuteApply()
        {
            if (_isAdding && SelectedContact != null)
            {
                Contacts.Add(SelectedContact);
                _isAdding = false;
            }

            IsReadOnly = true;
            ApplyButtonVisibility = Visibility.Collapsed;
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