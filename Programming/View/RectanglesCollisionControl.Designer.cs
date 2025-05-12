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
            this.label18.Location = new System.Drawing.Point(23, 55);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 15);
            this.label18.TabIndex = 17;
            this.label18.Text = "Rectangles:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(62, 281);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 15);
            this.label17.TabIndex = 15;
            this.label17.Text = "Id:";
            // 
            // RectanglesListBox1
            // 
            this.RectanglesListBox1.FormattingEnabled = true;
            this.RectanglesListBox1.Location = new System.Drawing.Point(26, 72);
            this.RectanglesListBox1.Margin = new System.Windows.Forms.Padding(2);
            this.RectanglesListBox1.Name = "RectanglesListBox1";
            this.RectanglesListBox1.Size = new System.Drawing.Size(219, 108);
            this.RectanglesListBox1.TabIndex = 14;
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPanel.Location = new System.Drawing.Point(249, 46);
            this.CanvasPanel.Margin = new System.Windows.Forms.Padding(2);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(391, 344);
            this.CanvasPanel.TabIndex = 16;
            // 
            // RemoveRectangleButton
            // 
            this.RemoveRectangleButton.Location = new System.Drawing.Point(148, 195);
            this.RemoveRectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveRectangleButton.Name = "RemoveRectangleButton";
            this.RemoveRectangleButton.Size = new System.Drawing.Size(66, 24);
            this.RemoveRectangleButton.TabIndex = 23;
            this.RemoveRectangleButton.Text = "Remove";
            this.RemoveRectangleButton.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(63, 306);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 15);
            this.label21.TabIndex = 20;
            this.label21.Text = "X:";
            // 
            // AddRectangleButton
            // 
            this.AddRectangleButton.Location = new System.Drawing.Point(47, 195);
            this.AddRectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddRectangleButton.Name = "AddRectangleButton";
            this.AddRectangleButton.Size = new System.Drawing.Size(64, 24);
            this.AddRectangleButton.TabIndex = 22;
            this.AddRectangleButton.Text = "Add";
            this.AddRectangleButton.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(64, 329);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 15);
            this.label22.TabIndex = 21;
            this.label22.Text = "Y:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 347);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 15);
            this.label20.TabIndex = 19;
            this.label20.Text = "Wigth:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(41, 372);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 15);
            this.label19.TabIndex = 18;
            this.label19.Text = "Height:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(33, 263);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(117, 15);
            this.label23.TabIndex = 24;
            this.label23.Text = "Selected Rectangle:";
            // 
            // IdRecTextBox
            // 
            this.IdRecTextBox.Location = new System.Drawing.Point(82, 279);
            this.IdRecTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IdRecTextBox.Name = "IdRecTextBox";
            this.IdRecTextBox.Size = new System.Drawing.Size(76, 20);
            this.IdRecTextBox.TabIndex = 25;
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(82, 301);
            this.XTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(76, 20);
            this.XTextBox.TabIndex = 26;
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(82, 324);
            this.YTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(76, 20);
            this.YTextBox.TabIndex = 27;
            // 
            // WidthRecTextBox
            // 
            this.WidthRecTextBox.Location = new System.Drawing.Point(82, 347);
            this.WidthRecTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.WidthRecTextBox.Name = "WidthRecTextBox";
            this.WidthRecTextBox.Size = new System.Drawing.Size(76, 20);
            this.WidthRecTextBox.TabIndex = 28;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(82, 370);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(76, 20);
            this.HeightTextBox.TabIndex = 29;
            // 
            // RectanglesCollisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Name = "RectanglesCollisionControl";
            this.Size = new System.Drawing.Size(676, 455);
            this.Load += new System.EventHandler(this.RectanglesCollisionControl_Load);
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
