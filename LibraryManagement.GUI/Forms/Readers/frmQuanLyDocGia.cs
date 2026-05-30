using System;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Readers
{
    public partial class frmQuanLyDocGia : Form
    {
        private readonly DocGiaBLL _docGiaBLL = new DocGiaBLL();

        public frmQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void frmQuanLyDocGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvDocGia.DataSource = _docGiaBLL.GetAll();
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvDocGia.Columns.Count > 0)
            {
                dgvDocGia.Columns["MaDocGia"].HeaderText = "Mã Độc Giả";
                dgvDocGia.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvDocGia.Columns["SDT"].HeaderText = "Số Điện Thoại";
                dgvDocGia.Columns["Email"].HeaderText = "Email";
                dgvDocGia.Columns["NgayCap"].HeaderText = "Ngày Cấp";
                if (dgvDocGia.Columns.Contains("MaTK")) dgvDocGia.Columns["MaTK"].Visible = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvDocGia.DataSource = _docGiaBLL.Search(keyword);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var dg = LayThongTinForm();
            var result = _docGiaBLL.Add(dg);
            MessageBox.Show(result.msg);
            if (result.ok)
            {
                LoadData();
                LamMoi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var dg = LayThongTinForm();
            var result = _docGiaBLL.Update(dg);
            MessageBox.Show(result.msg);
            if (result.ok)
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.CurrentRow == null) return;
            string id = dgvDocGia.CurrentRow.Cells["MaDocGia"].Value.ToString();

            if (MessageBox.Show("Xác nhận xóa độc giả này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var result = _docGiaBLL.Delete(id);
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

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDocGia.Rows[e.RowIndex];
                txtMaDocGia.Text = row.Cells["MaDocGia"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                txtMaDocGia.ReadOnly = true;
            }
        }

        private void LamMoi()
        {
            txtMaDocGia.Clear();
            txtMaDocGia.ReadOnly = true; // BLL tự tạo mã
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTimKiem.Clear();
        }

        private DocGia LayThongTinForm()
        {
            return new DocGia
            {
                MaDocGia = txtMaDocGia.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }
    }
}
