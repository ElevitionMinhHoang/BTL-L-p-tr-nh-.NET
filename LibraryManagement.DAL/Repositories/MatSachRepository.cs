// ===== LibraryManagement.DAL/Repositories/MatSachRepository.cs =====
using System.Collections.Generic;
using System.Linq;
using Dapper;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class MatSachRepository : IRepository<MatSachRecord>
    {
        private readonly LibraryContext _context;

        public MatSachRepository()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<MatSachRecord> GetAll()
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"SELECT m.*, s.TenSach 
                               FROM MatSach m
                               JOIN Sach s ON m.MaSach = s.MaSach";
                return db.Query<MatSachRecord>(sql);
            }
        }

        public MatSachRecord GetById(int id)
        {
            return _context.MatSachs.Find(id);
        }

        public int Add(MatSachRecord entity)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = @"INSERT INTO MatSach (MaPhieu, MaSach, LoaiSuCo, MucBoiThuong, NgayGhiNhan) 
                               VALUES (@MaPhieu, @MaSach, @LoaiSuCo, @MucBoiThuong, @NgayGhiNhan);
                               SELECT CAST(SCOPE_IDENTITY() as int)";
                return db.Query<int>(sql, entity).Single();
            }
        }

        public bool Update(MatSachRecord entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var entity = _context.MatSachs.Find(id);
            if (entity != null)
            {
                _context.MatSachs.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<MatSachRecord> GetByPhieu(string maPhieu)
        {
            using (var db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT * FROM MatSach WHERE MaPhieu = @maPhieu";
                return db.Query<MatSachRecord>(sql, new { maPhieu });
            }
        }
    }
}
