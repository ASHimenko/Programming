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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ObjectOrientedPractics.Model.Item;

namespace ObjectOrientedPractics.View.Tabs
{
    
    public partial class ItemsTab : UserControl
    {
        private List<Item> _items = new List<Item>();
        private Item _currentItem;

        /// <summary>
        /// Флаг режима редактирования.
        /// </summary>
        private bool _isEditing = false;

        /// <summary>
        /// Инициализирует новый экземпляр класса ItemsTab.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки вкладки.
        /// </summary>
        private void ItemsTab_Load(object sender, EventArgs e)
        {
            UpdateListBox();
            ClearInputs();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить товар".
        /// </summary>
        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBoxName.Text;
                var info = textBoxInfo.Text;
                var cost = double.Parse(textBoxCost.Text);
                var newItem = new Item(name, info, cost);
                _items.Add(newItem);

                UpdateListBox();
                ClearInputs();

                _currentItem = null;
                ItemsListBox.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Редактировать/Сохранить".
        /// </summary>
        private void buttonEditItems_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                // Режим сохранения изменений
                try
                {
                    _currentItem.Name = textBoxName.Text;
                    _currentItem.Info = textBoxInfo.Text;
                    _currentItem.Cost = double.Parse(textBoxCost.Text);

                    _isEditing = false;
                    buttonEditItems.Text = "Edit";
                    ItemsListBox.Enabled = true;
                    buttonAddItems.Enabled = true;
                    buttonRemoveItems.Enabled = true;

                    UpdateListBox();
                    MessageBox.Show("Изменения сохранены", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentItem = null;
                    ItemsListBox.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Режим начала редактирования
                if (_currentItem == null)
                {
                    MessageBox.Show("Выберите товар для редактирования", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _isEditing = true;
                buttonEditItems.Text = "Save";
                ItemsListBox.Enabled = false;
                buttonAddItems.Enabled = false;
                buttonRemoveItems.Enabled = false;
            }
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
            else
            {
                _currentItem = null;
                ClearInputs();
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
        }

        /// <summary>
        /// Обновляет отображение списка товаров.
        /// </summary>
        private void UpdateListBox()
        {
            int selectedIndex = ItemsListBox.SelectedIndex;
            ItemsListBox.DataSource = null;
            ItemsListBox.DataSource = _items;

            // Восстанавливаем выделение после обновления
            if (selectedIndex >= 0 && selectedIndex < _items.Count)
            {
                ItemsListBox.SelectedIndex = selectedIndex;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле "Название".
        /// </summary>
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (_currentItem != null && !string.IsNullOrEmpty(textBoxName.Text))
            {
                try
                {
                    _currentItem.Name = textBoxName.Text;
                    
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
            if (_currentItem != null && !string.IsNullOrEmpty(textBoxInfo.Text))
            {
                try
                {
                    _currentItem.Info = textBoxInfo.Text;
                    
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