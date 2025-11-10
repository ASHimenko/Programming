using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Пространство имен приложения
namespace ObjectOrientedPractics
{
    /// <summary>
    /// Главное окно приложения (точка входа в пользовательский интерфейс).
    /// Выступает в роли координатора, управляющего данными и взаимодействием между вкладками.
    /// </summary>
    public partial class MainForm : Form
    {
        // Закрытое поле, содержащее всю бизнес-логику (списки товаров и покупателей).
        private Store _store = new Store();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            // Метод, сгенерированный дизайнером, который инициализирует все визуальные компоненты.
            InitializeComponent();

            // Заполнение списков покупателей и товаров тестовыми данными для отладки.
            GenerateDefaultCustomers();
            GenerateDefaultItems();

            // Присвоение списков товаров и покупателей свойствам соответствующих UserControl'ов (вкладок).
            this.CustomersTab.Customers = _store.Customers;
            this.ItemsTab.Items = _store.Items;
            this.CartsTab.Customers = _store.Customers;
            this.CartsTab.Items = _store.Items;
            this.OrdersTab.Customers = _store.Customers;
            this.CartsTab.OrderCreated += CartsTab_OrderCreated;

            // Подписка на событие смены вкладки в элементе управления Tabs (TabControl).
            // При смене вкладки будет вызван метод Tabs_SelectedIndexChanged.
            this.Tabs.SelectedIndexChanged += new EventHandler(this.Tabs_SelectedIndexChanged);
        }
        
        /// <summary>
        /// Создает 5 тестовых покупателей и добавляет их в список Store.Customers.
        /// </summary>
        private void GenerateDefaultCustomers()
        {
            // Проверка, необходимая только в том случае, если поле _store было бы null.
            if (_store == null)
            {
                _store = new Store();
            }

            // Создание тестовых объектов Address.
            var address1 = new Address("450000", "Россия", "Башкортостан", "Ленина", "10", "1");
            var address2 = new Address("123456", "Россия", "Москва", "Тверская", "5", "10");
            var address3 = new Address("654321", "Россия", "Санкт-Петербург", "Невский", "25", "3");
            var address4 = new Address("300000", "Россия", "Тульская", "Мира", "7", "2");
            var address5 = new Address("987654", "Россия", "Краснодарский", "Приморская", "1", "1");

            // Создание новых покупателей и добавление их в список Store.
            _store.Customers.Add(new Customer("Иванов Иван Иванович", address1));
            _store.Customers.Add(new Customer("Петров Петр Петрович", address2));
            _store.Customers.Add(new Customer("Сидорова Анна Сергеевна", address3));
            _store.Customers.Add(new Customer("Кузнецов Олег Викторович", address4));
            _store.Customers.Add(new Customer("Васильева Елена Игоревна", address5));
        }

        /// <summary>
        /// Создает 10 тестовых товаров и добавляет их в список Store.Items.
        /// Использует строковый тип для стоимости (Cost) и enum Category.
        /// </summary>
        private void GenerateDefaultItems()
        {
            // Проверка инициализации Store.
            if (_store == null)
            {
                _store = new Store();
            }

            // Добавление товаров в список Store.Items.
            // Примечание: Стоимость передается как строка (например, "75000,00").
            _store.Items.Add(new Item("Смартфон X100", "Флагманский телефон с тройной камерой.", "75000,00", Category.Electronics));
            _store.Items.Add(new Item("Ноутбук Pro", "Ультрабук для профессиональной работы.", "120000,50", Category.Electronics));
            _store.Items.Add(new Item("Чайник электрический", "Быстрый нагрев, объем 1.7 л.", "2500,00", Category.Electronics));
            _store.Items.Add(new Item("Кофеварка рожковая", "Для приготовления эспрессо и капучино.", "15000,99", Category.Home));
            _store.Items.Add(new Item("Книга 'C# для профи'", "Подробное руководство по .NET Core.", "1890,00", Category.Books));
            _store.Items.Add(new Item("Мышь беспроводная", "Эргономичный дизайн, сенсор 16000 dpi.", "4200,00", Category.Electronics));
            _store.Items.Add(new Item("Ковер шерстяной", "Ручная работа, размер 2x3 метра.", "35000,00", Category.Home));
            _store.Items.Add(new Item("Лампа настольная LED", "Гибкая стойка, 3 режима освещения.", "1550,00", Category.Home));
            _store.Items.Add(new Item("Набор посуды 'Стандарт'", "12 предметов из нержавеющей стали.", "8999,00", Category.Home));
            _store.Items.Add(new Item("Фитнес-браслет Z3", "Мониторинг сна и активности.", "3100,00", Category.Electronics));
        }

        /// <summary>
        /// Обработчик события смены выбранной вкладки в TabControl.
        /// Используется для синхронизации данных при переходе на вкладку Carts.
        /// </summary>
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, совпадает ли выбранная вкладка с вкладкой CartsTab (tabPage1).
            // (Предполагается, что CartsTab размещен в tabPage1).
            if (this.Tabs.SelectedTab == this.tabPage1)
            {
                // Вызываем метод обновления данных на вкладке CartsTab.
                // Это гарантирует, что списки товаров и покупателей будут актуальными.
                this.CartsTab.RefreshData();
            }
        }

        private void CartsTab_OrderCreated(object sender, Order newOrder)
        {
            this.OrdersTab.UpdateOrders();
        }
    }
}