using Programming.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();

            SeasonComboBox.DataSource = Enum.GetValues(typeof(Season));
            SeasonComboBox.SelectedIndex = 0;

            EnumsListBox.Items.Add("Weekday");
            EnumsListBox.Items.Add("Genre");
            EnumsListBox.Items.Add("Color");
            EnumsListBox.Items.Add("EducationForm");
            EnumsListBox.Items.Add("SmartphoneManufacturer");
            EnumsListBox.Items.Add("Season");

            EnumsListBox.SelectedIndex = 0;
        }

        private void EnumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValuesListBox.Items.Clear();

            string selectedEnum = EnumsListBox.SelectedItem.ToString();

            switch (selectedEnum)
            {
                case "Weekday":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(Weekday)).Cast<object>().ToArray());
                    break;
                case "Genre":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(Genre)).Cast<object>().ToArray());
                    break;
                case "Color":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(Colors)).Cast<object>().ToArray());
                    break;
                case "EducationForm":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(EducationForm)).Cast<object>().ToArray());
                    break;
                case "SmartphoneManufacturer":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(SmartphoneManufacturer)).Cast<object>().ToArray());
                    break;
                case "Season":
                    ValuesListBox.Items.AddRange(Enum.GetValues(typeof(Season)).Cast<object>().ToArray());
                    break;
            }
        }

        private void ValuesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValuesListBox.SelectedItem != null)
            {
                var selectedValue = ValuesListBox.SelectedItem;

                // Преобразуем значение в целое число
                int numericValue = (int)selectedValue;

                // Отображаем числовое значение в TextBox
                ValueTextBox.Text = numericValue.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox.Text;

            if (Enum.TryParse(inputText, true, out Weekday weekday))
            {
                int numericValue = (int)weekday;
                ResultLabel.Text = $"Этот день недели ({weekday} = {numericValue})";
            }
            else
            {
                ResultLabel.Text = "Нет такого дня недели";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Season selectedSeason = (Season)SeasonComboBox.SelectedItem;

            switch (selectedSeason)
            {
                case Season.Summer:
                    MessageBox.Show("Ура! Солнце!", "Лето", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Season.Autumn:
                    this.BackColor = Color.FromArgb(0xE2, 0x9C, 0x45);
                    break;
                case Season.Winter:
                    MessageBox.Show("Брр! Холодно!", "Зима", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Season.Spring:
                    this.BackColor = Color.FromArgb(0x55, 0x9C, 0x45);
                    break;
            }
        }
    }
}
