// ===== LibraryManagement.Models/DTOs/ChiTietMuonDTO.cs =====
namespace LibraryManagement.Models.DTOs
{
    public class ChiTietMuonDTO
    {
        public int MaChiTiet { get; set; }
        public string MaPhieu { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal PhiPhat { get; set; }
    }
}
