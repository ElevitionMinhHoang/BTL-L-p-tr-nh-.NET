# Module Auth & Quản lý Người dùng - LibraryManagement

Dưới đây là mã nguồn hoàn chỉnh cho module Auth & Quản lý người dùng, được thiết kế theo kiến trúc 3 lớp (3-Layer Architecture) cho .NET Framework 4.7.2.

---

// ===== LibraryManagement.Models/TaiKhoan.cs =====
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhauHash { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}

// ===== LibraryManagement.Models/DTOs/LoginDTO.cs =====
namespace LibraryManagement.Models.DTOs
{
    public class LoginDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }
}

// ===== LibraryManagement.Models/DTOs/TaiKhoanDTO.cs =====
namespace LibraryManagement.Models.DTOs
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public bool IsActive { get; set; }
    }
}

// ===== LibraryManagement.DAL/ConnectionHelper.cs =====
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagement.DAL
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}

// ===== LibraryManagement.DAL/DatabaseContext.cs =====
using System.Data.Entity;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryDB")
        {
            // Tắt khởi tạo database tự động nếu đã có sẵn
            Database.SetInitializer<LibraryContext>(null);
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        
        // Placeholder cho các DbSet khác
        // public DbSet<Sach> Sachs { get; set; }
        // public DbSet<DocGia> DocGias { get; set; }
        // public DbSet<PhieuMuon> PhieuMuons { get; set; }
    }
}

// ===== LibraryManagement.DAL/Repositories/IRepository.cs =====
using System.Collections.Generic;

namespace LibraryManagement.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}

// ===== LibraryManagement.DAL/Repositories/TaiKhoanRepository.cs =====
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class TaiKhoanRepository : IRepository<TaiKhoan>
    {
        public IEnumerable<TaiKhoan> GetAll()
        {
            using (var context = new LibraryContext())
            {
                return context.TaiKhoans.Where(t => t.IsActive).ToList();
            }
        }

        public TaiKhoan GetById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.TaiKhoans.Find(id);
            }
        }

        public int Add(TaiKhoan entity)
        {
            using (var context = new LibraryContext())
            {
                context.TaiKhoans.Add(entity);
                context.SaveChanges();
                return entity.MaTK;
            }
        }

        public bool Update(TaiKhoan entity)
        {
            using (var context = new LibraryContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                // Không cho phép update username và mật khẩu qua hàm generic này để bảo mật
                context.Entry(entity).Property(x => x.TenDangNhap).IsModified = false;
                context.Entry(entity).Property(x => x.MatKhauHash).IsModified = false;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE TaiKhoan SET IsActive=0 WHERE MaTK=@id";
                return db.Execute(sql, new { id }) > 0;
            }
        }

        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@tddn AND IsActive=1";
                return db.QueryFirstOrDefault<TaiKhoan>(sql, new { tddn = tenDangNhap });
            }
        }

        public bool CheckTenDangNhapExists(string tenDangNhap)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE TenDangNhap=@tddn";
                return db.ExecuteScalar<int>(sql, new { tddn = tenDangNhap }) > 0;
            }
        }

        public bool UpdatePassword(int maTK, string newHash)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE TaiKhoan SET MatKhauHash=@hash WHERE MaTK=@id";
                return db.Execute(sql, new { hash = newHash, id = maTK }) > 0;
            }
        }
        
        public int CountActiveAdmins()
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE Role='Admin' AND IsActive=1";
                return db.ExecuteScalar<int>(sql);
            }
        }
    }
}

// ===== LibraryManagement.BLL/AuthBLL.cs =====
using BCrypt.Net;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;
using System;

namespace LibraryManagement.BLL
{
    public enum LoginResult { Success, NotFound, WrongPassword, Disabled }

    public class LoginResponse
    {
        public LoginResult Result { get; set; }
        public TaiKhoanDTO UserInfo { get; set; }
    }

    public class AuthBLL
    {
        private readonly TaiKhoanRepository _repo = new TaiKhoanRepository();

