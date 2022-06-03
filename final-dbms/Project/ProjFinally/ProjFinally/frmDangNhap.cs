using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace ProjFinally
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string name = txtUser.Text;
           
            SqlConnection conn = DBConnection.GetConnection(name, pass);
            try
            {
                MessageBox.Show("Openning Connection ...");
                conn.Open();
                if (radNV.Checked == true)
                {
                    this.Hide();
                    Form fm = new frmMainNV(name, pass, 1);
                    fm.Show();
                }
                if (radQL.Checked==true)
                {
                    this.Hide();
                    Form fm = new frmMainNV(name, pass, 0);
                    fm.Show();
                }
                conn.Close();
               
            }
            catch (Exception t)
            {
                MessageBox.Show("Error: " + t.Message);
                
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
           
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                Application.Exit();
        }
    }
}
