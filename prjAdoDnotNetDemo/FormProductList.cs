using prjAdoDnotNetDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAdoDnotNetDemo
{
    public partial class FormProductList : Form
    {
        public FormProductList()
        {
            InitializeComponent();
        }
        SqlCommandBuilder builder = new SqlCommandBuilder();
        SqlDataAdapter adapter;
        int _position = -1;
        bool isColor = false;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string sql = "select * from tProduct";
            adapter = new SqlDataAdapter(sql, con);
            builder.DataAdapter = adapter;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
            SetGridStyle();
        }
        void SetGridStyle()
        {
            bool isColor = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (isColor) row.DefaultCellStyle.BackColor = Color.LightBlue;
                else row.DefaultCellStyle.BackColor = Color.White;
                isColor = !isColor;
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormProductEditor f = new FormProductEditor();
            DialogResult dialogResult = f.ShowDialog();
            if (!f.IsAddProductInfo) return;
            CProduct p = f.product;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.NewRow();
            row["fId"] = p.productId;
            row["fName"] = p.productName;
            row["fCost"] = p.productCost;
            row["fQty"] = p.productQty;
            row["fPrice"] = p.productPrice;
            table.Rows.Add(row);
            SetGridStyle();
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _position = e.RowIndex;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_position < 0) return;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.Rows[_position];
            CProduct p = new CProduct()
            {
                productId = Convert.ToInt32(row["fId"]),
                productName = row["fName"].ToString(),
                productCost = Convert.ToDecimal(row["fCost"]),
                productQty = Convert.ToInt32(row["fQty"]),
                productPrice = Convert.ToDecimal(row["fPrice"])
            };
            FormProductEditor formProductEditor = new FormProductEditor();
            formProductEditor.product = p;
            formProductEditor.ShowDialog();

            if (!formProductEditor.IsAddProductInfo) return;
            row["fId"] = formProductEditor.product.productId;
            row["fName"] = formProductEditor.product.productName;
            row["fCost"] = formProductEditor.product.productCost;
            row["fQty"] = formProductEditor.product.productQty;
            row["fPrice"] = formProductEditor.product.productPrice;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_position < 0) return;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.Rows[_position];
            row.Delete();
        }

        private void FormProductList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            if (table.Rows.Count > 0) adapter.Update(table);
        }

        private void btnSearchKeyword_Click(object sender, EventArgs e)
        {
            FormKeyword formKeyword = new FormKeyword();
            formKeyword.ShowDialog();
            if (formKeyword.isOKButtonClick)
            {
                string keyword = formKeyword.keyword;
                DataTable table = dataGridView1.DataSource as DataTable;
                DataView dv = new DataView(table);
                string cmd = $"Convert(fId, 'System.String') like '%{keyword}%' ";
                cmd += $"or fName LIKE '%{keyword}%' ";
                cmd += $"or Convert(fCost, 'System.String') like '%{keyword}%' ";
                cmd += $"or Convert(fPrice, 'System.String') like '%{keyword}%' ";
                dv.RowFilter = cmd;
                dataGridView2.DataSource = dv;
            }
            
            
            

        }
    }
}
