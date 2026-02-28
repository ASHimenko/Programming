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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CustomersTab = new ObjectOrientedPractics.View.Tabs.CustomersTab();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ItemsTab = new ObjectOrientedPractics.View.Tabs.ItemsTab();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CartsTab = new ObjectOrientedPractics.View.Tabs.CartsTab();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.OrdersTab = new ObjectOrientedPractics.View.Tabs.OrdersTab();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.priorityOrdersTab1 = new ObjectOrientedPractics.View.Tabs.PriorityOrdersTab();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CustomersTab);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1292, 731);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CustomersTab
            // 
            this.CustomersTab.Customers = null;
            this.CustomersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersTab.Location = new System.Drawing.Point(3, 2);
            this.CustomersTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomersTab.MinimumSize = new System.Drawing.Size(1248, 734);
            this.CustomersTab.Name = "CustomersTab";
            this.CustomersTab.Size = new System.Drawing.Size(1286, 734);
            this.CustomersTab.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ItemsTab);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1292, 731);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ItemsTab
            // 
            this.ItemsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsTab.Items = null;
            this.ItemsTab.Location = new System.Drawing.Point(3, 2);
            this.ItemsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ItemsTab.MinimumSize = new System.Drawing.Size(1248, 734);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Size = new System.Drawing.Size(1286, 734);
            this.ItemsTab.TabIndex = 0;
            // 
            // Tabs
            // 
            this.Tabs.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Controls.Add(this.tabPage3);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage4);
            this.Tabs.Controls.Add(this.tabPage5);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tabs.MinimumSize = new System.Drawing.Size(1300, 760);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1300, 760);
            this.Tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CartsTab);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1292, 731);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Carts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CartsTab
            // 
            this.CartsTab.Customers = null;
            this.CartsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartsTab.Items = null;
            this.CartsTab.Location = new System.Drawing.Point(4, 4);
            this.CartsTab.Margin = new System.Windows.Forms.Padding(5);
            this.CartsTab.MinimumSize = new System.Drawing.Size(1248, 734);
            this.CartsTab.Name = "CartsTab";
            this.CartsTab.Size = new System.Drawing.Size(1284, 734);
            this.CartsTab.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.OrdersTab);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1292, 731);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Orders";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // OrdersTab
            // 
            this.OrdersTab.Customers = null;
            this.OrdersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersTab.Location = new System.Drawing.Point(4, 4);
            this.OrdersTab.Margin = new System.Windows.Forms.Padding(5);
            this.OrdersTab.MinimumSize = new System.Drawing.Size(1248, 734);
            this.OrdersTab.Name = "OrdersTab";
            this.OrdersTab.Size = new System.Drawing.Size(1284, 734);
            this.OrdersTab.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.priorityOrdersTab1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1292, 731);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "PriorityOrder";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // priorityOrdersTab1
            // 
            this.priorityOrdersTab1.DeliveryTime = null;
            this.priorityOrdersTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priorityOrdersTab1.Location = new System.Drawing.Point(3, 3);
            this.priorityOrdersTab1.MinimumSize = new System.Drawing.Size(1248, 734);
            this.priorityOrdersTab1.Name = "priorityOrdersTab1";
            this.priorityOrdersTab1.Size = new System.Drawing.Size(1286, 734);
            this.priorityOrdersTab1.StoreItems = null;
            this.priorityOrdersTab1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.Tabs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1300, 800);
            this.Name = "MainForm";
            this.Text = "Object Oriented Practics";
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private View.Tabs.ItemsTab ItemsTab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl Tabs;
        //private View.Tabs.CustomersTab CustomersTab;
        private System.Windows.Forms.TabPage tabPage1;
        private View.Tabs.CartsTab CartsTab;
        private System.Windows.Forms.TabPage tabPage4;
        private View.Tabs.CustomersTab CustomersTab;
        private View.Tabs.OrdersTab OrdersTab;
        private System.Windows.Forms.TabPage tabPage5;
        private View.Tabs.PriorityOrdersTab priorityOrdersTab1;
    }
}