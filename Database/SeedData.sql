-- ============================================================
-- 1. BẢNG TaiKhoan 
-- ============================================================
INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhauHash, Salt, Role) VALUES
('TK001', 'admin',       '$2a$11$placeholder_admin_hash_here',     'salt_admin',     'Admin'),
('TK002', 'thuthu1',     '$2a$11$placeholder_tt1_hash_here',       'salt_tt1',       'ThuThu'),
('TK003', 'thuthu2',     '$2a$11$placeholder_tt2_hash_here',       'salt_tt2',       'ThuThu'),
('TK004', 'docgia001',   '$2a$11$placeholder_dg001_hash_here',     'salt_dg001',     'DocGia'),
('TK005', 'docgia002',   '$2a$11$placeholder_dg002_hash_here',     'salt_dg002',     'DocGia'),
('TK006', 'docgia003',   '$2a$11$placeholder_dg003_hash_here',     'salt_dg003',     'DocGia'),
('TK007', 'docgia004',   '$2a$11$placeholder_dg004_hash_here',     'salt_dg004',     'DocGia'),
('TK008', 'docgia005',   '$2a$11$placeholder_dg005_hash_here',     'salt_dg005',     'DocGia'),
('TK009', 'docgia006',   '$2a$11$placeholder_dg006_hash_here',     'salt_dg006',     'DocGia'),
('TK010', 'docgia007',   '$2a$11$placeholder_dg007_hash_here',     'salt_dg007',     'DocGia'),
('TK011', 'docgia008',   '$2a$11$placeholder_dg008_hash_here',     'salt_dg008',     'DocGia'),
('TK012', 'docgia009',   '$2a$11$placeholder_dg009_hash_here',     'salt_dg009',     'DocGia'),
('TK013', 'docgia010',   '$2a$11$placeholder_dg010_hash_here',     'salt_dg010',     'DocGia'),
('TK014', 'thuthu3',     '$2a$11$placeholder_tt3_hash_here',       'salt_tt3',       'ThuThu'),
('TK015', 'manager',     '$2a$11$placeholder_manager_hash_here',   'salt_manager',   'Admin');
GO

-- ============================================================
-- 2. BẢNG DanhMuc
-- ============================================================
INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc, LoaiDanhMuc) VALUES
-- Thể loại
('TL001', N'Công nghệ thông tin', 'TheLoai'),
('TL002', N'Văn học', 'TheLoai'),
('TL003', N'Kinh tế', 'TheLoai'),
('TL004', N'Khoa học tự nhiên', 'TheLoai'),
('TL005', N'Lịch sử – Địa lý', 'TheLoai'),
('TL006', N'Tâm lý – Kỹ năng', 'TheLoai'),
('TL007', N'Ngoại ngữ', 'TheLoai'),
('TL008', N'Thiếu nhi', 'TheLoai'),
('TL009', N'Triết học', 'TheLoai'),

-- NXB
('NXB01', N'NXB Trẻ', 'NXB'),
('NXB02', N'NXB Kim Đồng', 'NXB'),
('NXB03', N'NXB Giáo dục Việt Nam', 'NXB'),
('NXB04', N'NXB Tổng hợp TP.HCM', 'NXB'),
('NXB05', N'NXB Lao Động', 'NXB'),

-- Tác giả
('TA001', N'Robert C. Martin', 'TacGia'),
('TA002', N'Nguyễn Nhật Ánh', 'TacGia'),
('TA003', N'Martin Fowler', 'TacGia'),
('TA004', N'Dale Carnegie', 'TacGia'),
('TA005', N'Stephen Covey', 'TacGia'),
('TA006', N'Nam Cao', 'TacGia'),
('TA007', N'Andrew Hunt', 'TacGia'),
('TA008', N'Eric Evans', 'TacGia');
GO

