using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVien
{
    public partial class frmThongKe : Form
    {
        Panel pan1 = new Panel();

        QuanLiSinhVienEntities ql = new QuanLiSinhVienEntities();
        public frmThongKe()
        {
            InitializeComponent();
            this.Controls.Add(pan1);
            panel_contrl.Visible = false;
            pan1.Size = new Size(622, 135);
            pan1.Location = new Point(166, 45);
            addCOm();

        }
        private void addCOm()
        {
            comboBox_tt.Items.Add("Sinh viên");
            comboBox_tt.Text = "Sinh viên";
            comboBox_tt.Items.Add("Giáo viên");
            comboBox_tt.Items.Add("Lớp");
            comboBox_tt.Items.Add("Khoa");
            comboBox_tt.Items.Add("Môn học");
            comboBox_tt.Items.Add("Điểm");
        }
        private void tong_lbl_Click(object sender, EventArgs e)
        {
            ComboBox com1 = new ComboBox();
            pan1.Controls.Add(com1);
            com1.DataSource = ql.Khoas;
            com1.DisplayMember = "tenkhoa";

        }

        private void panel_contrl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int a = comboBox_tt.SelectedIndex;
            if (a == 0)
            {
                quanLiSV();
            }
            else if (a == 1)
            {
                quanLiGV();
            }
            else if (a == 2)
            {
                quanLiLop();

            }
            else if (a == 3)
            {
                dataGridView_TT.DataSource = ql.Khoas.ToArray();
                tong_lbl.Text = "Tổng số khoa là: " + ql.Khoas.ToArray().Length;
            }
            else if (a == 4)
            {
                dataGridView_TT.DataSource = ql.MonHocs.ToArray();
                tong_lbl.Text = "Tổng số môn học là: " + ql.MonHocs.ToArray().Length;
            }
            else if (a == 5)
            {
                quanLiDiem();
            }
        }
        private void quanLiGV()
        {
            Label la = new Label();
            Label la1 = new Label();
            ComboBox com = new ComboBox();
            ComboBox com1 = new ComboBox();
            ComboBox com2 = new ComboBox();
            Button button_rs = new Button();
            pan1.Controls.Clear();
            dataGridView_TT.DataSource = ql.GiangViens.ToArray();
            tong_lbl.Text = "Tổng số giảng viên là: " + ql.GiangViens.ToArray().Length;
            button_rs.Text = "Reset";
            #region add pan1
            pan1.Controls.Add(la);
            pan1.Controls.Add(la1);
            pan1.Controls.Add(com);
            pan1.Controls.Add(com1);
            pan1.Controls.Add(com2);
            pan1.Controls.Add(button_rs);
            #endregion
            la.Text = "Tìm kiếm giảng viên";
            la.Location = new Point(13, 25);
            la1.Location = new Point(450, 109);
            button_rs.Location = new Point(200, 80);
            com.Location = new Point(121, 21);
            com1.Location = new Point(250, 21);
            com2.Location = new Point(400, 21);
            la1.AutoSize = true;
            la.AutoSize = true;
            com.DataSource = ql.GiangViens.ToArray();
            com.DisplayMember = "magv";
            com.ValueMember = "magv";
            com1.DataSource = ql.Khoas.ToArray();
            com1.DisplayMember = "tenkhoa";
            com1.ValueMember = "makhoa";
            com2.DataSource = ql.MonHocs.ToArray();
            com2.DisplayMember = "tenmh";
            com2.ValueMember = "mamh";
            com.AutoCompleteMode = AutoCompleteMode.Suggest;
            com.AutoCompleteSource = AutoCompleteSource.ListItems;
            #region event
            com.SelectedValueChanged += combox_gv;
            com1.SelectedValueChanged += combox_gv_khoa;
            com2.SelectedValueChanged += combox_gv_mh;
            button_rs.Click += rs_gv;
            #endregion
        }
        private void quanLiSV()
        {
            Label la = new Label();
            Label la1 = new Label();
            ComboBox com = new ComboBox();
            Button button_rs = new Button();
            pan1.Controls.Clear();
            dataGridView_TT.DataSource = ql.SinhViens.ToArray();
            la1.Text = "Tổng số sinh viên là: " + ql.SinhViens.ToArray().Length;
            button_rs.Text = "Reset";
            #region add pan1
            pan1.Controls.Add(la);
            pan1.Controls.Add(la1);
            pan1.Controls.Add(com);
            pan1.Controls.Add(button_rs);
            #endregion
            la.Text = "Tìm kiếm sinh viên";
            la.Location = new Point(13, 25);
            la1.Location = new Point(450, 109);
            button_rs.Location = new Point(200, 80);
            com.Location = new Point(121, 21);
            la1.AutoSize = true;
            com.DataSource = ql.SinhViens.ToArray();
            com.DisplayMember = "masv";
            com.ValueMember = "masv";
            com.AutoCompleteMode = AutoCompleteMode.Suggest;
            com.AutoCompleteSource = AutoCompleteSource.ListItems;
            #region event
            com.SelectedValueChanged += combox_sv;
            button_rs.Click += rs_sv;
            #endregion
        }
        private void quanLiLop()
        {
            pan1.Controls.Clear();
            dataGridView_TT.DataSource = ql.Lops.ToArray();
            tong_lbl.Text = "Tổng số lớp là: " + ql.Lops.ToArray().Length;
            Label la = new Label();
            la.Text = "Hiển thị danh sách sinh viên theo lớp";
            la.AutoSize = true;
            la.Location = new Point(10, 10);
            Label la1 = new Label();
            la1.Text = "Tổng số lớp là: " + ql.Lops.ToArray().Length;
            la1.AutoSize = true;
            la1.Location = new Point(200, 100);
            ComboBox combo = new ComboBox();
            combo.DataSource = ql.Lops.ToArray();
            combo.DisplayMember = "tenlop";
            combo.ValueMember = "malop";
            combo.Location = new Point(200, 10);
            combo.SelectedValueChanged += indssv_lop;
            Button button = new Button();
            button.Text = "Reset";
            button.Location = new Point(100, 100);
            button.Click += rs_lop;
            pan1.Controls.Add(la);
            pan1.Controls.Add(la1);
            pan1.Controls.Add(combo);
            pan1.Controls.Add(button);

        }
        private void quanLiDiem()
        {
            pan1.Controls.Clear();
            dataGridView_TT.DataSource = ql.Diems.ToArray();
            ComboBox com = new ComboBox();
            com.DataSource = ql.Lops.ToArray();
            com.DisplayMember = "tenlop";
            com.ValueMember = "malop";
            com.Location = new Point(20, 20);
            com.SelectedValueChanged += inDiem_Lop;
            pan1.Controls.Add(com);
        }
        #region sự kiện
        #region sự kiện sv
        private void rs_sv(object sender, EventArgs e)
        {
            dataGridView_TT.DataSource = ql.SinhViens.ToArray();
        }
        private void combox_sv(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            int masv = (int)com.SelectedValue;
            dataGridView_TT.DataSource = ql.SinhViens.Where(sv => sv.masv == masv).ToList();

        }
        #endregion
        #region sự kiện gv
        private void rs_gv(object sender, EventArgs e)
        {
            dataGridView_TT.DataSource = ql.GiangViens.ToArray();
        }

        private void combox_gv(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            int masv = (int)com.SelectedValue;
            dataGridView_TT.DataSource = ql.GiangViens.Where(sv => sv.magv == masv).ToList();

        }
        private void combox_gv_khoa(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            int masv = (int)com.SelectedValue;
            dataGridView_TT.DataSource = ql.GiangViens.Where(sv => sv.makhoa == masv).ToList();

        }
        private void combox_gv_mh(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            int masv = (int)com.SelectedValue;
            dataGridView_TT.DataSource = ql.GiangViens.Where(sv => sv.mamh == masv).ToList();

        }
        #endregion
        #region sự kiện lop
        private void indssv_lop(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            List<SinhVien> dssv = ql.SinhViens.Where(sv => sv.malop == (int)com.SelectedValue).ToList();
            dataGridView_TT.DataSource = dssv;
            Label la = new Label();
            la.Text = "Lớp " + com.Text + " có: " + dssv.Count + " sinh viên";
            la.AutoSize = true;
            la.Location = new Point(300, 100);
            pan1.Controls.Remove(la);
            pan1.Controls.Add(la);
        }
        private void rs_lop(object sender, EventArgs e)
        {
            dataGridView_TT.DataSource = ql.Lops.ToList();
        }
        #endregion
        #region su kien diem
        private void inDiem_Lop(object sender, EventArgs e)
        {
            int malop = (int)((ComboBox)sender).SelectedValue;

            List<SinhVien> dssv = ql.SinhViens.Where(sv => sv.malop == malop).ToList();
            List<Diem> d;
            foreach (SinhVien svm in dssv)
            {
                d = ql.Diems.Where(ds => ds.masv == svm.masv).ToList();
                if (d.Count > 0)
                    dataGridView_TT.DataSource = d;
            }
        }
        #endregion
        #endregion
    }
}
