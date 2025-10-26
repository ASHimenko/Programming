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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.itamsTab1 = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.customersTab1 = new ObjectOrientedPractics.View.Tabs.CustomersTab();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.itemsTab1 = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.ItemTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ItemTab.SuspendLayout();
            this.SuspendLayout();
           
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.customersTab1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(816, 467);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // customersTab1
            // 
            this.customersTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersTab1.Location = new System.Drawing.Point(2, 2);
            this.customersTab1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customersTab1.Name = "customersTab1";
            this.customersTab1.Size = new System.Drawing.Size(812, 463);
            this.customersTab1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.itemsTab1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(816, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // itemsTab1
            // 
            
            this.itemsTab1.Location = new System.Drawing.Point(0, 0);
            this.itemsTab1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.itemsTab1.Name = "itemsTab1";
            this.itemsTab1.Size = new System.Drawing.Size(713, 474);
            this.itemsTab1.TabIndex = 0;
            // 
            // ItemTab
            // 
            this.ItemTab.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.ItemTab.Controls.Add(this.tabPage2);
            this.ItemTab.Controls.Add(this.tabPage3);
            this.ItemTab.Controls.Add(this.tabPage1);
            this.ItemTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemTab.Location = new System.Drawing.Point(0, 0);
            this.ItemTab.Margin = new System.Windows.Forms.Padding(2);
            this.ItemTab.Name = "ItemTab";
            this.ItemTab.SelectedIndex = 0;
            this.ItemTab.Size = new System.Drawing.Size(824, 493);
            this.ItemTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 467);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Carts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 493);
            this.Controls.Add(this.ItemTab);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TabPage tabPage1;
    }
}

