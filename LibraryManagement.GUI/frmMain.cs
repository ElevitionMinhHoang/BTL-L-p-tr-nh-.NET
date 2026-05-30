using System;
using System.Windows.Forms;
using LibraryManagement.GUI.Forms.Auth;
using LibraryManagement.GUI.Forms.Admin;
using LibraryManagement.GUI.Forms.Reader;

namespace LibraryManagement.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (UserSession.Current == null)
            {
                this.Close();
                return;
            }

            lblUser.Text = $"Xin chào, {UserSession.Current.HoTen} ({UserSession.Current.Role})";

            // Phân quyền menu
            btnQuanLyTaiKhoan.Visible = UserSession.IsAdmin;
            
            if (UserSession.IsBanDoc)
            {
                // Nếu là Bạn đọc thì redirect sang Form riêng
                this.Hide();
                new frmBanDoc().Show();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Hide();
            new frmDangNhap().Show();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Admin.frmQuanLyTaiKhoan();
            frm.ShowDialog();
        }

        private void LoadForm(Form frm)
        {
            panelContent.Controls.Clear();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            // Mặc định mở danh sách mượn
            LoadForm(new Forms.Borrowing.frmDanhSachMuon());
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.Borrowing.frmMuonSach());
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.Borrowing.frmTraSach());
        }
    }
}
