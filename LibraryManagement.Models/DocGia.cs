using System;

namespace LibraryManagement.Models
{
    public class DocGia
    {
        public string MaDocGia { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public DateTime NgayCap { get; set; }
    }
}
