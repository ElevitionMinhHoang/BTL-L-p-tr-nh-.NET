// ===== LibraryManagement.Models/MatSachRecord.cs =====
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("MatSach")]
    public class MatSachRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSuCo { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSach { get; set; }

        [StringLength(20)]
        public string LoaiSuCo { get; set; } // 'Mat' | 'HuHong'

        public decimal MucBoiThuong { get; set; } = 0;

        public DateTime NgayGhiNhan { get; set; } = DateTime.Today;

        // Navigation properties
        [ForeignKey("MaPhieu")]
        public virtual PhieuMuon PhieuMuon { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; }
    }
}
