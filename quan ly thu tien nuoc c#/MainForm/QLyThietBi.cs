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
    public partial class QLyThietBi : Form
    {
        DataProvider dp = new SQLProvider();
        public QLyThietBi()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "select * from ThietBi where (MaTBi like '%"+this.txtmatb.Text+"%') and (TenTBi like '%"+this.txttentb.Text+"%')";
            this.dataGridView3.DataSource = dp.Execute_Table(s);
        }

        private void Themtb_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmatb.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTB !");
                    return;
                }
            }
            catch { }
            string SPName = "insert_ThietBi_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaTBi",this.txtmatb.Text);
            para[1] = new SqlParameter("TenTBi",this.txttentb.Text);
            para[2] = new SqlParameter("GiaTien",this.txtgiatientb.Text.Trim());
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from ThietBi");
                MessageBox.Show("Thêm thành công !");
            }
            else
                MessageBox.Show("Không thêm được ! Giá tiền phải là số !");
        }

        private void QLyThietBi_Load(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = dp.Execute_Table("select * from ThietBi");
        }

        private void xoatb_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmatb.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTB cần xoá !");
                    return;
                }
            }
            catch
            { }
            string SPName = "delete_ThietBi_1";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("MaTBi",this.txtmatb.Text);
            txtmatb.DataBindings.Clear();
            txttentb.DataBindings.Clear();
            txtgiatientb.DataBindings.Clear();
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from ThietBi");
                MessageBox.Show("Xoá thành công !");
            }
            else
                MessageBox.Show("Không xoá được !");
        }

        private void suatb_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmatb.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập MaTB cần sửa !");
                    return;
                }
            }
            catch
            { }
            string SPName = "update_ThietBi_1";
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("MaTBi", this.txtmatb.Text);
            para[1] = new SqlParameter("TenTBi", this.txttentb.Text);
            para[2] = new SqlParameter("GiaTien",this.txtgiatientb.Text.Trim());
            if (dp.Execute_Modify(SPName, para) >= 1)
            {
                this.dataGridView3.DataSource = dp.Execute_Table("select * from ThietBi");
                MessageBox.Show("Cập nhật thành công !");
            }
            else
                MessageBox.Show("Cập nhật thất bại ! Giá tiền phải là số !");
        }
        private void Load_Thietbi()
        {
            string s = "select * from ThietBi";
            this.dataGridView3.DataSource = dp.Execute_Table(s);
        }
        private void Refreshtb_Click(object sender, EventArgs e)
        {
            txtmatb.Text = "";
            txtmatb.Enabled = true;
            txttentb.Text = "";
            txtgiatientb.Text = "";
            this.Load_Thietbi();
        }

        private void closetb_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
