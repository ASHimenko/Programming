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
    public partial class MainForm : Form
    {
        private Store _store = new Store();
        public MainForm()
        {
            InitializeComponent();
            GenerateDefaultCustomers();
            GenerateDefaultItems();

            // Передача данных вкладкам
            this.CustomersTab.Customers = _store.Customers;
            this.ItemsTab.Items = _store.Items;
            this.CartsTab.Customers = _store.Customers;
            this.CartsTab.Items = _store.Items;

            CartsTab.Items = _store.Items;
            CartsTab.Customers = _store.Customers;
            this.Tabs.SelectedIndexChanged += new EventHandler(this.Tabs_SelectedIndexChanged);
        }

        private void GenerateDefaultCustomers()
        {
            if (_store == null)
            {
                _store = new Store();
            }

            var address1 = new Address("450000", "Россия", "Башкортостан", "Ленина", "10", "1");
            var address2 = new Address("123456", "Россия", "Москва", "Тверская", "5", "10");
            var address3 = new Address("654321", "Россия", "Санкт-Петербург", "Невский", "25", "3");
            var address4 = new Address("300000", "Россия", "Тульская", "Мира", "7", "2");
            var address5 = new Address("987654", "Россия", "Краснодарский", "Приморская", "1", "1");

            _store.Customers.Add(new Customer("Иванов Иван Иванович", address1));
            _store.Customers.Add(new Customer("Петров Петр Петрович", address2));
            _store.Customers.Add(new Customer("Сидорова Анна Сергеевна", address3));
            _store.Customers.Add(new Customer("Кузнецов Олег Викторович", address4));
            _store.Customers.Add(new Customer("Васильева Елена Игоревна", address5));
        }

        private void GenerateDefaultItems()
        {
            if (_store == null)
            {
                _store = new Store();
            }

            _store.Items.Add(new Item("Смартфон X100", "Флагманский телефон с тройной камерой.", "75000,00", Category.Electronics));
            _store.Items.Add(new Item("Ноутбук Pro", "Ультрабук для профессиональной работы.", "120000,50", Category.Electronics));
            _store.Items.Add(new Item("Чайник электрический", "Быстрый нагрев, объем 1.7 л.", "2500,00", Category.Electronics));
            _store.Items.Add(new Item("Кофеварка рожковая", "Для приготовления эспрессо и капучино.", "15000,99", Category.Home));
            _store.Items.Add(new Item("Книга 'C# для профи'", "Подробное руководство по .NET Core.", "1890,00", Category.Books));
            _store.Items.Add(new Item("Мышь беспроводная", "Эргономичный дизайн, сенсор 16000 dpi.", "4200,00", Category    .Electronics));
            _store.Items.Add(new Item("Ковер шерстяной", "Ручная работа, размер 2x3 метра.", "35000,00", Category.Home));
            _store.Items.Add(new Item("Лампа настольная LED", "Гибкая стойка, 3 режима освещения.", "1550,00", Category.Home));
            _store.Items.Add(new Item("Набор посуды 'Стандарт'", "12 предметов из нержавеющей стали.", "8999,00", Category.Home));
            _store.Items.Add(new Item("Фитнес-браслет Z3", "Мониторинг сна и активности.", "3100,00",   Category.Electronics));
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Tabs.SelectedTab == this.tabPage1)
            {
                this.CartsTab.RefreshData();
            }
            
        }
    }
}
