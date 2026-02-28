namespace ObjectOrientedPractics.View.Tabs
{
    partial class CustomersTab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersTab));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsPriorityCheckBox = new System.Windows.Forms.CheckBox();
            this.AddressControl = new ObjectOrientedPractics.View.Controls.AddressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.CustomerListBox = new System.Windows.Forms.ListBox();
            this.CustomersGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveDiscountsButton = new System.Windows.Forms.Button();
            this.AddDiscountsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DiscountsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.CustomersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.IsPriorityCheckBox);
            this.groupBox1.Controls.Add(this.AddressControl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FullNameTextBox);
            this.groupBox1.Controls.Add(this.IDTextBox);
            this.groupBox1.Location = new System.Drawing.Point(477, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(722, 377);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Customer";
            // 
            // IsPriorityCheckBox
            // 
            this.IsPriorityCheckBox.AutoSize = true;
            this.IsPriorityCheckBox.Location = new System.Drawing.Point(109, 81);
            this.IsPriorityCheckBox.Name = "IsPriorityCheckBox";
            this.IsPriorityCheckBox.Size = new System.Drawing.Size(83, 20);
            this.IsPriorityCheckBox.TabIndex = 14;
            this.IsPriorityCheckBox.Text = "Is Priority";
            this.IsPriorityCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddressControl
            // 
            this.AddressControl.Address = ((ObjectOrientedPractics.Model.Address)(resources.GetObject("AddressControl.Address")));
            this.AddressControl.Location = new System.Drawing.Point(6, 106);
            this.AddressControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressControl.Name = "AddressControl";
            this.AddressControl.Size = new System.Drawing.Size(710, 267);
            this.AddressControl.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Full Name:";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(109, 46);
            this.FullNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(443, 22);
            this.FullNameTextBox.TabIndex = 1;
            this.FullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(109, 18);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 22);
            this.IDTextBox.TabIndex = 0;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Customers";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddButton.Location = new System.Drawing.Point(26, 665);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 43);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RemoveButton.Location = new System.Drawing.Point(146, 665);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(112, 43);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // CustomerListBox
            // 
            this.CustomerListBox.FormattingEnabled = true;
            this.CustomerListBox.ItemHeight = 16;
            this.CustomerListBox.Location = new System.Drawing.Point(19, 41);
            this.CustomerListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomerListBox.Name = "CustomerListBox";
            this.CustomerListBox.Size = new System.Drawing.Size(425, 596);
            this.CustomerListBox.TabIndex = 10;
            this.CustomerListBox.SelectedIndexChanged += new System.EventHandler(this.CustomerListBox_SelectedIndexChanged);
            // 
            // CustomersGroupBox
            // 
            this.CustomersGroupBox.Controls.Add(this.RemoveDiscountsButton);
            this.CustomersGroupBox.Controls.Add(this.AddDiscountsButton);
            this.CustomersGroupBox.Controls.Add(this.label1);
            this.CustomersGroupBox.Controls.Add(this.DiscountsListBox);
            this.CustomersGroupBox.Controls.Add(this.groupBox1);
            this.CustomersGroupBox.Controls.Add(this.CustomerListBox);
            this.CustomersGroupBox.Controls.Add(this.AddButton);
            this.CustomersGroupBox.Controls.Add(this.RemoveButton);
            this.CustomersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CustomersGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomersGroupBox.Name = "CustomersGroupBox";
            this.CustomersGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomersGroupBox.Size = new System.Drawing.Size(1248, 734);
            this.CustomersGroupBox.TabIndex = 11;
            this.CustomersGroupBox.TabStop = false;
            this.CustomersGroupBox.Text = "Customers";
            // 
            // RemoveDiscountsButton
            // 
            this.RemoveDiscountsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RemoveDiscountsButton.Location = new System.Drawing.Point(1074, 550);
            this.RemoveDiscountsButton.Name = "RemoveDiscountsButton";
            this.RemoveDiscountsButton.Size = new System.Drawing.Size(113, 50);
            this.RemoveDiscountsButton.TabIndex = 14;
            this.RemoveDiscountsButton.Text = "Remove";
            this.RemoveDiscountsButton.UseVisualStyleBackColor = true;
            this.RemoveDiscountsButton.Click += new System.EventHandler(this.RemoveDiscountsButton_Click);
            // 
            // AddDiscountsButton
            // 
            this.AddDiscountsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddDiscountsButton.Location = new System.Drawing.Point(1074, 490);
            this.AddDiscountsButton.Name = "AddDiscountsButton";
            this.AddDiscountsButton.Size = new System.Drawing.Size(113, 50);
            this.AddDiscountsButton.TabIndex = 13;
            this.AddDiscountsButton.Text = "Add";
            this.AddDiscountsButton.UseVisualStyleBackColor = true;
            this.AddDiscountsButton.Click += new System.EventHandler(this.AddDiscountsButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Discounts";
            // 
            // DiscountsListBox
            // 
            this.DiscountsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountsListBox.FormattingEnabled = true;
            this.DiscountsListBox.ItemHeight = 16;
            this.DiscountsListBox.Location = new System.Drawing.Point(483, 447);
            this.DiscountsListBox.Name = "DiscountsListBox";
            this.DiscountsListBox.Size = new System.Drawing.Size(529, 228);
            this.DiscountsListBox.TabIndex = 11;
            // 
            // CustomersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomersGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1248, 734);
            this.Name = "CustomersTab";
            this.Size = new System.Drawing.Size(1248, 734);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CustomersGroupBox.ResumeLayout(false);
            this.CustomersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FullNameTextBox;
        ////private System.Windows.Forms.Panel Customers;
        //private System.Windows.Forms.ListBox CustomersListBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label label4;
        private Controls.AddressControl AddressControl;
        private System.Windows.Forms.ListBox CustomerListBox;
        private System.Windows.Forms.GroupBox CustomersGroupBox;
        private System.Windows.Forms.CheckBox IsPriorityCheckBox;
        private System.Windows.Forms.Button RemoveDiscountsButton;
        private System.Windows.Forms.Button AddDiscountsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox DiscountsListBox;
    }
}
