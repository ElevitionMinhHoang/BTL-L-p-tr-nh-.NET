// ===== LibraryManagement.GUI/UIHelper.cs =====
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LibraryManagement.GUI
{
    public static class UIHelper
    {
        public static void ShowToast(Form owner, string message, string type = "Success")
        {
            // Đơn giản hóa: Dùng MessageDialog hoặc MessageBox có style Guna
            Guna2MessageDialog dialog = new Guna2MessageDialog();
            // Guna2MessageDialog has a Parent property (Control), not ParentForm
            dialog.Parent = owner;
            dialog.Text = message;
            dialog.Caption = type == "Success" ? "Thành công" : (type == "Error" ? "Lỗi" : "Thông báo");
            dialog.Icon = type == "Success" ? MessageDialogIcon.Information : (type == "Error" ? MessageDialogIcon.Error : MessageDialogIcon.Warning);
            dialog.Buttons = MessageDialogButtons.OK;
            dialog.Style = MessageDialogStyle.Light;
            dialog.Show();
        }

        public static bool ConfirmDelete(string itemName)
        {
            return MessageBox.Show($"Bạn có chắc chắn muốn xóa/hủy {itemName} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // BẢNG MÀU
        public static Color ColorPrimary = ColorTranslator.FromHtml("#2E75B6");
        public static Color ColorSuccess = ColorTranslator.FromHtml("#22C55E");
        public static Color ColorDanger = ColorTranslator.FromHtml("#EF4444");
        public static Color ColorWarning = ColorTranslator.FromHtml("#F59E0B");
        public static Color ColorBackground = ColorTranslator.FromHtml("#F0F4F8");
    }
}
