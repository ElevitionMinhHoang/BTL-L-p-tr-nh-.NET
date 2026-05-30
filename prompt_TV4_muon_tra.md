Hãy đọc file (ghi rõ tên file) prompt_TV3_sach_danhmuc_docgia.md để làm giao diện phần chức năng của tôi
# PROMPT TV4 — QUẢN LÝ MƯỢN-TRẢ SÁCH (nghiệp vụ cốt lõi)
# Chạy: gemini "$(cat prompt_TV4_muon_tra.md)"

Bạn là senior .NET developer. Viết code hoàn chỉnh cho module Mượn-Trả sách.
KHÔNG viết "// TODO". Mỗi file bắt đầu bằng `// ===== [đường dẫn] =====`.

---
## PHẦN 1 — QUY TẮC GIAO DIỆN BẮT BUỘC (UI_DESIGN_SKILL)

.NET 4.7.2, Guna.UI2.WinForms đã cài (NuGet).

**BẢNG MÀU — chỉ dùng các màu này:**
- Nền app: #F0F4F8 | Card: #FFFFFF | Header dialog: #1E2A3A
- Primary button: #2E75B6 | Hover: #1F4E79
- Input nền: #F8FAFC | Input border: #E2E8F0 | Input focus: #2E75B6
- Text chính: #1A202C | Text phụ: #64748B
- Success: #22C55E | Danger: #EF4444 | Warning: #F59E0B
- DGV header: #1E2A3A chữ trắng | Row alt: #F8FAFC | Selected: #EBF4FF

**BADGE TRẠNG THÁI PHIẾU MƯỢN (dùng trong dgv CellFormatting):**
- DangMuon → text "Đang mượn", bg #EFF6FF, fg #1D4ED8
- DaTra → text "Đã trả", bg #F0FDF4, fg #15803D
- QuaHan → text "Quá hạn", bg #FEF2F2, fg #DC2626
- ChoXuLy → text "Chờ duyệt", bg #FFFBEB, fg #B45309
- DaHuy → text "Đã hủy", bg #F8FAFC, fg #64748B

