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
    public partial class frmLichSuMuaHang : Form
    {
        SqlConnection myConn = null;
        string strConnectionString = "Data Source=(local);Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";
        public frmLichSuMuaHang()
        {
            InitializeComponent();
        }

        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
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
            string sql = "select * from LICHSUMUAHANG";
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myCmd.CommandType = CommandType.Text;
            myCmd.Connection = myConn;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dgvLichSuMH.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (myConn == null)
            {
                myConn = new SqlConnection(strConnectionString);
            }
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }
            string MaKhachHang = txtMaKH.Text;
            string sql = "SELECT * FROM LICHSUMUAHANG WHERE MaKH LIKE N'%" + MaKhachHang + "%'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, myConn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvLichSuMH.DataSource = dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) 
                this.Close();
        }
    }
}
