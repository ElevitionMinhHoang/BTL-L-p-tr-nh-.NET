USE master;
GO

-- Xóa database nếu đã tồn tại để tạo mới hoàn toàn
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'LibraryManagement')
BEGIN
    ALTER DATABASE LibraryManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryManagement;
END
GO

CREATE DATABASE LibraryManagement;
GO
USE LibraryManagement;
GO

-- 1. Bảng TaiKhoan
CREATE TABLE TaiKhoan (
    MaTK        INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash NVARCHAR(255) NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    Role        NVARCHAR(20) NOT NULL, -- 'Admin' | 'ThuThu' | 'BanDoc'
    Email       NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    NgayTao     DATETIME DEFAULT GETDATE(),
    IsActive    BIT DEFAULT 1
);

-- 2. Bảng DanhMuc (dùng chung cho TheLoai/NXB/TacGia)
CREATE TABLE DanhMuc (
    MaDanhMuc   NVARCHAR(50) PRIMARY KEY,
    TenDanhMuc  NVARCHAR(100) NOT NULL,
    LoaiDanhMuc NVARCHAR(20) NOT NULL  -- 'TheLoai' | 'NXB' | 'TacGia'
);

-- 3. Bảng Sach
CREATE TABLE Sach (
    MaSach      NVARCHAR(50) PRIMARY KEY,
    TenSach     NVARCHAR(255) NOT NULL,
    MaDanhMuc   NVARCHAR(50) REFERENCES DanhMuc(MaDanhMuc),
    NamXB       INT,
    SoLuong     INT DEFAULT 0,
    TrangThai   NVARCHAR(20) DEFAULT N'CoSan'
);

-- 4. Bảng DocGia
CREATE TABLE DocGia (
    MaDocGia    NVARCHAR(50) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    SDT         NVARCHAR(15),
    Email       NVARCHAR(100),
    NgayCap     DATE DEFAULT GETDATE(),
    MaTK        INT REFERENCES TaiKhoan(MaTK)
);

-- 5. Bảng PhieuMuon
CREATE TABLE PhieuMuon (
    MaPhieu     NVARCHAR(50) PRIMARY KEY,
    MaDocGia    NVARCHAR(50) REFERENCES DocGia(MaDocGia),
    NgayMuon    DATE DEFAULT GETDATE(),
    HanTra      DATE NOT NULL,
    NgayTra     DATE NULL,
    TrangThai   NVARCHAR(20) DEFAULT N'DangMuon'
    -- 'DangMuon' | 'DaTra' | 'QuaHan' | 'ChoXuLy'
);

-- 6. Bảng ChiTietMuon
CREATE TABLE ChiTietMuon (
    MaChiTiet   INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu     NVARCHAR(50) REFERENCES PhieuMuon(MaPhieu),
    MaSach      NVARCHAR(50) REFERENCES Sach(MaSach),
    SoLuong     INT DEFAULT 1,
    PhiPhat     DECIMAL(10,2) DEFAULT 0
);

-- 7. Bảng MatSach (mất/hỏng)
CREATE TABLE MatSach (
    MaSuCo      INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu     NVARCHAR(50) REFERENCES PhieuMuon(MaPhieu),
    MaSach      NVARCHAR(50) REFERENCES Sach(MaSach),
    LoaiSuCo    NVARCHAR(20),  -- 'Mat' | 'HuHong'
    MucBoiThuong DECIMAL(10,2) DEFAULT 0,
    NgayGhiNhan DATE DEFAULT GETDATE()
);

-- 8. Bảng DatMuon (đặt mượn online)
CREATE TABLE DatMuon (
    MaDatMuon   NVARCHAR(50) PRIMARY KEY,
    MaDocGia    NVARCHAR(50) REFERENCES DocGia(MaDocGia),
    MaSach      NVARCHAR(50) REFERENCES Sach(MaSach),
    NgayDat     DATE DEFAULT GETDATE(),
    TrangThai   NVARCHAR(20) DEFAULT N'ChoXuLy'
    -- 'ChoXuLy' | 'DaDuyet' | 'TuChoi'
);
