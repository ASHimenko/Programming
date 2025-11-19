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

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Вкладка для управления заказами покупателей.
    /// </summary>
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Список заказов.
        /// </summary>
        private List<Order> _orders;

        /// <summary>
        /// Выбранный заказ.
        /// </summary>
        private Order _selectedOrder;

        /// <summary>
        /// Возвращает или задает список покупателей.
        /// </summary>
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                UpdateOrders();

                OrderItemsListBox.Enabled = false;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            _orders = new List<Order>();
            OrdersDataGridView.AutoGenerateColumns = false;

            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));

            OrdersDataGridView.SelectionChanged += OrdersDataGridView_SelectionChanged;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Обновляет список заказов на основе данных о покупателях.
        /// </summary>
        public void UpdateOrders()
        {
            _orders.Clear();
            _orders.AddRange(_customers.SelectMany(customer => customer.Orders));

            OrdersDataGridView.DataSource = null;
            OrdersDataGridView.DataSource = _orders;

            ConfigureDataGridViewColumns();
        }

        /// <summary>
        /// Настраивает колонки DataGridView для отображения заказов.
        /// </summary>
        private void ConfigureDataGridViewColumns()
        {
            if (OrdersDataGridView.Columns["IdColumn"] != null)
            {
                OrdersDataGridView.Columns["IdColumn"].DataPropertyName = "Id";
                OrdersDataGridView.Columns["DataColumn"].DataPropertyName = "Date";
                OrdersDataGridView.Columns["CustomerFullNameColumn"].DataPropertyName = "CustomerFullName";
                OrdersDataGridView.Columns["DeliveryAddressColumn"].DataPropertyName = "DeliveryAddressString";
                OrdersDataGridView.Columns["AmountColumn"].DataPropertyName = "Amount";
                OrdersDataGridView.Columns["StatusColumn"].DataPropertyName = "OrderStatus";
            }
        }

        /// <summary>
        /// Обработчик события изменения выбранной строки в DataGridView.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Данные события.</param>
        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count == 0)
            {
                ClearSelectedOrderControls();
                return;
            }

            Order selectedOrder = OrdersDataGridView.SelectedRows[0].DataBoundItem as Order;

            UpdateSelectedOrderControls(selectedOrder);
        }

        /// <summary>
        /// Очищает элементы управления выбранного заказа.
        /// </summary>
        private void ClearSelectedOrderControls()
        {
            _selectedOrder = null;

            IdTextBox.Text = string.Empty;
            CreatedTextBox.Text = string.Empty;
            StatusComboBox.SelectedIndex = -1; 
            AmountLabel.Text = "0,00";

            AddressControl.ClearAddress();

            OrderItemsListBox.Items.Clear();
            
        }

        /// <summary>
        /// Обновляет элементы управления данными выбранного заказа.
        /// </summary>
        /// <param name="order">Выбранный заказ.</param>
        private void UpdateSelectedOrderControls(Order order)
        {
            if (order == null)
            {
                ClearSelectedOrderControls();
                return;
            }

            _selectedOrder = order;

            try
            {
                StatusComboBox.SelectedIndexChanged -= StatusComboBox_SelectedIndexChanged;

                IdTextBox.Text = order.Id.ToString();
                CreatedTextBox.Text = order.Date.ToString();
                StatusComboBox.SelectedItem = order.OrderStatus;
                AmountLabel.Text = order.Amount.ToString("F2");

                if (order.DeliveryAddress != null)
                {
                    AddressControl.Address = new Address(
                        order.DeliveryAddress.Index,
                        order.DeliveryAddress.Country,
                        order.DeliveryAddress.City,
                        order.DeliveryAddress.Street,
                        order.DeliveryAddress.Building,
                        order.DeliveryAddress.Apartment
                    );
                }
                else
                {
                    AddressControl.Address = new Address();
                }

                OrderItemsListBox.Items.Clear();
                if (order.Cart?.Items != null)
                {
                    foreach (var item in order.Cart.Items)
                    {
                        OrderItemsListBox.Items.Add(item.Name);
                    }
                }
            }
            finally
            {
                StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            }


        }

        /// <summary>
        /// Обработчик события изменения статуса заказа.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Данные события.</param>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedOrder == null || StatusComboBox.SelectedItem == null)
            {
                return;
            }

            OrderStatus newStatus = (OrderStatus)StatusComboBox.SelectedItem;
            _selectedOrder.OrderStatus = newStatus;

            OrdersDataGridView.Refresh();
        }

        /// <summary>
        /// Обновляет данные на вкладке OrdersTab, собирая все заказы всех покупателей.
        /// </summary>
        public void RefreshData(List<Customer> customers)
        {
            _customers = customers;

            UpdateOrders();
        }
    }
}
