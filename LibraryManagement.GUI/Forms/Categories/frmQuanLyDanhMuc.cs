using System;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Categories
{
    public partial class frmQuanLyDanhMuc : Form
    {
        private readonly DanhMucBLL _danhMucBLL = new DanhMucBLL();

        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new string[] { "TheLoai", "NXB", "TacGia" });
            cboLoai.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            dgvDanhMuc.DataSource = _danhMucBLL.GetAll();
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvDanhMuc.Columns.Count > 0)
            {
                dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã Danh Mục";
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên Danh Mục";
                dgvDanhMuc.Columns["LoaiDanhMuc"].HeaderText = "Loại Danh Mục";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var dm = LayThongTinForm();
            if (string.IsNullOrWhiteSpace(dm.MaDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập Mã danh mục!");
                return;
            }

            string result = _danhMucBLL.Add(dm);
            if (result == null)
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
                LamMoi();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var dm = LayThongTinForm();
            string result = _danhMucBLL.Update(dm);
            if (result == null)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow == null) return;
            string id = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_danhMucBLL.Delete(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Có thể danh mục này đang được sử dụng.");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
                cboLoai.SelectedItem = row.Cells["LoaiDanhMuc"].Value.ToString();
                
                txtMaDanhMuc.ReadOnly = true;
            }
        }

        private void LamMoi()
        {
            txtMaDanhMuc.Clear();
            txtMaDanhMuc.ReadOnly = false;
            txtTenDanhMuc.Clear();
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
        }

        private DanhMuc LayThongTinForm()
        {
            return new DanhMuc
            {
                MaDanhMuc = txtMaDanhMuc.Text.Trim(),
                TenDanhMuc = txtTenDanhMuc.Text.Trim(),
                LoaiDanhMuc = cboLoai.SelectedItem?.ToString() ?? ""
            };
        }
    }
}
