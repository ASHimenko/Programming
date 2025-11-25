using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Вкладка для управления товарами (добавление, редактирование, удаление).
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Текущий выбранный товар.
        /// </summary>
        private Item _currentItem;

        /// <summary>
        /// Инициализирует новый экземпляр класса ItemsTab.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
        }

        /// <summary>
        /// Возвращает или задает список товаров.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                UpdateListBox();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить товар".
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)
                || string.IsNullOrWhiteSpace(InfoTextBox.Text)
                || string.IsNullOrWhiteSpace(CostTextBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(CostTextBox.Text, out double numberValue))
            {
                MessageBox.Show("Стоимость товара должна быть вещественным числом", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numberValue > 100000 || numberValue < 0)
            {
                MessageBox.Show("Стоимость товара должна быть в диапазоне от 0 до 100000", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var name = NameTextBox.Text;
            var info = InfoTextBox.Text;
            var cost = CostTextBox.Text;
            Category category = (Category)CategoryComboBox.SelectedItem;
            _currentItem = new Item(name, info, cost, category);

            _items.Add(_currentItem);
            UpdateListBox();
            _currentItem = null;
            UpdateInputs();

        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить товар".
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _items.Remove(_currentItem);
            UpdateListBox();
            ClearInputs();
            _currentItem = null;

        }

        /// <summary>
        /// Обработчик изменения выбранного элемента в списке товаров.
        /// </summary>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex != -1)
            {
                _currentItem = _items[ItemsListBox.SelectedIndex];
                UpdateInputs();
            }
        }

        /// <summary>
        /// Очищает поля ввода.
        /// </summary>
        private void ClearInputs()
        {
            NameTextBox.Clear();
            InfoTextBox.Clear();
            CostTextBox.Clear();
        }

        /// <summary>
        /// Обновляет поля ввода данными текущего товара.
        /// </summary>
        private void UpdateInputs()
        {
            if (_currentItem != null)
            {
                NameTextBox.Text = _currentItem.Name;
                InfoTextBox.Text = _currentItem.Info;
                CostTextBox.Text = _currentItem.Cost.ToString();
                CategoryComboBox.SelectedItem = _currentItem.Category;
            }
            else
            {
                NameTextBox.Clear();
                InfoTextBox.Clear();
                CostTextBox.Clear();
                CategoryComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Обновляет отображение списка товаров.
        /// </summary>
        private void UpdateListBox()
        {
            if (_items == null)
            {
                return;
            }

            ItemsListBox.Items.Clear();

            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Название".
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                _currentItem.Name = NameTextBox.Text;
                UpdateListBox();
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Описание".
        /// </summary>
        private void InfoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                _currentItem.Info = InfoTextBox.Text;
                UpdateListBox();
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Стоимость".
        /// </summary>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && !string.IsNullOrEmpty(CostTextBox.Text))
            {
                _currentItem.Cost = CostTextBox.Text;
                UpdateListBox();
            }
            
        }

        /// <summary>
        /// Обработчик изменения выбранной категории в выпадающем списке.
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                _currentItem.Category = (Category)CategoryComboBox.SelectedIndex;
                UpdateListBox();
            }
        }

    }
}