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
    public partial class frmMainNV : Form
    {
        string name = "";
        string pass = "";
        int role = 0;
        public frmMainNV(string name,string user,int role)
        {
            this.name = name;
            this.pass = user;
            this.role = role;
            InitializeComponent();
            if (this.role == 1)
            {
                thôngTinTàiKhoảnToolStripMenuItem.Visible = false;
                nhàCungCấpToolStripMenuItem.Visible = false;
                lôHàngToolStripMenuItem.Visible = false;
                chiTiếtLôHàngToolStripMenuItem.Visible = false;
                nhânViênToolStripMenuItem.Visible = false;
                quảnLýBánHàngToolStripMenuItem.Visible = false;



            }
            
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form fm = new frmThongTinTaiKhoan(this.name,this.pass,this.role);
            fm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void frmMainNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmSanPham(this.name, this.pass, this.role);
            fm.Show();
        }

        private void lôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmLoHang(this.name,this.pass,this.role);
            fm.Show();

        }

        private void chiTiếtLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmLoHangChiTiet(this.name, this.pass, this.role);
            fm.Show();

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmNhanVien(this.name, this.pass, this.role);
            fm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmCongTy(this.name, this.pass, this.role);
            fm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmKhachHang(this.name, this.pass, this.role);
            fm.Show();
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmHoaDon(this.name, this.pass, this.role);
            fm.Show();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmChiTietHoaDon(this.name, this.pass, this.role);
            fm.Show();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmBAOCAO(this.name, this.pass, this.role);
            fm.Show();
        }

        private void frmMainNV_Load(object sender, EventArgs e)
        {

        }

        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form fm = new frmThongKe(this.name, this.pass, this.role);
            fm.Show();
        }
    }
}
