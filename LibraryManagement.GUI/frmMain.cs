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
            // Load child form vào panel hoặc mở form mới
            var frm = new frmQuanLyTaiKhoan();
            frm.ShowDialog();
        }
    }
}
