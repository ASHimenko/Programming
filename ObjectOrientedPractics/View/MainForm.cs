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


namespace ObjectOrientedPractics
{
    /// <summary>
    /// Главное окно приложения (точка входа в пользовательский интерфейс).
    /// Выступает в роли координатора, управляющего данными и взаимодействием между вкладками.
    /// </summary>
    public partial class MainForm : Form
    {
        
        private Store _store = new Store();
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            
            InitializeComponent();

            GenerateDefaultCustomers();
            GenerateDefaultItems();
            GenerateDefaultOrders();

            this.CustomersTab.Customers = _store.Customers;
            this.ItemsTab.Items = _store.Items;
            this.CartsTab.Customers = _store.Customers;
            this.CartsTab.Items = _store.Items;
            this.OrdersTab.Customers = _store.Customers;
            this.CartsTab.OrderCreated += CartsTab_OrderCreated;

            this.Tabs.SelectedIndexChanged += new EventHandler(this.Tabs_SelectedIndexChanged);
        }
        
        /// <summary>
        /// Создает 5 тестовых покупателей и добавляет их в список Store.Customers.
        /// </summary>
        private void GenerateDefaultCustomers()
        {

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
            
            if (_store == null)
            {
                _store = new Store();
            }

            // Добавление товаров в список Store.Items.
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
        /// Создает тестовые заказы и присваивает их соответствующим покупателям.
        /// </summary>
        private void GenerateDefaultOrders()
        {

            var customer1 = _store.Customers[0];
            var customer2 = _store.Customers[1];
            var customer3 = _store.Customers[2];
            var address1 = customer1.Address; 
            var address2 = customer2.Address;
            var address3 = customer3.Address;

            var cart1 = new Cart();
            cart1.Items.Add(_store.Items[0]);
            cart1.Items.Add(_store.Items[4]); 

            var order1 = new Order
            {
                Cart = cart1,
                Customer = customer1,
                DeliveryAddress = address1,
                OrderStatus = ObjectOrientedPractics.Model.OrderStatus.Processing
            };

            var cart2 = new Cart();
            cart2.Items.Add(_store.Items[7]);

            var order2 = new Order
            {
                Cart = cart2,
                Customer = customer2,
                DeliveryAddress = address2,
                OrderStatus = ObjectOrientedPractics.Model.OrderStatus.New
            };

            var cart3 = new Cart();
            cart3.Items.Add(_store.Items[1]); 

            var order3 = new Order
            {
                Cart = cart3,
                Customer = customer3,
                DeliveryAddress = address3,
                OrderStatus = ObjectOrientedPractics.Model.OrderStatus.Delivered
            };

            customer1.Orders = new List<Order>() { order1 };
            customer2.Orders = new List<Order>() { order2 };
            customer3.Orders = new List<Order>() { order3 };
        }

        /// <summary>
        /// Обработчик события смены выбранной вкладки в TabControl.
        /// Используется для синхронизации данных при переходе на вкладку Carts.
        /// </summary>
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.Tabs.SelectedTab == this.tabPage1)
            {
                
                this.CartsTab.RefreshData();
            }

            if (Tabs.SelectedTab == tabPage4) 
            {
                this.OrdersTab.RefreshData(this._store.Customers);
            }
        }

        /// <summary>
        /// Обработчик события создания нового заказа на вкладке CartsTab.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="newOrder">Новый созданный заказ.</param>
        private void CartsTab_OrderCreated(object sender, Order newOrder)
        {
            this.OrdersTab.UpdateOrders();
        }


    }
}