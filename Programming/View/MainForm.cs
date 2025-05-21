using Programming.Model;
using Programming.Model.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Programming.MainForm;
using ModelRectangle = Programming.Model.Geometry.Rectangle;

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
        private readonly List<Panel> rectanglePanels;

        /// <summary>
        /// Конструктор формы MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Сброс счетчика для геометрических фигур
            Programming.Model.Geometry.Rectangle.ResetCounter();

            rectanglePanels = new List<Panel>();
            rectangles = new List<ModelRectangle>();
            _random = new Random();

            //RectanglesListBox1.SelectedIndexChanged += RectanglesListBox1_SelectedIndexChanged;
            // Настройка источника данных для ComboBox с сезонами
            SeasonComboBox.DataSource = Enum.GetValues(typeof(Season));
            SeasonComboBox.SelectedIndex = 0;

            // Добавление элементов в список EnumListBox
            EnumsListBox.Items.Add("Weekday");
            EnumsListBox.Items.Add("Genre");
            EnumsListBox.Items.Add("Color");
            EnumsListBox.Items.Add("EducationForm");
            EnumsListBox.Items.Add("SmartphoneManufacturer");
            EnumsListBox.Items.Add("Season");

            EnumsListBox.SelectedIndex = 0;

            // Инициализация массива прямоугольников
            _rectangles = new ModelRectangle[5];
            Random random = new Random();
            for (int i = 0; i < _rectangles.Length; i++)
            {
                double length = random.Next(1, 100);
                double width = random.Next(1, 100);
                Model.Geometry.Point2D center = new Model.Geometry.Point2D(random.Next(0, 100), random.Next(0, 100));
                _rectangles[i] = new ModelRectangle(length, width, "White", center);
                RectanglesListBox.Items.Add($"Rectangle {i + 1}");
            }

            // Инициализация массива фильмов
            _movies = new Movie[5];
            for (int i = 0; i < _movies.Length; i++)
            {
                _movies[i] = new Movie($"Movie {i + 1}", random.Next(60, 180), random.Next(1900, DateTime.Now.Year), "Action", random.Next(0, 11));
                MoviesListBox.Items.Add($"Movie {i + 1}");
            }

            // Установка выбранных элементов по умолчанию
            RectanglesListBox.SelectedIndex = 0;
            MoviesListBox.SelectedIndex = 0;

            // Сделать поля центра прямоугольника только для чтения
            CenterXTextBox.ReadOnly = true;
            CenterYTextBox.ReadOnly = true;
            IdTextBox.ReadOnly = true;

