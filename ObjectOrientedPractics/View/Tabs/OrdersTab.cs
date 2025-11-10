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
    public partial class OrdersTab : UserControl
    {
        private List<Customer> _customers;
        private List<Order> _orders;
        private Order _selectedOrder;

        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                UpdateOrders();

                StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));

                OrdersDataGridView.SelectionChanged += OrdersDataGridView_SelectionChanged;
                StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            }
        }

        public OrdersTab()
        {
            InitializeComponent();
            _orders = new List<Order>();
            OrdersDataGridView.AutoGenerateColumns = false;
        }

       public void UpdateOrders()
        {
            if (_customers == null)
            {
                _orders.Clear();
                OrdersDataGridView.DataSource = null;
                return;
            }

            _orders.Clear();
            _orders.AddRange(_customers.SelectMany(customer => customer.Orders));

            OrdersDataGridView.DataSource = null;
            OrdersDataGridView.DataSource = _orders;

            if (OrdersDataGridView.Columns.Count == 0 || OrdersDataGridView.Columns["IdColumn"] == null)
            {
                return;
            }

            OrdersDataGridView.Columns["IdColumn"].DataPropertyName = "Id";
            OrdersDataGridView.Columns["DataColumn"].DataPropertyName = "Date";
            OrdersDataGridView.Columns["CustomerFullNameColumn"].DataPropertyName = "CustomerFullName";
            OrdersDataGridView.Columns["DeliveryAddressColumn"].DataPropertyName = "DeliveryAddressString"; 
            OrdersDataGridView.Columns["AmountColumn"].DataPropertyName = "Amount";
            OrdersDataGridView.Columns["StatusColumn"].DataPropertyName = "OrderStatus";

            if (_orders.Count > 0)
            {
                // Сначала очищаем выбор, чтобы предотвратить сбои
                OrdersDataGridView.ClearSelection();

                // Устанавливаем выбор на первую строку
                OrdersDataGridView.Rows[0].Selected = true;
            }
            else
            {
                // Если заказов нет, очищаем правую панель (запускает ClearSelectedOrderControls через SelectionChanged)
                OrdersDataGridView_SelectionChanged(null, null);
            }

            OrdersDataGridView.Refresh();
        }

        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count == 0)
            {
                ClearSelectedOrderControls();
                return;
            }

            // 2. Получаем выбранный объект Order
            Order selectedOrder = OrdersDataGridView.SelectedRows[0].DataBoundItem as Order;

            // 3. Обновляем правую панель
            UpdateSelectedOrderControls(selectedOrder);
        }

        private void ClearSelectedOrderControls()
        {
            _selectedOrder = null;

            // Предполагается, что Id, Created - TextBoxes, Amount - Label, Items - ListBox
            IdTextBox.Text = string.Empty;
            CreatedTextBox.Text = string.Empty;
            StatusComboBox.SelectedIndex = -1; // Сброс выбора статуса

            AddressControl.ClearAddress();

            OrderItemsListBox.Items.Clear();
            AmountLabel.Text = "0,00";
        }

        private void UpdateSelectedOrderControls(Order order)
        {
            if (order == null)
            {
                ClearSelectedOrderControls();
                return;
            }

            _selectedOrder = order;

            // 1. Отображение данных заказа
            IdTextBox.Text = order.Id.ToString();
            CreatedTextBox.Text = order.Date.ToString();
            StatusComboBox.SelectedItem = order.OrderStatus;
            AmountLabel.Text = order.Amount.ToString();

            // 2. Отображение адреса (предполагается, что DeliveryAddress не null)
            AddressControl.Address = order.DeliveryAddress;

            // 3. Отображение списка товаров (в ListBox)
            OrderItemsListBox.Items.Clear();
            foreach (var item in order.Cart.Items)
            {
                OrderItemsListBox.Items.Add(item.Name);
            }

            // **ВАЖНО:** Остальные поля (кроме StatusComboBox) должны быть ReadOnly
            // Это можно настроить в дизайнере или в конструкторе.
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedOrder == null || StatusComboBox.SelectedItem == null)
            {
                return;
            }

            // 2. Обновление статуса в модели
            // Предполагается, что StatusComboBox.SelectedItem имеет тип OrderStatus
            OrderStatus newStatus = (OrderStatus)StatusComboBox.SelectedItem;
            _selectedOrder.OrderStatus = newStatus;

            // 3. Обновляем DataGridView
            OrdersDataGridView.Refresh();
        }
    }
}
