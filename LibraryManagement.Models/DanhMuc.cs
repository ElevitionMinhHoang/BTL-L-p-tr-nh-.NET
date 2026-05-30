using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public string MaDanhMuc { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string LoaiDanhMuc { get; set; } = string.Empty; // 'TheLoai', 'NXB', 'TacGia'
    }
}
