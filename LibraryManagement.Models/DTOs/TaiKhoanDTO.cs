namespace LibraryManagement.Models.DTOs
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public bool IsActive { get; set; }
    }
}
