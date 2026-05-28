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
