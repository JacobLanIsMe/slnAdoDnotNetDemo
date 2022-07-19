using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjAdoDnotNetDemo.Models;

namespace prjAdoDnotNetDemo
{
    public partial class FormProductEditor : Form
    {
        public FormProductEditor()
        {
            InitializeComponent();
        }
        CProduct _product = new CProduct();
        public CProduct product
        {
            get
            {
                _product.productId = Convert.ToInt32(textBoxId.Text);
                _product.productName = textBoxName.Text;
                _product.productCost = Convert.ToDecimal(textBoxCost.Text);
                _product.productQty = Convert.ToInt32(textBoxQty.Text);
                _product.productPrice = Convert.ToDecimal(textBoxPrice.Text);
                return _product;
            }
            set
            {
                _product = value;
                textBoxId.Text = _product.productId.ToString();
                textBoxName.Text = _product.productName;
                textBoxCost.Text = _product.productCost.ToString("0.0");
                textBoxQty.Text = _product.productQty.ToString();
                textBoxPrice.Text = _product.productPrice.ToString("0.0");
            }
        }
        bool isAddProductInfo = false;
        public bool IsAddProductInfo
        {
            get { return isAddProductInfo; }
        }
        bool isDataValidated()
        {
            string message = "";
            if (textBoxName.Text == "") message += "\n品名必須填";
            if (textBoxCost.Text == "") message += "\n成本必須填";
            if (textBoxQty.Text == "") message += "\n庫存必須填";
            if (textBoxPrice.Text == "") message += "\n售價必須填";
            if (message != "")
            {
                MessageBox.Show(message);
            }
            return message == "";
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!isDataValidated()) return;
            isAddProductInfo = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
