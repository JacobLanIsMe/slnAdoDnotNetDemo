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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbDemo;Integrated Security=True";
            con.Open();
            string sql = "select * from tProduct";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int btnLocationX = 10;
            int btnLocationY = 10;
           
            while (reader.Read())
            {
                panel1.Width = (int)SystemInformation.WorkingArea.Width * 2 / 3;
                Button bt = new Button();
                bt.Name = reader["fId"].ToString();
                bt.Size = new Size(200, 100);
                bt.Location = new Point(btnLocationX, btnLocationY);
                bt.Text = reader["fName"].ToString() + "\n\n" +
                          reader["fQty"].ToString() + "\n\n" +
                          Math.Round(Convert.ToDecimal(reader["fPrice"]), 0, MidpointRounding.AwayFromZero).ToString();
                panel1.Controls.Add(bt);
                if (btnLocationY + 200 < panel1.Height) btnLocationY += 110;
                else { btnLocationX += 210; btnLocationY = 10; }
            }
        }
    }
}
