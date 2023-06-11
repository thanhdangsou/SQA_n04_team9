using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public static string s = "Phần mềm quản lý tính tiền nước - Nhóm 9        ";
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = s;
            string tam = s[0].ToString();
            s = s.Substring(1, s.Length - 1) + tam;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            lbnam.Text = "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbdongho.Text = DateTime.Now.ToLongTimeString();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            QLykhachhang ql = new QLykhachhang();
            ql.ShowDialog();


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            QLyNhanVien nv = new QLyNhanVien();
            nv.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            QLyThietBi tb = new QLyThietBi();
            tb.ShowDialog();
        }

       


   
    }
}
