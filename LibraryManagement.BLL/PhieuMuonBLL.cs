// ===== LibraryManagement.BLL/PhieuMuonBLL.cs =====
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.BLL
{
    public class PhieuMuonBLL
    {
        private readonly PhieuMuonRepository _repo;
        private readonly SachRepository _sachRepo;
        private readonly DocGiaRepository _dgRepo;

        public PhieuMuonBLL()
        {
            _repo = new PhieuMuonRepository();
            _sachRepo = new SachRepository();
            _dgRepo = new DocGiaRepository();
        }

        public IEnumerable<PhieuMuonDTO> GetAll() => _repo.GetAllDTO();
        public IEnumerable<PhieuMuonDTO> GetByDocGia(string maDocGia) => _repo.GetByDocGia(maDocGia);
        public IEnumerable<PhieuMuonDTO> GetQuaHan() => _repo.GetQuaHan();
        public IEnumerable<PhieuMuonDTO> GetByTrangThai(string trangThai) => _repo.GetByTrangThai(trangThai);

        public string TaoPhieuMuon(string maDocGia, List<string> danhSachMaSach, DateTime hanTra)
        {
            try
            {
                // Validate
                var dg = _dgRepo.GetById(maDocGia);
                if (dg == null) return "Độc giả không tồn tại.";

                if (danhSachMaSach == null || danhSachMaSach.Count == 0)
                    return "Danh sách sách mượn không được để trống.";

                if (danhSachMaSach.Count > 5)
                    return "Mỗi lần chỉ được mượn tối đa 5 cuốn.";

                if (hanTra <= DateTime.Today)
                    return "Hạn trả phải lớn hơn ngày mượn.";

                // Kiểm tra số lượng đang mượn
                int soDangMuon = _repo.GetByDocGia(maDocGia)
                    .Count(p => p.TrangThai == "DangMuon" || p.TrangThai == "QuaHan");
                
                if (soDangMuon + danhSachMaSach.Count > 5)
                    return $"Độc giả đang mượn {soDangMuon} cuốn. Tổng số sách mượn không được quá 5.";

                List<ChiTietMuon> chiTiets = new List<ChiTietMuon>();
                string maPhieu = "PM" + DateTime.Now.ToString("yyyyMMddHHmmss");

                foreach (var maSach in danhSachMaSach)
                {
                    var sach = _sachRepo.GetById(maSach);
                    if (sach == null) return $"Sách {maSach} không tồn tại.";
                    if (sach.SoLuong <= 0) return $"Sách '{sach.TenSach}' đã hết.";

                    chiTiets.Add(new ChiTietMuon
                    {
                        MaPhieu = maPhieu,
                        MaSach = maSach,
                        SoLuong = 1,
                        PhiPhat = 0
                    });
                }

                var phieu = new PhieuMuon
                {
                    MaPhieu = maPhieu,
                    MaDocGia = maDocGia,
                    NgayMuon = DateTime.Today,
                    HanTra = hanTra,
                    TrangThai = "DangMuon"
                };

                _repo.CreatePhieuMuon(phieu, chiTiets);
                return null; // OK
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public decimal TinhPhiPhat(DateTime hanTra, DateTime ngayTra)
        {
            int soNgayTre = (ngayTra.Date - hanTra.Date).Days;
            if (soNgayTre <= 0) return 0;
            return soNgayTre * 2000; // 2.000đ/ngày
        }

        public string TraSach(string maPhieu, DateTime ngayTra = default)
        {
            try
            {
                if (ngayTra == default) ngayTra = DateTime.Today;

                var phieu = _repo.GetById(maPhieu);
                if (phieu == null) return "Phiếu mượn không tồn tại.";
                if (phieu.TrangThai != "DangMuon" && phieu.TrangThai != "QuaHan")
                    return "Phiếu mượn này không ở trạng thái có thể trả.";

                var chiTietPhat = new List<(string maSach, decimal phiPhat)>();
                foreach (var ct in phieu.ChiTietMuons)
                {
                    decimal phi = TinhPhiPhat(phieu.HanTra, ngayTra);
                    chiTietPhat.Add((ct.MaSach, phi));
                }

                _repo.TraSach(maPhieu, ngayTra, chiTietPhat);
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string HuyPhieu(string maPhieu)
        {
            try
            {
                var phieu = _repo.GetById(maPhieu);
                if (phieu == null) return "Phiếu mượn không tồn tại.";
                if (phieu.TrangThai != "DangMuon" && phieu.TrangThai != "ChoXuLy")
                    return "Chỉ có thể hủy phiếu đang mượn hoặc chờ duyệt.";

                _repo.HuyPhieu(maPhieu);
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string GiaHanPhieu(string maPhieu, DateTime hanTraMoi)
        {
            try
            {
                var phieu = _repo.GetById(maPhieu);
                if (phieu == null) return "Phiếu mượn không tồn tại.";
                if (hanTraMoi <= phieu.HanTra) return "Hạn trả mới phải lớn hơn hạn trả cũ.";

                _repo.GiaHanPhieu(maPhieu, hanTraMoi);
                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public void CapNhatTrangThaiQuaHan()
        {
            using (var db = DAL.ConnectionHelper.GetConnection())
            {
                db.Open();
                string sql = "UPDATE PhieuMuon SET TrangThai = 'QuaHan' WHERE TrangThai = 'DangMuon' AND HanTra < GETDATE()";
                Dapper.SqlMapper.Execute(db, sql);
            }
        }
    }
}
