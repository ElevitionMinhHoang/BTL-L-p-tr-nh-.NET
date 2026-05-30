// ===== LibraryManagement.BLL/DocGiaBLL.cs =====
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class DocGiaBLL
    {
        private readonly DocGiaRepository _repo;
        private readonly PhieuMuonRepository _phieuRepo;

        public DocGiaBLL()
        {
            _repo = new DocGiaRepository();
            _phieuRepo = new PhieuMuonRepository();
        }

        public IEnumerable<DocGia> GetAll() => _repo.GetAll();
        public DocGia GetById(string maDocGia) => _repo.GetById(maDocGia);

        public int GetSoDangMuon(string maDocGia)
        {
            return _phieuRepo.GetByDocGia(maDocGia)
                .Count(p => p.TrangThai == "DangMuon" || p.TrangThai == "QuaHan");
        }
    }
}
