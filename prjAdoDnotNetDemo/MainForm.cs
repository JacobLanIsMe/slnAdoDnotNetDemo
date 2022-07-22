using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAdoDnotNetDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomerEditor formCustomerEditor = new FormCustomerEditor();
            formCustomerEditor.MdiParent = this;
            //formCustomerEditor.FormBorderStyle = FormBorderStyle.None;
            formCustomerEditor.WindowState = FormWindowState.Maximized;

            //formCustomerEditor.Dock = DockStyle.Fill;
            formCustomerEditor.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormProductList formProductList = new FormProductList();
            formProductList.MdiParent = this;
            //formProductList.FormBorderStyle = FormBorderStyle.None;
            formProductList.WindowState = FormWindowState.Maximized;
            //formProductList.Dock = DockStyle.Fill;
            formProductList.Show();
        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 階層排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 關閉目前視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void 關閉所有視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //FormLogin formLogin = new FormLogin();
            //formLogin.ShowDialog();
            //labelHelloString.Text = "歡迎 "+ formLogin.helloString + "回來";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FormOrder formOrder = new FormOrder();
            formOrder.MdiParent = this;
            formOrder.WindowState = FormWindowState.Maximized;
            formOrder.Show();

        }
    }
}
