using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataProviders;

namespace MainForm
{
    public partial class QLykhachhang : Form
    {
        DataTable dt = new DataTable();
        DataProvider dp = new SQLProvider();

        public QLykhachhang()
        {
            InitializeComponent();
        }
        
        private void QLy1_Load(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = dp.Execute_Table("select * from KhachHang");
            this.dataGridView2.DataSource = dp.Execute_Table("select * from LoaiKhachHang");
            dt = dp.Execute_Table("Select * from LoaiKhachHang");
            txtloaikh.DataSource = dt;
            txtloaikh.DisplayMember = "MaLoaiKH";
            txtloaikh.ValueMember = "MaLoaiKH";
        }
        
        
        //Bang chi tiet khach hang


        private void Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsocm.Text== "")

                {
                    MessageBox.Show("Bạn phải nhập SoCM !");
                    return;
                }
                if (txtmakh.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaKH !");
                    return;
                }
                if (txtngaysinhkh.Value.Year >= DateTime.Now.Year - 10)
                {
                    MessageBox.Show("Năm sinh phải lớn hơn năm hiện tại là 10 !");
                    return;
                }
            }
            catch
            {
            }
            string SPName = "insert_KhachHang_1";
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("MaKH", this.txtmakh.Text);
            para[1] = new SqlParameter("HoKH", this.txthokh.Text);
            para[2] = new SqlParameter("TenKH", this.txttenkh.Text);
            para[3] = new SqlParameter("SoCM", this.txtsocm.Text);
            para[4] = new SqlParameter("NgaySinh", DateTime.Parse(this.txtngaysinhkh.Text));
            para[5] = new SqlParameter("LoaiKH", this.txtloaikh.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from KhachHang");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Thêm Không được !");
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            string SPName = "delete_KhachHang_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaKH",this.txtmakh.Text);
            txtmakh.DataBindings.Clear();
            txthokh.DataBindings.Clear();
            txttenkh.DataBindings.Clear();
            txtsocm.DataBindings.Clear();
            txtngaysinhkh.DataBindings.Clear();
            txtloaikh.DataBindings.Clear();
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select*from KhachHang");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Xoá thất bại !");
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmakh.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaKH cần sửa !");
                }
                if (txtsocm.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập SoCM !");
                    return;
                }
                if (txtngaysinhkh.Value.Year >= DateTime.Now.Year - 10)
                {
                    MessageBox.Show("Năm sinh phải lớn hơn năm hiện tại là 10 !");
                    return;
                }
            }
            catch
            { }
            string SPName = "update_KhachHang_1";
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("MaKH", this.txtmakh.Text);
            para[1] = new SqlParameter("HoKH", this.txthokh.Text);
            para[2] = new SqlParameter("TenKH", this.txttenkh.Text);
            para[3] = new SqlParameter("SoCM", this.txtsocm.Text);
            para[4] = new SqlParameter("NgaySinh", DateTime.Parse(this.txtngaysinhkh.Text));
            para[5] = new SqlParameter("LoaiKH", this.txtloaikh.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from KhachHang");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Cập nhật thất bại !");
        }
        public void Load_KhachHang()
        {
            string s = "select *from KhachHang";
            dataGridView3.DataSource = dp.Execute_Table(s);
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            txtmakh.Text = "";
            txtmakh.Enabled=true;
            txthokh.Text = "";
            txttenkh.Text = "";
            txtngaysinhkh.Text = "";
            txtsocm.Text = "";
            txtloaikh.Text = "";
            this.Load_KhachHang();
        }


        //Bang chi tiet loai khach hang

        private void thems_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmaloaikh.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaLoaiKH !");
                    return;
                }
            }
            catch
            { }
            string SPName = "insert_LoaiKhachHang_1";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("MaLoaiKH",this.txtmaloaikh.Text);
            para[1] = new SqlParameter("TenLoaiKH",this.txttenloaikh.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("select * from LoaiKhachHang ");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được !");
        }

        private void xoas_Click(object sender, EventArgs e)
        {
            string SPName = "delete_LoaiKhachHang_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaLoaiKH",this.txtmaloaikh.Text);
            txtmaloaikh.DataBindings.Clear();
            txttenloaikh.DataBindings.Clear();
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("select * from LoaiKhachHang ");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Load_LoaiKhachHang()
        {
            string s="select * from LoaiKhachHang";
            this.dataGridView2.DataSource = dp.Execute_Table(s);
        }
        private void refreshs_Click(object sender, EventArgs e)
        {
            txtmaloaikh.Text = "";
            txtmaloaikh.Enabled = true;
            txttenloaikh.Text = "";
            this.Load_LoaiKhachHang();
        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            string SPName = "update_LoaiKhachHang_1";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("MaLoaiKH", this.txtmaloaikh.Text);
            para[1] = new SqlParameter("TenLoaiKH", this.txttenloaikh.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("select * from LoaiKhachHang ");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Cập nhật thất bại !");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
