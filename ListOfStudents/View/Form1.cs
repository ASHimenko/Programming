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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ListOfStudents
{
    public partial class StudentsForm : Form
    {
        // Основная коллекция студентов (привязана к ListBox)
        private BindingList<Student> _students = new BindingList<Student>();

        // Генератор случайных чисел для тестовых данных
        private Random _random = new Random();

        // Текущий редактируемый студент
        private Student _currentStudentForEdit;

        // Флаг режима редактирования
        private bool _isEditMode = false;

        // Имя файла для сохранения данных
        private const string DataFileName = "students.dat";

        public StudentsForm()
        {
            InitializeComponent();
            InitializeControls();// Настройка элементов управления
            LoadStudentsFromFile(); // Загрузка данных при запуске
            this.FormClosing += StudentsForm_FormClosing; // Обработчик закрытия формы
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

        // Генерация тестовых данных
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

        // Сортировка студентов по ФИО
        private void SortStudents()
        {
            var sorted = new BindingList<Student>(_students.OrderBy(s => s.FullName).ToList());
            _students = sorted;
            StudentsListBox.DataSource = _students;
        }

        // Обработчик кнопки "Добавить/Сохранить"
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupTextBox.Text) ||
                string.IsNullOrWhiteSpace(RecordBookIdTextBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            // Проверка ФИО
            if (!IsValidName(FullNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректное ФИО (только буквы и пробелы)",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                
                return;
            }

            // Проверка группы
            if (!IsValidNumber(GroupTextBox.Text))
            {
                MessageBox.Show("Номер группы должен содержать только цифры",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                
                return;
            }

            // Проверка зачетной книжки
            if (!IsValidRecordBookId(RecordBookIdTextBox.Text))
            {
                MessageBox.Show("Номер зачётной книжки должен содержать ровно 6 цифр",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                
                return;
            }


            if (_isEditMode)
            {
                SaveEditedStudent(); 
                return;
            }

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

        // Очистка полей ввода
        private void ClearInputs()
        {
            FullNameTextBox.Clear();
            GroupTextBox.Clear();
            RecordBookIdTextBox.Clear();
            FacultyComboBox.SelectedIndex = 0;
            EducationFormComboBox.SelectedIndex = 0;
        }

        // Удаление выбранного студента
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItem != null)
            {
                _students.Remove((Student)StudentsListBox.SelectedItem);
            }
        }


        private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentStudentForEdit == null)
            {
                EditButton.Enabled = StudentsListBox.SelectedItem != null;
            }
        }

        
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ограничение длины
            if (FullNameTextBox.Text.Length > 200)
            {
                FullNameTextBox.Text = FullNameTextBox.Text.Substring(0, 200);
                FullNameTextBox.SelectionStart = 200;
                return;
            }

            // Валидация символов
            if (!IsValidName(FullNameTextBox.Text))
            {
                MessageBox.Show("ФИО может содержать только буквы, пробелы и дефисы",
                              "Ошибка ввода",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                FullNameTextBox.Focus();
            }

        }

        private void GroupTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ограничение длины
            if (GroupTextBox.Text.Length > 10)
            {
                GroupTextBox.Text = GroupTextBox.Text.Substring(0, 10);
                GroupTextBox.SelectionStart = 10;
                return;
            }

            // Валидация цифр
            if (!IsValidNumber(GroupTextBox.Text))
            {
                MessageBox.Show("Номер группы должен содержать только цифры",
                              "Ошибка ввода",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                GroupTextBox.Focus();
            }
        
        }

        // Редактирование выбранного студента
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите студента для редактирования");
                return;
            }

            _isEditMode = true;
            _currentStudentForEdit = (Student)StudentsListBox.SelectedItem;

            FullNameTextBox.Text = _currentStudentForEdit.FullName;
            GroupTextBox.Text = _currentStudentForEdit.Group;
            FacultyComboBox.SelectedItem = _currentStudentForEdit.Faculty;
            EducationFormComboBox.SelectedItem = _currentStudentForEdit.EducationForm;

            UpdateUIState();
        }

        // Сохранение отредактированного студента
        private void SaveEditedStudent()
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupTextBox.Text))
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }

            // Создаем нового студента с обновленными данными
            var updatedStudent = new Student(
                fullName: FullNameTextBox.Text,
                recordBookId: _currentStudentForEdit.RecordBookId, // Сохраняем оригинальный ID
                group: GroupTextBox.Text,
                faculty: (Faculty)FacultyComboBox.SelectedItem,
                educationForm: (EducationForm)EducationFormComboBox.SelectedItem
            );

            // Удаляем старого студента
            _students.Remove(_currentStudentForEdit);

            // Добавляем обновленного студента
            _students.Add(updatedStudent);

            SortStudents();
            ExitEditMode();
        }

        // Выход из режима редактирования
        private void ExitEditMode()
        {
            _isEditMode = false;
            _currentStudentForEdit = null;
            ClearInputs();
            UpdateUIState();
        }

        // Обновление состояния элементов интерфейса
        private void UpdateUIState()
        {
            AddButton.Text = _isEditMode ? "Save" : "Add";
            EditButton.Enabled = !_isEditMode && StudentsListBox.SelectedItem != null;
            DeleteButton.Enabled = !_isEditMode && StudentsListBox.SelectedItem != null;
            CancelEditButton.Visible = _isEditMode;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            ExitEditMode();
        }

        private void StudentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveStudentsToFile();
        }

        // Работа с файлами
        private void SaveStudentsToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(DataFileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, _students.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void LoadStudentsFromFile()
        {
            if (File.Exists(DataFileName))
            {
                try
                {
                    using (FileStream fs = new FileStream(DataFileName, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        List<Student> loadedStudents = (List<Student>)formatter.Deserialize(fs);
                        _students = new BindingList<Student>(loadedStudents);
                        StudentsListBox.DataSource = _students;
                        SortStudents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                    // Если не удалось загрузить, создаем тестовые данные
                    GenerateTestData();
                }
            }
            else
            {
                GenerateTestData();
            }
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-');
        }

        private bool IsValidNumber(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   input.All(char.IsDigit);
        }

        private void RecordBookIdTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ограничение длины (не более 6 цифр)
            if (RecordBookIdTextBox.Text.Length > 6)
            {
                RecordBookIdTextBox.Text = RecordBookIdTextBox.Text.Substring(0, 6);
                RecordBookIdTextBox.SelectionStart = 6;
                return;
            }

            // Валидация цифр
            if (!string.IsNullOrEmpty(RecordBookIdTextBox.Text) &&
        !IsDigitsOnly(RecordBookIdTextBox.Text))
            {
                MessageBox.Show("Номер зачётной книжки должен содержать только цифры",
                              "Ошибка ввода",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }

        private bool IsValidRecordBookId(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
           input.Length == 6 &&
           input.All(char.IsDigit);
        }

        private bool IsDigitsOnly(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   input.All(char.IsDigit);
        }
    }
}