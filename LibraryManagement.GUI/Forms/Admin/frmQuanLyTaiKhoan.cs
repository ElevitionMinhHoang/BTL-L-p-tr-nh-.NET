using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models.DTOs;
using LibraryManagement.GUI.Forms.Auth;

using System.Windows.Forms;

namespace LibraryManagement.GUI.Forms.Admin
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private readonly TaiKhoanBLL _bll = new TaiKhoanBLL();
        private List<TaiKhoanDTO> _allUsers;
        private bool _isAdding = false;

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền truy cập!");
                this.Close();
                return;
            }
            LoadData();
            if (cboRoleChiTiet.Items.Count > 0)
                cboRoleChiTiet.SelectedIndex = 0;
        }

        private void LoadData()
        {
            _allUsers = _bll.GetAll().ToList();
            dgvTaiKhoan.DataSource = _allUsers;
            if (dgvTaiKhoan.Columns.Contains("MaTK"))
                dgvTaiKhoan.Columns["MaTK"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            ClearDetails();
            txtTenDangNhap.ReadOnly = false;
            txtMatKhauMoi.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var dto = new TaiKhoanDTO
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Role = cboRoleChiTiet.SelectedItem?.ToString() ?? "NhanVien",
                Email = txtEmail.Text.Trim(),
                SoDienThoai = txtSdt.Text.Trim(),
                IsActive = chkActive.Checked
            };

            string error;
            if (_isAdding)
            {
                error = _bll.AddTaiKhoan(dto, txtMatKhauMoi.Text);
            }
            else
            {
                if (dgvTaiKhoan.CurrentRow == null) return;
                dto.MaTK = (int)dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value;
                error = _bll.UpdateTaiKhoan(dto);
            }

            if (error == null)
            {
                MessageBox.Show("Thành công!");
                LoadData();
                _isAdding = false;
                btnLuu.Enabled = false;
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            int id = (int)dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value;
            if (id == UserSession.Current.MaTK)
            {
                MessageBox.Show("Không thể xóa chính mình!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_bll.DeleteTaiKhoan(id))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản này!");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower();
            dgvTaiKhoan.DataSource = _allUsers.Where(u => 
                u.TenDangNhap.ToLower().Contains(keyword) || 
                u.HoTen.ToLower().Contains(keyword)).ToList();
        }

        private void ClearDetails()
        {
            txtTenDangNhap.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSdt.Clear();
            txtMatKhauMoi.Clear();
            chkActive.Checked = true;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _isAdding = false;
                var row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSdt.Text = row.Cells["SoDienThoai"].Value.ToString();
                chkActive.Checked = (bool)row.Cells["IsActive"].Value;
                cboRoleChiTiet.SelectedItem = row.Cells["Role"].Value.ToString();
                
                txtTenDangNhap.ReadOnly = true;
                txtMatKhauMoi.Enabled = true; // Cho phép reset pass
                btnLuu.Enabled = true;
            }
        }
    }
}
