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
    public partial class frmNhanVien : Form
    {
        string name = "", pass = "";
        int role = 1;
        SqlConnection myConn = null;
        bool Them = false;
        string strConnectionString = "Data Source=(local);Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";
        public frmNhanVien(string name,string pass,int role)
        {
            this.role = role;
            this.name = name;
            this.pass = pass;
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataNhanVien();
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtChucVu.ResetText();
            this.txtDienThoai.ResetText();
            this.txtNgayLam.ResetText();
            this.txtLuong.ResetText();
            this.txtNgaySinh.ResetText();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[numrow].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[numrow].Cells[1].Value.ToString();
            txtChucVu.Text = dgvNhanVien.Rows[numrow].Cells[2].Value.ToString();
            txtDienThoai.Text = dgvNhanVien.Rows[numrow].Cells[3].Value.ToString();
            txtNgayLam.Text = dgvNhanVien.Rows[numrow].Cells[4].Value.ToString();
            txtLuong.Text = dgvNhanVien.Rows[numrow].Cells[5].Value.ToString();
            txtNgaySinh.Text = dgvNhanVien.Rows[numrow].Cells[6].Value.ToString();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadDataNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!txtMaNV.Text.Trim().Equals(""))
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
                cmd.CommandText = "addNHANVIEN";
                cmd.Connection = myConn;
                cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txtMaNV.Text;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = txtTenNV.Text;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = txtChucVu.Text;
                cmd.Parameters.Add("@SDT_NV", SqlDbType.NChar).Value = txtDienThoai.Text;
                cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = txtNgayLam.Text;
                cmd.Parameters.Add("@Luong", SqlDbType.Int).Value = txtLuong.Text;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtNgaySinh.Text;
                int count = cmd.ExecuteNonQuery();
                //myConn.Close();
                if (count > 0)
                {
                    MessageBox.Show("Đã thêm nhân viên thành công!");
                }
                else
                    MessageBox.Show("Thêm thất bại! Hãy thử lại!");
            }
            else
            {
                MessageBox.Show("Mã nhân viên chưa có. Lỗi rồi! Hãy thử lại đi!");
                txtMaNV.Focus();
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
            txtMaNV.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateNHANVIEN";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txtMaNV.Text;
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = txtTenNV.Text;
            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = txtChucVu.Text;
            cmd.Parameters.Add("@SDT_NV", SqlDbType.NChar).Value = txtDienThoai.Text;
            cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = txtNgayLam.Text;
            cmd.Parameters.Add("@Luong", SqlDbType.Int).Value = txtLuong.Text;
            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtNgaySinh.Text;
            int count = cmd.ExecuteNonQuery();
            //myConn.Close();
            if (count > 0)
            {
                txtMaNV.Enabled = true;
                MessageBox.Show("Đã sửa nhân viên thành công!");
            }
            else
                MessageBox.Show("Sửa thất bại! Hãy thử lại!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtChucVu.ResetText();
            this.txtDienThoai.ResetText();
            this.txtNgayLam.ResetText();
            this.txtLuong.ResetText();
            this.txtNgaySinh.ResetText();
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
            cmd.CommandText = "deleteNHANVIEN";
            cmd.Connection = myConn;
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txtMaNV.Text;
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

        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadDataNhanVien()
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
            myCmd.CommandText = "showNHANVIEN";
            myCmd.Connection = myConn;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }



    }
}
