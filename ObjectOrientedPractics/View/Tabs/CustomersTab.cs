using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View.Controls;
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
                AddressControl.Address = new Address();
            }
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
    }
}
