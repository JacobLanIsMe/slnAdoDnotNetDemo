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
            refresh();
        }
        SqlCommandBuilder builder = new SqlCommandBuilder();
        SqlDataAdapter adapter;
        int _position = -1;
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
        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            if (table.Rows.Count > 0) adapter.Update(table);
            refresh();
        }

        //private DataTable ReverseTable(DataTable table)
        //{
        //    DataTable reversedTable = new DataTable();
        //    //DataRow row1 = table.NewRow();
        //    //for (int i = 0; i < table.Columns.Count; i++)
        //    //{
        //    //    string colName1 = table.Columns[i].ColumnName;
        //    //    row1[colName1] = i;
        //    //}
        //    //table.Rows.Add(row1);

        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        reversedTable.Columns.Add(i.ToString());
        //    }
        //    foreach(DataColumn col in table.Columns)
        //    {
        //        string colName = col.ColumnName;
        //        DataRow row = reversedTable.NewRow();
        //        for (int i = 0; i < reversedTable.Columns.Count; i++)
        //        {
        //            row[i.ToString()] = table.Rows[i][colName];
        //        }
        //        reversedTable.Rows.Add(row);
        //    }
        //    return reversedTable;
        //}
        
        private void btnSearchKeyword_Click(object sender, EventArgs e)
        {
            SetGridStyle();
            FormKeyword formKeyword = new FormKeyword();
            formKeyword.ShowDialog();
            if (formKeyword.isOKButtonClick)
            {
                string keyword = formKeyword.keyword;
                DataTable table = dataGridView1.DataSource as DataTable;
                DataView dv = new DataView(table);

                string cmd = $"fName like '%{keyword}%' ";
                if (decimal.TryParse(keyword, out decimal result2))
                {
                    cmd += $"or fId = {keyword} ";
                    cmd += $"or fCost = {keyword} ";
                    cmd += $"or fPrice = {keyword} ";
                    cmd += $"or fQty = {keyword} ";
                }
                dv.RowFilter = cmd;
                dataGridView2.DataSource = dv;
                //DataView dv2 = new DataView(table, "", "fId", DataViewRowState.CurrentRows);
                //foreach (DataRowView drv in dv)
                //{
                //    int index = dv2.Find(drv["fId"]);
                //    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                //}

                //string cmd = $"fName like '%{keyword}%' ";
                //cmd += $"or Convert(fId, 'System.String') = '{keyword}' ";
                //cmd += $"or Convert(fCost, 'System.String') = '{keyword}' ";
                //cmd += $"or Convert(fPrice, 'System.String') = '{keyword}' ";
                //cmd += $"or Convert(fQty, 'System.String') = '{keyword}' ";

                //List<string> _cmd = new List<string>();
                //string cmd1 = $"fId = {keyword} ";
                //cmd1 += $"or fCost = {keyword} ";
                //cmd1 += $"or fPrice = {keyword} ";
                //cmd1 += $"or fQty = {keyword} ";
                //string cmd2 = $"fName like '%{keyword}%' ";
                //_cmd.Add(cmd2);
                //_cmd.Add(cmd1);
                //DataTable table2 = new DataTable();
                //foreach (string cmd in _cmd)
                //{
                //    DataView dv = new DataView(table);
                //    dv.RowFilter = cmd;
                //    table2.Merge(dv.ToTable());
                //}
                //dataGridView2.DataSource = table2;

                //List<object> rowId = new List<object>();
                //foreach (DataRowView row in dv)
                //{
                //    rowId.Add(row["fId"]);
                //}
                //if (rowId.Count == 0)
                //    return;
                //foreach (object id in rowId)
                //{
                //    DataView dv2 = new DataView(table, "", "fId", DataViewRowState.CurrentRows);
                //    int index = dv2.Find(id);
                //    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                //}
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    DataTable selectedTable = new DataTable();
                    selectedTable.Columns.Add("number");
                    selectedTable.Columns.Add(i.ToString());
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        DataRow row = selectedTable.NewRow();
                        row["number"] = table.Rows[j]["fId"];
                        row[i.ToString()] = table.Rows[j][table.Columns[i]];
                        selectedTable.Rows.Add(row);
                    }
                    DataView newdv = new DataView(selectedTable);
                    DataView newdv2 = new DataView(selectedTable, "", "number", DataViewRowState.CurrentRows);
                    
                    newdv.RowFilter = $"fName like '%{keyword}%' ";
                    foreach (DataRowView drv in newdv)
                    {
                        int rowIndex = newdv2.Find(drv["number"]);
                        dataGridView1.Rows[rowIndex].Cells[i].Style.BackColor = Color.Yellow;

                    }
                }
            }
        }

        private void btnReverseTable_Click(object sender, EventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            
            //DataTable newTable = table.Clone();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataTable selectedTable = new DataTable();
                selectedTable.Columns.Add("number");
                selectedTable.Columns.Add(i.ToString());
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    DataRow row = selectedTable.NewRow();
                    row["number"] = table.Rows[j]["fId"];
                    row[i.ToString()] = table.Rows[j][table.Columns[i]];
                    selectedTable.Rows.Add(row);
                }
                DataView newdv = new DataView(selectedTable);
                DataView newdv2 = new DataView(selectedTable, "", "number", DataViewRowState.CurrentRows);
                string cmd = $"'{i.ToString()}' like '%男%' ";
                newdv.RowFilter = cmd;
                foreach (DataRowView drv in newdv)
                {
                    int rowIndex = newdv2.Find(drv["number"]);
                    dataGridView1.Rows[rowIndex].Cells[i].Style.BackColor = Color.Yellow;
                    
                }
            }


        }

        //private string Repeatedword(string[] array)
        //{
        //    for (int i = 0; i < array.Length - 1; i++)
        //    {

        //        for (int j = 0; j < array[0].Length; j++)
        //        {
        //            if ()
        //        }
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
