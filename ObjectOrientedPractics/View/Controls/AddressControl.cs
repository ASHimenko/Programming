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

namespace ObjectOrientedPractics.View.Controls
{
    /// <summary>
    /// Элемент управления для ввода и редактирования адреса.
    /// </summary>
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Объект адреса для редактирования.
        /// </summary>
        private Address _address = new Address();
        private bool _isUpdatingFromExternal = false;

        /// <summary>
        /// Инициализирует новый экземпляр класса AddressControl.
        /// </summary>
        public AddressControl()
        {

            InitializeComponent();
            _address = new Address();
            UpdateControlsFromAddress();

        }

        /// <summary>
        /// Возвращает или задает адрес. При установке обновляет отображение контролов.
        /// </summary>
        public Address Address
        {
            get => _address;
            set
            {
                if (_address == null)
                {
                    _address = new Address();
                }
                _address = value;
                _isUpdatingFromExternal = true;
                UpdateControlsFromAddress();
                _isUpdatingFromExternal = false;
                
            }
        }


        /// <summary>
        /// Обновляет поля ввода данными из объекта адреса.
        /// </summary>
        private void UpdateControlsFromAddress()
        {
            if (_address == null)
            {
                _address = new Address();
            }
            IndexTextBox.Text = _address.Index;
            CountryTextBox.Text = _address.Country;
            CityTextBox.Text = _address.City;
            StreetTextBox.Text = _address.Street;
            BuildingTextBox.Text = _address.Building;
            ApartmentTextBox.Text = _address.Apartment;

        }

        public event EventHandler AddressChanged;

        /// <summary>
        /// Обновляет объект адреса данными из полей ввода.
        /// </summary>
        private void UpdateAddressFromControls()
        {
            if (_isUpdatingFromExternal) return;

            _address.Index = IndexTextBox.Text;
            _address.Country = CountryTextBox.Text;
            _address.City = CityTextBox.Text;
            _address.Street = StreetTextBox.Text;
            _address.Building = BuildingTextBox.Text;
            _address.Apartment = ApartmentTextBox.Text;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ClearFields()
        {
            StreetTextBox.Clear();
            CityTextBox.Clear();
            IndexTextBox.Clear();
            CountryTextBox.Clear();
            BuildingTextBox.Clear();
            ApartmentTextBox.Clear();
        }
        public void ClearAddress()
        {
            // Предполагается, что это имена ваших текстовых полей внутри AddressControl
            IndexTextBox.Text = string.Empty;
            CountryTextBox.Text = string.Empty;
            CityTextBox.Text = string.Empty;
            StreetTextBox.Text = string.Empty;
            BuildingTextBox.Text = string.Empty;
            ApartmentTextBox.Text = string.Empty;

            // Также можно сбросить внутреннее поле _address
            this.Address = new Address();
        }

        // Обработчики событий изменения текста
        private void IndexTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }
        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }

        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAddressFromControls();
        }


    }
}