-- ============================================================
-- 3. BẢNG Sach 
-- ============================================================
INSERT INTO Sach (MaSach, TenSach, MaDanhMuc, NamXB, SoLuong, TrangThai) VALUES
('S001', N'Clean Code', 'TL001', 2008, 5, N'CoSan'),
('S002', N'The Pragmatic Programmer', 'TL001', 2019, 4, N'CoSan'),
('S003', N'Design Patterns', 'TL001', 1994, 3, N'CoSan'),
('S004', N'Domain Driven Design', 'TL001', 2003, 2, N'CoSan'),
('S005', N'Lập trình C# nâng cao', 'TL001', 2022, 6, N'CoSan'),
('S006', N'ASP.NET Core MVC', 'TL001', 2023, 4, N'CoSan'),
('S007', N'Cơ sở dữ liệu thực hành', 'TL001', 2021, 5, N'CoSan'),
('S008', N'Tôi thấy hoa vàng trên cỏ xanh', 'TL002', 2010, 8, N'CoSan'),
('S009', N'Cho tôi xin một vé đi tuổi thơ', 'TL002', 2008, 7, N'CoSan'),
('S010', N'Chí Phèo', 'TL002', 2015, 4, N'CoSan'),
('S011', N'Đắc nhân tâm', 'TL006', 2016, 10, N'CoSan'),
('S012', N'7 Thói quen hiệu quả', 'TL006', 2017, 6, N'CoSan'),
('S013', N'Tư duy nhanh và chậm', 'TL006', 2018, 5, N'CoSan'),
('S014', N'Kinh tế học vi mô', 'TL003', 2020, 4, N'CoSan'),
('S015', N'Kinh tế học vĩ mô', 'TL003', 2020, 4, N'CoSan'),
('S016', N'Lịch sử Việt Nam', 'TL005', 2019, 3, N'CoSan'),
('S017', N'Vật lý đại cương', 'TL004', 2018, 5, N'CoSan'),
('S018', N'Toán cao cấp', 'TL004', 2021, 5, N'CoSan'),
('S019', N'English Grammar in Use', 'TL007', 2019, 6, N'CoSan'),
('S020', N'Refactoring', 'TL001', 2018, 2, N'HetHang');
GO

-- ============================================================
-- 4. BẢNG DocGia 
-- ============================================================
INSERT INTO DocGia (MaDocGia, HoTen, SDT, Email, NgayCap, MaTK) VALUES
('DG001', N'Nguyễn Văn An', '0901111111', 'an@gmail.com', '2024-01-10', 'TK004'),
('DG002', N'Trần Thị Bình', '0902222222', 'binh@gmail.com', '2024-01-15', 'TK005'),
('DG003', N'Lê Minh Châu', '0903333333', 'chau@gmail.com', '2024-02-01', 'TK006'),
('DG004', N'Phạm Thị Dung', '0904444444', 'dung@gmail.com', '2024-02-14', 'TK007'),
('DG005', N'Hoàng Văn Em', '0905555555', 'em@gmail.com', '2024-03-05', 'TK008'),
('DG006', N'Ngô Thị Phương', '0906666666', 'phuong@gmail.com', '2024-03-20', 'TK009'),
('DG007', N'Vũ Đức Giang', '0907777777', 'giang@gmail.com', '2024-04-01', 'TK010'),
('DG008', N'Đinh Thị Hương', '0908888888', 'huong@gmail.com', '2024-04-10', 'TK011'),
('DG009', N'Bùi Quang Huy', '0909999999', 'huy@gmail.com', '2024-05-01', 'TK012'),
('DG010', N'Đặng Minh Khánh', '0910101010', 'khanh@gmail.com', '2024-05-15', 'TK013'),
('DG011', N'Lưu Hải Nam', '0911111111', 'nam@gmail.com', '2024-06-01', NULL),
('DG012', N'Tạ Thu Trang', '0912222222', 'trang@gmail.com', '2024-06-10', NULL),
('DG013', N'Nguyễn Quốc Việt', '0913333333', 'viet@gmail.com', '2024-06-15', NULL),
('DG014', N'Phan Gia Bảo', '0914444444', 'bao@gmail.com', '2024-06-20', NULL),
('DG015', N'Đỗ Khánh Linh', '0915555555', 'linh@gmail.com', '2024-07-01', NULL);
GO

