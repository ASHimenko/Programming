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
using View.Model.Services;

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
        /// Флаг режима редактирования существующего контакта.
        /// </summary>
        private bool _isEditing = false;

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
                if (_isEditing || _isAdding)
                {
                    _isEditing = false;
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
        /// Команда для перехода в режим редактирования.
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Команда для удаления выбранного контакта.
        /// </summary>
        public ICommand RemoveCommand { get; }

        /// <summary>
        /// Конструктор MainVM.
        /// </summary>
        public MainVM()
        {
            Contacts = ContactSerializer.Load() ?? new ObservableCollection<Contact>(); ;

            AddCommand = new RelayCommand(obj => ExecuteAdd());
            EditCommand = new RelayCommand(obj => ExecuteEdit(), obj => SelectedContact != null);
            RemoveCommand = new RelayCommand(obj => ExecuteRemove(), obj => SelectedContact != null);
            ApplyCommand = new RelayCommand(obj => ExecuteApply());
        }

        /// <summary>
        /// Логика нажатия кнопки Add. Сбрасывает выделение и готовит пустые поля.
        /// </summary>
        private void ExecuteAdd()
        {
            SelectedContact = null;
            _isAdding = true;
            _isEditing = false;

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
            if (_isAdding)
            {
                int newId = 1;
                if (Contacts.Count > 0)
                {
                    newId = Contacts.Max(c => c.Id) + 1;
                }

                SelectedContact.Id = newId;
                Contacts.Add(SelectedContact);
                _isAdding = false;
            }

            if (_isEditing)
            {
                _isEditing = false;
            }

            ContactSerializer.Save(Contacts);
            IsReadOnly = true;
            ApplyButtonVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Логика удаления выбранного контакта.
        /// </summary>
        private void ExecuteRemove()
        {
            if (SelectedContact == null) return;

            int index = Contacts.IndexOf(SelectedContact);

            Contacts.Remove(SelectedContact);
            
            if (Contacts.Count > 0)
            {
                if (index >= Contacts.Count)
                {
                    index = Contacts.Count - 1;
                }

                SelectedContact = Contacts[index];
            }
            else
            {
                SelectedContact = null;
            }

            ContactSerializer.Save(Contacts);
        }

        /// <summary>
        /// Логика нажатия кнопки Edit.
        /// </summary>
        private void ExecuteEdit()
        {
            _isEditing = true;
            _isAdding = false;
            IsReadOnly = false;
            ApplyButtonVisibility = Visibility.Visible;
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