// ===== LibraryManagement.DAL/Repositories/DocGiaRepository.cs =====
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class DocGiaRepository : IRepository<DocGia>
    {
        private readonly LibraryContext _context;

        public DocGiaRepository()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<DocGia> GetAll()
        {
            return _context.DocGias.ToList();
        }

        public DocGia GetById(int id)
        {
            throw new System.NotSupportedException("DocGia uses string ID.");
        }

        public DocGia GetById(string maDocGia)
        {
            return _context.DocGias.Find(maDocGia);
        }

        public int Add(DocGia entity)
        {
            _context.DocGias.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(DocGia entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new System.NotSupportedException("DocGia uses string ID.");
        }
    }
}
