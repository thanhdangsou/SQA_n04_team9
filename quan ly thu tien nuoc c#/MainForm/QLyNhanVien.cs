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
    public partial class QLyNhanVien : Form
    {
        
        DataTable nhanvien = new DataTable();
        DataProvider dp = new SQLProvider();
        public QLyNhanVien()
        {
            InitializeComponent();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void Load_Nhanvien()
        {
            string s = "select * from NhanVien";
            this.dataGridView3.DataSource = dp.Execute_Table(s);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            txtmanv.Text = "";
            txtmanv.Enabled = true;
            txthonv.Text = "";
            txttennv.Text = "";
            txtngaysinhnv.Text = "";
            txtsodienthoainv.Text = "";
            txtdiachinv.Text = "";
            txtchucvunv.Text = "";
            this.Load_Nhanvien();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void closenv_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void themnv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmanv.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaNV !");
                    return;
                }
                if (txtngaysinhnv.Value.Year >= DateTime.Now.Year - 10)
                {
                    MessageBox.Show("năm sinh phải lớn hơn năm hiện tại là 10 !");
                    return;
                }
            }
            catch { }
            string SPName = "insert_NhanVien_1";
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("MaNV",this.txtmanv.Text);
            para[1] = new SqlParameter("HoNV",this.txthonv.Text);
            para[2] = new SqlParameter("TenNV",this.txttennv.Text);
            para[3] = new SqlParameter("NgaySinhNV",DateTime.Parse(this.txtngaysinhnv.Text));
            para[4] = new SqlParameter("DiaChi",this.txtdiachinv.Text);
            para[5] = new SqlParameter("SoDThoai", this.txtsodienthoainv.Text);
            para[6] = new SqlParameter("ChucVu",this.txtchucvunv.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from NhanVien");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được !");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void xoanv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmanv.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaNV cần xoá !");
                    return;
                }
            }
            catch
            { }
            string SPName = "delete_NhanVien_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaNV",this.txtmanv.Text);
            txtmanv.DataBindings.Clear();
            txthonv.DataBindings.Clear();
            txttennv.DataBindings.Clear();
            txtngaysinhnv.DataBindings.Clear();
            txtsodienthoainv.DataBindings.Clear();
            txtdiachinv.DataBindings.Clear();
            txtchucvunv.DataBindings.Clear();
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from NhanVien");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void suanv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmanv.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaNV !");
                    return;
                }
                if (txtngaysinhnv.Value.Year >= DateTime.Now.Year - 20)
                {
                    MessageBox.Show("năm sinh phải lớn hơn năm hiện tại là 10 !");
                    return;
                }
            }
            catch { }
            string SPName = "update_NhanVien_1";
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("MaNV", this.txtmanv.Text);
            para[1] = new SqlParameter("HoNV", this.txthonv.Text);
            para[2] = new SqlParameter("TenNV", this.txttennv.Text);
            para[3] = new SqlParameter("NgaySinhNV", DateTime.Parse(this.txtngaysinhnv.Text));
            para[4] = new SqlParameter("DiaChi", this.txtdiachinv.Text);
            para[5] = new SqlParameter("SoDThoai", this.txtsodienthoainv.Text);
            para[6] = new SqlParameter("ChucVu", this.txtchucvunv.Text);
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from NhanVien");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Không cập nhật được !");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void QLyNhanVien_Load(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = dp.Execute_Table("select * from NhanVien");
            nhanvien = dp.Execute_Table("select * from NhanVien");
            txttracuunhanvien.DataSource = nhanvien;
            txttracuunhanvien.DisplayMember = "MaNV";
            txttracuunhanvien.ValueMember = "MaNV";
           
        }

        private void Timnv_Click(object sender, EventArgs e)
        {
            string SPName = "select * from NhanVien where (MaNV like '%"+this.txttracuunhanvien.Text+"%') and (TenNV like '%"+this.txttennvtim.Text+"%')";
            this.dataGridView1.DataSource = dp.Execute_Table(SPName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        public void MaNV(ComboBox manv)
        {

            SqlDataReader dr = dp.Execute_Reader(SQLProvider.GetAll("NhanVien"));
            while (dr.Read())
                manv.Items.Add(dr["MaNV"]);
        }
    }
}
