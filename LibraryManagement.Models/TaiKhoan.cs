using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string MatKhauHash { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? SoDienThoai { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
