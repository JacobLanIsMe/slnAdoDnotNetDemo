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
        private void FormProductList_Load(object sender, EventArgs e)
        {
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
            dataGridView1.DataSource = new DataView(ds.Tables[0]);
            comboBoxSort.Items.Clear();
            foreach (DataColumn c in ds.Tables[0].Columns)
            {
                if (c.DataType != typeof(Byte[])) comboBoxSort.Items.Add(c.ColumnName);
            }
            SetGridStyle();
        }
        
        void SetGridStyle()
        {
            bool isColor = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = (isColor) ? Color.LightBlue : Color.White;
                }
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
            row.AcceptChanges();
        }

        private void FormProductList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataView dv = dataGridView1.DataSource as DataView;
            if (dv.Count > 0) adapter.Update(dv.Table);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataView dv = dataGridView1.DataSource as DataView;
            if (dv.Count > 0) adapter.Update(dv.Table);
            refresh();
        }
        
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

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null) return;
                        if (cell.Value.ToString().ToUpper().Contains(keyword.ToUpper()))
                        {
                            cell.Style.BackColor = Color.Yellow;
                        }
                    }
                }

                DataView dv2 = new DataView(table, "", "fId", DataViewRowState.CurrentRows);
                foreach (DataRowView drv in dv)
                {
                    int index = dv2.Find(drv["fId"]);
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                }

                //List<int> index = new List<int>();
                //for (int i = 0; i < table.Columns.Count; i++)
                //{
                //    DataTable selectedTable = new DataTable();
                //    string colName = "f" + i;
                //    selectedTable.Columns.Add("number", typeof(int));
                //    selectedTable.Columns.Add(colName, table.Columns[i].DataType);
                //    for (int j = 0; j < table.Rows.Count; j++)
                //    {
                //        DataRow row = selectedTable.NewRow();
                //        row["number"] = table.Rows[j]["fId"];
                //        row[colName] = table.Rows[j][table.Columns[i]];
                //        selectedTable.Rows.Add(row);
                //    }
                //DataView newdv = new DataView(selectedTable);
                //DataView newdv2 = new DataView(selectedTable, "", "number", DataViewRowState.CurrentRows);
                //string cmd2;
                //if (decimal.TryParse(keyword, out decimal result1))
                //{
                //    if (selectedTable.Columns[colName].DataType == typeof(string))
                //    {
                //        cmd2 = $"{colName} like '%{keyword}%' ";
                //    }
                //    else
                //    {
                //        cmd2 = $"{colName} = {keyword}";
                //    }
                //}
                //else
                //{
                //    cmd2 = $"{colName} like '%{keyword}%' ";
                //}
                //try
                //{
                //    newdv.RowFilter = cmd2;
                //}
                //catch
                //{
                //    continue;
                //}
                //foreach (DataRowView drv in newdv)
                //{
                //    string a = drv["number"].ToString();
                //    int rowIndex = newdv2.Find(drv["number"]);
                //    dataGridView1.Rows[rowIndex].Cells[i].Style.BackColor = Color.Yellow;
                //    index.Add(rowIndex);
                //}
                //}
                //DataTable newTable = table.Clone();
                //newTable.Rows.Clear();
                //foreach (int i in index)
                //{
                //    DataRow row = newTable.NewRow();
                //    row.ItemArray = table.Rows[i].ItemArray;
                //    newTable.Rows.Add(row);
                //}
                //dataGridView2.DataSource = newTable;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            //con.Open();
            //string sql = $"select * from tProduct order by {comboBox1.Text}";
            //adapter = new SqlDataAdapter(sql, con);
            //builder.DataAdapter = adapter;
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //con.Close();
            //dataGridView1.DataSource = ds.Tables[0];

            
            DataView dv = dataGridView1.DataSource as DataView;
            dv.Sort = comboBoxSort.Text;
            dataGridView1.DataSource = dv;





            SetGridStyle();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "房型資料檔|*.xml";
           

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataView dv = dataGridView1.DataSource as DataView;

                DataTable tExport = new DataTable("tExportOnlyForHotel.com");
                tExport.Columns.Add("房型");
                tExport.Columns.Add("數量");
                tExport.Columns.Add("價格");
                foreach (DataRow row in dv.Table.Rows)
                {
                    DataRow newRow = tExport.NewRow();
                    newRow["房型"] = row["fName"].ToString();
                    newRow["數量"] = row["fQty"].ToString();
                    decimal price = Math.Round(Convert.ToDecimal(row["fPrice"]), 0,MidpointRounding.AwayFromZero);
                    newRow["價格"] = price.ToString();
                    tExport.Rows.Add(newRow);
                }

                tExport.WriteXml(saveFileDialog.FileName);
            }
        }
    }
    
}
