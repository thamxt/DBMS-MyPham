using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ProjFinally
{
    public partial class frmCongTy : Form
    {
        string name = "", pass = "";
        int role = 1;
        public frmCongTy(string name,string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }

        SqlConnection myConn = null;
        string strConnectionString = "Data Source=(local);Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";

        private void frmCongTy_Load(object sender, EventArgs e)
        {
            LoadDataCongTy();
        }

        private void LoadDataCongTy()
        {
            DataTable dt = new DataTable();

            if (myConn == null)
            {
                myConn = new SqlConnection(strConnectionString);
            }
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = "showCONGTY";
            myCmd.Connection = myConn;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dgvCongTy.DataSource = dt;
        }

        private void dgvCongTy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaCT.Text = dgvCongTy.Rows[numrow].Cells[0].Value.ToString();
            txtTenCT.Text = dgvCongTy.Rows[numrow].Cells[1].Value.ToString();
            txtDienThoai.Text = dgvCongTy.Rows[numrow].Cells[3].Value.ToString();
            txtNgayHopTac.Text = dgvCongTy.Rows[numrow].Cells[4].Value.ToString();
            txtGiayPhep.Text = dgvCongTy.Rows[numrow].Cells[5].Value.ToString();
            txtDiaChi.Text = dgvCongTy.Rows[numrow].Cells[2].Value.ToString();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadDataCongTy();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaCT.Text.Trim().Equals(""))
            {
                if (myConn == null)
                {
                    myConn = new SqlConnection(strConnectionString);
                }
                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addCONGTY";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@MaCT", SqlDbType.NVarChar).Value = txtMaCT.Text;
                cmd.Parameters.Add("@TenCT", SqlDbType.NVarChar).Value = txtTenCT.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@SDT_CT", SqlDbType.NChar).Value = txtDienThoai.Text;
                cmd.Parameters.Add("@NgayHopTac", SqlDbType.Date).Value = txtNgayHopTac.Text;
                cmd.Parameters.Add("@GiayPhep", SqlDbType.NVarChar).Value = txtGiayPhep.Text;
                int count = cmd.ExecuteNonQuery();
                //myConn.Close();
                if (count > 0)
                {
                    MessageBox.Show("Đã thêm công ty thành công!");
                }
                else
                    MessageBox.Show("Thêm thất bại! Hãy thử lại!");
            }
            else
            {
                MessageBox.Show("Mã công ty chưa có. Lỗi rồi! Hãy thử lại đi!");
                txtMaCT.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (myConn == null)
            {
                myConn = new SqlConnection(strConnectionString);
            }
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }
            txtMaCT.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateCONGTY";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaCT", SqlDbType.NVarChar).Value = txtMaCT.Text;
            cmd.Parameters.Add("@TenCT", SqlDbType.NVarChar).Value = txtTenCT.Text;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@SDT_CT", SqlDbType.NChar).Value = txtDienThoai.Text;
            cmd.Parameters.Add("@NgayHopTac", SqlDbType.Date).Value = txtNgayHopTac.Text;
            cmd.Parameters.Add("@GiayPhep", SqlDbType.NVarChar).Value = txtGiayPhep.Text;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Sửa thành công!");
                txtMaCT.Enabled = true;
            }
            else
                MessageBox.Show("Sửa thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (myConn == null)
            {
                myConn = new SqlConnection(strConnectionString);
            }
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteCONGTY";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaCT", SqlDbType.NVarChar).Value = txtMaCT.Text;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
                MessageBox.Show("Xóa thất bại!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmMainNV(this.name, this.pass, this.role);
            fm.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaCT.ResetText();
            this.txtTenCT.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.txtNgayHopTac.ResetText();
            this.txtGiayPhep.ResetText();
        }
        
        


    }

}
