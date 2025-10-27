using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CartsTab : UserControl
    {
        public CartsTab()
        {
            InitializeComponent();
            UpdateItemsListBox();
            UpdateCustomersComboBox();
            CustomerComboBox.SelectedIndexChanged += CustomerComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Возвращает или задает список товаров, доступных для корзин.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возвращает или задает список покупателей, для которых создаются корзины.
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Текущий выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

        private void UpdateItemsListBox()
        {
            if (Items==null || ItemsListBox == null)
            {
                return;
            }

            ItemsListBox.Items.Clear();
            foreach (var item in Items)
            {
                ItemsListBox.Items.Add(item);
            }
        }

        private void UpdateCustomersComboBox()
        {
            if (Customers == null || CustomerComboBox == null)
            {
                return;
            }

            CustomerComboBox.Items.Clear();

            foreach (var customer in Customers)
            {
                CustomerComboBox.Items.Add(customer);
            }
        }

        private void UpdateCartsListBox()
        {
            if (CartsListBox == null)
            {
                return;
            }
            CartsListBox.Items.Clear();

            // Если покупатель выбран и у него есть корзина, отображаем товары
            if (_currentCustomer != null && _currentCustomer.Cart != null)
            {
                foreach(var item in _currentCustomer.Cart.Items)
                {
                    CartsListBox.Items.Add($"{item.Name} - {item.Cost}");
                }
            }
        }

        private void UpdatePriceLabel()
        {
            if (PriceLabel == null)
            {
                return;
            }

            double totalCost = 0;

            if (_currentCustomer != null && _currentCustomer.Cart != null)
            {
                foreach ( var item in _currentCustomer.Cart.Items)
                {
                    totalCost += double.Parse(item.Cost);
                }
            }

            PriceLabel.Text = totalCost.ToString();
        }

        /// <summary>
        /// Обработчик: При выборе покупателя в ComboBox, обновляет список корзины.
        /// </summary>
        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerComboBox.SelectedIndex == -1 || Customers == null)
            {
                _currentCustomer = null;
            }
            else
            {
                _currentCustomer = Customers[CustomerComboBox.SelectedIndex];
            }

            UpdateCartsListBox();
            UpdatePriceLabel();
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            //Проверки
            if (_currentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ItemsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Item selectedItem = Items[ItemsListBox.SelectedIndex];
            _currentCustomer.Cart.Items.Add(selectedItem);

            UpdateCartsListBox();
            UpdatePriceLabel();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (CartsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentCustomer.Cart.Items.RemoveAt(CartsListBox.SelectedIndex);

            UpdateCartsListBox();
            UpdatePriceLabel();
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            //Проверки
            if (_currentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            if (_currentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newOrder = new Order();
            var orderCart = new Cart();
            orderCart.Items = new List<Item>(_currentCustomer.Cart.Items);

            newOrder.Cart = orderCart;
            newOrder.DeliveryAddress = _currentCustomer.Address;

            if (_currentCustomer.Orders == null)
            {
                _currentCustomer.Orders = new List<Order>();
            }
            _currentCustomer.Orders.Add(newOrder);

            _currentCustomer.Cart.Items.Clear();
            UpdateCartsListBox();
            UpdatePriceLabel();
        }

        public void RefreshData()
        {
            UpdateItemsListBox();
            UpdateCustomersComboBox();

            if (_currentCustomer != null)
            {
                UpdateCartsListBox();
                UpdatePriceLabel();
            }
            else
            {
                CartsListBox.Items.Clear();
                PriceLabel.Text = "0,00";
            }
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                MessageBox.Show("Сначала выберите покупателя, корзину которого нужно очистить.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentCustomer.Cart != null && _currentCustomer.Cart.Items != null)
            {
                _currentCustomer.Cart.Items.Clear();
            }

            UpdateCartsListBox();
            UpdatePriceLabel();
        }
    }
}
