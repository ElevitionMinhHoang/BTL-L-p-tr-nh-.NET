// ===== LibraryManagement.Models/ChiTietMuon.cs =====
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("ChiTietMuon")]
    public class ChiTietMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTiet { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSach { get; set; }

        public int SoLuong { get; set; } = 1;

        public decimal PhiPhat { get; set; } = 0;

        // Navigation properties
        [ForeignKey("MaPhieu")]
        public virtual PhieuMuon PhieuMuon { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; }
    }
}
