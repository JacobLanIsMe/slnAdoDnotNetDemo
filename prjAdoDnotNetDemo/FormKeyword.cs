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
    public partial class FormKeyword : Form
    {
        public FormKeyword()
        {
            InitializeComponent();
        }
        bool _isOKClick = false;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            _isOKClick = true;
            this.Close();
        }
        public string keyword
        {
            get { return txtKeyword.Text; }
            set { txtKeyword.Text = value; }
        }
        public bool isOKButtonClick
        {
            get { return _isOKClick; }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
