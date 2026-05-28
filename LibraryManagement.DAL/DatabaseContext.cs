using System.Data.Entity;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryDB")
        {
            // Tắt khởi tạo database tự động nếu đã có sẵn
            Database.SetInitializer<LibraryContext>(null);
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        
        // Placeholder cho các DbSet khác
        // public DbSet<Sach> Sachs { get; set; }
        // public DbSet<DocGia> DocGias { get; set; }
        // public DbSet<PhieuMuon> PhieuMuons { get; set; }
    }
}
