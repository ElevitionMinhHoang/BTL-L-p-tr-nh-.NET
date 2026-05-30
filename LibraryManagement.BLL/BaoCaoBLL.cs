
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models.DTOs;

namespace LibraryManagement.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoRepository _repo = new BaoCaoRepository();

        public KpiDTO GetKpi(int nam, int? thang)
        {
            ValidatePeriod(nam, thang);
            return _repo.GetKpi(nam, thang);
        }

        public IEnumerable<SachMuonNhieuDTO> GetTopSach(int nam, int? thang, int top = 10)
        {
            ValidatePeriod(nam, thang);
            return _repo.GetTopSachMuon(nam, thang, top);
        }

        public IEnumerable<ThongKeTheLoaiDTO> GetThongKeTheLoai(int nam, int? thang)
        {
            ValidatePeriod(nam, thang);
            return _repo.GetThongKeTheLoai(nam, thang);
        }

        public IEnumerable<SachTonDTO> GetSachTon(int nam)
        {
            ValidatePeriod(nam, null);
            return _repo.GetSachTon(nam);
        }

        public IEnumerable<DoanhThuPhatDTO> GetDoanhThuPhat(int nam, int? thang)
        {
            ValidatePeriod(nam, thang);
            return _repo.GetDoanhThuPhat(nam, thang);
        }

        public string XuatExcel(int nam, int? thang, string exportPath)
        {
            try
            {
                ValidatePeriod(nam, thang);

                if (string.IsNullOrWhiteSpace(exportPath))
                {
                    return "Duong dan xuat Excel khong hop le.";
                }

                string directory = Path.GetDirectoryName(exportPath);
                if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var workbook = new XLWorkbook())
                {
                    AddTopSachSheet(workbook, GetTopSach(nam, thang, 50).ToList());
                    AddTheLoaiSheet(workbook, GetThongKeTheLoai(nam, thang).ToList());
                    AddDoanhThuSheet(workbook, GetDoanhThuPhat(nam, thang).ToList());
                    workbook.SaveAs(exportPath);
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void AddTopSachSheet(XLWorkbook workbook, IList<SachMuonNhieuDTO> data)
        {
            var ws = workbook.Worksheets.Add("Top Sach");
            WriteHeader(ws, "Ma sach", "Ten sach", "The loai", "Luot muon", "So luong hien co");

            for (int i = 0; i < data.Count; i++)
            {
                int row = i + 2;
                ws.Cell(row, 1).Value = data[i].MaSach;
                ws.Cell(row, 2).Value = data[i].TenSach;
                ws.Cell(row, 3).Value = data[i].TheLoai;
                ws.Cell(row, 4).Value = data[i].LuotMuon;
                ws.Cell(row, 5).Value = data[i].SoLuongHienCo;
            }

            FormatWorksheet(ws, 5);
        }

        private static void AddTheLoaiSheet(XLWorkbook workbook, IList<ThongKeTheLoaiDTO> data)
        {
            var ws = workbook.Worksheets.Add("Theo The Loai");
            WriteHeader(ws, "The loai", "Luot muon", "Phan tram");