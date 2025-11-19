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
    public partial class PriorityOrdersTab : OrdersTab
    {
        private Model.Order _selectedOrder;

        private List<Model.Item> _storeItems;

        public PriorityOrdersTab()
        {
            InitializeComponent();

            DeliveryTimeComboBox.DataSource = Enum.GetValues(typeof(Model.DeliveryTimeSlot));

            DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
        }

        public void SynOrderItemsListBox()
        {
            OrderItemsListBox.Items.Clear();
            if (_selectedOrder?.Cart?.Items != null)
            {
                foreach (var item in _selectedOrder.Cart.Items)
                {
                    OrderItemsListBox.Items.Add(item.Name);
                }
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (_selectedOrder == null || _storeItems == null)
            {
                MessageBox.Show("Сначала выберите заказ и убедитесь, что товары доступны.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random random = new Random();
            int randomIndex = random.Next(_storeItems.Count);
            Model.Item randomItem = _storeItems[randomIndex];

            if (_selectedOrder.Cart == null)
            {
                _selectedOrder.Cart = new Model.Cart();
            }
            _selectedOrder.Cart.Items.Add(randomItem);

            SynOrderItemsListBox();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (_selectedOrder == null || OrderItemsListBox.SelectedIndex == -1)
            {
                return;
            }

            int selectedIndex = OrderItemsListBox.SelectedIndex;

            _selectedOrder.Cart.Items.RemoveAt(selectedIndex);

            SynOrderItemsListBox();

            if (OrderItemsListBox.Items.Count > 0)
            {
                if (selectedIndex < OrderItemsListBox.Items.Count)
                {
                    OrderItemsListBox.SelectedIndex = selectedIndex;
                }
                else
                {
                    OrderItemsListBox.SelectedIndex = OrderItemsListBox.Items.Count - 1;
                }
            }
        }

        private void ClearOrderButton_Click(object sender, EventArgs e)
        {
            _selectedOrder = null;

            ClearSelectedOrderControls();

            CreateNewPriorityOrder();
        }

        /// <summary>
        /// Очищает элементы управления выбранного заказа и сбрасывает ссылку на объект.
        /// </summary>
        private void ClearSelectedOrderControls()
        {
            _selectedOrder = null;

            // Сброс полей заказа
            IdTextBox.Text = string.Empty;
            CreatedTextBox.Text = string.Empty;
            StatusComboBox.SelectedIndex = -1;
            AmountLabel.Text = "0,00";

            // Сброс полей адреса
            AddressControl.ClearAddress(); // Предполагается наличие такого метода в AddressControl

            // Сброс списка товаров
            OrderItemsListBox.Items.Clear();

        }

        /// <summary>
        /// Создает новый пустой экземпляр приоритетного заказа и отображает его на вкладке.
        /// </summary>
        private void CreateNewPriorityOrder()
        {
            PriorityOrder newOrder = new PriorityOrder();

            _selectedOrder = newOrder;

            UpdateSelectedOrderControls(newOrder);

        }

        // Внутри класса PriorityOrdersTab : OrdersTab
        // Инициализация ComboBox должна быть в конструкторе PriorityOrdersTab()!

        /// <summary>
        /// Обновляет элементы управления данными выбранного заказа,
        /// добавляя логику для PriorityOrder.
        /// </summary>
        protected override void UpdateSelectedOrderControls(Order order)
        {
            // 1. Вызываем базовую реализацию для заполнения ID, Created, Status и т.д.
            base.UpdateSelectedOrderControls(order);

            // 2. Дополнительная логика для PriorityOrder
            try
            {
                // Временно отписываем обработчик
                DeliveryTimeComboBox.SelectedIndexChanged -= DeliveryTimeComboBox_SelectedIndexChanged;

                // --- Логика PriorityOrder ---
                if (order is PriorityOrder priorityOrder)
                {
                    // Здесь мы не скрываем панель, предполагая, что она всегда видна на этой вкладке.
                    DeliveryTimeComboBox.SelectedItem = priorityOrder.DeliveryTime;
                }
                else
                {
                    // Если почему-то сюда попал обычный Order, сбрасываем поле PriorityTime
                    DeliveryTimeComboBox.SelectedIndex = -1;
                }
            }
            finally
            {
                // Восстанавливаем обработчик
                DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
            }
        }

        // Внутри класса PriorityOrdersTab : OrdersTab
        /// <summary>
        /// Обработчик события изменения времени доставки.
        /// </summary>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран именно PriorityOrder
            if (_selectedOrder is PriorityOrder priorityOrder && DeliveryTimeComboBox.SelectedItem != null)
            {
                // Обновляем модель данных
                priorityOrder.DeliveryTime = (Model.DeliveryTimeSlot)DeliveryTimeComboBox.SelectedItem;
            }
        }
    }
}
