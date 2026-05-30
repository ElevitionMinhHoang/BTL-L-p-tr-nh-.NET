// ===== LibraryManagement.DAL/Repositories/SachRepository.cs =====
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class SachRepository : IRepository<Sach>
    {
        private readonly LibraryContext _context;

        public SachRepository()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Sach> GetAll()
        {
            return _context.Sachs.ToList();
        }

        public Sach GetById(int id)
        {
            throw new System.NotSupportedException("Sach uses string ID.");
        }

        public Sach GetById(string maSach)
        {
            return _context.Sachs.Find(maSach);
        }

        public int Add(Sach entity)
        {
            _context.Sachs.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(Sach entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new System.NotSupportedException("Sach uses string ID.");
        }
    }
}
