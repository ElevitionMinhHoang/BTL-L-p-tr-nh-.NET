// ===== LibraryManagement.DAL/Repositories/DatMuonRepository.cs =====
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.DAL.Repositories
{
    public class DatMuonRepository : IRepository<DatMuon>
    {
        private readonly LibraryContext _context;

        public DatMuonRepository()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<DatMuon> GetAll()
        {
            return _context.DatMuons.ToList();
        }

        public DatMuon GetById(int id)
        {
            throw new System.NotSupportedException("DatMuon uses string ID.");
        }

        public DatMuon GetById(string maDatMuon)
        {
            return _context.DatMuons.Find(maDatMuon);
        }

        public int Add(DatMuon entity)
        {
            _context.DatMuons.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(DatMuon entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new System.NotSupportedException("DatMuon uses string ID.");
        }

        public IEnumerable<DatMuonDTO> GetPending()
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT dm.*, d.HoTen AS TenDocGia, s.TenSach 
                               FROM DatMuon dm
                               JOIN DocGia d ON dm.MaDocGia = d.MaDocGia
                               JOIN Sach s ON dm.MaSach = s.MaSach
                               WHERE dm.TrangThai = 'ChoXuLy'
                               ORDER BY dm.NgayDat ASC";
                return db.Query<DatMuonDTO>(sql);
            }
        }

        public IEnumerable<DatMuon> GetByDocGia(string maDocGia)
        {
            return _context.DatMuons.Where(d => d.MaDocGia == maDocGia).ToList();
        }

        public bool UpdateTrangThai(string maDatMuon, string trangThai)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE DatMuon SET TrangThai = @trangThai WHERE MaDatMuon = @maDatMuon";
                return db.Execute(sql, new { trangThai, maDatMuon }) > 0;
            }
        }
    }
}
