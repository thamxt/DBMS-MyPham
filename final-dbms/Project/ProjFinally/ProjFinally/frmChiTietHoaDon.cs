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

namespace ProjFinally
{
    public partial class frmChiTietHoaDon : Form
    {
        string name = "", pass = "";
        int role = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            string MaKhachHang = textBox1.Text;
            //  Tao Connection
            SqlDataAdapter da;
            DBConnection cnn = new DBConnection();
            //
            // Tạo câu lệnh truy vấn lấy toàn bộ view THONGKEBANHANG noi MaKH = MaKhachHang
            string sql = "SELECT * FROM THONGKEBANHANG WHERE MaKH LIKE N'%" + MaKhachHang + "%'";
            // Tạo một kết nối đến sql
            SqlConnection con = cnn.GetConnection1();
            // khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //mở kết nối
            con.Open();
            // Đổ dữ liệu từ sqlDataAdapter vào DataTable
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            // Đóng kết nối
            con.Close();
            dataGridView1.DataSource = dtt;

            int tong = 0;
            foreach (DataRow row in dtt.Rows)
            {
                tong = tong + Convert.ToInt32(row["ThanhTien"]);
            }
            textBox2.Text = tong.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form fm = new frmMainNV(this.name,this.pass,this.role);
            Hide();
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MaKhachHang = textBox1.Text;
            string MaHD = textBox3.Text;
            //  Tao Connection
            SqlDataAdapter da;
            DBConnection cnn = new DBConnection();
            //
            // Tạo câu lệnh truy vấn lấy toàn bộ view THONGKEBANHANG noi MaKH = MaKhachHang
            string sql = "SELECT * FROM THONGKEBANHANG WHERE MaKH LIKE N'%" + MaKhachHang + "%' and MaHD LIKE '%" + MaHD + "%' ";
            // Tạo một kết nối đến sql
            SqlConnection con = cnn.GetConnection1();
            // khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //mở kết nối
            con.Open();
            // Đổ dữ liệu từ sqlDataAdapter vào DataTable
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            // Đóng kết nối
            con.Close();
            dataGridView1.DataSource = dtt;

            int tong = 0;
            foreach (DataRow row in dtt.Rows)
            {
                tong = tong + Convert.ToInt32(row["ThanhTien"]);
            }
            textBox2.Text = tong.ToString();
        }

        public frmChiTietHoaDon(string name,string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }
    }
}
