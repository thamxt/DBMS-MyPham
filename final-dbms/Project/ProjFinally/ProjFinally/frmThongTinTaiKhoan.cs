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
using System.Configuration;

namespace ProjFinally
{
    public partial class frmThongTinTaiKhoan : Form
    {
        string name = "";
        string pass = "";
        int q=1;

        public frmThongTinTaiKhoan(string name,string pass,int q)
        {
            this.name = name;
            this.q = q;
            this.pass = pass;
            InitializeComponent();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThongTinTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form fm = new frmMainNV(this.name, this.pass, this.q);
            fm.Show();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection(name, pass);
                conn.Open();
                MessageBox.Show("waiting Connect to database...");

                SqlDataAdapter daAcc = null;
                DataTable dtAcc = null;

                daAcc = new SqlDataAdapter("select * from TAIKHOAN", conn);
                dtAcc = new DataTable();
                daAcc.Fill(dtAcc);
                dgvAcc.DataSource = dtAcc;

            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG. Lỗi rồi!!!");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = DBConnection.GetConnection(name, pass);
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "addTAIKHOAN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add("@useID", SqlDbType.VarChar).Value = txtUser.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
                cmd.Parameters.Add("@role", SqlDbType.Int).Value =Convert.ToInt32(txtRole.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("thong cong");
                
                txtRole.ResetText();
                txtUser.ResetText();
                txtPass.ResetText();
                txtUser.Focus();
                con.Close();

            }
            catch(SqlException)
            {
                MessageBox.Show("kkk insert dc ");
                con.Close();
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = DBConnection.GetConnection(name, pass);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "updateTAIKHOAN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add("@useID", SqlDbType.VarChar).Value = txtUser.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;
                cmd.Parameters.Add("@role", SqlDbType.Int).Value = Convert.ToInt32(txtRole.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("thong cong");

                
                con.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("kkk update dc ");
                con.Close();
            }
        }

        private void dgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAcc.Rows[e.RowIndex];
                txtUser.Text = row.Cells[0].Value.ToString();
                txtPass.Text = row.Cells[1].Value.ToString();
                txtRole.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            SqlConnection con = DBConnection.GetConnection(name, pass);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deleteTAIKHOAN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add("@useID", SqlDbType.VarChar).Value = txtUser.Text;


                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("thong cong");


                con.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("kkk delete dc ");
                con.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form fm = new frmMainNV(this.name, this.pass, this.q);
            fm.Show();
        }
    }
}
