using Dapper;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryManagement.DAL.Repositories
{
    public class DanhMucRepository
    {
        public IEnumerable<DanhMuc> GetAll()
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                return db.Query<DanhMuc>("SELECT * FROM DanhMuc").ToList();
            }
        }

        public IEnumerable<DanhMuc> GetByLoai(string loai)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                return db.Query<DanhMuc>("SELECT * FROM DanhMuc WHERE LoaiDanhMuc = @loai", new { loai }).ToList();
            }
        }

        public DanhMuc GetById(string id)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                return db.QueryFirstOrDefault<DanhMuc>("SELECT * FROM DanhMuc WHERE MaDanhMuc = @id", new { id });
            }
        }

        public bool Add(DanhMuc entity)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc, LoaiDanhMuc) VALUES (@MaDanhMuc, @TenDanhMuc, @LoaiDanhMuc)";
                return db.Execute(sql, entity) > 0;
            }
        }

        public bool Update(DanhMuc entity)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE DanhMuc SET TenDanhMuc = @TenDanhMuc, LoaiDanhMuc = @LoaiDanhMuc WHERE MaDanhMuc = @MaDanhMuc";
                return db.Execute(sql, entity) > 0;
            }
        }

        public bool Delete(string id)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "DELETE FROM DanhMuc WHERE MaDanhMuc = @id";
                return db.Execute(sql, new { id }) > 0;
            }
        }
    }
}
