// ===== LibraryManagement.BLL/DatMuonBLL.cs =====
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.BLL
{
    public class DatMuonBLL
    {
        private readonly DatMuonRepository _repo;
        private readonly SachRepository _sachRepo;
        private readonly PhieuMuonBLL _phieuBLL;

        public DatMuonBLL()
        {
            _repo = new DatMuonRepository();
            _sachRepo = new SachRepository();
            _phieuBLL = new PhieuMuonBLL();
        }

        public string TaoDatMuon(string maDocGia, string maSach)
        {
            try
            {
                var sach = _sachRepo.GetById(maSach);
                if (sach == null) return "Sách không tồn tại.";

                var exists = _repo.GetAll()
                    .Any(d => d.MaDocGia == maDocGia && d.MaSach == maSach && d.TrangThai == "ChoXuLy");
                if (exists) return "Bạn đã đặt mượn cuốn sách này và đang chờ duyệt.";

                var datMuon = new DatMuon
                {
                    MaDatMuon = "DM" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    MaDocGia = maDocGia,
                    MaSach = maSach,
                    NgayDat = DateTime.Today,
                    TrangThai = "ChoXuLy"
                };

                _repo.Add(datMuon);
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public IEnumerable<DatMuonDTO> GetPending() => _repo.GetPending();

        public string DuyetDatMuon(string maDatMuon)
        {
            try
            {
                var dm = _repo.GetById(maDatMuon);
                if (dm == null) return "Yêu cầu đặt mượn không tồn tại.";
                if (dm.TrangThai != "ChoXuLy") return "Yêu cầu đã được xử lý trước đó.";

                var sach = _sachRepo.GetById(dm.MaSach);
                if (sach == null || sach.SoLuong <= 0) return "Sách hiện đã hết, không thể duyệt.";

                // Tạo phiếu mượn (hạn trả 14 ngày)
                string error = _phieuBLL.TaoPhieuMuon(dm.MaDocGia, new List<string> { dm.MaSach }, DateTime.Today.AddDays(14));
                if (error != null) return error;

                _repo.UpdateTrangThai(maDatMuon, "DaDuyet");
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string TuChoiDatMuon(string maDatMuon, string lyDo)
        {
            try
            {
                var dm = _repo.GetById(maDatMuon);
                if (dm == null) return "Yêu cầu đặt mượn không tồn tại.";

                _repo.UpdateTrangThai(maDatMuon, "TuChoi");
                // Có thể lưu lý do vào đâu đó nếu DB có cột, hiện tại chỉ update trạng thái
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
