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
    public partial class PriorityOrdersTab : UserControl
    {
        /// <summary>
        /// Текущий редактируемый приоритетный заказ.
        /// State Pattern: хранит текущее состояние редактируемого объекта
        /// Model Entity: представляет бизнес-сущность приоритетного заказа. 
        /// (Исправлено: должно быть PriorityOrder, а не общий Order)
        /// </summary>
        private Model.PriorityOrder _selectedOrder;

        /// <summary>
        /// Список всех доступных товаров из Store.
        /// Dependency Injection: зависимость от внешнего источника данных
        /// Repository Pattern: обеспечивает доступ к каталогу товаров
        /// </summary>
        private List<Model.Item> _storeItems;

        /// <summary>
        /// Генератор случайных чисел для выбора товара.
        /// Helper Class: вспомогательный класс для реализации функционала "Add Item"
        /// </summary>
        private Random _random = new Random();

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
        /// Свойство для установки списка товаров извне.
        /// Property with Side Effects: устанавливает контекст данных для добавления товаров
        /// Data Context: устанавливает контекст данных для работы с товарами
        /// </summary>
        public List<Model.Item> StoreItems
        {
            get => _storeItems;
            set => _storeItems = value;
        }

        /// <summary>
        /// Возвращает или задает выбранное время доставки заказа.
        /// </summary>
        public string DeliveryTime { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PriorityOrdersTab"/>.
        /// Constructor: выполняет начальную настройку компонентов и данных
        /// UI Initialization: настраивает источники данных и обработчики событий
        /// </summary>
        public PriorityOrdersTab()
        {
            InitializeComponent();
            
            DeliveryTimeComboBox.DataSource = _deliveryTimeSlots;

            DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
            AddItemButton.Click += AddItemButton_Click;
            RemoveItemButton.Click += RemoveItemButton_Click;
            ClearOrderButton.Click += ClearOrderButton_Click; 
        }

        /// <summary>
        /// Синхронизирует ListBox товаров заказа с моделью данных.
        /// Data Synchronization: обновляет UI ListBox на основе данных в Cart
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки "Add Item". Добавляет случайный товар в заказ.
        /// </summary>
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (_selectedOrder == null || _storeItems == null || _storeItems.Count == 0)
            {
                MessageBox.Show("Невозможно добавить товар. Заказ не выбран или список товаров пуст.",
                                "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int randomIndex = _random.Next(0, _storeItems.Count);
            Model.Item itemToAdd = _storeItems[randomIndex];

            if (_selectedOrder.Cart == null)
            {
                _selectedOrder.Cart = new Model.Cart();
            }

            _selectedOrder.Cart.Items.Add(itemToAdd);

            UpdateSelectedOrderControls(_selectedOrder);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить товар" из заказа.
        /// Удаляет выбранный товар из текущего заказа и обновляет отображение.
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки "Очистить заказ".
        /// Очищает элементы управления выбранного заказа и создает новый приоритетный заказ.
        /// </summary>
        private void ClearOrderButton_Click(object sender, EventArgs e)
        {
            ClearSelectedOrderControls();
            CreateNewPriorityOrder();
        }

        /// <summary>
        /// Очищает элементы управления выбранного заказа и сбрасывает ссылку на объект.
        /// UI Reset: сброс всех элементов управления в исходное состояние
        /// </summary>
        private void ClearSelectedOrderControls()
        {
            _selectedOrder = null;

            IdTextBox.Text = string.Empty;
            CreatedTextBox.Text = string.Empty;
            StatusComboBox.SelectedIndex = -1;
            AmountLabel.Text = "0,00";

            DeliveryTimeComboBox.SelectedIndex = -1;

            AddressControl.ClearAddress();

            OrderItemsListBox.Items.Clear();

        }

        /// <summary>
        /// Создает новый пустой экземпляр приоритетного заказа и отображает его на вкладке.
        /// Factory Pattern: создает новый экземпляр PriorityOrder
        /// State Update: устанавливает новый заказ как текущий редактируемый
        /// </summary>
        private void CreateNewPriorityOrder()
        {
            Model.PriorityOrder newOrder = new Model.PriorityOrder();

            _selectedOrder = newOrder;

            UpdateSelectedOrderControls(newOrder);
        }

        /// <summary>
        /// Обновляет элементы управления данными выбранного заказа.
        /// Data Binding: синхронизация UI с данными текущего PriorityOrder
        /// Type Check: проверка типа для доступа к свойствам PriorityOrder
        /// </summary>
        /// <param name="order">Выбранный заказ (ожидается PriorityOrder).</param>
        private void UpdateSelectedOrderControls(Model.Order order)
        {
            if (order == null)
            {
                ClearSelectedOrderControls();
                return;
            }

            if (!(order is Model.PriorityOrder priorityOrder)) 
            {
                ClearSelectedOrderControls();
                MessageBox.Show("Данный заказ не является приоритетным и не может быть обработан на этой вкладке.",
                                "Неверный тип заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selectedOrder = priorityOrder;
            IdTextBox.ReadOnly = true;
            CreatedTextBox.ReadOnly = true;

            try
            {
                IdTextBox.Text = order.Id.ToString();
                CreatedTextBox.Text = order.Date.ToString();
                StatusComboBox.SelectedItem = order.OrderStatus;
                AmountLabel.Text = order.Amount.ToString("F2");

                DeliveryTimeComboBox.SelectedItem = priorityOrder.DeliveryTime; 

                if (order.DeliveryAddress != null)
                {
                    AddressControl.Address = new Model.Address(
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
                    AddressControl.Address = new Model.Address();
                }

                OrderItemsListBox.Items.Clear();
                if (order.Cart?.Items != null)
                {
                    foreach (var item in order.Cart.Items)
                    {
                        OrderItemsListBox.Items.Add($"{item.Name} ({item.Cost:F2})");
                    }
                }
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// Обработчик события изменения времени доставки.
        /// Обновляет модель _selectedOrder строковым значением.
        /// </summary>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedOrder != null && DeliveryTimeComboBox.SelectedItem != null)
            {
                string selectedTime = DeliveryTimeComboBox.SelectedItem.ToString();

                _selectedOrder.DeliveryTime = selectedTime;
            }
        }
    }
}
