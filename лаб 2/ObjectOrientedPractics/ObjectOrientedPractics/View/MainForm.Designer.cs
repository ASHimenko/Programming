namespace ObjectOrientedPractics
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.itamsTab1 = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.customersTab1 = new ObjectOrientedPractics.View.Tabs.CustomersTab();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.itemsTab1 = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.ItemTab = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ItemTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // itamsTab1
            // 
            this.itamsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itamsTab1.Location = new System.Drawing.Point(3, 3);
            this.itamsTab1.Name = "itamsTab1";
            this.itamsTab1.Size = new System.Drawing.Size(1081, 581);
            this.itamsTab1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.customersTab1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1087, 587);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // customersTab1
            // 
            this.customersTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersTab1.Location = new System.Drawing.Point(3, 3);
            this.customersTab1.Name = "customersTab1";
            this.customersTab1.Size = new System.Drawing.Size(1081, 581);
            this.customersTab1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.itemsTab1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1087, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // itemsTab1
            // 
            this.itemsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTab1.Location = new System.Drawing.Point(3, 3);
            this.itemsTab1.Name = "itemsTab1";
            this.itemsTab1.Size = new System.Drawing.Size(1081, 581);
            this.itemsTab1.TabIndex = 0;
            // 
            // ItemTab
            // 
            this.ItemTab.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.ItemTab.Controls.Add(this.tabPage2);
            this.ItemTab.Controls.Add(this.tabPage3);
            this.ItemTab.Location = new System.Drawing.Point(0, 0);
            this.ItemTab.Name = "ItemTab";
            this.ItemTab.SelectedIndex = 0;
            this.ItemTab.Size = new System.Drawing.Size(1095, 616);
            this.ItemTab.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 607);
            this.Controls.Add(this.ItemTab);
            this.Name = "MainForm";
            this.Text = "Object Oriented Practics";
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ItemTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private View.Tabs.ItemsTab itamsTab1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private View.Tabs.ItemsTab itemsTab1;
        private System.Windows.Forms.TabControl ItemTab;
        private View.Tabs.CustomersTab customersTab1;
    }
}

