using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class TaiKhoanRepository : IRepository<TaiKhoan>
    {
        public IEnumerable<TaiKhoan> GetAll()
        {
            using (var context = new LibraryContext())
            {
                return context.TaiKhoans.Where(t => t.IsActive).ToList();
            }
        }

        public TaiKhoan GetById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.TaiKhoans.Find(id);
            }
        }

        public int Add(TaiKhoan entity)
        {
            using (var context = new LibraryContext())
            {
                context.TaiKhoans.Add(entity);
                context.SaveChanges();
                return entity.MaTK;
            }
        }

        public bool Update(TaiKhoan entity)
        {
            using (var context = new LibraryContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                // Không cho phép update username và mật khẩu qua hàm generic này để bảo mật
                context.Entry(entity).Property(x => x.TenDangNhap).IsModified = false;
                context.Entry(entity).Property(x => x.MatKhauHash).IsModified = false;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE TaiKhoan SET IsActive=0 WHERE MaTK=@id";
                return db.Execute(sql, new { id }) > 0;
            }
        }

        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@tddn AND IsActive=1";
                return db.QueryFirstOrDefault<TaiKhoan>(sql, new { tddn = tenDangNhap });
            }
        }

        public bool CheckTenDangNhapExists(string tenDangNhap)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE TenDangNhap=@tddn";
                return db.ExecuteScalar<int>(sql, new { tddn = tenDangNhap }) > 0;
            }
        }

        public bool UpdatePassword(int maTK, string newHash)
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "UPDATE TaiKhoan SET MatKhauHash=@hash WHERE MaTK=@id";
                return db.Execute(sql, new { hash = newHash, id = maTK }) > 0;
            }
        }
        
        public int CountActiveAdmins()
        {
            using (IDbConnection db = ConnectionHelper.GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE Role='Admin' AND IsActive=1";
                return db.ExecuteScalar<int>(sql);
            }
        }
    }
}
