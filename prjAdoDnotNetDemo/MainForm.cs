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
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
            FormCustomerEditor formCustomerEditor = new FormCustomerEditor();
            formCustomerEditor.MdiParent = this;
            formCustomerEditor.FormBorderStyle = FormBorderStyle.None;
            formCustomerEditor.Dock = DockStyle.Fill;
            formCustomerEditor.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
            FormProductList formProductList = new FormProductList();
            formProductList.MdiParent = this;
            formProductList.FormBorderStyle = FormBorderStyle.None;
            formProductList.Dock = DockStyle.Fill;
            formProductList.Show();
        }
    }
}