**CONTROLS BẮT BUỘC:**
- Guna2Button (BorderRadius=8, Animated=true)
- Guna2TextBox (BorderRadius=8, FocusedBorderColor=#2E75B6)
- Guna2ComboBox (BorderRadius=8), Guna2DataGridView
- Font DUY NHẤT: Segoe UI
- KHÔNG GroupBox — dùng Panel + Label
- UIHelper.ShowToast() thay MessageBox thành công
- UIHelper.ConfirmDelete() cho xác nhận xóa/hủy

---
## PHẦN 2 — DATABASE SCHEMA

```sql
CREATE TABLE PhieuMuon (
    MaPhieu  NVARCHAR(50) PRIMARY KEY,
    MaDocGia NVARCHAR(50) REFERENCES DocGia(MaDocGia),
    NgayMuon DATE DEFAULT GETDATE(),
    HanTra   DATE NOT NULL,
    NgayTra  DATE NULL,
    TrangThai NVARCHAR(20) DEFAULT N'DangMuon'
    -- 'DangMuon' | 'DaTra' | 'QuaHan' | 'ChoXuLy' | 'DaHuy'
);
CREATE TABLE ChiTietMuon (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu   NVARCHAR(50) REFERENCES PhieuMuon(MaPhieu),
    MaSach    NVARCHAR(50) REFERENCES Sach(MaSach),
    SoLuong   INT DEFAULT 1,
    PhiPhat   DECIMAL(10,2) DEFAULT 0
);
CREATE TABLE MatSach (
    MaSuCo       INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu      NVARCHAR(50) REFERENCES PhieuMuon(MaPhieu),
    MaSach       NVARCHAR(50) REFERENCES Sach(MaSach),
    LoaiSuCo     NVARCHAR(20),  -- 'Mat' | 'HuHong'
    MucBoiThuong DECIMAL(10,2) DEFAULT 0,
    NgayGhiNhan  DATE DEFAULT GETDATE()
);
CREATE TABLE DatMuon (
    MaDatMuon NVARCHAR(50) PRIMARY KEY,
    MaDocGia  NVARCHAR(50) REFERENCES DocGia(MaDocGia),
    MaSach    NVARCHAR(50) REFERENCES Sach(MaSach),
    NgayDat   DATE DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'ChoXuLy'
    -- 'ChoXuLy' | 'DaDuyet' | 'TuChoi'
);
```

---
## PHẦN 3 — CODE HIỆN CÓ (gọi đúng class này)

```csharp
ConnectionHelper.GetConnection()    // SqlConnection
LibraryContext                       // EF DbContext (cần thêm DbSet mới)
IRepository<T>                       // interface đã có
UserSession.Current, IsAdmin, IsThuThu, IsBanDoc
UIHelper.ShowToast(form, msg, type)
UIHelper.ConfirmDelete(itemName)

// SachBLL đã có (TV3 viết):
SachBLL.UpdateSoLuong(maSach, delta)   // cộng/trừ tồn kho
SachBLL.GetAll()

// DocGiaBLL đã có (TV3 viết):
DocGiaBLL.GetSoDangMuon(maDocGia)
```

---
## PHẦN 4 — MODELS

### FILE 1: LibraryManagement.Models/PhieuMuon.cs (VIẾT LẠI)
```
[Table("PhieuMuon")]
- string   MaPhieu   [Key]
- string   MaDocGia  [Required]
- DateTime NgayMuon  = DateTime.Today
- DateTime HanTra    [Required]
- DateTime? NgayTra  (nullable)
- string   TrangThai = "DangMuon"
Navigation: DocGia DocGia (virtual), List<ChiTietMuon> ChiTietMuons
```

### FILE 2: LibraryManagement.Models/ChiTietMuon.cs (TẠO MỚI)
```
[Table("ChiTietMuon")]
- int     MaChiTiet   [Key, DatabaseGenerated(Auto)]
- string  MaPhieu     [Required]
- string  MaSach      [Required]
- int     SoLuong     = 1
- decimal PhiPhat     = 0
Navigation: PhieuMuon PhieuMuon (virtual), Sach Sach (virtual)
```

### FILE 3: LibraryManagement.Models/MatSachModel.cs (TẠO MỚI — tên class MatSachRecord tránh trùng)
```
[Table("MatSach")]
- int     MaSuCo       [Key, Auto]
- string  MaPhieu
- string  MaSach
- string  LoaiSuCo     -- 'Mat' | 'HuHong'
- decimal MucBoiThuong = 0
- DateTime NgayGhiNhan = DateTime.Today
```

### FILE 4: LibraryManagement.Models/DatMuon.cs (TẠO MỚI)
```
[Table("DatMuon")]
- string MaDatMuon [Key]
- string MaDocGia
- string MaSach
- DateTime NgayDat = DateTime.Today
- string TrangThai = "ChoXuLy"
Navigation: DocGia DocGia, Sach Sach
```

### FILE 5: DTOs/PhieuMuonDTO.cs (TẠO MỚI)
```
- string MaPhieu, MaDocGia, TenDocGia
- DateTime NgayMuon, HanTra
- DateTime? NgayTra
- string TrangThai, TrangThaiDisplay
- bool IsQuaHan → NgayTra == null && HanTra < DateTime.Today
- decimal TongPhiPhat
- List<ChiTietMuonDTO> ChiTiet
```

### FILE 6: DTOs/ChiTietMuonDTO.cs (TẠO MỚI)
```
- int MaChiTiet | string MaPhieu, MaSach, TenSach
- int SoLuong | decimal PhiPhat
```

### FILE 7: DTOs/DatMuonDTO.cs (TẠO MỚI)
```
- string MaDatMuon, MaDocGia, TenDocGia, MaSach, TenSach
- DateTime NgayDat | string TrangThai
```

---
## PHẦN 5 — DAL

### FILE 8: LibraryManagement.DAL/DatabaseContext.cs (VIẾT LẠI — thêm DbSet)
```
Thêm vào LibraryContext (giữ nguyên các DbSet cũ):
public DbSet<PhieuMuon>   PhieuMuons   { get; set; }
public DbSet<ChiTietMuon> ChiTietMuons { get; set; }
public DbSet<MatSachRecord> MatSachs   { get; set; }
public DbSet<DatMuon>     DatMuons     { get; set; }
```

### FILE 9: LibraryManagement.DAL/Repositories/PhieuMuonRepository.cs (VIẾT LẠI)
```
Implement IRepository<PhieuMuon> +

GetById(maPhieu): EF include DocGia + ChiTietMuons + Sach

GetAll(): Dapper JOIN để lấy cả TenDocGia:
"SELECT p.*, d.HoTen AS TenDocGia FROM PhieuMuon p
 JOIN DocGia d ON p.MaDocGia=d.MaDocGia ORDER BY p.NgayMuon DESC"

GetByDocGia(maDocGia): Dapper filter theo MaDocGia

GetByTrangThai(trangThai): Dapper filter

GetQuaHan(): Dapper:
"SELECT * FROM PhieuMuon WHERE TrangThai='DangMuon' AND HanTra < GETDATE()"

CreatePhieuMuon(PhieuMuon phieu, List<ChiTietMuon> chiTiet):
  TRANSACTION BẮBT BUỘC:
  1. INSERT PhieuMuon
  2. Với mỗi ChiTietMuon: INSERT ChiTietMuon
  3. UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach= @ma AND SoLuong > 0
     (kiểm tra rows affected = 1, nếu không → ROLLBACK, throw Exception)
  4. Nếu SoLuong sau trừ = 0: UPDATE Sach SET TrangThai='HetSach'
  Dùng SqlTransaction, COMMIT chỉ khi tất cả thành công

TraSach(maPhieu, ngayTra, List<(string maSach, decimal phiPhat)> chiTiet):
  TRANSACTION:
  1. UPDATE PhieuMuon SET TrangThai='DaTra', NgayTra= @ngayTra WHERE MaPhieu= @ma
  2. Với mỗi cuốn: UPDATE ChiTietMuon SET PhiPhat= @phi WHERE MaPhieu= @ma AND MaSach= @maSach
  3. UPDATE Sach SET SoLuong=SoLuong+1 WHERE MaSach= @ma
  4. UPDATE TrangThai Sach về 'CoSan' nếu đang 'HetSach'

HuyPhieu(maPhieu):
  TRANSACTION:
  1. Lấy danh sách ChiTietMuon của phiếu
  2. UPDATE PhieuMuon SET TrangThai='DaHuy'
  3. Cộng lại SoLuong từng cuốn

GiaHanPhieu(maPhieu, hanTraMoi): Dapper UPDATE HanTra
```

### FILE 10: LibraryManagement.DAL/Repositories/MatSachRepository.cs (VIẾT LẠI)
```
- int Add(MatSachRecord entity): Dapper INSERT, trả MaSuCo mới
- IEnumerable<MatSachRecord> GetByPhieu(string maPhieu)
- IEnumerable<MatSachRecord> GetAll(): JOIN PhieuMuon + Sach để lấy tên
```

### FILE 11: LibraryManagement.DAL/Repositories/DatMuonRepository.cs (VIẾT LẠI)
```
- int Add(DatMuon entity): EF
- IEnumerable<DatMuon> GetPending(): Dapper WHERE TrangThai='ChoXuLy' + JOIN Sach + DocGia
- IEnumerable<DatMuon> GetByDocGia(string maDocGia)
- bool UpdateTrangThai(string maDatMuon, string trangThai): Dapper
```

---
## PHẦN 6 — BLL

### FILE 12: LibraryManagement.BLL/PhieuMuonBLL.cs (VIẾT LẠI)
```
PhieuMuonRepository _repo + SachRepository _sachRepo + DocGiaRepository _dgRepo

IEnumerable<PhieuMuonDTO> GetAll()
IEnumerable<PhieuMuonDTO> GetByDocGia(string maDocGia)
IEnumerable<PhieuMuonDTO> GetQuaHan()

string TaoPhieuMuon(string maDocGia, List<string> danhSachMaSach, DateTime hanTra):
  Validate:
  - maDocGia tồn tại
  - danhSachMaSach không rỗng, tối đa 5 cuốn/lần
  - hanTra > ngày hôm nay
  - DocGia không đang nợ quá 3 cuốn chưa trả
  - Từng cuốn sách phải còn tồn kho > 0
  Tạo MaPhieu tự động: "PM" + DateTime.Now.ToString("yyyyMMddHHmmss")
  Gọi repo.CreatePhieuMuon() → bắt Exception nếu rollback
  Return null nếu OK, string lỗi nếu thất bại

decimal TinhPhiPhat(DateTime hanTra, DateTime ngayTra):
  Số ngày trễ = (ngayTra - hanTra).Days
  Nếu <= 0 → 0
  Nếu > 0 → ngayTre * 2000 (2.000đ/ngày, có thể cấu hình)

string TraSach(string maPhieu, DateTime ngayTra = default):
  ngayTra = ngayTra == default ? DateTime.Today : ngayTra
  Lấy phiếu, kiểm tra TrangThai == "DangMuon"
  Tính phiPhat từng cuốn: TinhPhiPhat(hanTra, ngayTra)
  Gọi repo.TraSach()

string HuyPhieu(string maPhieu):
  Kiểm tra TrangThai là "DangMuon" hoặc "ChoXuLy"
  Gọi repo.HuyPhieu()

string GiaHanPhieu(string maPhieu, DateTime hanTraMoi):
  hanTraMoi > hanTra hiện tại
  Gọi repo.GiaHanPhieu()

void CapNhatTrangThaiQuaHan():
  Dùng Dapper: UPDATE PhieuMuon SET TrangThai='QuaHan'
  WHERE TrangThai='DangMuon' AND HanTra < GETDATE()
  [Gọi method này khi mở form DanhSachMuon]
```

### FILE 13: LibraryManagement.BLL/MatSachBLL.cs (VIẾT LẠI)
```
string GhiNhanMatSach(string maPhieu, string maSach, string loaiSuCo, decimal mucBoiThuong):
  Validate: loaiSuCo phải là 'Mat' hoặc 'HuHong', mucBoiThuong >= 0
  Kiểm tra phiếu tồn tại và đang DangMuon
  INSERT MatSach
  Nếu loaiSuCo='Mat': UPDATE Sach SET SoLuong = SoLuong - 1 (không rollback)
  Return null nếu OK

IEnumerable<MatSachRecord> GetByPhieu(string maPhieu)
```

### FILE 14: LibraryManagement.BLL/DatMuonBLL.cs (VIẾT LẠI)
```
string TaoDatMuon(string maDocGia, string maSach):
  Kiểm tra sách tồn tại
  Kiểm tra DocGia chưa có đặt mượn cuốn này chưa duyệt
  MaDatMuon = "DM" + DateTime.Now.ToString("yyyyMMddHHmmss")
  Gọi repo.Add()

IEnumerable<DatMuonDTO> GetPending(): lấy danh sách chờ duyệt

string DuyetDatMuon(string maDatMuon):
  Lấy thông tin đặt mượn
  Kiểm tra sách còn tồn kho
  Gọi PhieuMuonBLL.TaoPhieuMuon(maDocGia, [maSach], hanTra=today+14)
  Nếu OK: UpdateTrangThai(maDatMuon, "DaDuyet")

string TuChoiDatMuon(string maDatMuon, string lyDo):
  UpdateTrangThai(maDatMuon, "TuChoi")
```

---
## PHẦN 7 — GUI

### FILE 15: frmMuonSach.cs + Designer
**Quyền:** ThuThu + Admin.

**Giao diện:**
```
Form: 900x640, FormBorderStyle.None hoặc Sizable
Card chia 2 vùng:

TRÁI (400px) — Thông tin phiếu:
  Section "Thông tin bạn đọc":
    [txtMaDocGia: nhập mã] [btnTimDocGia: 🔍]
    lblTenDocGia (hiện tên sau tìm)
    lblSoDangMuon (hiện "Đang mượn: X cuốn", vàng nếu > 0)
  Section "Danh sách sách mượn":
    [txtMaSach: nhập mã] [btnThemSach: + Thêm]
    lstSachMuon (ListBox hoặc DataGridView nhỏ): TenSach | [×]
    lblThongBaoSach (đỏ nếu sách hết)
  Section "Hạn trả":
    dateHanTra (DateTimePicker, min=tomorrow)
    lblSoNgay (tự tính: "14 ngày")

PHẢI (Fill) — Xác nhận:
  lblTongSach: "Số sách: X"
  Danh sách cuốn sách đã chọn (tên + tình trạng)
  [🔄 RESET] [✓ TẠO PHIẾU MƯỢN]
```

**Logic:**
```csharp
btnTimDocGia: DocGiaBLL.GetAll() filter → hiện tên + SoDangMuon
btnThemSach:
  Gọi SachBLL search → kiểm tra TrangThai != 'HetSach'
  Thêm vào list (tối đa 5)
[×] trên list: xóa sách khỏi list
btnTaoPhieu:
  PhieuMuonBLL.TaoPhieuMuon(maDocGia, listMaSach, hanTra)
  Lỗi → UIHelper.ShowToast Error
  OK → UIHelper.ShowToast Success → hỏi có in phiếu không → Reset form
```

### FILE 16: frmTraSach.cs + Designer
**Quyền:** ThuThu + Admin.

**Giao diện:**
```
Card:
  Section "Tìm phiếu mượn":
    [txtMaPhieu] [btnTim: 🔍]
    Hoặc [txtMaDocGia] [btnTimDocGia] → hiện danh sách phiếu đang mượn

  Section "Thông tin phiếu" (hiện sau khi tìm được):
    lblTenDocGia, lblNgayMuon, lblHanTra
    lblTinhTrang: "⚠ QUÁ HẠN X NGÀY" (đỏ) hoặc "Còn X ngày" (xanh)
    DataGridView: TenSach | SoLuong | PhiPhat (tự tính)
    lblTongPhiPhat: "Tổng tiền phạt: X.XXX đ" (đỏ, bold)

  [🚫 HỦY PHIẾU] [✓ XÁC NHẬN TRẢ]
```

**Logic:**
```csharp
btnTim: PhieuMuonBLL.GetAll() filter theo MaPhieu/MaDocGia → hiện thông tin
Khi hiện thông tin: tự tính PhiPhat từng cuốn = TinhPhiPhat(hanTra, today)
btnXacNhanTra:
  PhieuMuonBLL.TraSach(maPhieu, DateTime.Today)
  OK → ShowToast + hiện tổng tiền phạt cần thu + Reset
btnHuyPhieu: ConfirmDelete → PhieuMuonBLL.HuyPhieu()
```

### FILE 17: frmDanhSachMuon.cs + Designer
**Quyền:** ThuThu + Admin (xem và duyệt), BanDoc (chỉ xem của mình).

**Giao diện:**
```
TabControl với 3 tab:
  Tab 1 "📋 Tất cả phiếu":
    Toolbar: [txtTimKiem] [cboTrangThai: Tất cả/Đang mượn/Đã trả/Quá hạn/Chờ duyệt] [btnLamMoi]
    Guna2DataGridView: MaPhieu(100px), TenDocGia(160px), NgayMuon(100px),
      HanTra(100px), TrangThai(110px, badge màu), TongPhiPhat(110px), [Xem][Hành động]
    [Hành động] context theo trạng thái:
      DangMuon → [Trả] [Gia hạn] [Ghi mất]
      ChoXuLy  → [Duyệt] [Từ chối]

  Tab 2 "⏰ Quá hạn" (lọc sẵn TrangThai=QuaHan):
    Cùng DGV, nổi bật màu đỏ

  Tab 3 "🕐 Chờ duyệt" (lấy từ DatMuonBLL.GetPending()):
    Guna2DataGridView: MaDatMuon, TenDocGia, TenSach, NgayDat, [Duyệt][Từ chối]
```

**Logic:**
```csharp
Load: PhieuMuonBLL.CapNhatTrangThaiQuaHan() trước → LoadData()
btnLamMoi / filter thay đổi → LoadData()
[Gia hạn]: InputBox nhập ngày mới → PhieuMuonBLL.GiaHanPhieu()
[Ghi mất]: mở frmMatSach(maPhieu, maSach).ShowDialog()
[Duyệt]: DatMuonBLL.DuyetDatMuon()
[Từ chối]: DatMuonBLL.TuChoiDatMuon()
```

### FILE 18: frmMatSach.cs + Designer
**Quyền:** ThuThu + Admin.
```
FormBorderStyle.None, Size=440x320
Header "GHI NHẬN SỰ CỐ SÁCH"
Body:
  lblTenSach (hiện tên sách)
  Loại sự cố: RadioButton "Mất sách" | "Hư hỏng"
  Field "Mức bồi thường (VNĐ)":
    Guna2TextBox, chỉ nhập số
    Gợi ý: Mất → 200.000đ, Hư hỏng → 50.000đ
  lblGhiChu: "Bồi thường sẽ được trừ vào tài khoản độc giả"
Footer: [Hủy] [✓ Xác nhận]

Logic: MatSachBLL.GhiNhanMatSach(maPhieu, maSach, loai, mucBoiThuong)
```

---
## PHẦN 8 — THỨ TỰ VIẾT

FILE 1→7 (Models/DTOs) → FILE 8 (DatabaseContext) → FILE 9→11 (DAL) → FILE 12→14 (BLL) → FILE 15→18 (GUI)
