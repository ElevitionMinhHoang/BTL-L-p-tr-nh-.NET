using System;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.GUI.Forms.Auth;

namespace LibraryManagement.GUI.Forms.Reader
{
    public partial class frmBanDoc : Form
    {
        public frmBanDoc()
        {
            InitializeComponent();
        }

        private void frmBanDoc_Load(object sender, EventArgs e)
        {
            if (UserSession.Current == null)
            {
                this.Close();
                return;
            }
            lblWelcome.Text = $"Chào mừng độc giả: {UserSession.Current.HoTen}";
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string oldPass = txtMatKhauCu.Text;
            string newPass = txtMatKhauMoi.Text;
            string confirmPass = txtXacNhan.Text;

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            // Kiểm tra mật khẩu cũ
            var authBll = new AuthBLL();
            var loginCheck = authBll.Login(new Models.DTOs.LoginDTO { 
                TenDangNhap = UserSession.Current.TenDangNhap, 
                MatKhau = oldPass 
            });

            if (loginCheck.Result != LoginResult.Success)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!");
                return;
            }

            var tkBll = new TaiKhoanBLL();
            string error = tkBll.ResetPassword(UserSession.Current.MaTK, newPass);

            if (error == null)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtXacNhan.Clear();
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Close();
            new frmDangNhap().Show();
        }

        private void btnTraCuuSach_Click(object sender, EventArgs e)
        {
            // Mở form tra cứu sách
            // new frmTraCuuSach().ShowDialog();
        }

        private void btnLichSuMuon_Click(object sender, EventArgs e)
        {
            // Mở form lịch sử mượn
            // new frmLichSuMuon().ShowDialog();
        }
    }
}
