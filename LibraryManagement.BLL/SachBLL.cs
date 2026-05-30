// ===== LibraryManagement.BLL/SachBLL.cs =====
using System.Collections.Generic;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class SachBLL
    {
        private readonly SachRepository _repo;

        public SachBLL()
        {
            _repo = new SachRepository();
        }

        public IEnumerable<Sach> GetAll() => _repo.GetAll();
        public Sach GetById(string maSach) => _repo.GetById(maSach);
    }
}
