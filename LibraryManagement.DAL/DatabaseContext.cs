// ===== LibraryManagement.DAL/DatabaseContext.cs =====
using System.Data.Entity;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryDB")
        {
            Database.SetInitializer<LibraryContext>(null);
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<PhieuMuon> PhieuMuons { get; set; }
        public DbSet<ChiTietMuon> ChiTietMuons { get; set; }
        public DbSet<MatSachRecord> MatSachs { get; set; }
        public DbSet<DatMuon> DatMuons { get; set; }
    }
}
