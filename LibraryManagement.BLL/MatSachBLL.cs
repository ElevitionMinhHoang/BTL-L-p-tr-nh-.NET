// ===== LibraryManagement.BLL/MatSachBLL.cs =====
using System;
using System.Collections.Generic;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class MatSachBLL
    {
        private readonly MatSachRepository _repo;
        private readonly PhieuMuonRepository _phieuRepo;
        private readonly SachRepository _sachRepo;

        public MatSachBLL()
        {
            _repo = new MatSachRepository();
            _phieuRepo = new PhieuMuonRepository();
            _sachRepo = new SachRepository();
        }

        public string GhiNhanMatSach(string maPhieu, string maSach, string loaiSuCo, decimal mucBoiThuong)
        {
            try
            {
                if (loaiSuCo != "Mat" && loaiSuCo != "HuHong")
                    return "Loại sự cố không hợp lệ.";

                if (mucBoiThuong < 0)
                    return "Mức bồi thường không được âm.";

                var phieu = _phieuRepo.GetById(maPhieu);
                if (phieu == null) return "Phiếu mượn không tồn tại.";
                if (phieu.TrangThai != "DangMuon" && phieu.TrangThai != "QuaHan")
                    return "Phiếu mượn không ở trạng thái đang mượn.";

                var record = new MatSachRecord
                {
                    MaPhieu = maPhieu,
                    MaSach = maSach,
                    LoaiSuCo = loaiSuCo,
                    MucBoiThuong = mucBoiThuong,
                    NgayGhiNhan = DateTime.Today
                };

                _repo.Add(record);

                if (loaiSuCo == "Mat")
                {
                    // Theo prompt: UPDATE Sach SET SoLuong = SoLuong - 1
                    // Lưu ý: Sách đã được trừ khi mượn. Nếu trừ tiếp có thể là để đánh dấu mất hẳn khỏi tổng số.
                    var sach = _sachRepo.GetById(maSach);
                    if (sach != null)
                    {
                        // Ở đây ta chỉ cập nhật database trực tiếp qua Dapper cho nhanh theo yêu cầu
                        using (var db = DAL.ConnectionHelper.GetConnection())
                        {
                            string sql = "UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach = @maSach AND SoLuong > 0";
                            Dapper.SqlMapper.Execute(db, sql, new { maSach });
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public IEnumerable<MatSachRecord> GetByPhieu(string maPhieu) => _repo.GetByPhieu(maPhieu);
    }
}
