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
    public partial class frmThongKe : Form
    {
        string name = "";
        string pass = "";
        int role = 1;
        public frmThongKe(string name , string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmMainNV(this.name, this.pass, this.role);
            fm.Show();
        }

        // kiem tra san pham ton kho
        private void button7_Click(object sender, EventArgs e)
        {
            //  Tao Connection
            SqlDataAdapter da;
            DBConnection cnn = new DBConnection();
            //
            // Tạo câu lệnh truy vấn lấy lich su mua hang cua khach hang
            string sql = "select * from BAOCAOTONKHO";
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
            dataGridView4.DataSource = dtt;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // dem so luong hoa don trong mot khoang thoi gian
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //  Tao Connection
            SqlDataAdapter da;
            DBConnection cnn = new DBConnection();
            //
            // Tạo câu lệnh truy vấn lấy toàn bộ view THONGKEBANHANG noi MaKH = MaKhachHang
            string sql = "SELECT * FROM THONGKEBANHANG";
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

        private void button2_Click(object sender, EventArgs e)
        {

            //  Tao Connection
            SqlDataAdapter da;
            DBConnection cnn = new DBConnection();
            //
            // Tạo câu lệnh truy vấn lấy toàn bộ view THONGKENHAPHANG noi MaKH = MaKhachHang
            string sql = "SELECT * FROM THONGKENHAPHANG";
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
            dataGridView2.DataSource = dtt;

            int tong = 0;
            foreach (DataRow row in dtt.Rows)
            {
                tong = tong + Convert.ToInt32(row["ThanhTien"]);
            }
            textBox1.Text = tong.ToString();
        }
    }
}
