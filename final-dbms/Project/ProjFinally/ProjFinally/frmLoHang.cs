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
    public partial class frmLoHang : Form
    {

        string strConnectionString = "Data Source=(local);" +
            "Initial Catalog=QuanLyCuaHangMyPham;" +
            "Integrated Security=True";
        string name = "", pass = "";
        int role = 1;

        SqlConnection conn = null;

        bool Them = false;
        // Phuong thuc dung chung
        void LoadData()
        {

            try
            {
                //
                DataTable dt = new DataTable();

                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand myCmd = new SqlCommand();
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.CommandText = "allLoHang";
                myCmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dgvLoHang.DataSource = dt;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
                txtMaLo.Enabled = true;



            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Lo Hang. Lỗi rồi!!!");
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLo.Enabled = true;


            Them = true;

            txtMaLo.ResetText();
            txtMaNV.ResetText();
            txtNgayLap.ResetText();
            txtMaCT.ResetText();

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;

            txtMaLo.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            dgvLoHang_CellClick(null, null);
            txtMaLo.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            // panel.Enabled = false;
        }

        private void dgvLoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = dgvLoHang.CurrentCell.RowIndex;

            txtMaLo.Text =
            dgvLoHang.Rows[r].Cells[0].Value.ToString();

            txtNgayLap.Text =
            dgvLoHang.Rows[r].Cells[1].Value.ToString();

            txtMaNV.Text =
            dgvLoHang.Rows[r].Cells[2].Value.ToString();

            txtMaCT.Text =
            dgvLoHang.Rows[r].Cells[3].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!txtMaLo.Text.Trim().Equals(""))
            {
                // Mở kết nối 
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                // Thêm dữ liệu 
                if (Them)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand();

                        cmd.CommandText = "addLOHANG";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;


                        cmd.Parameters.Add("@MaLo", SqlDbType.Int).Value =  txtMaLo.Text;
                        cmd.Parameters.Add("@NgayLap", SqlDbType.NVarChar).Value = txtNgayLap.Text;
                        cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txtMaNV.Text;
                        cmd.Parameters.Add("@MaCT", SqlDbType.NVarChar).Value = txtMaCT.Text;

                        cmd.ExecuteNonQuery();

                        conn.Close();
                        LoadData();

                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
                else // sua doi
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand();

                        cmd.CommandText = "updateLOHANG";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;


                        int r = dgvLoHang.CurrentCell.RowIndex;

                        string strMaLo =
                        dgvLoHang.Rows[r].Cells[0].Value.ToString();

                        cmd.Parameters.Add("@MaLo", SqlDbType.Int).Value = int.Parse(strMaLo);
                        cmd.Parameters.Add("@NgayLap", SqlDbType.NVarChar).Value = txtNgayLap.Text;
                        cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txtMaNV.Text;
                        cmd.Parameters.Add("@MaCT", SqlDbType.NVarChar).Value = txtMaCT.Text;

                        cmd.ExecuteNonQuery();

                        conn.Close();
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!");
                    }
                }
                // Đóng kết nối 
                conn.Close();
            }
            else
            {
                MessageBox.Show("Mã KH chưa có. Lỗi rồi!");
                txtMaLo.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaLo.Enabled = true;

            txtMaLo.ResetText();
            txtMaNV.ResetText();
            txtNgayLap.ResetText();
            txtMaCT.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult traloi;

            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                // Mở kết nối 
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "deleteLOHANG";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    int r = dgvLoHang.CurrentCell.RowIndex;
                    string strMAKH =
                    dgvLoHang.Rows[r].Cells[0].Value.ToString();

                    cmd.Parameters.Add("@MaLo", SqlDbType.Int).Value = int.Parse(strMAKH);

                    cmd.ExecuteNonQuery();
                    //đóng chuỗi kết nối.
                    conn.Close();


                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
                finally
                {
                    // Đóng kết nối 
                    conn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmMainNV(this.name, this.pass, this.role);
            fm.Show();
        }

        private void frmLoHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public frmLoHang(string name, string pass, int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }


    }
}