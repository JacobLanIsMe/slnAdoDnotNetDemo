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
    public partial class FormCustomerEditor : Form
    {
        public FormCustomerEditor()
        {
            InitializeComponent();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string password = textBoxPassword.Text;
            string sql = "insert into tCustomer (";
            sql += "fName,";
            sql += "fPhone,";
            sql += "fEmail,";
            sql += "fAddress,";
            sql += "fPassword";
            sql += ") values (";
            sql += "@K_name,";
            sql += "@K_phone,";
            sql += "@K_email,";
            sql += "@K_address,";
            sql += "@K_password)";
            List<SqlParameter> para = new List<SqlParameter>();
            para.Add(new SqlParameter("K_name", name));
            para.Add(new SqlParameter("K_phone", phone));
            para.Add(new SqlParameter("K_email", email));
            para.Add(new SqlParameter("K_address", address));
            para.Add(new SqlParameter("K_password", password));
            executeSql(sql, para);
            MessageBox.Show("新增成功");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxNumber.Text);
            string sql = "delete from tCustomer where fid = @K_FID";
            List<SqlParameter> para = new List<SqlParameter>();
            para.Add(new SqlParameter("K_FID", id));
            executeSql(sql, para);
            MessageBox.Show("刪除完成");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update tCustomer set ";
            sql += "fname = @K_name,";
            sql += "fPhone = @K_phone,";
            sql += "fEmail = @K_email,";
            sql += "fAddress = @K_address,";
            sql += "fPassword = @K_password ";
            sql += "where fid = @K_fid";
            List<SqlParameter> para = new List<SqlParameter>();
            para.Add(new SqlParameter("K_name", textBoxName.Text));
            para.Add(new SqlParameter("K_phone", textBoxPhone.Text));
            para.Add(new SqlParameter("K_email", textBoxEmail.Text));
            para.Add(new SqlParameter("K_address", textBoxAddress.Text));
            para.Add(new SqlParameter("K_password", textBoxPassword.Text));
            para.Add(new SqlParameter("K_fid", Convert.ToInt32(textBoxNumber.Text)));
            executeSql(sql, para);
            MessageBox.Show("修改完成");
        }
        private void executeSql(string sql, List<SqlParameter> para)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (para != null) cmd.Parameters.AddRange(para.ToArray());
            //foreach (SqlParameter i in para)
            //{
            //    cmd.Parameters.Add(i);
            //}
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pkslist.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string sql = "select * from tCustomer";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["fName"].ToString());
                pkslist.Add((int)reader["fid"]);
            }
            con.Close();
        }
        List<int> pkslist = new List<int>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            string sql = "";
            if (selectedIndex < pkslist.Count()) sql = $"select * from tCustomer where fid = {pkslist[selectedIndex]}";
            List<SqlParameter> para = new List<SqlParameter>();
            DisplayBySql(sql, para);
        }
        private void btnSearchKeyword_Click(object sender, EventArgs e)
        {
            FormKeyword formKeyword = new FormKeyword();
            formKeyword.ShowDialog();
            string keyword = formKeyword.keyword;
            if (formKeyword.isOKButtonClick)
            {
                string sql = "select * from tCustomer where fName like @K_keyword ";
                sql += "or fPhone like @K_keyword ";
                sql += "or fEmail like @K_keyword ";
                sql += "or fAddress like @K_keyword";
                List<SqlParameter> para = new List<SqlParameter>();
                para.Add(new SqlParameter("K_keyword", "%"+keyword+"%"));
                DisplayBySql(sql, para);
            }
        }
        private void DisplayBySql(string sql, List<SqlParameter> para)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (para != null) cmd.Parameters.AddRange(para.ToArray<SqlParameter>());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBoxNumber.Text = reader["fid"].ToString();
                textBoxName.Text = reader["fName"].ToString();
                textBoxPhone.Text = reader["fPhone"].ToString();
                textBoxEmail.Text = reader["fEmail"].ToString();
                textBoxAddress.Text = reader["fAddress"].ToString();
                textBoxPassword.Text = reader["fPassword"].ToString();
            }
            con.Close();
        }
    }
}
