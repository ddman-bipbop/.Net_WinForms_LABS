namespace WindowsFormsApp_FOR_LABS
{
    partial class Form1
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.stanokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameRepairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workshopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.craftbanchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameRepairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workshopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.menuStrip2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stanokToolStripMenuItem,
            this.nameRepairToolStripMenuItem,
            this.workshopToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(907, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // stanokToolStripMenuItem
            // 
            this.stanokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem});
            this.stanokToolStripMenuItem.Name = "stanokToolStripMenuItem";
            this.stanokToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.stanokToolStripMenuItem.Text = "CraftBanch";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // nameRepairToolStripMenuItem
            // 
            this.nameRepairToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem1});
            this.nameRepairToolStripMenuItem.Name = "nameRepairToolStripMenuItem";
            this.nameRepairToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.nameRepairToolStripMenuItem.Text = "Name Repair";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // workshopToolStripMenuItem
            // 
            this.workshopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem2,
            this.editToolStripMenuItem2});
            this.workshopToolStripMenuItem.Name = "workshopToolStripMenuItem";
            this.workshopToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.workshopToolStripMenuItem.Text = "Repair";
            this.workshopToolStripMenuItem.Click += new System.EventHandler(this.workshopToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem2
            // 
            this.addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            this.addToolStripMenuItem2.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem2.Text = "Add";
            this.addToolStripMenuItem2.Click += new System.EventHandler(this.addToolStripMenuItem2_Click);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(96, 22);
            this.editToolStripMenuItem2.Text = "Edit";
            this.editToolStripMenuItem2.Click += new System.EventHandler(this.editToolStripMenuItem2_Click);
            // 
            // listView1
            // 
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup3";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 390);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(519, 165);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // menuStrip3
            // 
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.craftbanchToolStripMenuItem,
            this.nameRepairToolStripMenuItem1,
            this.workshopToolStripMenuItem1});
            this.menuStrip3.Location = new System.Drawing.Point(12, 31);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(246, 24);
            this.menuStrip3.TabIndex = 2;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // craftbanchToolStripMenuItem
            // 
            this.craftbanchToolStripMenuItem.Name = "craftbanchToolStripMenuItem";
            this.craftbanchToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.craftbanchToolStripMenuItem.Text = "Craftbanch";
            this.craftbanchToolStripMenuItem.Click += new System.EventHandler(this.craftbanchToolStripMenuItem_Click);
            // 
            // nameRepairToolStripMenuItem1
            // 
            this.nameRepairToolStripMenuItem1.Name = "nameRepairToolStripMenuItem1";
            this.nameRepairToolStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.nameRepairToolStripMenuItem1.Text = "Name Repair";
            this.nameRepairToolStripMenuItem1.Click += new System.EventHandler(this.nameRepairToolStripMenuItem1_Click);
            // 
            // workshopToolStripMenuItem1
            // 
            this.workshopToolStripMenuItem1.Name = "workshopToolStripMenuItem1";
            this.workshopToolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.workshopToolStripMenuItem1.Text = "Workshop";
            this.workshopToolStripMenuItem1.Click += new System.EventHandler(this.workshopToolStripMenuItem1_Click);
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 225);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(519, 159);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyUp);
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(0, 58);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(519, 161);
            this.listView3.TabIndex = 4;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            this.listView3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView3_KeyUp);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(907, 582);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip3);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_2);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видРемонтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem stanokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameRepairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem workshopToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem craftbanchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameRepairToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem workshopToolStripMenuItem1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
    }
}

