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
using ModelRectangle = Programming.Model.Rectangle;

namespace Programming
{
    public partial class MainForm: Form
    {
        private ModelRectangle[] _rectangles;
        private ModelRectangle _currentRectangle;

        private Movie[] _movies;
        private Movie _currentMovie;

        private readonly List<ModelRectangle> rectangles;
        private Random _random;
        private ModelRectangle currentRectangle;
        private readonly List<Panel> _rectanglePanels;

        public MainForm()
        {
            InitializeComponent();

            _rectanglePanels = new List<Panel>();
            rectangles = new List<ModelRectangle>();
            _rectanglePanels = new List<Panel>();
            _random = new Random();

            RectanglesListBox.SelectedIndexChanged += RectanglesListBox_SelectedIndexChanged;

            SeasonComboBox.DataSource = Enum.GetValues(typeof(Season));
            SeasonComboBox.SelectedIndex = 0;

            EnumsListBox.Items.Add("Weekday");
            EnumsListBox.Items.Add("Genre");
            EnumsListBox.Items.Add("Color");
            EnumsListBox.Items.Add("EducationForm");
            EnumsListBox.Items.Add("SmartphoneManufacturer");
            EnumsListBox.Items.Add("Season");

            EnumsListBox.SelectedIndex = 0;

            _rectangles = new ModelRectangle[5];
            Random random = new Random();
            for (int i = 0; i < _rectangles.Length; i++)
            {
                double length = random.Next(1, 100);
                double width = random.Next(1, 100);
                Point2D center = new Point2D(random.Next(0, 100), random.Next(0, 100));
                _rectangles[i] = new ModelRectangle(length, width, "White", center);
                RectanglesListBox.Items.Add($"Rectangle {i + 1}");
            }

            _movies = new Movie[5];
            for (int i = 0; i < _movies.Length; i++)
            {
                _movies[i] = new Movie($"Movie {i + 1}", random.Next(60, 180), random.Next(1900, DateTime.Now.Year), "Action", random.Next(0, 11));
                MoviesListBox.Items.Add($"Movie {i + 1}");
            }

            RectanglesListBox.SelectedIndex = 0;
            MoviesListBox.SelectedIndex = 0;

            CenterXTextBox.ReadOnly = true;
            CenterYTextBox.ReadOnly = true;
            IdTextBox.ReadOnly = true;


            // Настройка начального состояния
            ClearRectangleFields();
            RemoveRectangleButton.Enabled = false;

            // Подписываемся на события
            AddRectangleButton.Click += AddRectangleButton_Click_1;
            RemoveRectangleButton.Click += RemoveRectangleButton_Click;
            RectanglesListBox1.SelectedIndexChanged += RectanglesListBox1_SelectedIndexChanged;


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

        private void RectanglesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = RectanglesListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                _currentRectangle = _rectangles[selectedIndex];
                UpdateRectangleFields();
            }
        }

        private void UpdateRectangleFields()
        {
            LengthTextBox.Text = _currentRectangle.Length.ToString();
            WidthTextBox.Text = _currentRectangle.Width.ToString();
            ColorTextBox.Text = _currentRectangle.Color.ToString();
            CenterXTextBox.Text = _currentRectangle.Center.X.ToString();
            CenterYTextBox.Text = _currentRectangle.Center.Y.ToString();
            IdTextBox.Text = _currentRectangle.Id.ToString();
        }

        private void UpdateMovieFields()
        {
            if (_currentRectangle != null)
            {
                TitleTextBox.Text = _currentMovie.Title;
                DurationTextBox.Text = _currentMovie.DurationMinutes.ToString();
                YearTextBox.Text = _currentMovie.ReleaseYear.ToString();
                GenreTextBox.Text = _currentMovie.Genre;
                RatingTextBox.Text = _currentMovie.Rating.ToString();
            }
        }

