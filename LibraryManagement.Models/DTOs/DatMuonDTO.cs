// ===== LibraryManagement.Models/DTOs/DatMuonDTO.cs =====
using System;

namespace LibraryManagement.Models.DTOs
{
    public class DatMuonDTO
    {
        public string MaDatMuon { get; set; }
        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayDat { get; set; }
        public string TrangThai { get; set; }
    }
}
