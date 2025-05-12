using Programming.Model.Geometry;
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
using ModelRectangle = Programming.Model.Geometry.Rectangle;

namespace Programming.View
{
    public partial class RectanglesCollisionControl : UserControl
    {

        private readonly List<ModelRectangle> rectangles;
        private readonly List<Panel> rectanglePanels;
        private readonly Random _random;
        private ModelRectangle currentRectangle;

        public RectanglesCollisionControl()
        {
            InitializeComponent();

            rectangles = new List<ModelRectangle>();
            rectanglePanels = new List<Panel>();
            _random = new Random();
        }

        

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
            HeightTextBox.Text = rectangle.Length.ToString();
            WidthRecTextBox.Text = rectangle.Width.ToString();
            XTextBox.Text = rectangle.Center.X.ToString();
            YTextBox.Text = rectangle.Center.Y.ToString();
            IdRecTextBox.Text = rectangle.Id.ToString();
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
                currentRectangle.UpdateCenter(currentRectangle.Center.X, y);
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
        }
        private void RectanglesCollisionControl_Load(object sender, EventArgs e)
        {

        }

        private void AddRectangleButton_Click(object sender, EventArgs e)
        {

        }
    }
}
