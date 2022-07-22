
namespace prjAdoDnotNetDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編輯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.室窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.垂直排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.階層排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關閉目前視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關閉所有視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelHelloString = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.labelHelloString);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 145);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 57);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 54);
            this.toolStripButton1.Text = "關閉";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnProduct.Location = new System.Drawing.Point(161, 83);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(137, 59);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "產品系統";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCustomer.Location = new System.Drawing.Point(18, 83);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(137, 59);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "會員系統";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.編輯ToolStripMenuItem,
            this.室窗ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 編輯ToolStripMenuItem
            // 
            this.編輯ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.編輯ToolStripMenuItem.Name = "編輯ToolStripMenuItem";
            this.編輯ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.編輯ToolStripMenuItem.Text = "編輯";
            // 
            // 室窗ToolStripMenuItem
            // 
            this.室窗ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.水平排列ToolStripMenuItem,
            this.垂直排列ToolStripMenuItem,
            this.階層排列ToolStripMenuItem,
            this.關閉目前視窗ToolStripMenuItem,
            this.關閉所有視窗ToolStripMenuItem});
            this.室窗ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.室窗ToolStripMenuItem.Name = "室窗ToolStripMenuItem";
            this.室窗ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.室窗ToolStripMenuItem.Text = "視窗";
            // 
            // 水平排列ToolStripMenuItem
            // 
            this.水平排列ToolStripMenuItem.Name = "水平排列ToolStripMenuItem";
            this.水平排列ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.水平排列ToolStripMenuItem.Text = "水平排列";
            this.水平排列ToolStripMenuItem.Click += new System.EventHandler(this.水平排列ToolStripMenuItem_Click);
            // 
            // 垂直排列ToolStripMenuItem
            // 
            this.垂直排列ToolStripMenuItem.Name = "垂直排列ToolStripMenuItem";
            this.垂直排列ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.垂直排列ToolStripMenuItem.Text = "垂直排列";
            this.垂直排列ToolStripMenuItem.Click += new System.EventHandler(this.垂直排列ToolStripMenuItem_Click);
            // 
            // 階層排列ToolStripMenuItem
            // 
            this.階層排列ToolStripMenuItem.Name = "階層排列ToolStripMenuItem";
            this.階層排列ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.階層排列ToolStripMenuItem.Text = "階層排列";
            this.階層排列ToolStripMenuItem.Click += new System.EventHandler(this.階層排列ToolStripMenuItem_Click);
            // 
            // 關閉目前視窗ToolStripMenuItem
            // 
            this.關閉目前視窗ToolStripMenuItem.Name = "關閉目前視窗ToolStripMenuItem";
            this.關閉目前視窗ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.關閉目前視窗ToolStripMenuItem.Text = "關閉目前視窗";
            this.關閉目前視窗ToolStripMenuItem.Click += new System.EventHandler(this.關閉目前視窗ToolStripMenuItem_Click);
            // 
            // 關閉所有視窗ToolStripMenuItem
            // 
            this.關閉所有視窗ToolStripMenuItem.Name = "關閉所有視窗ToolStripMenuItem";
            this.關閉所有視窗ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.關閉所有視窗ToolStripMenuItem.Text = "關閉所有視窗";
            this.關閉所有視窗ToolStripMenuItem.Click += new System.EventHandler(this.關閉所有視窗ToolStripMenuItem_Click);
            // 
            // labelHelloString
            // 
            this.labelHelloString.AutoSize = true;
            this.labelHelloString.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelHelloString.Location = new System.Drawing.Point(699, 83);
            this.labelHelloString.Name = "labelHelloString";
            this.labelHelloString.Size = new System.Drawing.Size(98, 21);
            this.labelHelloString.TabIndex = 4;
            this.labelHelloString.Text = "歡迎回來";
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOrder.Location = new System.Drawing.Point(304, 83);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(137, 59);
            this.btnOrder.TabIndex = 5;
            this.btnOrder.Text = "線上訂購";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編輯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 室窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水平排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂直排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 階層排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關閉目前視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關閉所有視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label labelHelloString;
        private System.Windows.Forms.Button btnOrder;
    }
}