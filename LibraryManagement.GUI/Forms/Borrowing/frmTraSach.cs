// ===== LibraryManagement.GUI/Forms/Borrowing/frmTraSach.cs =====
using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Borrowing
{
    public partial class frmTraSach : Form
    {
        private readonly PhieuMuonBLL _phieuBLL = new PhieuMuonBLL();
        private PhieuMuon _currentPhieu = null;

        public frmTraSach()
        {
            InitializeComponent();
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu.Text.Trim();
            if (string.IsNullOrEmpty(maPhieu)) return;

            // Load đầy đủ thông qua Repository (đã được bọc trong BLL nếu cần, 
            // ở đây ta có thể dùng DAL trực tiếp hoặc thêm method vào BLL)
            // Để đơn giản và đúng logic, ta dùng PhieuMuonRepository.GetById(string)
            var repo = new DAL.Repositories.PhieuMuonRepository();
            var phieu = repo.GetById(maPhieu);

            if (phieu != null)
            {
                if (phieu.TrangThai == "DaTra" || phieu.TrangThai == "DaHuy")
                {
                    UIHelper.ShowToast(this, "Phiếu này đã được xử lý (Đã trả hoặc Đã hủy)!", "Warning");
                    return;
                }

                _currentPhieu = phieu;
                DisplayPhieuInfo(phieu);
            }
            else
            {
                UIHelper.ShowToast(this, " không tìm thấy phiếu mượn!", "Error");
                pnlInfo.Visible = false;
                btnXacNhanTra.Visible = false;
                btnHuyPhieu.Visible = false;
            }
        }

        private void DisplayPhieuInfo(PhieuMuon phieu)
        {
            pnlInfo.Visible = true;
            btnXacNhanTra.Visible = true;
            btnHuyPhieu.Visible = true;

            lblTenDocGia.Text = $"Tên độc giả: {phieu.DocGia?.HoTen}";
            lblNgayMuon.Text = $"Ngày mượn: {phieu.NgayMuon:dd/MM/yyyy}";
            lblHanTra.Text = $"Hạn trả: {phieu.HanTra:dd/MM/yyyy}";

            int daysLate = (DateTime.Today.Date - phieu.HanTra.Date).Days;
            if (daysLate > 0)
            {
                lblTinhTrang.Text = $"⚠ QUÁ HẠN {daysLate} NGÀY";
                lblTinhTrang.ForeColor = UIHelper.ColorDanger;
            }
            else
            {
                lblTinhTrang.Text = $"Còn {Math.Abs(daysLate)} ngày";
                lblTinhTrang.ForeColor = UIHelper.ColorSuccess;
            }

            dgvDetails.Rows.Clear();
            decimal tongPhat = 0;
            foreach (var ct in phieu.ChiTietMuons)
            {
                decimal phi = _phieuBLL.TinhPhiPhat(phieu.HanTra, DateTime.Today);
                dgvDetails.Rows.Add(ct.Sach?.TenSach, ct.SoLuong, phi.ToString("N0") + " đ");
                tongPhat += phi;
            }

            lblTongPhiPhat.Text = $"Tổng tiền phạt: {tongPhat:N0} đ";
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            if (_currentPhieu == null) return;

            string error = _phieuBLL.TraSach(_currentPhieu.MaPhieu, DateTime.Today);
            if (error == null)
            {
                UIHelper.ShowToast(this, "Xác nhận trả sách thành công!", "Success");
                
                decimal tongPhat = 0;
                foreach (var ct in _currentPhieu.ChiTietMuons)
                {
                    tongPhat += _phieuBLL.TinhPhiPhat(_currentPhieu.HanTra, DateTime.Today);
                }

                if (tongPhat > 0)
                {
                    if (MessageBox.Show($"Phiếu mượn có phí phạt {tongPhat:N0} đ. Bạn có muốn in hóa đơn phạt không?", "In hóa đơn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrintingService.InHoaDonPhat(_currentPhieu.MaPhieu, tongPhat);
                    }
                }

                ResetForm();
            }
            else
            {
                UIHelper.ShowToast(this, error, "Error");
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (_currentPhieu == null) return;

            if (UIHelper.ConfirmDelete("phiếu mượn này"))
            {
                string error = _phieuBLL.HuyPhieu(_currentPhieu.MaPhieu);
                if (error == null)
                {
                    UIHelper.ShowToast(this, "Hủy phiếu thành công!", "Success");
                    ResetForm();
                }
                else
                {
                    UIHelper.ShowToast(this, error, "Error");
                }
            }
        }

        private void ResetForm()
        {
            _currentPhieu = null;
            txtMaPhieu.Clear();
            pnlInfo.Visible = false;
            btnXacNhanTra.Visible = false;
            btnHuyPhieu.Visible = false;
        }
    }
}