-- ============================================================
-- 5. BẢNG PhieuMuon 
-- ============================================================
INSERT INTO PhieuMuon (MaPhieu, MaDocGia, NgayMuon, HanTra, NgayTra, TrangThai) VALUES
('PM001', 'DG001', '2024-02-01', '2024-02-15', '2024-02-13', N'DaTra'),
('PM002', 'DG002', '2024-02-10', '2024-02-24', '2024-02-23', N'DaTra'),
('PM003', 'DG003', '2024-03-01', '2024-03-15', '2024-03-14', N'DaTra'),
('PM004', 'DG004', '2025-05-01', '2025-05-20', NULL, N'DangMuon'),
('PM005', 'DG005', '2025-05-10', '2025-05-25', NULL, N'DangMuon'),
('PM006', 'DG006', '2025-05-15', '2025-05-29', NULL, N'DangMuon'),
('PM007', 'DG007', '2025-03-01', '2025-03-15', NULL, N'QuaHan'),
('PM008', 'DG008', '2025-03-10', '2025-03-24', NULL, N'QuaHan'),
('PM009', 'DG009', '2025-04-01', '2025-04-15', NULL, N'ChoXuLy'),
('PM010', 'DG010', '2025-05-20', '2025-06-03', NULL, N'DangMuon'),
('PM011', 'DG011', '2025-04-10', '2025-04-24', '2025-04-22', N'DaTra'),
('PM012', 'DG012', '2025-04-15', '2025-04-29', '2025-04-30', N'DaTra'),
('PM013', 'DG013', '2025-05-05', '2025-05-19', NULL, N'DangMuon'),
('PM014', 'DG014', '2025-03-05', '2025-03-20', NULL, N'QuaHan'),
('PM015', 'DG015', '2025-05-18', '2025-06-01', NULL, N'DangMuon');
GO

-- ============================================================
-- 6. BẢNG ChiTietMuon
-- ============================================================
INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong, PhiPhat) VALUES
('PM001', 'S001', 1, 0),
('PM001', 'S008', 1, 0),
('PM002', 'S011', 1, 0),
('PM003', 'S005', 1, 0),
('PM003', 'S019', 1, 0),
('PM004', 'S002', 1, 0),
('PM005', 'S009', 1, 0),
('PM005', 'S012', 1, 0),
('PM006', 'S006', 1, 0),
('PM007', 'S003', 1, 200000),
('PM008', 'S013', 1, 150000),
('PM008', 'S014', 1, 150000),
('PM009', 'S004', 1, 0),
('PM010', 'S007', 1, 0),
('PM010', 'S015', 1, 0),
('PM011', 'S016', 1, 0),
('PM012', 'S017', 1, 5000),
('PM013', 'S018', 1, 0),
('PM014', 'S020', 1, 300000),
('PM015', 'S010', 1, 0);
GO

-- ============================================================
-- 7. BẢNG MatSach
-- ============================================================
INSERT INTO MatSach (MaPhieu, MaSach, LoaiSuCo, MucBoiThuong, NgayGhiNhan) VALUES
('PM009', 'S004', N'Mat', 350000, '2025-04-20'),
('PM007', 'S003', N'HuHong', 120000, '2025-04-01'),
('PM014', 'S020', N'Mat', 450000, '2025-04-10');
GO

-- ============================================================
-- 8. BẢNG DatMuon (15 bản ghi)
-- ============================================================
INSERT INTO DatMuon (MaDatMuon, MaDocGia, MaSach, NgayDat, TrangThai) VALUES
('DM001', 'DG001', 'S020', '2025-05-18', N'ChoXuLy'),
('DM002', 'DG003', 'S018', '2025-05-19', N'ChoXuLy'),
('DM003', 'DG004', 'S010', '2025-05-20', N'DaDuyet'),
('DM004', 'DG005', 'S001', '2025-05-21', N'DaDuyet'),
('DM005', 'DG006', 'S011', '2025-05-22', N'TuChoi'),
('DM006', 'DG002', 'S003', '2025-05-23', N'ChoXuLy'),
('DM007', 'DG007', 'S004', '2025-05-24', N'ChoXuLy'),
('DM008', 'DG008', 'S005', '2025-05-25', N'DaDuyet'),
('DM009', 'DG009', 'S006', '2025-05-26', N'TuChoi'),
('DM010', 'DG010', 'S007', '2025-05-27', N'ChoXuLy'),
('DM011', 'DG011', 'S008', '2025-05-28', N'DaDuyet'),
('DM012', 'DG012', 'S009', '2025-05-29', N'ChoXuLy'),
('DM013', 'DG013', 'S012', '2025-05-30', N'DaDuyet'),
('DM014', 'DG014', 'S013', '2025-05-31', N'TuChoi'),
('DM015', 'DG015', 'S014', '2025-06-01', N'ChoXuLy');
GO
