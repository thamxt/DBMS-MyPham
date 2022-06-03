using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjFinally
{
    public partial class frmHoaDon : Form
    {
        HOADONBLL bllhoadon;
        string name = "", pass = "";
        int role = 1;
        public frmHoaDon(string name,string pass,int role)
        {
            this.name = name;
            this.pass = pass;
            this.role = role;
            InitializeComponent();
            bllhoadon = new HOADONBLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form fm = new frmMainNV(this.name,this.pass,this.role);
            fm.ShowDialog();
        }

        public void ShowAllHOADON()
        {
            DataTable dt = bllhoadon.getAllHOADON();
            dataGridView1.DataSource = dt;
        }

       
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            ShowAllHOADON();
        }

        int ID;

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                HOADON hoadon = new HOADON();

                hoadon.NgayLapHD = DateTime.Parse(dateTimePicker1.Text);
                hoadon.MaNV = textBox3.Text;
                hoadon.MaKH = textBox6.Text;
                hoadon.MaSP = textBox2.Text;
                hoadon.SoLuong = int.Parse(textBox7.Text);
                hoadon.Gia = int.Parse(textBox11.Text);
                hoadon.MucGiamGia = int.Parse(textBox8.Text);

                if (bllhoadon.InsertHOADON(hoadon))
                {
                    ShowAllHOADON();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi , xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            // kiem tra da nhap MaHD chua
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
            }
            if (CheckData())
            {
                HOADON hoadon = new HOADON();

                hoadon.MaHD = int.Parse(textBox1.Text);
                hoadon.NgayLapHD = DateTime.Parse(dateTimePicker1.Text);
                hoadon.MaNV = textBox3.Text;
                hoadon.MaKH = textBox6.Text;
                hoadon.MaSP = textBox2.Text;
                hoadon.SoLuong = int.Parse(textBox7.Text);
                hoadon.Gia = int.Parse(textBox11.Text);
                hoadon.MucGiamGia = int.Parse(textBox8.Text);

                if (bllhoadon.UpdateHOADON(hoadon))
                {
                    ShowAllHOADON();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi , xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HOADON hoadon = new HOADON();
                hoadon.MaHD = ID;
                if (bllhoadon.DeleteHOADON(hoadon))
                {
                    ShowAllHOADON();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi , xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon frmchitiethd = new frmChiTietHoaDon(this.name,this.pass,this.role);
            Hide();
            frmchitiethd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                HOADON hoadon = new HOADON();
                hoadon.MaHD = int.Parse(textBox1.Text);
                hoadon.NgayLapHD = DateTime.Parse(dateTimePicker1.Text);
                hoadon.MaNV = textBox3.Text;
                hoadon.MaKH = textBox6.Text;
                hoadon.MaSP = textBox2.Text;
                hoadon.SoLuong = int.Parse(textBox7.Text);
                hoadon.Gia = int.Parse(textBox11.Text);
                hoadon.MucGiamGia = int.Parse(textBox8.Text);

                if (bllhoadon.InsertSANPHAM(hoadon))
                {
                    ShowAllHOADON();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi , xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                HOADON hoadon = new HOADON();
                hoadon.MaHD = int.Parse(textBox1.Text);
                hoadon.NgayLapHD = DateTime.Parse(dateTimePicker1.Text);
                hoadon.MaNV = textBox3.Text;
                hoadon.MaKH = textBox6.Text;
                hoadon.MaSP = textBox2.Text;
                hoadon.SoLuong = int.Parse(textBox7.Text);
                hoadon.Gia = int.Parse(textBox11.Text);
                hoadon.MucGiamGia = int.Parse(textBox8.Text);

                if (bllhoadon.DeleteSANPHAM(hoadon))
                {
                    ShowAllHOADON();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi , xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dataGridView1.Rows[index].Cells["MaHD"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[index].Cells["MaHD"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[index].Cells["NgayLapHD"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[index].Cells["MaKH"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[index].Cells["MaNV"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[index].Cells["MaSP"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[index].Cells["SoLuong"].Value.ToString();
                textBox11.Text = dataGridView1.Rows[index].Cells["Gia"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[index].Cells["MucGiamGia"].Value.ToString();
                textBox12.Text = dataGridView1.Rows[index].Cells["ThanhTien"].Value.ToString();

            }
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Bạn chưa nhập mức giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return false;

            }
            return true;
        }






    }
}