        public LoginResponse Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.TenDangNhap) || string.IsNullOrEmpty(dto.MatKhau))
            {
                return new LoginResponse { Result = LoginResult.NotFound };
            }

            var taiKhoan = _repo.GetByTenDangNhap(dto.TenDangNhap);

            if (taiKhoan == null)
            {
                return new LoginResponse { Result = LoginResult.NotFound };
            }

            if (!taiKhoan.IsActive)
            {
                return new LoginResponse { Result = LoginResult.Disabled };
            }

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(dto.MatKhau, taiKhoan.MatKhauHash);

            if (!isPasswordCorrect)
            {
                return new LoginResponse { Result = LoginResult.WrongPassword };
            }

            return new LoginResponse
            {
                Result = LoginResult.Success,
                UserInfo = new TaiKhoanDTO
                {
                    MaTK = taiKhoan.MaTK,
                    TenDangNhap = taiKhoan.TenDangNhap,
                    HoTen = taiKhoan.HoTen,
                    Role = taiKhoan.Role,
                    Email = taiKhoan.Email,
                    SoDienThoai = taiKhoan.SoDienThoai,
                    IsActive = taiKhoan.IsActive
                }
            };
        }
    }
}

// ===== LibraryManagement.BLL/TaiKhoanBLL.cs =====
using BCrypt.Net;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.BLL
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanRepository _repo = new TaiKhoanRepository();

        public IEnumerable<TaiKhoanDTO> GetAll()
        {
            return _repo.GetAll().Select(t => new TaiKhoanDTO
            {
                MaTK = t.MaTK,
                TenDangNhap = t.TenDangNhap,
                HoTen = t.HoTen,
                Role = t.Role,
                Email = t.Email,
                SoDienThoai = t.SoDienThoai,
                IsActive = t.IsActive
            });
        }

        public string AddTaiKhoan(TaiKhoanDTO dto, string matKhauRaw)
        {
            if (string.IsNullOrWhiteSpace(dto.TenDangNhap) || string.IsNullOrWhiteSpace(dto.HoTen))
                return "Tên đăng nhập và Họ tên không được để trống";

            if (string.IsNullOrWhiteSpace(matKhauRaw) || matKhauRaw.Length < 6)
                return "Mật khẩu phải có ít nhất 6 ký tự";

            if (_repo.CheckTenDangNhapExists(dto.TenDangNhap))
                return "Tên đăng nhập đã tồn tại";

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = dto.TenDangNhap,
                HoTen = dto.HoTen,
                Role = dto.Role,
                Email = dto.Email,
                SoDienThoai = dto.SoDienThoai,
                MatKhauHash = BCrypt.Net.BCrypt.HashPassword(matKhauRaw, workFactor: 12),
                IsActive = true
            };

            _repo.Add(taiKhoan);
            return null; // OK
        }

        public string UpdateTaiKhoan(TaiKhoanDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.HoTen))
                return "Họ tên không được để trống";

            var entity = _repo.GetById(dto.MaTK);
            if (entity == null) return "Không tìm thấy tài khoản";

            entity.HoTen = dto.HoTen;
            entity.Role = dto.Role;
            entity.Email = dto.Email;
            entity.SoDienThoai = dto.SoDienThoai;
            entity.IsActive = dto.IsActive;

            bool success = _repo.Update(entity);
            return success ? null : "Cập nhật thất bại";
        }

        public bool DeleteTaiKhoan(int maTK)
        {
            if (!CanDelete(maTK)) return false;
            return _repo.Delete(maTK);
        }

        public string ResetPassword(int maTK, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                return "Mật khẩu mới phải có ít nhất 6 ký tự";

            string hash = BCrypt.Net.BCrypt.HashPassword(matKhauMoi, workFactor: 12);
            bool success = _repo.UpdatePassword(maTK, hash);
            return success ? null : "Cập nhật mật khẩu thất bại";
        }

        public bool CanDelete(int maTK)
        {
            var user = _repo.GetById(maTK);
            if (user == null) return false;

            if (user.Role == "Admin")
            {
                int activeAdmins = _repo.CountActiveAdmins();
                if (activeAdmins <= 1) return false; // Không thể xóa Admin cuối cùng
            }
            return true;
        }
    }
}

