
using System;

namespace LibraryManagement.Models.DTOs
{
    public class KpiDTO
    {
        public int TongLuotMuonThang { get; set; }
        public int TongDangMuon { get; set; }
        public int TongQuaHan { get; set; }
        public decimal TongTienPhatThang { get; set; }
    }

    public class SachMuonNhieuDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public int LuotMuon { get; set; }
        public int SoLuongHienCo { get; set; }
    }

    public class ThongKeTheLoaiDTO
    {
        public string TenTheLoai { get; set; }
        public int LuotMuon { get; set; }
        public double PhanTram { get; set; }
    }

    public class SachTonDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public int SoLuong { get; set; }
        public int LuotMuon { get; set; }
    }

    public class DoanhThuPhatDTO
    {
        public DateTime Ngay { get; set; }
        public int SoPhieu { get; set; }
        public decimal TongPhat { get; set; }
    }
}