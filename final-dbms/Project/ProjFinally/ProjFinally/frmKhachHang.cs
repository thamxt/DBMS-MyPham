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
    public partial class frmKhachHang : Form
    {
        string name = "", pass = "";
        int role = 1;
        public frmKhachHang(string name,string pas,int role)
        {
            this.role = role;
            this.name = name;
            this.pass = pas;
            InitializeComponent();
        }
        SqlConnection myConn = null;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataKhachHang();
        }

     
        string strConnectionString = "Data Source=(local);Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";


        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[numrow].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[numrow].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[numrow].Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.Rows[numrow].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaKH.Text.Trim().Equals(""))
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
                cmd.CommandText = "addKHACHHANG";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = txtMaKH.Text;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = txtTenKH.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@SDT_KH", SqlDbType.NChar).Value = txtDienThoai.Text;
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    
                    MessageBox.Show("Đã thêm khách hàng thành công!");
                }
                else
                    MessageBox.Show("Thêm khách hàng thất bại! Hãy thử lại!");
            }
            else
            {
                MessageBox.Show("Mã khách hàng chưa có. Lỗi rồi! Hãy thử lại đi!");
                txtMaKH.Focus();
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
            txtMaKH.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateKHACHHANG";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = txtMaKH.Text;
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = txtTenKH.Text;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@SDT_KH", SqlDbType.NChar).Value = txtDienThoai.Text;
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                txtMaKH.Enabled = true;
                MessageBox.Show("Đã sửa khách hàng thành công!");
            }
            else
                MessageBox.Show("Sửa khách hàng thất bại! Hãy thử lại!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
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
            cmd.CommandText = "deleteKHACHHANG";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = txtMaKH.Text;
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

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadDataKhachHang();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            Form fm = new frmLichSuMuaHang();
            fm.Show();
        }

        private void LoadDataKhachHang()
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
            myCmd.CommandText = "showKHACHHANG";
            myCmd.Connection = myConn;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dgvKhachHang.DataSource = dt;
        }


    }
}
