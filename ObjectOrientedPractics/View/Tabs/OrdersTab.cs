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
        /// Сохраняет ссылку на _selectedOrder, только если он является PriorityOrder.
        /// </summary>
        private PriorityOrder _selectedPriorityOrder;

        /// <summary>
        /// Список временных интервалов для доставки заказов.
        /// </summary>
        private List<string> _deliveryTimeSlots = new List<string>
        {
            "9:00 – 11:00",
            "11:00 – 13:00",
            "13:00 – 15:00",
            "15:00 – 17:00",
            "17:00 – 19:00"
        };

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

                DeliveryTimeComboBox.DataSource = _deliveryTimeSlots;
                DeliveryTimeComboBox.SelectedIndex = -1;
                OrderItemsListBox.Enabled = false;
                DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
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
            if (_customers == null)
            {
                _orders.Clear();

                OrdersDataGridView.DataSource = null;
                return;
            }

            _orders.Clear();
            var customersSource = _customers ?? new List<Customer>();
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
                HidePriorityOptions();
                return;
            }

            _selectedOrder = order;
            _selectedPriorityOrder = null;

            try
            {
                StatusComboBox.SelectedIndexChanged -= StatusComboBox_SelectedIndexChanged;
                DeliveryTimeComboBox.SelectedIndexChanged -= DeliveryTimeComboBox_SelectedIndexChanged;

                IdTextBox.Text = order.Id.ToString();
                CreatedTextBox.Text = order.Date.ToString();
                StatusComboBox.SelectedItem = order.OrderStatus;
                AmountLabel.Text = order.Amount.ToString("F2");

                var customer = FindCustomerByOrder(order);

                if (order is PriorityOrder priorityOrder || (customer != null && customer.IsPriority))
                {
                    if (order is PriorityOrder finalPriorityOrder)
                    {
                        _selectedPriorityOrder = finalPriorityOrder;
                        ShowPriorityOptions();
                        DeliveryTimeComboBox.SelectedItem = finalPriorityOrder.DeliveryTime;
                    }
                    else
                    {
                        _selectedPriorityOrder = null;
                        HidePriorityOptions();
                    }
                }
                else
                {
                    _selectedPriorityOrder = null;
                    HidePriorityOptions();
                }


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
                DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
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

        /// <summary>
        /// Обработчик события изменения времени доставки.
        /// Real-time Update: мгновенное применение изменений к модели данных
        /// Data Binding: синхронизация выбора в UI с свойством модели
        /// </summary>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_selectedOrder != null && DeliveryTimeComboBox.SelectedItem != null)
            {
                string selectedTime = DeliveryTimeComboBox.SelectedItem.ToString();

                _selectedOrder.DeliveryTime = selectedTime;

                OrdersDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Скрывает элементы управления для приоритетных опций.
        /// </summary>
        private void HidePriorityOptions()
        {
            DeliveryTimeLabel.Visible = false;
            PriorityOptionsLabel.Visible = false;
            DeliveryTimeComboBox.Visible = false;
            DeliveryTimeComboBox.SelectedIndex = -1; 
        }

        /// <summary>
        /// Показывает элементы управления для приоритетных опций.
        /// </summary>
        private void ShowPriorityOptions()
        {
            DeliveryTimeLabel.Visible = true;
            PriorityOptionsLabel.Visible = true;
            DeliveryTimeComboBox.Visible = true;
        }

        /// <summary>
        /// Находит покупателя по заданному заказу.
        /// </summary>
        /// <param name="order">Заказ для поиска.</param>
        /// <returns>Объект Customer или null, если не найден.</returns>
        private Customer FindCustomerByOrder(Order order)
        {
            if (order == null || _customers == null)
            {
                return null;
            }

            string customerFullName = order.CustomerFullName; 
            return _customers.FirstOrDefault(c => c.FullName == customerFullName);
        }
    }
}
