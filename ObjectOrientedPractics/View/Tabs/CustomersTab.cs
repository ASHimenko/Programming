using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.View.Controls;
using ObjectOrientedPractics.View.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CustomersTab : UserControl
    {
        private List<Customer> _customers = new List<Customer>();
        private Customer _currentCustomer;
        public CustomersTab()
        {
            InitializeComponent();

            IsPriorityCheckBox.CheckedChanged += IsPriorityCheckBox_CheckedChanged;
        }

        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                UpdateListBox();
            }
        }

        /// <summary>
        /// Обновляет информацию о выбранном покупателе в элементах управления.
        /// </summary>
        private void UpdateCustomerInfo()
        {
            IsPriorityCheckBox.CheckedChanged += IsPriorityCheckBox_CheckedChanged;

            if (_currentCustomer != null)
            {
                IDTextBox.Text = _currentCustomer.Id.ToString();
                FullNameTextBox.Text = _currentCustomer.FullName;
                AddressControl.Address = _currentCustomer.Address;
            }
            else
            {
                IDTextBox.Clear();
                FullNameTextBox.Clear();
                AddressControl.ClearAddress();
            }

            IsPriorityCheckBox.CheckedChanged += IsPriorityCheckBox_CheckedChanged;
        }

        /// <summary>
        /// Обновляет список покупателей в ListBox.
        /// </summary>
        private void UpdateListBox()
        {
            if (_customers == null) return;

            CustomerListBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomerListBox.Items.Add(customer);
            }
        }

        /// <summary>
        /// Обновляет добавляет покупателей в ListBox.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Поле фамилия должно быть заполнено", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentCustomer = new Customer(FullNameTextBox.Text, AddressControl.Address);
            _customers.Add(_currentCustomer);

            UpdateListBox();
            _currentCustomer = null;
            UpdateCustomerInfo();
            AddressControl.ClearFields();
        }

        /// <summary>
        /// Обновляет удаляет покупателей в ListBox.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _customers.Remove(_currentCustomer);
            UpdateListBox();
            ClearInputs();
            _currentCustomer = null;

        }

        public void ClearInputs()
        {
            IDTextBox.Clear();
            FullNameTextBox.Clear();
            AddressControl.ClearFields();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentCustomer != null)
            {
                _currentCustomer.FullName = FullNameTextBox.Text;
                UpdateListBox();
            }
        }

        private void CustomerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerListBox.SelectedIndex != -1 && CustomerListBox.SelectedIndex < _customers.Count)
            {
                _currentCustomer = _customers[CustomerListBox.SelectedIndex];
                UpdateCustomerInfo();

            }
        }

        /// <summary>
        /// Обработчик события изменения состояния флажка "Is Priority".
        /// Сохраняет статус приоритета в текущем покупателе.
        /// </summary>
        private void IsPriorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                return;
            }

            _currentCustomer.IsPriority = IsPriorityCheckBox.Checked;

        }

        private void AddDiscountsButton_Click(object sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                MessageBox.Show("Сначала выберите покупателя.");
                return;
            }

            using (var form = new DiscountsTab())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Category selectedCategory = form.SelectedCategory;

                    PercentDiscount newDiscount = new PercentDiscount(selectedCategory);
                    _currentCustomer.Discounts.Add(newDiscount);

                    UpdateDiscountsListBox();
                }
            }
        }

        public void UpdateDiscountsListBox()
        {
            if (_currentCustomer == null) return;

            List<IDiscount> sortedDiscounts = SortDiscounts(_currentCustomer.Discounts);

            DiscountsListBox.DataSource = null; 
            DiscountsListBox.DataSource = sortedDiscounts;
            DiscountsListBox.DisplayMember = "Info";
        }

        /// <summary>
        /// Сортирует список скидок покупателя так, чтобы PointsDiscount всегда была первой.
        /// </summary>
        /// <param name="discounts">Список IDiscount покупателя.</param>
        /// <returns>Отсортированный список IDiscount.</returns>
        private List<IDiscount> SortDiscounts(List<IDiscount> discounts)
        {
            if (discounts == null) return new List<IDiscount>();

            IDiscount pointsDiscount = discounts.OfType<PointsDiscount>().FirstOrDefault();

            List<IDiscount> otherDiscounts = discounts.Where(d => !(d is PointsDiscount)).ToList();

            List<IDiscount> sortedList = new List<IDiscount>();

            if (pointsDiscount != null)
            {
                sortedList.Add(pointsDiscount);
            }

            sortedList.AddRange(otherDiscounts);

            return sortedList;
        }

        private void RemoveDiscountsButton_Click(object sender, EventArgs e)
        {
            if (DiscountsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите скидку для удаления.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IDiscount selectedDiscount = (IDiscount)DiscountsListBox.SelectedItem;

            if (selectedDiscount is PointsDiscount)
            {
                MessageBox.Show("Накопительную скидку нельзя удалить, она обязательна для покупателя.",
                                "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentCustomer.Discounts.Remove(selectedDiscount);

            UpdateDiscountsListBox();
        }
    }
}
