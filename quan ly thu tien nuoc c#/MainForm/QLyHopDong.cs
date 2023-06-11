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
    public partial class QLyHopDong : Form
    {
        DataTable nv = new DataTable();
        DataTable kh = new DataTable();
        DataTable loaikh = new DataTable();
        DataTable dongia = new DataTable();
        DataTable hopdong = new DataTable();
        DataTable thietbi = new DataTable();
        DataProvider dp = new SQLProvider();
        public QLyHopDong()
        {
            InitializeComponent();
        }

        private void QLyHopDong_Load(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = dp.Execute_Table("select * from HopDong");
            this.dataGridView1.DataSource = dp.Execute_Table("select * from CTHopDong");
            this.dataGridView2.DataSource = dp.Execute_Table("select * from DonGia");
            this.dataGridView4.DataSource = dp.Execute_Table("select * from HoaDon");
            nv = dp.Execute_Table("select * from NhanVien");
            kh = dp.Execute_Table("select * from KhachHang");
            loaikh = dp.Execute_Table("select * from LoaiKhachHang");
            dongia = dp.Execute_Table("select * from DonGia");
            hopdong = dp.Execute_Table("select * from HopDong");
            thietbi = dp.Execute_Table("select * from ThietBi");
            txtmanvhd.DataSource = nv;
            txtmanvhd.DisplayMember = "MaNV";
            txtmanvhd.ValueMember = "MaNV";
            txtmakhhd.DataSource = kh;
            txtmakhhd.DisplayMember = "MaKH";
            txtmakhhd.ValueMember = "MaKH";
            txtloakhdg.DataSource = loaikh;
            txtloakhdg.DisplayMember = "MaLoaiKH";
            txtloakhdg.ValueMember = "MaLoaiKH";
            txtmakhachhanghd.DataSource = kh;
            txtmakhachhanghd.DisplayMember = "MaKH";
            txtmakhachhanghd.ValueMember = "MaKH";
            txtmadongiahoadon.DataSource = dongia;
            txtmadongiahoadon.DisplayMember = "MaDGia";
            txtmadongiahoadon.ValueMember = "MaDGia";
            txtmanvhd.DataSource = nv;
            txtmanvhd.DisplayMember = "MaNV";
            txtmanvhd.ValueMember = "MaNV";
            txtmahopdocthp.DataSource = hopdong;
            txtmahopdocthp.DisplayMember = "MaHDong";
            txtmahopdocthp.ValueMember = "MaHDong";
            txtmatbcthp.DataSource = thietbi;
            txtmatbcthp.DisplayMember = "MaTBi";
            txtmatbcthp.ValueMember = "MaTBi";
        }


        //Bảng hợp đồng


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahd.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHD !");
                    return;
                }
            }
            catch
            { }
            string s = "update_HopDong_1";
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("MaHDong", this.txtmahd.Text);
            para[1] = new SqlParameter("MaKH", this.txtmakhhd.Text);
            para[2] = new SqlParameter("MaNV", this.txtmanvhd.Text);
            para[3] = new SqlParameter("NgayThang", DateTime.Parse(this.txtngaythanghd.Text));
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from HopDong");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được !");
        }

        private void txtThenhd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahd.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHD !");
                    return;
                }
            }
            catch
            { }
            string s = "insert_HopDong_1";
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("MaHDong", this.txtmahd.Text);
            para[1] = new SqlParameter("MaKH",this.txtmakhhd.Text);
            para[2] = new SqlParameter("MaNV",this.txtmanvhd.Text);
            para[3] = new SqlParameter("NgayThang",DateTime.Parse(this.txtngaythanghd.Text));
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from HopDong");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được !");
        }

        private void xoahd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahd.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHD cần xoá !");
                    return;
                }
            }
            catch { }
            string s = "delete_HopDong_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaHDong", this.txtmahd.Text);
            txtmahd.DataBindings.Clear();
            txtmakhhd.DataBindings.Clear();
            txtmanvhd.DataBindings.Clear();
            txtngaythanghd.DataBindings.Clear();
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from HopDong");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }
        private void Load_HopDong()
        {
            string s = "select * from HopDong";
            this.dataGridView3.DataSource = dp.Execute_Table(s);
        }
        private void Refreshhd_Click(object sender, EventArgs e)
        {
            txtmahd.Text = "";
            txtmahd.Enabled = true;
            txtmakhhd.Text = "";
            txtmanvhd.Text = "";
            txtngaythanghd.Text = "";
            this.Load_HopDong();
        }

        private void Timhd_Click(object sender, EventArgs e)
        {
            string s = "select * from HopHong where (MaHD like '%"+this.txtmahd.Text+"%') and (MaKH lile '%"+this.txtmakhhd.Text+"%') and ( MaNV like '%"+this.txtmanvhd.Text+"%')";
            this.dataGridView3.DataSource = dp.Execute_Table(s);
        }

        private void Closehd_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahopdocthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHDong !");
                    return;
                }
                if (txtmatbcthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTBi !");
                    return;
                }
            }
            catch { }
            string s = "insert_CTHopDong_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaHDong", this.txtmahopdocthp.Text);
            para[1] = new SqlParameter("MaTBi", this.txtmatbcthp.Text);
            para[2] = new SqlParameter("SoLuongTB", this.txtsoluongtbcthd.Text.Trim());
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from CTHopDong");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Không cập nhật được !");
        }
        private void Load_CTHopDong()
        {
            string s = "select * from CTHopDong";
            this.dataGridView1.DataSource = dp.Execute_Table(s);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            txtmahopdocthp.Text = "";
            txtmahopdocthp.Enabled = true;
            txtmatbcthp.Text = "";
            txtmatbcthp.Enabled = true;
            txtsoluongtbcthd.Text = "";
            this.Load_CTHopDong();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "select * from CTHopDong where (MaHDong like '%"+this.txtmahopdocthp.Text+"%') and (maTBi where like '%"+this.txtmatbcthp.Text+"%')";
            this.dataGridView1.DataSource = dp.Execute_Table(s);
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void themcthd_Click(object sender, EventArgs e)
        {   
            try
            {
                if (txtmahopdocthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHDong !");
                    return;
                }
                if (txtmatbcthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTBi !");
                    return;
                }
            }
            catch { }
            string s = "insert_CTHopDong_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaHDong", this.txtmahopdocthp.Text);
            para[1] = new SqlParameter("MaTBi", this.txtmatbcthp.Text);
            para[2] = new SqlParameter("SoLuongTB", this.txtsoluongtbcthd.Text.Trim());
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from CTHopDong");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được !");
        }

        private void xoacthd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahopdocthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHDong cần xóa!");
                    return;
                }
                if (txtmatbcthp.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTBi cần xoá ");
                    return;
                }
            }
            catch { }
            string s = "delete_CTHopDong_1";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("MaHDong",this.txtmahopdocthp.Text);
            para[1] = new SqlParameter("MaTBi",this.txtmatbcthp.Text);
            txtmahopdocthp.DataBindings.Clear();
            txtmatbcthp.DataBindings.Clear();
            txtsoluongtbcthd.DataBindings.Clear();
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("Select * from CTHopDong");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void closecthd_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }



        //Bảng đơn giá :

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmadg.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaDGia !");
                    return;
                }
            }
            catch
            { }
            string SPName = "insert_DonGia_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaDGia", this.txtmadg.Text);
            para[1] = new SqlParameter("LoaiKH", this.txtloakhdg.Text);
            para[2] = new SqlParameter("DonGia", this.txtdongiadg.Text.Trim());
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("Select * from DonGia");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được ! bạn hãy xem lại các thông tìn vừa nhập có hợp lệ không !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmadg.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaDG cần xoá");
                    return;
                }
            }
            catch
            { }
            string s = "delete_DonGia_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaDGia",this.txtmadg.Text);
            txtmadg.DataBindings.Clear();
            txtloakhdg.DataBindings.Clear();
            txtdongiadg.DataBindings.Clear();
            if (dp.Execute_Modify(s, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("select * from DonGia");
                    MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtmadg.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaDGia cần sửa !");
                    return;
                }
            }
            catch
            { }
            string SPName = "update_DonGia_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaDGia", this.txtmadg.Text);
            para[1] = new SqlParameter("LoaiKH", this.txtloakhdg.Text);
            para[2] = new SqlParameter("DonGia", this.txtdongiadg.Text.Trim());
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView2.DataSource = dp.Execute_Table("Select * from DonGia");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Không cập nhật được ! bạn hãy xem lại các thông tìn vừa nhập có hợp lệ không !");
        }
        private void Load_DonGia()
        {
            this.dataGridView2.DataSource = dp.Execute_Table("select * from DonGia");
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            txtmadg.Text = "";
            txtmadg.Enabled = true;
            txtloakhdg.Text = "";
            txtdongiadg.Text = "";
            this.Load_DonGia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        //Bảng hợp đồng 


        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahoadon.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHDon !");
                    return;
                }
                if (int.Parse(this.txtsokthoadoa.Text.Trim()) < int.Parse(this.txtsobdhoadon.Text.Trim()))
                {
                    MessageBox.Show("SoKT phai lon hon SoBD");
                    return;
                }
            }
            catch { }
            string s = "insert_HoaDon_1";
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("MaHDon",this.txtmahoadon.Text);
            p[1] = new SqlParameter("MaKH",this.txtmakhachhanghd.Text);
            p[2] = new SqlParameter("NgayThang",DateTime.Parse(this.txtngaythanghd.Text));
            p[3] = new SqlParameter("SoBD",this.txtsobdhoadon.Text.Trim());
            p[4] = new SqlParameter("SoKT",this.txtsokthoadoa.Text.Trim());
            p[5] = new SqlParameter("MaDGia",this.txtmadongiahoadon.Text);
            if (dp.Execute_Modify(s, p) >= 1)
            {
                this.dataGridView4.DataSource = dp.Execute_Table("select * from HoaDon");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được ! Xem lại các thông tin vừa nhập có hợp lệ không !");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahoadon.Text == "")
                {
                    MessageBox.Show("Bạn hãy nhập MaHDon cần xoá !");
                    return;
                }
            }
            catch { }
            string s = "delete_HoaDon_1";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("MaHDon",this.txtmahoadon.Text);
            txtmahoadon.DataBindings.Clear();
            txtmakhachhanghd.DataBindings.Clear();
            txtngaythanghd.DataBindings.Clear();
            txtsobdhoadon.DataBindings.Clear();
            txtsokthoadoa.DataBindings.Clear();
            txtmadongiahoadon.DataBindings.Clear();
            if (dp.Execute_Modify(s, p) >= 1)
            {
                this.dataGridView4.DataSource = dp.Execute_Table("select * from HoaDon");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahoadon.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaHDon !");
                    return;
                }
                if (int.Parse(this.txtsokthoadoa.Text) < int.Parse(this.txtsobdhoadon.Text))
                {
                    MessageBox.Show("SoKT phai lon hon SoBD");
                    return;
                }
            }
            catch { }
            string s = "update_HoaDon_1";
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("MaHDon", this.txtmahoadon.Text);
            p[1] = new SqlParameter("MaKH", this.txtmakhachhanghd.Text);
            p[2] = new SqlParameter("NgayThang", DateTime.Parse(this.txtngaythanghd.Text));
            p[3] = new SqlParameter("SoBD", this.txtsobdhoadon.Text.Trim());
            p[4] = new SqlParameter("SoKT", this.txtsokthoadoa.Text.Trim());
            p[5] = new SqlParameter("MaDGia", this.txtmadongiahoadon.Text);
            if (dp.Execute_Modify(s, p) >= 1)
            {
                this.dataGridView4.DataSource = dp.Execute_Table("select * from HoaDon");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Không cập nhật được ! Xem lại các thông tin vừa nhập có hợp lệ không !");
        }
        private void Load_HoaDon()
        {
            this.dataGridView4.DataSource = dp.Execute_Table("select * from HoaDon");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            txtmahoadon.Text = "";
            txtmahoadon.Enabled = true;
            txtmakhachhanghd.Text = "";
            txtngaythanghd.Text = "";
            txtsobdhoadon.Text = "";
            txtsokthoadoa.Text = "";
            txtmadongiahoadon.Text = "";
            this.Load_HoaDon();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s = "select * from HoaDon where MaKH like '%"+this.txtmakhachhanghd.Text+"%'";
            this.dataGridView4.DataSource = dp.Execute_Table(s);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
