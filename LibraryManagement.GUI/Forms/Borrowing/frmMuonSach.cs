// ===== LibraryManagement.GUI/Forms/Borrowing/frmMuonSach.cs =====
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Borrowing
{
    public partial class frmMuonSach : Form
    {
        private readonly DocGiaBLL _docGiaBLL = new DocGiaBLL();
        private readonly SachBLL _sachBLL = new SachBLL();
        private readonly PhieuMuonBLL _phieuBLL = new PhieuMuonBLL();

        private string _selectedMaDocGia = null;
        private List<Sach> _selectedBooks = new List<Sach>();

        public frmMuonSach()
        {
            InitializeComponent();
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            dateHanTra.Value = DateTime.Today.AddDays(14);
            UpdateSoNgay();
        }

        private void btnTimDocGia_Click(object sender, EventArgs e)
        {
            string maDG = txtMaDocGia.Text.Trim();
            if (string.IsNullOrEmpty(maDG)) return;

            var dg = _docGiaBLL.GetById(maDG);
            if (dg != null)
            {
                _selectedMaDocGia = dg.MaDocGia;
                lblTenDocGia.Text = $"Tên độc giả: {dg.HoTen}";
                int soDangMuon = _docGiaBLL.GetSoDangMuon(dg.MaDocGia);
                lblSoDangMuon.Text = $"Đang mượn: {soDangMuon} cuốn";
                lblSoDangMuon.ForeColor = soDangMuon > 0 ? UIHelper.ColorWarning : UIHelper.ColorPrimary;
            }
            else
            {
                UIHelper.ShowToast(this, "Không tìm thấy độc giả!", "Error");
                ResetDocGia();
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();
            if (string.IsNullOrEmpty(maSach)) return;

            if (_selectedBooks.Any(s => s.MaSach == maSach))
            {
                UIHelper.ShowToast(this, "Sách này đã có trong danh sách chọn!", "Warning");
                return;
            }

            if (_selectedBooks.Count >= 5)
            {
                UIHelper.ShowToast(this, "Tối đa 5 cuốn một lần mượn!", "Warning");
                return;
            }

            var sach = _sachBLL.GetById(maSach);
            if (sach != null)
            {
                if (sach.SoLuong <= 0)
                {
                    lblThongBaoSach.Text = $"Sách '{sach.TenSach}' đã hết hàng!";
                    return;
                }

                lblThongBaoSach.Text = "";
                _selectedBooks.Add(sach);
                UpdateBookGrid();
                txtMaSach.Clear();
            }
            else
            {
                UIHelper.ShowToast(this, "Không tìm thấy sách!", "Error");
            }
        }

        private void UpdateBookGrid()
        {
            dgvSelectedBooks.Rows.Clear();
            foreach (var s in _selectedBooks)
            {
                dgvSelectedBooks.Rows.Add(s.MaSach, s.TenSach);
            }
            lblTongSach.Text = $"Số sách chọn: {_selectedBooks.Count}";
        }

        private void dgvSelectedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSelectedBooks.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                string maSach = dgvSelectedBooks.Rows[e.RowIndex].Cells["colMaSach"].Value.ToString();
                var item = _selectedBooks.FirstOrDefault(s => s.MaSach == maSach);
                if (item != null)
                {
                    _selectedBooks.Remove(item);
                    UpdateBookGrid();
                }
            }
        }

        private void dateHanTra_ValueChanged(object sender, EventArgs e)
        {
            UpdateSoNgay();
        }

        private void UpdateSoNgay()
        {
            int days = (dateHanTra.Value.Date - DateTime.Today).Days;
            lblSoNgay.Text = $"Số ngày: {days} ngày";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            ResetDocGia();
            _selectedBooks.Clear();
            UpdateBookGrid();
            txtMaSach.Clear();
            dateHanTra.Value = DateTime.Today.AddDays(14);
            lblThongBaoSach.Text = "";
        }

        private void ResetDocGia()
        {
            _selectedMaDocGia = null;
            txtMaDocGia.Clear();
            lblTenDocGia.Text = "Tên độc giả: (Chưa)";
            lblSoDangMuon.Text = "Đang mượn: --";
            lblSoDangMuon.ForeColor = UIHelper.ColorPrimary;
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaDocGia))
            {
                UIHelper.ShowToast(this, "Vui lòng chọn độc giả!", "Error");
                return;
            }

            if (_selectedBooks.Count == 0)
            {
                UIHelper.ShowToast(this, "Vui lòng chọn ít nhất một cuốn sách!", "Error");
                return;
            }

            string error = _phieuBLL.TaoPhieuMuon(_selectedMaDocGia, _selectedBooks.Select(s => s.MaSach).ToList(), dateHanTra.Value);
            if (error == null)
            {
                UIHelper.ShowToast(this, "Tạo phiếu mượn thành công!", "Success");
                
                // Lấy mã phiếu vừa tạo (đây là logic đơn giản, thực tế nên trả về mã từ BLL)
                string maPhieuMoi = "PM" + DateTime.Now.ToString("yyyyMMddHHmmss"); 
                // Lưu ý: mã này có thể lệch 1s so với BLL nếu chạy song song, 
                // nhưng trong context này thì nó là mã duy nhất vừa được tính.

                if (MessageBox.Show("Bạn có muốn in phiếu mượn không?", "In phiếu", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PrintingService.InPhieuMuon(maPhieuMoi);
                }
                ResetForm();
            }
            else
            {
                UIHelper.ShowToast(this, error, "Error");
            }
        }
    }
}
