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
    public partial class frmLoHangChiTiet : Form
    {
        string name = "", pass = "";
        int role = 1;
        public frmLoHangChiTiet(string name,string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }
        string strConnectionString = "Data Source=(local);" +
            "Initial Catalog=QuanLyCuaHangMyPham;" +
            "Integrated Security=True";

        SqlConnection conn = null;

        bool Them = false;

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            Them = true;

            txtMaLo_CT.ResetText();
            txtMaSP.ResetText();
            txtMucGiamGia.ResetText();
            txtSoLuong.ResetText();
            txtGia.ResetText();

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;

            txtMaLo_CT.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            dgvChiTietLoHang_CellClick(null, null);

            txtMaLo_CT.Enabled = false;
            txtMaSP.Enabled = false;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void dgvChiTietLoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChiTietLoHang.CurrentCell.RowIndex;

            txtMaLo_CT.Text =
            dgvChiTietLoHang.Rows[r].Cells[0].Value.ToString();

            txtMaSP.Text =
            dgvChiTietLoHang.Rows[r].Cells[1].Value.ToString();


            txtSoLuong.Text =
            dgvChiTietLoHang.Rows[r].Cells[2].Value.ToString();
            txtGia.Text =
            dgvChiTietLoHang.Rows[r].Cells[3].Value.ToString();
            txtMucGiamGia.Text =
            dgvChiTietLoHang.Rows[r].Cells[4].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // kiem chung du lieu
            if (!txtMaLo_CT.Text.Trim().Equals(""))
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
                        //sử dụng thuộc tính CommandText để chỉ định tên Proc
                        cmd.CommandText = "addLOHANGCHITIET";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        //khai báo các thông tin của tham số truyền vào

                        cmd.Parameters.Add("@MaLo_CT", SqlDbType.Int).Value = txtMaLo_CT.Text;
                        cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = txtMaSP.Text;
                        cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = txtSoLuong.Text;
                        cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = txtGia.Text;
                        cmd.Parameters.Add("@MucGiamGia", SqlDbType.Int).Value = txtMucGiamGia.Text;

                        cmd.ExecuteNonQuery();
                        //đóng chuỗi kết nối.
                        conn.Close();
                        LoadData();
                        // Thông báo 
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
                        //sử dụng thuộc tính CommandText để chỉ định tên Proc
                        cmd.CommandText = "updateLOHANGCHIIET";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;


                        int r = dgvChiTietLoHang.CurrentCell.RowIndex;

                        string strMaLo_CT =
                        dgvChiTietLoHang.Rows[r].Cells[0].Value.ToString();

                        cmd.Parameters.Add("@MaLo_CT", SqlDbType.Int).Value = int.Parse(strMaLo_CT);

                        cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = txtMaSP.Text;
                        cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = txtSoLuong.Text;
                        cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = txtGia.Text;
                        cmd.Parameters.Add("@MucGiamGia", SqlDbType.Int).Value = txtMucGiamGia.Text;

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
                txtMaLo_CT.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            txtMaLo_CT.ResetText();
            txtMaSP.ResetText();
            txtGia.ResetText();
            txtMucGiamGia.ResetText();
            txtSoLuong.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            // panel.Enabled = false;
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

                    cmd.CommandText = "deleteLOHANGCHITIET";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    int r = dgvChiTietLoHang.CurrentCell.RowIndex;

                    string strMaLo_CT =
                    dgvChiTietLoHang.Rows[r].Cells[0].Value.ToString();

                    cmd.Parameters.Add("MaLo_CT", SqlDbType.Int).Value = int.Parse(strMaLo_CT);

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

        private void frmLoHangChiTiet_Load(object sender, EventArgs e)
        {
            LoadData();
        }

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
                myCmd.CommandText = "allLoHangChiTiet";
                myCmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dgvChiTietLoHang.DataSource = dt;
                dgvChiTietLoHang.DataSource = dt;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
                txtMaLo_CT.Enabled = true;
                txtMaSP.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Lô hàng chi tiết. Lỗi rồi!!!");
            }
        }
    }
}
