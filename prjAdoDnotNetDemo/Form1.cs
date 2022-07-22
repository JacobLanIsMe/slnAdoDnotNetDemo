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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string sql = "insert into tCustomer (fName, fPhone, fEmail, fAddress, fPassword) values (@k1, @k2, @k3, @k4, @k5)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("k1", "紹瑋"));
            cmd.Parameters.Add(new SqlParameter("k2", "0905121776"));
            cmd.Parameters.Add(new SqlParameter("k3", "ssss@hotmail.com"));
            cmd.Parameters.Add(new SqlParameter("k4", "台中市"));
            cmd.Parameters.Add(new SqlParameter("k5", "444555"));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("新增成功");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from tCustomer where fName = 'Jacob Lan'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("刪除成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update tCustomer set fPhone = '0923445766', fEmail = 'dfafa@outlook.com' where fName = 'Jacob Lan'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("修改成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tCustomer";
            SqlDataReader reader = cmd.ExecuteReader();
            string result = "";
            
            if (reader.Read() == true)
            {
                result = reader["fName"].ToString() + "\n" + reader["fPhone"].ToString();
            }
            con.Close();
            MessageBox.Show($"查詢結果: \n{result}");
        }

        private void btnCustomerEditor_Click(object sender, EventArgs e)
        {
            FormCustomerEditor formCustomerEditor = new FormCustomerEditor();
            formCustomerEditor.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormProductList formProductList = new FormProductList();
            formProductList.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction sqlTransaction = con.BeginTransaction(); ;
            cmd.Connection = con;
            cmd.Transaction = sqlTransaction;
            try
            {
                cmd.CommandText = "Insert into tCustomer (fName, fPhone, fEmail, fAddress, fPassword) values ('Hello', '01', 'Hello@gmail.com', '台北市', '1234')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into tCustomer (fName, fPhone, fEmail, fAddress, fPassword) values ('Hi', '01', 'Hi@gmail.com', '台南市')";
                cmd.ExecuteNonQuery();
                sqlTransaction.Commit();
                MessageBox.Show("交易成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("交易失敗");
            }
            finally
            {
                MessageBox.Show("結束");
            }
        }
    }
}
