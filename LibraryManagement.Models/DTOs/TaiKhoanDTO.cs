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
