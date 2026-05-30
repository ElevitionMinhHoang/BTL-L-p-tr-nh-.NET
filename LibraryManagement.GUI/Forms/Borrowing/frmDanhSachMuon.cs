// ===== LibraryManagement.GUI/Forms/Borrowing/frmDanhSachMuon.cs =====
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.GUI.Forms.Borrowing
{
    public partial class frmDanhSachMuon : Form
    {
        private readonly PhieuMuonBLL _phieuBLL = new PhieuMuonBLL();
        private readonly DatMuonBLL _datMuonBLL = new DatMuonBLL();

        public frmDanhSachMuon()
        {
            InitializeComponent();
        }

        private void frmDanhSachMuon_Load(object sender, EventArgs e)
        {
            _phieuBLL.CapNhatTrangThaiQuaHan();
            LoadData();
        }

        private void LoadData()
        {
            var all = _phieuBLL.GetAll().ToList();
            
            // Filter
            string search = txtSearch.Text.ToLower();
            string status = cboTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            var filtered = all.Where(p => 
                (string.IsNullOrEmpty(search) || p.MaPhieu.ToLower().Contains(search) || p.TenDocGia.ToLower().Contains(search)) &&
                (status == "Tất cả" || p.TrangThai == status)
            ).ToList();

            dgvAll.DataSource = filtered;
            
            // Load Quá hạn
            dgvQuaHan.DataSource = all.Where(p => p.TrangThai == "QuaHan").ToList();

            // Load Chờ duyệt
            dgvChoDuyet.DataSource = _datMuonBLL.GetPending().ToList();

            // Load Lịch sử sự cố
            var matSachRepo = new DAL.Repositories.MatSachRepository();
            dgvSuCo.DataSource = matSachRepo.GetAll().ToList();
        }

        private void dgvAll_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAll.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string val = e.Value.ToString();
                switch (val)
                {
                    case "DangMuon":
                        e.CellStyle.BackColor = Color.FromArgb(239, 246, 255);
                        e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216);
                        break;
                    case "DaTra":
                        e.CellStyle.BackColor = Color.FromArgb(240, 253, 244);
                        e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                        break;
                    case "QuaHan":
                        e.CellStyle.BackColor = Color.FromArgb(254, 242, 242);
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        break;
                    case "ChoXuLy":
                        e.CellStyle.BackColor = Color.FromArgb(255, 251, 235);
                        e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                        break;
                    case "DaHuy":
                        e.CellStyle.BackColor = Color.FromArgb(248, 250, 252);
                        e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                        break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData();
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        private void btnLamMoi_Click(object sender, EventArgs e) => LoadData();

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsmiGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count > 0)
            {
                var row = dgvAll.SelectedRows[0];
                string maPhieu = row.Cells["MaPhieu"].Value.ToString();
                DateTime hanTraCu = (DateTime)row.Cells["HanTra"].Value;
                DateTime hanTraMoi = hanTraCu.AddDays(7);

                string error = _phieuBLL.GiaHanPhieu(maPhieu, hanTraMoi);
                if (error == null)
                {
                    UIHelper.ShowToast(this, $"Gia hạn đến {hanTraMoi:dd/MM/yyyy} thành công!", "Success");
                    LoadData();
                }
                else UIHelper.ShowToast(this, error, "Error");
            }
        }

        private void tsmiTraSach_Click(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count > 0)
            {
                string maPhieu = dgvAll.SelectedRows[0].Cells["MaPhieu"].Value.ToString();
                // Chuyển sang form trả sách hoặc xử lý trực tiếp
                var frm = new frmTraSach();
                // Ở đây ta có thể truyền mã phiếu vào form trả sách nếu constructor hỗ trợ
                frm.ShowDialog();
                LoadData();
            }
        }

        private void tsmiGhiMat_Click(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count > 0)
            {
                string maPhieu = dgvAll.SelectedRows[0].Cells["MaPhieu"].Value.ToString();
                // Lấy cuốn sách đầu tiên của phiếu để ghi mất (đơn giản hóa)
                var repo = new DAL.Repositories.PhieuMuonRepository();
                var phieu = repo.GetById(maPhieu);
                if (phieu != null && phieu.ChiTietMuons.Any())
                {
                    var ct = phieu.ChiTietMuons.First();
                    var frm = new frmMatSach(maPhieu, ct.MaSach, ct.Sach?.TenSach ?? "Sách");
                    if (frm.ShowDialog() == DialogResult.OK) LoadData();
                }
            }
        }

        private void tsmiHuyPhieu_Click(object sender, EventArgs e)
        {
            if (dgvAll.SelectedRows.Count > 0)
            {
                string maPhieu = dgvAll.SelectedRows[0].Cells["MaPhieu"].Value.ToString();
                if (UIHelper.ConfirmDelete("phiếu mượn " + maPhieu))
                {
                    string error = _phieuBLL.HuyPhieu(maPhieu);
                    if (error == null)
                    {
                        UIHelper.ShowToast(this, "Hủy phiếu thành công!", "Success");
                        LoadData();
                    }
                    else UIHelper.ShowToast(this, error, "Error");
                }
            }
        }

        private void tsmiDuyet_Click(object sender, EventArgs e)
        {
            if (dgvChoDuyet.SelectedRows.Count > 0)
            {
                string maDM = dgvChoDuyet.SelectedRows[0].Cells["MaDatMuon"].Value.ToString();
                string error = _datMuonBLL.DuyetDatMuon(maDM);
                if (error == null)
                {
                    UIHelper.ShowToast(this, "Đã duyệt và tạo phiếu mượn thành công!", "Success");
                    LoadData();
                }
                else UIHelper.ShowToast(this, error, "Error");
            }
        }

        private void tsmiTuChoi_Click(object sender, EventArgs e)
        {
            if (dgvChoDuyet.SelectedRows.Count > 0)
            {
                string maDM = dgvChoDuyet.SelectedRows[0].Cells["MaDatMuon"].Value.ToString();
                string error = _datMuonBLL.TuChoiDatMuon(maDM, "Từ chối bởi thủ thư");
                if (error == null)
                {
                    UIHelper.ShowToast(this, "Đã từ chối yêu cầu!", "Success");
                    LoadData();
                }
                else UIHelper.ShowToast(this, error, "Error");
            }
        }
    }
}
