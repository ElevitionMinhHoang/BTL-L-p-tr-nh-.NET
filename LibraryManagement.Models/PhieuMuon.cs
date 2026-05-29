using System;

namespace LibraryManagement.Models
{
    public class PhieuMuon
    {
        public string MaPhieu { get; set; } = string.Empty;
        public string MaDocGia { get; set; } = string.Empty;
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string TrangThai { get; set; } = string.Empty;
    }
}
