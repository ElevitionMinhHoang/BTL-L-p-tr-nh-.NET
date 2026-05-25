namespace LibraryManagement.Models
{
    public class TaiKhoan
    {
        public string MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
    }
}
