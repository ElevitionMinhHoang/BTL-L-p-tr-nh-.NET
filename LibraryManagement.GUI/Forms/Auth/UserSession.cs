using LibraryManagement.Models.DTOs;

namespace LibraryManagement.GUI.Forms.Auth
{
    public static class UserSession
    {
        public static TaiKhoanDTO Current { get; set; }
        public static bool IsAdmin => Current?.Role == "Admin";
        public static bool IsThuThu => Current?.Role == "ThuThu";
        public static bool IsBanDoc => Current?.Role == "BanDoc";

        public static void Logout()
        {
            Current = null;
        }
    }
}
