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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool isClosed = true;

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosed)
            {
                e.Cancel = true;
            } 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string account = txtAccount.Text;
            string password = txtPassword.Text;

            string sql = "select * from tCustomer where fName = @K_Account and fPassword = @K_Password";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("K_Account", account));
            cmd.Parameters.Add(new SqlParameter("K_Password", password));
            cmd.CommandText = sql;
            

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                con.Close();
                isClosed = false;
                Close();
            }
            else
            {
                con.Close();
                MessageBox.Show("帳號與密碼錯誤");
            }
        }
    }
}
