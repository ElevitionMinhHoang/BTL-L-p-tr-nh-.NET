// ===== LibraryManagement.Models/DatMuon.cs =====
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("DatMuon")]
    public class DatMuon
    {
        [Key]
        [StringLength(50)]
        public string MaDatMuon { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDocGia { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSach { get; set; }

        public DateTime NgayDat { get; set; } = DateTime.Today;

        [StringLength(20)]
        public string TrangThai { get; set; } = "ChoXuLy";

        // Navigation properties
        [ForeignKey("MaDocGia")]
        public virtual DocGia DocGia { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; }
    }
}
