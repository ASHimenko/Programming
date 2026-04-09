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
        /// Поле для редактирования текущего выбранного контакта.
        /// </summary>
        private Contact _editingContact;

        /// <summary>
        /// Поле, определяющее, доступны ли поля для редактирования.
        /// </summary>
        private bool _isReadOnly = true;

        /// <summary>
        /// Флаг, блокирующий все кнопки во время операций.
        /// </summary>
        private bool _isBusy;

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
        /// Флаг, указывающий, находится ли приложение в режиме удаления контакта.
        /// </summary>
        private bool _isRemove = false;

        /// <summary>
        /// Свойство для привязки IsEnabled кнопок.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set 
            { 
                _isBusy = value; 
                OnPropertyChanged(); 
            }
        }
        
        /// <summary>
        /// Флаг, показывающий, что идет редактирование или добавление.
        /// </summary>
        public bool IsEditingOrAdding => _isEditing || _isAdding;

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
                if ((_isAdding || _isEditing) && value != null && value != _selectedContact)
                {
                    CancelCurrentOperation();
                }

                _selectedContact = value;
                OnPropertyChanged();

                IsReadOnly = true;
                ApplyButtonVisibility = Visibility.Collapsed;

                if (_selectedContact != null && !_isEditing && !_isAdding)
                {
                    EditingContact = new Contact
                    {
                        Id = _selectedContact.Id,
                        Name = _selectedContact.Name,
                        PhoneNumber = _selectedContact.PhoneNumber,
                        Email = _selectedContact.Email
                    };
                }
            }
        }

        /// <summary>
        /// Отменяет текущую операцию.
        /// </summary>
        private void CancelCurrentOperation()
        {
            if (_isAdding)
            {
                _isAdding = false;
                EditingContact = new Contact();
            }

            if (_isEditing)
            {
                _isEditing = false;
            }

            IsBusy = false;
            ApplyButtonVisibility = Visibility.Collapsed;
            IsReadOnly = true;
        }

        /// <summary>
        /// Временный контакт для редактирования.
        /// </summary>
        public Contact EditingContact
        {
            get => _editingContact;
            set { _editingContact = value; OnPropertyChanged(); }
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
            //EditingContact = new Contact();
            IsBusy = false;

            AddCommand = new RelayCommand(obj => ExecuteAdd(), obj => !IsBusy);
            EditCommand = new RelayCommand(obj => ExecuteEdit(), obj => SelectedContact != null && !IsBusy);
            RemoveCommand = new RelayCommand(obj => ExecuteRemove(), obj => SelectedContact != null && !IsBusy);
            ApplyCommand = new RelayCommand(obj => ExecuteApply(), obj => CanApply());
        }

        private bool CanApply()
        {
            if (EditingContact == null) return false;

            return string.IsNullOrEmpty(EditingContact[nameof(Contact.Name)]) &&
                   string.IsNullOrEmpty(EditingContact[nameof(Contact.PhoneNumber)]) &&
                   string.IsNullOrEmpty(EditingContact[nameof(Contact.Email)]);
        }

        /// <summary>
        /// Логика нажатия кнопки Add. Сбрасывает выделение и готовит пустые поля.
        /// </summary>
        private void ExecuteAdd()
        {
            SelectedContact = new Contact();
            _isAdding = true;
            _isEditing = false;
            _isRemove = false;
            IsBusy = true;

            EditingContact = new Contact();

            IsReadOnly = false;
            CommandManager.InvalidateRequerySuggested();
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

                EditingContact.Id = newId;
                Contacts.Add(EditingContact);
                SelectedContact = EditingContact;
                _isAdding = false;
            }

            if (_isEditing)
            {
                var originalContact = Contacts.FirstOrDefault(c => c.Id == EditingContact.Id);
                if (originalContact != null)
                {
                    originalContact.Name = EditingContact.Name;
                    originalContact.PhoneNumber = EditingContact.PhoneNumber;
                    originalContact.Email = EditingContact.Email;

                    SelectedContact = originalContact;
                }

                _isEditing = false;
            }

            ContactSerializer.Save(Contacts);
            IsReadOnly = true;
            IsBusy = false;
            CommandManager.InvalidateRequerySuggested();
            ApplyButtonVisibility = Visibility.Collapsed;
            EditingContact = null;
        }

        /// <summary>
        /// Логика удаления выбранного контакта.
        /// </summary>
        private void ExecuteRemove()
        {
            if (SelectedContact == null) return;

            _isAdding = false;
            _isEditing = false;
            _isRemove = true;

            int index = Contacts.IndexOf(SelectedContact);

            if (_isRemove)
            {
                Contacts.Remove(SelectedContact);
            }

            if (index == -1)
            {
                return;
            }

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

            _isRemove = false;
            ContactSerializer.Save(Contacts);
        }

        /// <summary>
        /// Логика нажатия кнопки Edit.
        /// </summary>
        private void ExecuteEdit()
        {
            if (SelectedContact == null) return;

            EditingContact = new Contact
            {
                Id = SelectedContact.Id,
                Name = SelectedContact.Name,
                PhoneNumber = SelectedContact.PhoneNumber,
                Email = SelectedContact.Email
            };

            _isEditing = true;
            _isAdding = false;
            _isRemove= false;
            IsReadOnly = false;
            IsBusy = true;
            ApplyButtonVisibility = Visibility.Visible;
            CommandManager.InvalidateRequerySuggested();
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