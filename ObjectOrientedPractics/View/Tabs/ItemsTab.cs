using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    
    public partial class ItemsTab : UserControl
    {
        private List<Item> _items = new List<Item>();
        private Item _currentItem;

        /// <summary>
        /// Инициализирует новый экземпляр класса ItemsTab.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
        }

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
        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var info = textBoxInfo.Text;
            var cost = double.Parse(textBoxCost.Text);
            _currentItem = new Item(name, info, cost);
            _items.Add(_currentItem);

            UpdateListBox();

            _currentItem = null;
            UpdateInputs();


        }


        /// <summary>
        /// Обработчик нажатия кнопки "Удалить товар".
        /// </summary>
        private void buttonRemoveItems_Click(object sender, EventArgs e)
        {
            if (_currentItem == null)
            {
                MessageBox.Show("Выберите товар для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить товар '{_currentItem.Name}'?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _items.Remove(_currentItem);
                UpdateListBox();
                ClearInputs();
                _currentItem = null;
            }
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
            textBoxName.Clear();
            textBoxInfo.Clear();
            textBoxCost.Clear();
        }

        /// <summary>
        /// Обновляет поля ввода данными текущего товара.
        /// </summary>
        private void UpdateInputs()
        {
            if (_currentItem != null)
            {
                textBoxName.Text = _currentItem.Name;
                textBoxInfo.Text = _currentItem.Info;
                textBoxCost.Text = _currentItem.Cost.ToString();
            }
            else
            {
                textBoxName.Clear();
                textBoxInfo.Clear();
                textBoxCost.Clear();

            }
        }

        /// <summary>
        /// Обновляет отображение списка товаров.
        /// </summary>
        private void UpdateListBox()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
        
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Название".
        /// </summary>
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                try
                {
                    _currentItem.Name = textBoxName.Text;
                    UpdateListBox();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Описание".
        /// </summary>
        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                try
                {
                    _currentItem.Info = textBoxInfo.Text;
                    UpdateListBox();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Стоимость".
        /// </summary>
        private void textBoxCost_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && !string.IsNullOrEmpty(textBoxCost.Text))
            {
                try
                {
                    _currentItem.Cost = double.Parse(textBoxCost.Text);
                    UpdateListBox();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}