        private int FindRectangleWithMaxWidth(ModelRectangle[] rectangles)
        {
            int maxWidthIndex = 0;
            for (int i = 1; i < rectangles.Length; i++)
            {
                if (rectangles[i].Width > rectangles[maxWidthIndex].Width)
                {
                    maxWidthIndex = i;
                }
            }
            return maxWidthIndex;
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double length = double.Parse(LengthTextBox.Text);
                _currentRectangle.Length = length;
                LengthTextBox.BackColor = Color.White;
            }
            catch
            {
                LengthTextBox.BackColor = Color.LightPink;
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double width = double.Parse(WidthTextBox.Text);
                _currentRectangle.Width = width;
                WidthTextBox.BackColor = Color.White;
            }
            catch
            {
                WidthTextBox.BackColor = Color.LightPink;
            }
        }

        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentRectangle.Color = ColorTextBox.Text.ToString();
        }

        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = MoviesListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                _currentMovie = _movies[selectedIndex];
                UpdateMovieFields();
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            int maxWidthIndex = FindRectangleWithMaxWidth(_rectangles);
            RectanglesListBox.SelectedIndex = maxWidthIndex;
        }

        // lab 5

        private void ClearRectangleFields()
        {
            HeightTextBox.Text = "";
            WidthRecTextBox.Text = "";
            XTextBox.Text = "";
            YTextBox.Text = "";
            IdRecTextBox.Text = "";
        }
        private void AddRectangleButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Создаем новый временный список
                var tempList = _rectangles.ToList();

                double height = _random.Next(30, 100);
                double width = _random.Next(30, 100);
                int centerX = _random.Next(15, CanvasPanel.Width - (int)width / 2 - 15);
                int centerY = _random.Next(15, CanvasPanel.Height - (int)height / 2 - 15);

                // Добавляем новый прямоугольник
                var newRect = new ModelRectangle(height, width, "White", new Point2D(centerX, centerY));
                tempList.Add(newRect);
                _rectangles = tempList.ToArray(); // Возвращаем обратно в массив

                // Создаем панель
                var panel = new Panel
                {
                    Location = new Point(centerX - (int)width / 2, centerY - (int)height / 2),
                    Size = new Size((int)width, (int)height),
                    BackColor = Color.FromArgb(127, 127, 255, 127), // Полупрозрачный зеленый
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = _rectangles.Length - 1 // Сохраняем индекс
                };

                CanvasPanel.Controls.Add(panel);
                UpdateRectanglesList();
                FindCollisions();
                RemoveRectangleButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void FindCollisions()
        {
            foreach (Control control in CanvasPanel.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = Color.FromArgb(127, 127, 255, 127);
                }
            }

            // Проверяем пересечения
            for (int i = 0; i < _rectangles.Length; i++)
            {
                for (int j = i + 1; j < _rectangles.Length; j++)
                {
                    if (IsCollision(_rectangles[i], _rectangles[j]))
                    {
                        // Находим соответствующие панели
                        var panel1 = CanvasPanel.Controls.OfType<Panel>()
                            .FirstOrDefault(p => (int)p.Tag == i);
                        var panel2 = CanvasPanel.Controls.OfType<Panel>()
                            .FirstOrDefault(p => (int)p.Tag == j);

                        if (panel1 != null) panel1.BackColor = Color.FromArgb(127, 255, 127, 127);
                        if (panel2 != null) panel2.BackColor = Color.FromArgb(127, 255, 127, 127);
                    }
                }
            }
        }

        private bool IsCollision(ModelRectangle a, ModelRectangle b)
        {
            return Math.Abs(a.Center.X - b.Center.X) < (a.Width + b.Width) / 2 &&
                   Math.Abs(a.Center.Y - b.Center.Y) < (a.Length + b.Length) / 2;
        }

        private void RemoveRectangleButton_Click(object sender, EventArgs e)
        {
            if (RectanglesListBox.SelectedIndex == -1) return;

            int index = RectanglesListBox.SelectedIndex;

            // Удаляем панель
            var panelToRemove = CanvasPanel.Controls.OfType<Panel>()
                .FirstOrDefault(p => (int)p.Tag == index);
            if (panelToRemove != null)
            {
                CanvasPanel.Controls.Remove(panelToRemove);
            }

            // Обновляем массив
            var tempList = _rectangles.ToList();
            tempList.RemoveAt(index);
            _rectangles = tempList.ToArray();

            // Обновляем теги у оставшихся панелей
            for (int i = 0; i < CanvasPanel.Controls.Count; i++)
            {
                if (CanvasPanel.Controls[i] is Panel panel)
                {
                    panel.Tag = i;
                }
            }

            UpdateRectanglesList();
            FindCollisions();

            if (_rectangles.Length == 0)
            {
                ClearRectangleFields();
                RemoveRectangleButton.Enabled = false;
            }
        }

        private void UpdateRectanglesList()
        {
            RectanglesListBox.Items.Clear();
            for (int i = 0; i < _rectangles.Length; i++)
            {
                RectanglesListBox.Items.Add($"Rectangle {i + 1}");
            }
        }

        private void RectanglesListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RectanglesListBox1.SelectedIndex != -1 &&
                RectanglesListBox1.SelectedIndex < rectangles.Count)
            {
                _currentRectangle = _rectangles[RectanglesListBox1.SelectedIndex];
                UpdateRectangleFields();
            }
        }

    }
}
