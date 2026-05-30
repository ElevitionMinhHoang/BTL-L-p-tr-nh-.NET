// ===== LibraryManagement.Models/PhieuMuon.cs =====
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("PhieuMuon")]
    public class PhieuMuon
    {
        [Key]
        [StringLength(50)]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDocGia { get; set; }

        public DateTime NgayMuon { get; set; } = DateTime.Today;

        [Required]
        public DateTime HanTra { get; set; }

        public DateTime? NgayTra { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; } = "DangMuon";

        // Navigation properties
        [ForeignKey("MaDocGia")]
        public virtual DocGia DocGia { get; set; }

        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; }

        public PhieuMuon()
        {
            ChiTietMuons = new HashSet<ChiTietMuon>();
        }
    }
}
