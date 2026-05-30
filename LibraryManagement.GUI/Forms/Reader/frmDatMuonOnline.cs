// ===== LibraryManagement.GUI/Forms/Reader/frmDatMuonOnline.cs =====
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.GUI.Forms.Auth;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Reader
{
    public partial class frmDatMuonOnline : Form
    {
        private readonly SachBLL _sachBLL = new SachBLL();
        private readonly DatMuonBLL _datMuonBLL = new DatMuonBLL();
        private List<Sach> _allBooks = new List<Sach>();

        public frmDatMuonOnline()
        {
            InitializeComponent();
        }

        private void frmDatMuonOnline_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _allBooks = _sachBLL.GetAll().ToList();
            dgvBooks.DataSource = _allBooks;
            
            // Format columns
            if (dgvBooks.Columns["MaDanhMuc"] != null) dgvBooks.Columns["MaDanhMuc"].Visible = false;
            dgvBooks.Columns["MaSach"].HeaderText = "Mã sách";
            dgvBooks.Columns["TenSach"].HeaderText = "Tên sách";
            dgvBooks.Columns["NamXB"].HeaderText = "Năm XB";
            dgvBooks.Columns["SoLuong"].HeaderText = "Tồn kho";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            dgvBooks.DataSource = _allBooks.Where(s => s.TenSach.ToLower().Contains(search) || s.MaSach.ToLower().Contains(search)).ToList();
        }

        private void btnDatMuon_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            string maSach = dgvBooks.SelectedRows[0].Cells["MaSach"].Value.ToString();
            string tenSach = dgvBooks.SelectedRows[0].Cells["TenSach"].Value.ToString();

            // Tìm MaDocGia dựa trên UserSession (cần logic mapping MaTK -> MaDocGia)
            // Đơn giản hóa: Giả sử UserSession.Current có thông tin này hoặc ta tìm từ DocGiaBLL
            var dgBll = new DocGiaBLL();
            var docGia = dgBll.GetAll().FirstOrDefault(d => d.MaTK == UserSession.Current.MaTK);

            if (docGia == null)
            {
                UIHelper.ShowToast(this, "Không tìm thấy thông tin độc giả liên kết!", "Error");
                return;
            }

            if (MessageBox.Show($"Bạn muốn đặt mượn cuốn '{tenSach}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string error = _datMuonBLL.TaoDatMuon(docGia.MaDocGia, maSach);
                if (error == null)
                {
                    UIHelper.ShowToast(this, "Gửi yêu cầu đặt mượn thành công! Vui lòng chờ thủ thư duyệt.", "Success");
                }
                else
                {
                    UIHelper.ShowToast(this, error, "Error");
                }
            }
        }
    }
}
