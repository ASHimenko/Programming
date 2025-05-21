using ListOfStudents.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListOfStudents
{
    public partial class StudentsForm : Form
    {
        private BindingList<Student> _students = new BindingList<Student>();
        private Random _random = new Random();

        public StudentsForm()
        {
            InitializeComponent();
            InitializeControls();
            GenerateTestData();
        }

        private void InitializeControls()
        {
            // Настройка ComboBox для факультета
            FacultyComboBox.DataSource = Enum.GetValues(typeof(Faculty));

            // Настройка ComboBox для формы обучения
            EducationFormComboBox.DataSource = Enum.GetValues(typeof(EducationForm));

            // Настройка ListBox
            StudentsListBox.DataSource = _students;
            StudentsListBox.DisplayMember = "ToString";
        }

        private void GenerateTestData()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    fullName: $"Иванов Иван Иванович {i}",
                    recordBookId: _random.Next(100000, 999999),
                    group: $"ГР-{_random.Next(1, 20)}",
                    faculty: (Faculty)_random.Next(0, 4),
                    educationForm: (EducationForm)_random.Next(0, 3)
                ));
            }
            SortStudents();
        }

        private void SortStudents()
        {
            var sorted = new BindingList<Student>(_students.OrderBy(s => s.FullName).ToList());
            _students = sorted;
            StudentsListBox.DataSource = _students;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
            string.IsNullOrWhiteSpace(GroupTextBox.Text))
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }

            _students.Add(new Student(
                fullName: FullNameTextBox.Text,
                recordBookId: _random.Next(100000, 999999),
                group: GroupTextBox.Text,
                faculty: (Faculty)FacultyComboBox.SelectedItem,
                educationForm: (EducationForm)EducationFormComboBox.SelectedItem
            ));

            SortStudents();
            ClearInputs();
        }

        private void ClearInputs()
        {
            FullNameTextBox.Clear();
            GroupTextBox.Clear();
            FacultyComboBox.SelectedIndex = 0;
            EducationFormComboBox.SelectedIndex = 0;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItem != null)
            {
                _students.Remove((Student)StudentsListBox.SelectedItem);
            }
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FullNameTextBox.Text.Length > 200)
            {
                FullNameTextBox.Text = FullNameTextBox.Text.Substring(0, 200);
                FullNameTextBox.SelectionStart = 200;
            }

        }

        private void GroupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GroupTextBox.Text.Length > 10)
            {
                FullNameTextBox.Text = FullNameTextBox.Text.Substring(0, 10);
                GroupTextBox.SelectionStart = 10;
            }
        }

        private void RecordBookIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
