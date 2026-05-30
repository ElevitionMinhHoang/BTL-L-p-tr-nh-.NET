using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Books
{
    public partial class frmQuanLySach : Form
    {
        private readonly SachBLL _sachBLL = new SachBLL();
        private readonly DanhMucBLL _danhMucBLL = new DanhMucBLL();

        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            LoadDanhMucCombo();
            LoadData();
        }

        private void LoadDanhMucCombo()
        {
            var dsList = _danhMucBLL.GetAll();

            // ComboBox lọc
            var filterList = new List<DanhMuc> { new DanhMuc { MaDanhMuc = "", TenDanhMuc = "-- Tất cả --" } };
            filterList.AddRange(dsList);
            cboDanhMucFilter.DataSource = filterList;
            cboDanhMucFilter.DisplayMember = "TenDanhMuc";
            cboDanhMucFilter.ValueMember = "MaDanhMuc";

            // ComboBox nhập liệu
            cboDanhMuc.DataSource = new List<DanhMuc>(dsList);
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadData()
        {
            dgvSach.DataSource = _sachBLL.GetAll();
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvSach.Columns.Count > 0)
            {
                dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSach.Columns["MaDanhMuc"].Visible = false;
                dgvSach.Columns["TenDanhMuc"].HeaderText = "Danh Mục";
                dgvSach.Columns["NamXB"].HeaderText = "Năm XB";
                dgvSach.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string categoryId = cboDanhMucFilter.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(categoryId)) categoryId = null;
            dgvSach.DataSource = _sachBLL.Search(keyword, categoryId, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var s = LayThongTinForm();
            var result = _sachBLL.Add(s);
            MessageBox.Show(result.msg);
            if (result.ok)
            {
                LoadData();
                LamMoi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var s = LayThongTinForm();
            var result = _sachBLL.Update(s);
            MessageBox.Show(result.msg);
            if (result.ok)
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null) return;
            string id = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var result = _sachBLL.Delete(id);
                MessageBox.Show(result.msg);
                if (result.ok)
                {
                    LoadData();
                    LamMoi();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadData();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                cboDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value.ToString();
                numNamXB.Value = Convert.ToDecimal(row.Cells["NamXB"].Value);
                numSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                txtMaSach.ReadOnly = true;
            }
        }

        private void LamMoi()
        {
            txtMaSach.Clear();
            txtMaSach.ReadOnly = true; // BLL tự tạo mã
            txtTenSach.Clear();
            numNamXB.Value = DateTime.Now.Year;
            numSoLuong.Value = 0;
            if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
        }

        private Sach LayThongTinForm()
        {
            return new Sach
            {
                MaSach = txtMaSach.Text.Trim(),
                TenSach = txtTenSach.Text.Trim(),
                MaDanhMuc = cboDanhMuc.SelectedValue?.ToString(),
                NamXB = (int)numNamXB.Value,
                SoLuong = (int)numSoLuong.Value
            };
        }
    }
}