/*
            // Настройка начального состояния
            ClearRectangleFields();
            RemoveRectangleButton.Enabled = false;

            // Подписываемся на события
            AddRectangleButton.Click += AddRectangleButton_Click_1;
            RemoveRectangleButton.Click += RemoveRectangleButton_Click;
            RectanglesListBox1.SelectedIndexChanged += RectanglesListBox1_SelectedIndexChanged;

            // Подписка на события изменения текста
            LengthTextBox.TextChanged += HeightTextBox_TextChanged;
            WidthRecTextBox.TextChanged += WidthTextBox_TextChanged;
            CenterXTextBox.TextChanged += XTextBox_TextChanged;
            CenterYTextBox.TextChanged += YTextBox_TextChanged;
*/
        }

        /// <summary>
        /// Обработчик события изменения выбранного элемента в списке Enum.
        /// При выборе элемента из списка загружает соответствующие значения Enum в другой список.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие (обычно список Enum).</param>
        /// <param name="e">Аргументы события.</param>
        private void EnumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очистка элементов в списке значений
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

        /// <summary>
        /// Обработчик изменения выбранного элемента в списке ValuesListBox
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
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

        /// <summary>
        /// Обработчик нажатия на кнопку ParseButton для парсинга строки в перечисление Weekday
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void ParseButton_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox.Text;

            // Попытка преобразовать введенный текст в значение перечисления Weekday
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

        /// <summary>
        /// Обработчик нажатия кнопки button1 для выполнения действий в зависимости от выбранного сезона
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Получение выбранного сезона из ComboBox
            Season selectedSeason = (Season)SeasonComboBox.SelectedItem;

            // Выполнение действия в зависимости от выбранного сезона
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

        /// <summary>
        /// Обработчик изменения выбранного элемента в списке RectanglesListBox
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void RectanglesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = RectanglesListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Установка текущего прямоугольника в выбранный из списка
                _currentRectangle = _rectangles[selectedIndex];
                UpdateRectangleFields();
            }
        }

        /// <summary>
        /// Обновляет поля формы, связанные с текущим выбранным прямоугольником
        /// </summary>
        private void UpdateRectangleFields()
        {
            if (_currentRectangle != null)
            {
                // Отображение длины прямоугольника в текстовом поле
                LengthTextBox.Text = _currentRectangle.Length.ToString();
                // Отображение ширины прямоугольника в текстовом поле
                WidthTextBox.Text = _currentRectangle.Width.ToString();
                // Отображение координаты X центра прямоугольника
                CenterXTextBox.Text = _currentRectangle.Center.X.ToString();
                // Отображение координаты Y центра прямоугольника
                CenterYTextBox.Text = _currentRectangle.Center.Y.ToString();
                // Отображение идентификатора прямоугольника
                IdTextBox.Text = _currentRectangle.Id.ToString();
            }
        }

        /// <summary>
        /// Обновляет поля формы, связанные с текущим выбранным фильмом
        /// </summary>
        private void UpdateMovieFields()
        {
            if (_currentMovie != null)
            {
                // Отображение названия фильма
                TitleTextBox.Text = _currentMovie.Title;
                // Отображение длительности фильма в минутах
                DurationTextBox.Text = _currentMovie.DurationMinutes.ToString();
                // Отображение года выпуска фильма
                YearTextBox.Text = _currentMovie.ReleaseYear.ToString();
                // Отображение жанра фильма
                GenreTextBox.Text = _currentMovie.Genre;
                // Отображение рейтинга фильма
                RatingTextBox.Text = _currentMovie.Rating.ToString();
            }
        }

        /// <summary>
        /// Находит индекс прямоугольника с максимальной шириной в массиве
        /// </summary>
        /// <param name="rectangles">Массив прямоугольников</param>
        /// <returns>Индекс прямоугольника с максимальной шириной</returns>
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

        /// <summary>
        /// Обработчик изменения текста в TextBox для длины прямоугольника
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Попытка преобразовать введенное значение в число с плавающей точкой
                double length = double.Parse(LengthTextBox.Text);
                // Обновление длины текущего прямоугольника
                _currentRectangle.Length = length;
                // Установка фона TextBox в белый цвет при успешном вводе
                LengthTextBox.BackColor = Color.White;
            }
            catch
            {
                // В случае ошибки преобразования устанавливаем цвет фона в светло-розовый
                LengthTextBox.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в TextBox для ширины прямоугольника
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Попытка преобразовать введенное значение в число с плавающей точкой
                double width = double.Parse(WidthTextBox.Text);
                // Обновление ширины текущего прямоугольника
                _currentRectangle.Width = width;
                // Установка фона TextBox в белый цвет при успешном вводе
                WidthTextBox.BackColor = Color.White;
            }
            catch
            {
                // В случае ошибки преобразования устанавливаем цвет фона в светло-розовый
                WidthTextBox.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в TextBox для цвета прямоугольника
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            // Обновление цвета текущего прямоугольника на введенное значение
            _currentRectangle.Color = ColorTextBox.Text.ToString();
        }

        /// <summary>
        /// Обработчик изменения выбранного элемента в списке MoviesListBox
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = MoviesListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Установка текущего выбранного фильма
                _currentMovie = _movies[selectedIndex];
                // Обновление полей формы, связанных с фильмом
                UpdateMovieFields();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска прямоугольника с максимальной шириной
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void FindButton_Click(object sender, EventArgs e)
        {
            // Поиск индекса прямоугольника с максимальной шириной
            int maxWidthIndex = FindRectangleWithMaxWidth(_rectangles);
            // Установка выбранного элемента в списке по найденному индексу
            RectanglesListBox.SelectedIndex = maxWidthIndex;
        }
       


        // lab 5

        /*
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
                    var newRect = RectangleFactory.Randomize(CanvasPanel.Width, CanvasPanel.Height);
                    rectangles.Add(newRect);

                    RectanglesListBox1.Items.Add($"ID: {newRect.Id}  X: {newRect.Center.X} Y: {newRect.Center.Y}  W: {newRect.Width} H: {newRect.Length}");

                    var rectPanel = new Panel
                    {
                        Width = (int)newRect.Width,
                        Height = (int)newRect.Length,
                        Location = new Point((int)(newRect.Center.X - newRect.Width / 2), (int)(newRect.Center.Y - newRect.Length / 2)),
                        BackColor = Color.FromArgb(127, 127, 255, 127),
                        Tag = rectangles.Count - 1
                    };

                    rectanglePanels.Add(rectPanel);
                    CanvasPanel.Controls.Add(rectPanel);

                    FindCollisions();

                    RemoveRectangleButton.Enabled = true;

                }


                private void FindCollisions()
                {

                    // Сначала все прямоугольники зеленые
                    for (int i = 0; i < rectanglePanels.Count; i++)
                    {
                        rectanglePanels[i].BackColor = Color.FromArgb(127, 127, 255, 127);
                    }

                    // Проверяем пересечения между всеми парами прямоугольников
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        for (int j = i + 1; j < rectangles.Count; j++)
                        {

                            if (CollisionManager.IsCollision(rectangles[i], rectangles[j]))
                            {
                                rectanglePanels[i].BackColor = Color.FromArgb(127, 255, 127, 127);
                                rectanglePanels[j].BackColor = Color.FromArgb(127, 255, 127, 127);
                            }
                        }
                    }
                }

                private void RemoveRectangleButton_Click(object sender, EventArgs e)
                {
                    if (RectanglesListBox1.SelectedIndex == -1) return;

                    int index = RectanglesListBox1.SelectedIndex;

                    // Удаляем панель
                    if (rectanglePanels[index] != null)
                    {
                        CanvasPanel.Controls.Remove(rectanglePanels[index]);
                        rectanglePanels.RemoveAt(index);
                    }

                    // Удаляем прямоугольник
                    rectangles.RemoveAt(index);

                    // Обновляем ListBox
                    RectanglesListBox1.Items.RemoveAt(index);

                    // Обновляем теги у оставшихся панелей
                    for (int i = 0; i < rectanglePanels.Count; i++)
                    {
                        rectanglePanels[i].Tag = i;
                    }

                    FindCollisions();
                    RemoveRectangleButton.Enabled = rectangles.Count > 0;
                }



                private void RectanglesListBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    int selectedIndex = RectanglesListBox1.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        currentRectangle = rectangles[selectedIndex];
                        UpdateRectangleInfo(currentRectangle);
                    }
                    else
                    {
                        ClearRectangleFields();
                    }
                }

                private void UpdateRectangleInfo(ModelRectangle rectangle)
                {
                    LengthTextBox.Text = rectangle.Length.ToString();
                    WidthTextBox.Text = rectangle.Width.ToString();
                    CenterXTextBox.Text = rectangle.Center.X.ToString();
                    CenterYTextBox.Text = rectangle.Center.Y.ToString();
                    IdTextBox.Text = rectangle.Id.ToString();
                }
                private void HeightTextBox_TextChanged(object sender, EventArgs e)
                {

                    if (currentRectangle != null && double.TryParse(HeightTextBox.Text, out double length))
                    {
                        currentRectangle.Length = length;
                        HeightTextBox.BackColor = Color.White;
                        UpdatePanelVisuals();
                    }

                }

                private void WidthRecTextBox_TextChanged(object sender, EventArgs e)
                {
                    if (currentRectangle != null && double.TryParse(WidthRecTextBox.Text, out double width))
                    {
                        currentRectangle.Width = width;
                        WidthRecTextBox.BackColor = Color.White;
                        UpdatePanelVisuals();
                    }


                }

                private void XTextBox_TextChanged(object sender, EventArgs e)
                {
                    if (currentRectangle != null && int.TryParse(XTextBox.Text, out int x))
                    {
                        // Используем новый метод вместо прямого доступа
                        currentRectangle.UpdateCenter(x, currentRectangle.Center.Y);
                        XTextBox.BackColor = Color.White;
                        UpdatePanelVisuals();
                    }
                }

                private void YTextBox_TextChanged(object sender, EventArgs e)
                {
                    if (currentRectangle != null && int.TryParse(YTextBox.Text, out int y))
                    {
                        // Используем новый метод вместо прямого доступа
                        currentRectangle.UpdateCenter(_currentRectangle.Center.X, y);
                        YTextBox.BackColor = Color.White;
                        UpdatePanelVisuals();
                    }
                }

                public class Rectangle
                {
                   private static int _idCounter = 1;

                    public int Id { get; } 
                    public double Height { get; set; }
                    public double Width { get; set; }
                    public Model.Geometry.Point2D Center { get; private set; }

                    //Обновляет координаты центра фигуры
                    public void UpdateCenter(int x, int y)
                    {
                        Center = new Model.Geometry.Point2D(x, y);
                    }



                    public Rectangle(double height, double width, Model.Geometry.Point2D center)
                    {
                        if (_idCounter == int.MaxValue)
                        {
                            _idCounter = 1; // Сброс при достижении максимума
                        }

                        Id = _idCounter++;
                        Height = height;
                        Width = width;
                        Center = center;
                    }

                }

                private void UpdatePanelVisuals()
                {
                    if (currentRectangle == null) return;

                    int index = rectangles.IndexOf(currentRectangle);
                    if (index >= 0 && index < rectanglePanels.Count)
                    {
                        var panel = rectanglePanels[index];
                        panel.Location = new Point(
                            (int)(currentRectangle.Center.X - currentRectangle.Width / 2),
                            (int)(currentRectangle.Center.Y - currentRectangle.Length / 2));
                        panel.Size = new Size(
                            (int)currentRectangle.Width,
                            (int)currentRectangle.Length);

                        FindCollisions();
                    }
                }*/

    }
}
