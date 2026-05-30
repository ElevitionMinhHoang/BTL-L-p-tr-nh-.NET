// ===== LibraryManagement.Models/DTOs/PhieuMuonDTO.cs =====
using System;
using System.Collections.Generic;

namespace LibraryManagement.Models.DTOs
{
    public class PhieuMuonDTO
    {
        public string MaPhieu { get; set; }
        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public DateTime? NgayTra { get; set; }
        public string TrangThai { get; set; }
        public string TrangThaiDisplay { get; set; }
        public bool IsQuaHan => NgayTra == null && HanTra < DateTime.Today;
        public decimal TongPhiPhat { get; set; }
        public List<ChiTietMuonDTO> ChiTiet { get; set; } = new List<ChiTietMuonDTO>();
    }
}
