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
