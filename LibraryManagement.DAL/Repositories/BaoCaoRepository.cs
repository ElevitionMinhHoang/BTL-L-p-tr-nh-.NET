using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.DAL.Repositories
{
    public class BaoCaoRepository
    {
        public KpiDTO GetKpi(int nam, int? thang)
        {
            using (IDbConnection conn = ConnectionHelper.GetConnection())
            {
                var p = CreatePeriodParameters(nam, thang);

                const string sqlTongLuotMuon = @"
SELECT COUNT(p.MaPhieu)
FROM PhieuMuon p
WHERE YEAR(p.NgayMuon) = @Nam
  AND (@Thang IS NULL OR MONTH(p.NgayMuon) = @Thang);";

                const string sqlDangMuon = @"
SELECT COUNT(p.MaPhieu)
FROM PhieuMuon p
WHERE p.TrangThai = N'DangMuon';";

                const string sqlQuaHan = @"
SELECT COUNT(p.MaPhieu)
FROM PhieuMuon p
WHERE p.TrangThai = N'QuaHan';";

                const string sqlTienPhat = @"
SELECT ISNULL(SUM(ct.PhiPhat), 0)
FROM ChiTietMuon ct
INNER JOIN PhieuMuon p ON ct.MaPhieu = p.MaPhieu
WHERE p.NgayTra IS NOT NULL
  AND YEAR(p.NgayTra) = @Nam
  AND (@Thang IS NULL OR MONTH(p.NgayTra) = @Thang);";

                return new KpiDTO
                {
                    TongLuotMuonThang = conn.QuerySingle<int>(sqlTongLuotMuon, p),
                    TongDangMuon = conn.QuerySingle<int>(sqlDangMuon),
                    TongQuaHan = conn.QuerySingle<int>(sqlQuaHan),
                    TongTienPhatThang = conn.QuerySingle<decimal>(sqlTienPhat, p)
                };
            }
        }

        public IEnumerable<SachMuonNhieuDTO> GetTopSachMuon(int nam, int? thang, int top = 10)
        {
            using (IDbConnection conn = ConnectionHelper.GetConnection())
            {
                var p = CreatePeriodParameters(nam, thang);
                p.Add("@Top", top <= 0 ? 10 : top);

                const string sql = @"
SELECT TOP (@Top)
       s.MaSach,
       s.TenSach,
       d.TenDanhMuc AS TheLoai,
       COUNT(ct.MaChiTiet) AS LuotMuon,
       s.SoLuong AS SoLuongHienCo
FROM ChiTietMuon ct
INNER JOIN Sach s ON ct.MaSach = s.MaSach
INNER JOIN DanhMuc d ON s.MaDanhMuc = d.MaDanhMuc
INNER JOIN PhieuMuon p ON ct.MaPhieu = p.MaPhieu
WHERE YEAR(p.NgayMuon) = @Nam
  AND (@Thang IS NULL OR MONTH(p.NgayMuon) = @Thang)
  AND d.LoaiDanhMuc = N'TheLoai'
GROUP BY s.MaSach, s.TenSach, d.TenDanhMuc, s.SoLuong
ORDER BY LuotMuon DESC, s.TenSach ASC;";

                return conn.Query<SachMuonNhieuDTO>(sql, p).ToList();
            }
        }

        public IEnumerable<ThongKeTheLoaiDTO> GetThongKeTheLoai(int nam, int? thang)
        {
            using (IDbConnection conn = ConnectionHelper.GetConnection())
            {
                var p = CreatePeriodParameters(nam, thang);

                const string sql = @"
SELECT d.TenDanhMuc AS TenTheLoai,
       COUNT(ct.MaChiTiet) AS LuotMuon
FROM ChiTietMuon ct
INNER JOIN Sach s ON ct.MaSach = s.MaSach
INNER JOIN DanhMuc d ON s.MaDanhMuc = d.MaDanhMuc
INNER JOIN PhieuMuon p ON ct.MaPhieu = p.MaPhieu
WHERE YEAR(p.NgayMuon) = @Nam
  AND (@Thang IS NULL OR MONTH(p.NgayMuon) = @Thang)
  AND d.LoaiDanhMuc = N'TheLoai'
GROUP BY d.TenDanhMuc
ORDER BY LuotMuon DESC;";

                var result = conn.Query<ThongKeTheLoaiDTO>(sql, p).ToList();
                int total = result.Sum(x => x.LuotMuon);

                foreach (var item in result)
                {
                    item.PhanTram = total == 0 ? 0 : item.LuotMuon * 100.0 / total;
                }

                return result;
            }
        }

        public IEnumerable<SachTonDTO> GetSachTon(int nam)
        {
            using (IDbConnection conn = ConnectionHelper.GetConnection())
            {
                const string sql = @"
SELECT s.MaSach,
       s.TenSach,
       d.TenDanhMuc AS TheLoai,
       s.SoLuong,
       ISNULL(sub.LuotMuon, 0) AS LuotMuon
FROM Sach s
INNER JOIN DanhMuc d ON s.MaDanhMuc = d.MaDanhMuc
LEFT JOIN (
    SELECT ct.MaSach, COUNT(*) AS LuotMuon
    FROM ChiTietMuon ct
    INNER JOIN PhieuMuon p ON ct.MaPhieu = p.MaPhieu
    WHERE YEAR(p.NgayMuon) = @Nam
    GROUP BY ct.MaSach
) sub ON s.MaSach = sub.MaSach
WHERE s.SoLuong > 0
  AND d.LoaiDanhMuc = N'TheLoai'
ORDER BY LuotMuon ASC, s.TenSach ASC;";

                return conn.Query<SachTonDTO>(sql, new { Nam = nam }).ToList();
            }
        }

        public IEnumerable<DoanhThuPhatDTO> GetDoanhThuPhat(int nam, int? thang)
        {
            using (IDbConnection conn = ConnectionHelper.GetConnection())
            {
                var p = CreatePeriodParameters(nam, thang);

                const string sql = @"
SELECT CAST(p.NgayTra AS DATE) AS Ngay,
       COUNT(DISTINCT p.MaPhieu) AS SoPhieu,
       ISNULL(SUM(ct.PhiPhat), 0) AS TongPhat
FROM PhieuMuon p
INNER JOIN ChiTietMuon ct ON p.MaPhieu = ct.MaPhieu
WHERE p.NgayTra IS NOT NULL
  AND YEAR(p.NgayTra) = @Nam
  AND (@Thang IS NULL OR MONTH(p.NgayTra) = @Thang)
  AND ct.PhiPhat > 0
GROUP BY CAST(p.NgayTra AS DATE)
ORDER BY Ngay DESC;";

                return conn.Query<DoanhThuPhatDTO>(sql, p).ToList();
            }
        }

        private static DynamicParameters CreatePeriodParameters(int nam, int? thang)
        {
            var p = new DynamicParameters();
            p.Add("@Nam", nam);
            p.Add("@Thang", thang);
            return p;
        }
    }
}