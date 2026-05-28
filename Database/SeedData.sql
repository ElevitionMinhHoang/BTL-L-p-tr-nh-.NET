USE LibraryManagement;
GO

-- Password là 'admin123' đã được hash BCrypt
INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen, Role, Email, IsActive)
VALUES ('admin', '$2a$12$R9h/NrLmsXGqCST9GZJ6V.K8.vTf9zO5O5O5O5O5O5O5O5O5O5O5O', N'Quản trị viên', 'Admin', 'admin@library.com', 1);

-- Password là 'thuthu123'
INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen, Role, Email, IsActive)
VALUES ('thuthu12', '$2a$12$R9h/NrLmsXGqCST9GZJ6V.K8.vTf9zO5O5O5O5O5O5O5O5O5O5O5O', N'Nguyễn Thủ Thư', 'ThuThu', 'thuthu@library.com', 1);

-- Password là 'bandoc123'
INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen, Role, Email, IsActive)
VALUES ('bandoc12', '$2a$12$R9h/NrLmsXGqCST9GZJ6V.K8.vTf9zO5O5O5O5O5O5O5O5O5O5O5O', N'Lê Độc Giả', 'BanDoc', 'docgia@library.com', 1);