// ===== LibraryManagement.GUI/Forms/Auth/UserSession.cs =====
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.GUI.Forms.Auth
{
    public static class UserSession
    {
        public static TaiKhoanDTO Current { get; set; }
        public static bool IsAdmin => Current?.Role == "Admin";
        public static bool IsThuThu => Current?.Role == "ThuThu";
        public static bool IsBanDoc => Current?.Role == "BanDoc";

        public static void Logout()
        {
            Current = null;
        }
    }
}

// ===== LibraryManagement.GUI/Forms/Auth/frmDangNhap.cs =====
using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models.DTOs;
using Guna.UI2.WinForms;

namespace LibraryManagement.GUI.Forms.Auth
{
    public partial class frmDangNhap : Form
    {
        private int _loginAttempts = 0;
        private Timer _lockoutTimer;
        private int _lockoutSeconds = 0;

        public frmDangNhap()
        {
            InitializeComponent();
            SetupCustomStyles();
        }

        private void SetupCustomStyles()
        {
            // Thiết lập UI thủ công nếu không dùng Designer
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(400, 500);
            
            // Ví dụ Guna UI Layout (Giả lập)
            lblThongBao.Visible = false;
            lblThongBao.ForeColor = Color.Red;
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
                lblThongBao.Visible = true;
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
                        // Mở form bạn đọc
                        // new frmBanDoc().Show();
                    }
                    else
                    {
                        // Mở form main
                        // new frmMain().Show();
                    }
                    break;

                case LoginResult.NotFound:
                case LoginResult.WrongPassword:
                    HandleFailedLogin();
                    lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                    lblThongBao.Visible = true;
                    break;

                case LoginResult.Disabled:
                    lblThongBao.Text = "Tài khoản đã bị vô hiệu hóa";
                    lblThongBao.Visible = true;
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
                lblThongBao.Text = $"Sai quá nhiều lần. Thử lại sau {_lockoutSeconds}s";
                
                _lockoutTimer = new Timer();
                _lockoutTimer.Interval = 1000;
                _lockoutTimer.Tick += (s, ev) => {
                    _lockoutSeconds--;
                    if (_lockoutSeconds <= 0)
                    {
                        _lockoutTimer.Stop();
                        btnDangNhap.Enabled = true;
                        _loginAttempts = 0;
                        lblThongBao.Visible = false;
                    }
                    else
                    {
                        lblThongBao.Text = $"Sai quá nhiều lần. Thử lại sau {_lockoutSeconds}s";
                    }
                };
                _lockoutTimer.Start();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}

// ===== LibraryManagement.GUI/frmMain.cs =====
using System;
using System.Windows.Forms;
using LibraryManagement.GUI.Forms.Auth;

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

            lblUser.Text = $"Xin chào, {UserSession.Current.HoTen}";

            // Phân quyền menu
            btnQuanLyTaiKhoan.Visible = UserSession.IsAdmin;
            
            if (UserSession.IsBanDoc)
            {
                // Nếu là Bạn đọc thì redirect sang Form riêng
                this.Hide();
                // new frmBanDoc().Show();
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
            // Load child form vào panel
            // LoadForm(new frmQuanLyTaiKhoan());
        }
    }
}

// ===== LibraryManagement.GUI/Forms/Admin/frmQuanLyTaiKhoan.cs =====
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models.DTOs;
using LibraryManagement.GUI.Forms.Auth;

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
            cboRole.SelectedIndex = 0; // "Tất cả"
        }

        private void LoadData()
        {
            _allUsers = _bll.GetAll().ToList();
            dgvTaiKhoan.DataSource = _allUsers;
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
                Role = cboRoleChiTiet.SelectedItem.ToString(),
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
                dto.MaTK = (int)dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value;
                error = _bll.UpdateTaiKhoan(dto);
            }

            if (error == null)
            {
                MessageBox.Show("Thành công!");
                LoadData();
                _isAdding = false;
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
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
        }
    }
}

// ===== LibraryManagement.GUI/Forms/Reader/frmBanDoc.cs =====
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

            // Kiểm tra mật khẩu cũ (tái sử dụng logic login đơn giản)
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
    }
}
