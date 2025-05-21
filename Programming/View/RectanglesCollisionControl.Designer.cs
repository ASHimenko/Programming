namespace Programming.View
{
    partial class RectanglesCollisionControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.RectanglesListBox1 = new System.Windows.Forms.ListBox();
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.RemoveRectangleButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.AddRectangleButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.IdRecTextBox = new System.Windows.Forms.TextBox();
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.YTextBox = new System.Windows.Forms.TextBox();
            this.WidthRecTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "Rectangles:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(83, 346);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "Id:";
            // 
            // RectanglesListBox1
            // 
            this.RectanglesListBox1.FormattingEnabled = true;
            this.RectanglesListBox1.ItemHeight = 16;
            this.RectanglesListBox1.Location = new System.Drawing.Point(35, 89);
            this.RectanglesListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RectanglesListBox1.Name = "RectanglesListBox1";
            this.RectanglesListBox1.Size = new System.Drawing.Size(291, 132);
            this.RectanglesListBox1.TabIndex = 14;
            this.RectanglesListBox1.SelectedIndexChanged += new System.EventHandler(this.RectanglesListBox1_SelectedIndexChanged_1);
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPanel.Location = new System.Drawing.Point(332, 57);
            this.CanvasPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(521, 423);
            this.CanvasPanel.TabIndex = 16;
            // 
            // RemoveRectangleButton
            // 
            this.RemoveRectangleButton.Location = new System.Drawing.Point(197, 240);
            this.RemoveRectangleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveRectangleButton.Name = "RemoveRectangleButton";
            this.RemoveRectangleButton.Size = new System.Drawing.Size(88, 30);
            this.RemoveRectangleButton.TabIndex = 23;
            this.RemoveRectangleButton.Text = "Remove";
            this.RemoveRectangleButton.UseVisualStyleBackColor = true;
            this.RemoveRectangleButton.Click += new System.EventHandler(this.RemoveRectangleButton_Click_1);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(84, 377);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 16);
            this.label21.TabIndex = 20;
            this.label21.Text = "X:";
            // 
            // AddRectangleButton
            // 
            this.AddRectangleButton.Location = new System.Drawing.Point(63, 240);
            this.AddRectangleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddRectangleButton.Name = "AddRectangleButton";
            this.AddRectangleButton.Size = new System.Drawing.Size(85, 30);
            this.AddRectangleButton.TabIndex = 22;
            this.AddRectangleButton.Text = "Add";
            this.AddRectangleButton.UseVisualStyleBackColor = true;
            this.AddRectangleButton.Click += new System.EventHandler(this.AddRectangleButton_Click_1);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(85, 405);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 16);
            this.label22.TabIndex = 21;
            this.label22.Text = "Y:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(60, 427);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 16);
            this.label20.TabIndex = 19;
            this.label20.Text = "Wigth:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(55, 458);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 16);
            this.label19.TabIndex = 18;
            this.label19.Text = "Height:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(44, 324);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(129, 16);
            this.label23.TabIndex = 24;
            this.label23.Text = "Selected Rectangle:";
            // 
            // IdRecTextBox
            // 
            this.IdRecTextBox.Location = new System.Drawing.Point(109, 343);
            this.IdRecTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IdRecTextBox.Name = "IdRecTextBox";
            this.IdRecTextBox.Size = new System.Drawing.Size(100, 22);
            this.IdRecTextBox.TabIndex = 25;
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(109, 370);
            this.XTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(100, 22);
            this.XTextBox.TabIndex = 26;
            this.XTextBox.TextChanged += new System.EventHandler(this.XTextBox_TextChanged);
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(109, 399);
            this.YTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(100, 22);
            this.YTextBox.TabIndex = 27;
            this.YTextBox.TextChanged += new System.EventHandler(this.YTextBox_TextChanged);
            // 
            // WidthRecTextBox
            // 
            this.WidthRecTextBox.Location = new System.Drawing.Point(109, 427);
            this.WidthRecTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WidthRecTextBox.Name = "WidthRecTextBox";
            this.WidthRecTextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthRecTextBox.TabIndex = 28;
            this.WidthRecTextBox.TextChanged += new System.EventHandler(this.WidthRecTextBox_TextChanged);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(109, 455);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.HeightTextBox.TabIndex = 29;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // RectanglesCollisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.WidthRecTextBox);
            this.Controls.Add(this.YTextBox);
            this.Controls.Add(this.XTextBox);
            this.Controls.Add(this.IdRecTextBox);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.AddRectangleButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.RemoveRectangleButton);
            this.Controls.Add(this.CanvasPanel);
            this.Controls.Add(this.RectanglesListBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RectanglesCollisionControl";
            this.Size = new System.Drawing.Size(901, 560);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox RectanglesListBox1;
        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.Button RemoveRectangleButton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button AddRectangleButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox IdRecTextBox;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.TextBox YTextBox;
        private System.Windows.Forms.TextBox WidthRecTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
