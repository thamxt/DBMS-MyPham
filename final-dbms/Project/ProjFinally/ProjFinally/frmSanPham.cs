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
    public partial class frmSanPham : Form
    {
        string name = "", pass = "";
        int role = 1;
        string strConnectionString = "Data Source=(local);" +
            "Initial Catalog=QuanLyCuaHangMyPham;" +
            "Integrated Security=True";

        SqlConnection conn = null;

        bool Them = false;

        void LoadData()
        {

            try
            {

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
                myCmd.CommandText = "allSanPham";
                myCmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dgvSanPham.DataSource = dt;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
                txtMaSP.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table SanPham. Lỗi rồi!!!");
            }
        }
        public frmSanPham(string name, string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }

       

    
     
                     

        
    

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtGia.ResetText();
            txtNSX.ResetText();
            txtHSD.ResetText();
            txtMaDM.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

       
    
    

        private void btnThem_Click(object sender, EventArgs e)
        {

            Them = true;

            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtGia.ResetText();
            txtNSX.ResetText();
            txtHSD.ResetText();
            txtMaDM.ResetText();

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
        }


        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = dgvSanPham.CurrentCell.RowIndex;

            txtMaSP.Text =
            dgvSanPham.Rows[r].Cells[0].Value.ToString();
            txtTenSP.Text =
                dgvSanPham.Rows[r].Cells[1].Value.ToString();
            txtGia.Text =
                dgvSanPham.Rows[r].Cells[2].Value.ToString();
            txtNSX.Text =
                dgvSanPham.Rows[r].Cells[3].Value.ToString();
            txtHSD.Text =
                dgvSanPham.Rows[r].Cells[4].Value.ToString();
            txtMaDM.Text =
           dgvSanPham.Rows[r].Cells[5].Value.ToString();
        }

     

        private void frmSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            dgvSanPham_CellDoubleClick(null, null);

            txtMaSP.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (!txtMaSP.Text.Trim().Equals(""))
            {

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();

                if (Them)
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand();

                        cmd.CommandText = "addSANPHAM";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;


                        cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = txtMaSP.Text;
                        cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = txtTenSP.Text;
                        cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = txtGia.Text;
                        cmd.Parameters.Add("@NSX", SqlDbType.NVarChar).Value = txtNSX.Text;
                        cmd.Parameters.Add("@HSD", SqlDbType.NVarChar).Value = txtHSD.Text;
                        cmd.Parameters.Add("@MaDM", SqlDbType.NVarChar).Value = txtMaDM.Text;
                        cmd.Parameters.Add("@HinhSP", SqlDbType.NVarChar).Value = " ";


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

                        cmd.CommandText = "updateSANPHAM";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        int r = dgvSanPham.CurrentCell.RowIndex;

                        string strMaSP =
                        dgvSanPham.Rows[r].Cells[0].Value.ToString();
                        cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = strMaSP;

                        cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = txtTenSP.Text;
                        cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = txtGia.Text;
                        cmd.Parameters.Add("@NSX", SqlDbType.NVarChar).Value = txtNSX.Text;
                        cmd.Parameters.Add("@HSD", SqlDbType.NVarChar).Value = txtHSD.Text;
                        cmd.Parameters.Add("@MaDM", SqlDbType.NVarChar).Value = txtMaDM.Text;

                        cmd.Parameters.Add("@hinhSP", SqlDbType.NVarChar).Value = " ";

                        cmd.ExecuteNonQuery();

                        conn.Close();
                        LoadData();

                        MessageBox.Show("Đã sửa xong!");

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!");
                    }
                }


                conn.Close();
            }
            else
            {
                MessageBox.Show("Mã KH chưa có. Lỗi rồi!");
                txtMaSP.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;

            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "deleteSANPHAM";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;


                    int r = dgvSanPham.CurrentCell.RowIndex;

                    string strMaSP =
                    dgvSanPham.Rows[r].Cells[0].Value.ToString();

                    cmd.Parameters.Add("MaSP", SqlDbType.NVarChar).Value = strMaSP;


                    cmd.ExecuteNonQuery();

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

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

