using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models.DTOs;
using LibraryManagement.GUI.Forms.Reader;

namespace LibraryManagement.GUI.Forms.Auth
{
    public partial class frmDangNhap : Form
    {
        private int _loginAttempts = 0;
        private System.Windows.Forms.Timer _lockoutTimer;
        private int _lockoutSeconds = 0;

        public frmDangNhap()
        {
            InitializeComponent();
            SetupCustomStyles();
        }

        private void SetupCustomStyles()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            // lblThongBao.Visible = false;
            // lblThongBao.ForeColor = Color.Red;
            // txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            var authBll = new AuthBLL();
            var response = authBll.Login(new LoginDTO { TenDangNhap = username, MatKhau = password });

            switch (response.Result)
            {
                case LoginResult.Success:
                    UserSession.Current = response.UserInfo;
                    this.Hide();
                    if (UserSession.IsBanDoc)
                    {
                        new frmBanDoc().Show();
                    }
                    else
                    {
                        new frmMain().Show();
                    }
                    break;

                case LoginResult.NotFound:
                case LoginResult.WrongPassword:
                    HandleFailedLogin();
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    break;

                case LoginResult.Disabled:
                    MessageBox.Show("Tài khoản đã bị vô hiệu hóa");
                    break;
            }
        }

        private void HandleFailedLogin()
        {
            _loginAttempts++;
            if (_loginAttempts >= 5)
            {
                btnDangNhap.Enabled = false;
                _lockoutSeconds = 30;
                MessageBox.Show($"Sai quá nhiều lần. Thử lại sau {_lockoutSeconds}s");
                
                _lockoutTimer = new System.Windows.Forms.Timer();
                _lockoutTimer.Interval = 1000;
                _lockoutTimer.Tick += (s, ev) => {
                    _lockoutSeconds--;
                    if (_lockoutSeconds <= 0)
                    {
                        _lockoutTimer.Stop();
                        btnDangNhap.Enabled = true;
                        _loginAttempts = 0;
                    }
                };
                _lockoutTimer.Start();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
