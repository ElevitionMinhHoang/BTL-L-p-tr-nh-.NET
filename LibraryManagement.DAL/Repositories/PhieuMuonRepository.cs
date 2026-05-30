// ===== LibraryManagement.DAL/Repositories/PhieuMuonRepository.cs =====
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.DAL.Repositories
{
    public class PhieuMuonRepository : IRepository<PhieuMuon>
    {
        private readonly LibraryContext _context;

        public PhieuMuonRepository()
        {
            _context = new LibraryContext();
        }

        // Implementation of IRepository<PhieuMuon>
        public IEnumerable<PhieuMuon> GetAll()
        {
            return _context.PhieuMuons.ToList();
        }

        public PhieuMuon GetById(int id)
        {
            throw new NotSupportedException("PhieuMuon uses string ID. Use GetById(string maPhieu) instead.");
        }

        public int Add(PhieuMuon entity)
        {
            _context.PhieuMuons.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(PhieuMuon entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotSupportedException("PhieuMuon uses string ID.");
        }

        // Specialized Methods
        public PhieuMuon GetById(string maPhieu)
        {
            return _context.PhieuMuons
                .Include(p => p.DocGia)
                .Include(p => p.ChiTietMuons.Select(ct => ct.Sach))
                .FirstOrDefault(p => p.MaPhieu == maPhieu);
        }

        public IEnumerable<PhieuMuonDTO> GetAllDTO()
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT p.*, d.HoTen AS TenDocGia 
                               FROM PhieuMuon p
                               JOIN DocGia d ON p.MaDocGia = d.MaDocGia 
                               ORDER BY p.NgayMuon DESC";
                return db.Query<PhieuMuonDTO>(sql);
            }
        }

        public IEnumerable<PhieuMuonDTO> GetByDocGia(string maDocGia)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT p.*, d.HoTen AS TenDocGia 
                               FROM PhieuMuon p
                               JOIN DocGia d ON p.MaDocGia = d.MaDocGia 
                               WHERE p.MaDocGia = @maDocGia
                               ORDER BY p.NgayMuon DESC";
                return db.Query<PhieuMuonDTO>(sql, new { maDocGia });
            }
        }

        public IEnumerable<PhieuMuonDTO> GetByTrangThai(string trangThai)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT p.*, d.HoTen AS TenDocGia 
                               FROM PhieuMuon p
                               JOIN DocGia d ON p.MaDocGia = d.MaDocGia 
                               WHERE p.TrangThai = @trangThai
                               ORDER BY p.NgayMuon DESC";
                return db.Query<PhieuMuonDTO>(sql, new { trangThai });
            }
        }

        public IEnumerable<PhieuMuonDTO> GetQuaHan()
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT p.*, d.HoTen AS TenDocGia 
                               FROM PhieuMuon p
                               JOIN DocGia d ON p.MaDocGia = d.MaDocGia 
                               WHERE p.TrangThai = 'DangMuon' AND p.HanTra < GETDATE()
                               ORDER BY p.HanTra ASC";
                return db.Query<PhieuMuonDTO>(sql);
            }
        }

        public void CreatePhieuMuon(PhieuMuon phieu, List<ChiTietMuon> chiTiets)
        {
            using (var conn = ConnectionHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert PhieuMuon
                        string sqlPhieu = "INSERT INTO PhieuMuon (MaPhieu, MaDocGia, NgayMuon, HanTra, TrangThai) VALUES (@MaPhieu, @MaDocGia, @NgayMuon, @HanTra, @TrangThai)";
                        conn.Execute(sqlPhieu, phieu, trans);

                        foreach (var ct in chiTiets)
                        {
                            // 2. Insert ChiTietMuon
                            string sqlCT = "INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong, PhiPhat) VALUES (@MaPhieu, @MaSach, @SoLuong, @PhiPhat)";
                            conn.Execute(sqlCT, ct, trans);

                            // 3. Update Sach SoLuong
                            string sqlSach = "UPDATE Sach SET SoLuong = SoLuong - @SoLuong WHERE MaSach = @MaSach AND SoLuong >= @SoLuong";
                            int affected = conn.Execute(sqlSach, new { ct.SoLuong, ct.MaSach }, trans);
                            
                            if (affected == 0)
                                throw new Exception($"Sách {ct.MaSach} không đủ số lượng tồn kho.");

                            // 4. Check if SoLuong = 0 -> Update TrangThai
                            string sqlCheck = "UPDATE Sach SET TrangThai = N'HetSach' WHERE MaSach = @MaSach AND SoLuong = 0";
                            conn.Execute(sqlCheck, new { ct.MaSach }, trans);
                        }

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void TraSach(string maPhieu, DateTime ngayTra, List<(string maSach, decimal phiPhat)> chiTietPhat)
        {
            using (var conn = ConnectionHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Update PhieuMuon
                        string sqlPhieu = "UPDATE PhieuMuon SET TrangThai = 'DaTra', NgayTra = @ngayTra WHERE MaPhieu = @maPhieu";
                        conn.Execute(sqlPhieu, new { ngayTra, maPhieu }, trans);

                        foreach (var item in chiTietPhat)
                        {
                            // 2. Update ChiTietMuon PhiPhat
                            string sqlCT = "UPDATE ChiTietMuon SET PhiPhat = @phiPhat WHERE MaPhieu = @maPhieu AND MaSach = @maSach";
                            conn.Execute(sqlCT, new { item.phiPhat, maPhieu, item.maSach }, trans);

                            // 3. Check if book was lost (Mat)
                            string sqlCheckLost = "SELECT COUNT(1) FROM MatSach WHERE MaPhieu = @maPhieu AND MaSach = @maSach AND LoaiSuCo = 'Mat'";
                            bool isLost = conn.ExecuteScalar<int>(sqlCheckLost, new { maPhieu, item.maSach }, trans) > 0;

                            if (!isLost)
                            {
                                // 4. Update Sach SoLuong (Only if not lost)
                                string sqlSach = "UPDATE Sach SET SoLuong = SoLuong + 1 WHERE MaSach = @maSach";
                                conn.Execute(sqlSach, new { item.maSach }, trans);

                                // 5. Update TrangThai Sach
                                string sqlStatus = "UPDATE Sach SET TrangThai = N'CoSan' WHERE MaSach = @maSach AND TrangThai = N'HetSach'";
                                conn.Execute(sqlStatus, new { item.maSach }, trans);
                            }
                        }

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void HuyPhieu(string maPhieu)
        {
            using (var conn = ConnectionHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Get ChiTietMuon
                        string sqlGetCT = "SELECT MaSach, SoLuong FROM ChiTietMuon WHERE MaPhieu = @maPhieu";
                        var chiTiets = conn.Query<(string MaSach, int SoLuong)>(sqlGetCT, new { maPhieu }, trans).ToList();

                        // 2. Update PhieuMuon
                        string sqlPhieu = "UPDATE PhieuMuon SET TrangThai = 'DaHuy' WHERE MaPhieu = @maPhieu";
                        conn.Execute(sqlPhieu, new { maPhieu }, trans);

                        // 3. Revert SoLuong
                        foreach (var ct in chiTiets)
                        {
                            // Check if book was lost
                            string sqlCheckLost = "SELECT COUNT(1) FROM MatSach WHERE MaPhieu = @maPhieu AND MaSach = @maSach AND LoaiSuCo = 'Mat'";
                            bool isLost = conn.ExecuteScalar<int>(sqlCheckLost, new { maPhieu, ct.MaSach }, trans) > 0;

                            if (!isLost)
                            {
                                string sqlSach = "UPDATE Sach SET SoLuong = SoLuong + @SoLuong WHERE MaSach = @MaSach";
                                conn.Execute(sqlSach, new { ct.SoLuong, ct.MaSach }, trans);

                                string sqlStatus = "UPDATE Sach SET TrangThai = N'CoSan' WHERE MaSach = @MaSach AND TrangThai = N'HetSach'";
                                conn.Execute(sqlStatus, new { ct.MaSach }, trans);
                            }
                        }

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void GiaHanPhieu(string maPhieu, DateTime hanTraMoi)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE PhieuMuon SET HanTra = @hanTraMoi WHERE MaPhieu = @maPhieu";
                db.Execute(sql, new { hanTraMoi, maPhieu });
            }
        }
    }
}
