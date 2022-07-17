using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLiSinhVien
{
    public partial class Form1 : Form
    {

        #region thuộc tính
        GiangVien gv;
        MonHoc mh;
        Lop lop;
        Khoa kh;
        Diem d;
        SinhVien sv;
        QuanLiSinhVienEntities ql = new QuanLiSinhVienEntities();
        #endregion
        #region hàm tạo
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
        #region Các sự kiện
        #region sự kiên khoa
        private void click_khoa(object sender, DataGridViewCellEventArgs e)
        {
            int makhoa = (int)dataGridView_khoa.Rows[e.RowIndex].Cells[0].Value;
            kh = ql.Khoas.Where(kh => kh.makhoa == makhoa).First();
            textBox_makhoa_k.Text = makhoa.ToString();
            textBox_tenKhoa_k.Text = kh.tenkhoa;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ql.Khoas.Add(new Khoa(0, textBox_tenKhoa_k.Text));
            ql.SaveChanges();
            inKhoa();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            kh.tenkhoa = textBox_tenKhoa_k.Text;
            ql.SaveChanges();
            inKhoa();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ql.Khoas.Remove(kh);
            ql.SaveChanges();
            inKhoa();
        }
        #endregion
        #region sự kiện môn học
        private void click_mh(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView_mh.Rows[e.RowIndex].Cells[0].Value.ToString());
            int mamh = (int)dataGridView_mh.Rows[e.RowIndex].Cells[0].Value;
            mh = ql.MonHocs.Where(mh => mamh == mh.mamh).First();
            textBox_mamh_mh.Text = mh.mamh.ToString();
            textBox_tenmh_mh.Text = mh.tenmh;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ql.MonHocs.Add(new MonHoc(0, textBox_tenmh_mh.Text));
            ql.SaveChanges();
            inMH();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            mh.tenmh = textBox_tenmh_mh.Text;
            ql.SaveChanges();
            inMH();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ql.MonHocs.Remove(mh);
            ql.SaveChanges();
            inMH();
        }
        #endregion
        #region sự kiện giảng viên
        private void double_click_gv(object sender, DataGridViewCellEventArgs e)
        {
            int magv = int.Parse(dataGridView_gv.Rows[e.RowIndex].Cells[0].Value.ToString());
            gv = ql.GiangViens.Where(gv => magv == gv.magv).First();
            textBox_magv.Text = gv.magv.ToString();
            textBox_hotenGV.Text = gv.hoten;
            textBox_dcGV.Text = gv.diachi;
            textBox_sdtGV.Text = gv.sdt;
            comboBox_mhGV.SelectedValue = gv.mamh;
            comboBox_mhGV.DisplayMember = ql.MonHocs.Where(mh => mh.mamh == gv.mamh).First().tenmh;
            comboBox_tenKhoa_GV.SelectedValue = gv.makhoa;
            comboBox_tenKhoa_GV.DisplayMember = ql.Khoas.Where(mh => mh.makhoa == gv.makhoa).First().tenkhoa;
            dateTimePicker_nsGV.Value = gv.ngaysinh;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            gv.hoten = textBox_hotenGV.Text;
            gv.makhoa = (int)comboBox_tenKhoa_GV.SelectedValue;
            gv.mamh = (int)comboBox_mhGV.SelectedValue;
            gv.ngaysinh = dateTimePicker_nsGV.Value;
            gv.diachi = textBox_dcGV.Text;
            gv.sdt = textBox_sdtGV.Text;
            ql.SaveChanges();
            inGV();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ql.GiangViens.Remove(gv);
            ql.SaveChanges();
            inGV();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox_tenKhoa_GV.SelectedValue.ToString());
            //int magv, string hoten, string sdt, string diachi, DateTime? ngaysinh, int? makhoa, int? mamh
            addGV(new GiangVien(0, textBox_hotenGV.Text, textBox_sdtGV.Text,
               textBox_dcGV.Text, dateTimePicker_nsGV.Value, int.Parse(comboBox_tenKhoa_GV.SelectedValue.ToString()), int.Parse(comboBox_mhGV.SelectedValue.ToString())));
            ql.SaveChanges();
            inGV();
        }
        #endregion
        #region sự kiện chuyển quản lí
        private void button1_Click(object sender, EventArgs e)
        {
            inTTSV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inTTLop();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            inTTGV();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            inTTKhoa();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            inTTMonHoc();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inTTDiem();
        }

        #endregion
        #region sự kiện sinh viên
        private void button11_Click(object sender, EventArgs e)
        {
            //int masv, string hoten, string sdt, string diachi, DateTime? ngaysinh, int? malop
            ql.SinhViens.Add(new SinhVien(0, textBox_hoten_sv.Text, textBox_sdtSV.Text, textBox_dichi_sv.Text, dateTimePicker_nssv.Value, (int)comboBox_tenLop.SelectedValue));
            ql.SaveChanges();
            inSV();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sv.diachi = textBox_dichi_sv.Text;
            sv.hoten = textBox_hoten_sv.Text;
            sv.malop = (int)comboBox_tenLop.SelectedValue;
            sv.ngaysinh = dateTimePicker_nssv.Value;
            sv.sdt = textBox_sdtSV.Text;
            ql.SaveChanges();
            inSV();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ql.SinhViens.Remove(sv);
            ql.SaveChanges();
            inSV();
        }

        private void click(object sender, DataGridViewCellEventArgs e)
        {
            // int masv, string hoten, string sdt, string diachi, DateTime? ngaysinh, int? malop
            int masv = (int)dataGridView_sv.Rows[e.RowIndex].Cells[0].Value;
            sv = ql.SinhViens.Where(sv => sv.masv == masv).First();
            textbox_masv.Text = sv.masv.ToString();
            textBox_hoten_sv.Text = sv.hoten;
            dateTimePicker_nssv.Value = sv.ngaysinh;
            textBox_dichi_sv.Text = sv.diachi;
            textBox_sdtSV.Text = sv.sdt;
            comboBox_tenLop.DisplayMember = ql.Lops.Where(lop => lop.malop == sv.malop).First().tenlop;
            comboBox_tenLop.SelectedValue = sv.malop;

        }
        #endregion
        #region sự kiện điểm
        private void click_diem(object sender, DataGridViewCellEventArgs e)
        {
            int masv = (int)dataGridView_diem.Rows[e.RowIndex].Cells[0].Value;
            int mamh = (int)dataGridView_diem.Rows[e.RowIndex].Cells[1].Value;
            d = ql.Diems.Where(d => d.masv == masv && d.mamh == mamh).First();
            textBox_diemGK.Text = d.diemGiuaKi.ToString();
            textBox_diemCK.Text = d.diemCuoiKi.ToString();
            comboBox_masv_d.DisplayMember = masv.ToString();
            comboBox_mamh_d.DisplayMember = ql.MonHocs.Where(mh => mh.mamh == mamh).First().tenmh;
            comboBox_mamh_d.SelectedValue = mamh;

        }

        private void button27_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox_diemCK.Text.Equals("") ? null : double.Parse(textBox_diemCK.Text)+"");
            if (textBox_diemGK.Text.Equals(""))
            {
                ql.Diems.Add(new Diem(int.Parse(comboBox_masv_d.Text), (int)comboBox_mamh_d.SelectedValue, null, null));
            }
            else if (textBox_diemCK.Text.Equals(""))
            {
                ql.Diems.Add(new Diem(int.Parse(comboBox_masv_d.Text), (int)comboBox_mamh_d.SelectedValue, double.Parse(textBox_diemGK.Text), null));
            }
            else
            {
                ql.Diems.Add(new Diem(int.Parse(comboBox_masv_d.Text), (int)comboBox_mamh_d.SelectedValue, double.Parse(textBox_diemGK.Text), double.Parse(textBox_diemCK.Text)));
            }
            ql.SaveChanges();
            inDiem();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            d.mamh = (int)comboBox_mamh_d.SelectedValue;
            d.masv = int.Parse(comboBox_masv_d.Text);
            if (!textBox_diemGK.Text.Equals("")) d.diemGiuaKi = double.Parse(textBox_diemGK.Text);
            else d.diemGiuaKi = null;
            if (!textBox_diemCK.Text.Equals("")) d.diemCuoiKi = double.Parse(textBox_diemCK.Text);
            else d.diemCuoiKi = null;
            ql.SaveChanges();
            inDiem();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ql.Diems.Remove(d);
            ql.SaveChanges();
            inDiem();
        }
        #endregion
        #region sự kiện lớp
        private void click_lop(object sender, DataGridViewCellEventArgs e)
        {
            int malop = (int)dataGridView_lop.Rows[e.RowIndex].Cells[0].Value;
            lop = ql.Lops.Where(l => l.malop == malop).First();
            textBox_malop_l.Text = malop.ToString();
            textBox_tenlop_l.Text = lop.tenlop;
            textBox_khoahoc_l.Text = lop.khoahoc.ToString();
            comboBox_tenK_k.DisplayMember = ql.Khoas.Where(k => lop.makhoa == k.makhoa).First().tenkhoa;
            comboBox_tenK_k.SelectedValue = lop.makhoa;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //public Lop(int malop, int? makhoa, string tenlop, int? khoahoc)
            if (checkNull(textBox_tenlop_l.Text) && checkNull(textBox_khoahoc_l.Text))
                ql.Lops.Add(new Lop(0, (int)comboBox_tenK_k.SelectedValue, textBox_tenlop_l.Text, int.Parse(textBox_khoahoc_l.Text)));
            else
                error();
            ql.SaveChanges();
            inLop();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkNull(textBox_tenlop_l.Text) && checkNull(textBox_khoahoc_l.Text))
            {
                lop.tenlop = textBox_tenlop_l.Text;
                lop.khoahoc = int.Parse(textBox_khoahoc_l.Text);
                lop.makhoa = (int)comboBox_tenK_k.SelectedValue;
                inLop();
            }
            else
            {
                error();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ql.Lops.Remove(lop);
            ql.SaveChanges();
            inLop();
        }
        #endregion
        #region check nhập số
        private void ktSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
        #endregion        
        #endregion
        #region phương thức
        private void error()
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }
        private void inGV()
        {
            //dataGridView_gv.DataSource = null;
            dataGridView_gv.DataSource = ql.GiangViens.ToList();
            dataGridView_gv.Columns["magv"].HeaderText = "Mã giảng viên";
            dataGridView_gv.Columns["hoten"].HeaderText = "Họ tên";
            dataGridView_gv.Columns["diachi"].HeaderText = "Địa chỉ";
            dataGridView_gv.Columns["sdt"].HeaderText = "Số điện thoại";
            dataGridView_gv.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dataGridView_gv.Columns["makhoa"].HeaderText = "Mã khoa";
            dataGridView_gv.Columns["mamh"].HeaderText = "Mã môn học";
            dataGridView_gv.Columns["Khoa"].Visible = false;
            dataGridView_gv.Columns["MonHoc"].Visible = false;
            comboBox_tenKhoa_GV.DataSource = ql.Khoas.ToList();
            comboBox_mhGV.DataSource = ql.MonHocs.ToList();
            comboBox_tenKhoa_GV.DisplayMember = "tenkhoa";
            comboBox_tenKhoa_GV.ValueMember = "makhoa";
            comboBox_mhGV.DisplayMember = "tenmh";
            comboBox_mhGV.ValueMember = "mamh";

        }

        private void inSV()
        {
            dataGridView_sv.DataSource = ql.SinhViens.ToList();
            comboBox_tenLop.DataSource = ql.Lops.ToList();
            comboBox_tenLop.DisplayMember = "tenlop";
            comboBox_tenLop.ValueMember = "malop";
            dataGridView_sv.Columns["masv"].HeaderText = "Mã sinh viên";
            dataGridView_sv.Columns["hoten"].HeaderText = "Họ và tên";
            dataGridView_sv.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dataGridView_sv.Columns["sdt"].HeaderText = "Số điện thoại";
            dataGridView_sv.Columns["malop"].HeaderText = "Tên lớp";
            dataGridView_sv.Columns["diachi"].HeaderText = "Địa chỉ";
            dataGridView_sv.Columns["Lop"].Visible = false;
            dataGridView_sv.Columns["Diems"].Visible = false;
        }
        private void inLop()
        {
            dataGridView_lop.DataSource = ql.Lops.ToArray();
            comboBox_tenK_k.DataSource = ql.Khoas.ToList();
            comboBox_tenK_k.DisplayMember = "tenkhoa";
            comboBox_tenK_k.ValueMember = "makhoa";
            dataGridView_lop.Columns["malop"].HeaderText = "Mã lớp";
            dataGridView_lop.Columns["tenlop"].HeaderText = "Tên lớp";
            dataGridView_lop.Columns["khoahoc"].HeaderText = "Khóa học";
            dataGridView_lop.Columns["makhoa"].HeaderText = "Mã khoa";
            dataGridView_lop.Columns["Khoa"].Visible = false;
            dataGridView_lop.Columns["SinhViens"].Visible = false;

        }
        private void inKhoa()
        {
            dataGridView_khoa.DataSource = ql.Khoas.ToList();
            dataGridView_khoa.Columns["makhoa"].HeaderText = "Mã khoa";
            dataGridView_khoa.Columns["tenkhoa"].HeaderText = "Tên khoa";
            dataGridView_khoa.Columns["GiangViens"].Visible = false;
            dataGridView_khoa.Columns["Lops"].Visible = false;
        }
        private void inDiem()
        {
            dataGridView_diem.DataSource = ql.Diems.ToArray();
            dataGridView_diem.Columns["masv"].HeaderText = "Mã sinh viên";
            dataGridView_diem.Columns["mamh"].HeaderText = "Mã môn học";
            dataGridView_diem.Columns["diemGiuaKi"].HeaderText = "Điểm giữa kỳ";
            dataGridView_diem.Columns["diemCuoiKi"].HeaderText = "Điểm cuối kỳ";
            dataGridView_diem.Columns["MonHoc"].Visible = false;
            dataGridView_diem.Columns["SinhVien"].Visible = false;
            comboBox_masv_d.DataSource = ql.SinhViens.ToArray();
            comboBox_masv_d.DisplayMember = "masv";
            comboBox_mamh_d.DataSource = ql.MonHocs.ToArray();
            comboBox_mamh_d.DisplayMember = "tenmh";
            comboBox_mamh_d.ValueMember = "mamh";

        }
        private void inMH()
        {
            dataGridView_mh.DataSource = ql.MonHocs.ToArray();
            dataGridView_mh.Columns["mamh"].HeaderText = "Mã môn học";
            dataGridView_mh.Columns["tenmh"].HeaderText = "Tên môn học";
            dataGridView_mh.Columns["Diems"].Visible = false;
            dataGridView_mh.Columns["GiangViens"].Visible = false;
        }
        private void inTTDiem()
        {
            groupBox_diem.Visible = true;
            groupBox_gv.Visible = false;
            groupBox_khoa.Visible = false;
            groupBox_lop.Visible = false;
            groupBox_mh.Visible = false;
            groupBox_sv.Visible = false;
            inDiem();
        }
        private void inTTGV()
        {

            groupBox_diem.Visible = false;
            groupBox_gv.Visible = true;
            groupBox_khoa.Visible = false;
            groupBox_lop.Visible = false;
            groupBox_mh.Visible = false;
            groupBox_sv.Visible = false;
            inGV();
        }
        private void inTTKhoa()
        {
            groupBox_diem.Visible = false;
            groupBox_gv.Visible = false;
            groupBox_khoa.Visible = true;
            groupBox_lop.Visible = false;
            groupBox_mh.Visible = false;
            groupBox_sv.Visible = false;
            inKhoa();
        }
        private void inTTLop()
        {
            groupBox_diem.Visible = false;
            groupBox_gv.Visible = false;
            groupBox_khoa.Visible = false;
            groupBox_lop.Visible = true;
            groupBox_mh.Visible = false;
            groupBox_sv.Visible = false;
            inLop();
        }
        private void inTTMonHoc()
        {
            groupBox_diem.Visible = false;
            groupBox_gv.Visible = false;
            groupBox_khoa.Visible = false;
            groupBox_lop.Visible = false;
            groupBox_mh.Visible = true;
            groupBox_sv.Visible = false;
            inMH();
        }
        private void inTTSV()
        {
            groupBox_diem.Visible = false;
            groupBox_gv.Visible = false;
            groupBox_khoa.Visible = false;
            groupBox_lop.Visible = false;
            groupBox_mh.Visible = false;
            groupBox_sv.Visible = true;
            inSV();
        }
        private void addSV(SinhVien sv)
        {
            ql.SinhViens.Add(sv);
        }
        private void addGV(GiangVien gv)
        {
            ql.GiangViens.Add(gv);
        }
        private void addLop(Lop lop)
        {
            ql.Lops.Add(lop);
        }
        private void addKhoa(Khoa k)
        {
            ql.Khoas.Add(k);
        }
        private void addMH(MonHoc mh)
        {
            ql.MonHocs.Add(mh);
        }
        DataTable getGV()
        {
            SqlConnection conn = Connect.connect();
            conn.Open();
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from GiangVien", conn);
            dataAdapter.Fill(data);
            conn.Close();
            return data;
        }

        private bool checkNull(String a)
        {
            return a.Trim().Length == 0 || String.IsNullOrEmpty(a.Trim()) ? false : true;
        }








        #endregion

        private void thoongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmThongKe().ShowDialog();
            this.Hide();
        }
    }
}
