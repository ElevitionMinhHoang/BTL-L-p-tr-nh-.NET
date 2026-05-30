// ===== LibraryManagement.GUI/PrintingService.cs =====
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LibraryManagement.Models;

namespace LibraryManagement.GUI
{
    public static class PrintingService
    {
        public static void InPhieuMuon(string maPhieu)
        {
            try
            {
                var repo = new DAL.Repositories.PhieuMuonRepository();
                var phieu = repo.GetById(maPhieu);
                if (phieu == null) return;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("========================================");
                sb.AppendLine("          PHIẾU MƯỢN SÁCH               ");
                sb.AppendLine("========================================");
                sb.AppendLine($"Mã phiếu: {phieu.MaPhieu}");
                sb.AppendLine($"Độc giả:  {phieu.DocGia?.HoTen}");
                sb.AppendLine($"Ngày mượn: {phieu.NgayMuon:dd/MM/yyyy}");
                sb.AppendLine($"Hạn trả:   {phieu.HanTra:dd/MM/yyyy}");
                sb.AppendLine("----------------------------------------");
                sb.AppendLine("Danh sách sách:");
                foreach (var ct in phieu.ChiTietMuons)
                {
                    sb.AppendLine($"- {ct.Sach?.TenSach}");
                }
                sb.AppendLine("========================================");
                sb.AppendLine("      Vui lòng trả sách đúng hạn!       ");

                // Lưu ra file text tạm và mở lên
                string filePath = Path.Combine(Path.GetTempPath(), $"PhieuMuon_{maPhieu}.txt");
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in phiếu: " + ex.Message);
            }
        }

        public static void InHoaDonPhat(string maPhieu, decimal tongTien)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("========================================");
                sb.AppendLine("          HÓA ĐƠN PHÍ PHẠT              ");
                sb.AppendLine("========================================");
                sb.AppendLine($"Mã phiếu: {maPhieu}");
                sb.AppendLine($"Ngày thu: {DateTime.Now:dd/MM/yyyy}");
                sb.AppendLine($"Số tiền:  {tongTien:N0} VNĐ");
                sb.AppendLine("----------------------------------------");
                sb.AppendLine("Lý do: Trả sách quá hạn");
                sb.AppendLine("========================================");

                string filePath = Path.Combine(Path.GetTempPath(), $"HoaDonPhat_{maPhieu}.txt");
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message);
            }
        }
    }
}
