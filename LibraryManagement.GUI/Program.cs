using System;
using System.Windows.Forms;
using LibraryManagement.GUI.Forms.Auth;

namespace LibraryManagement.GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }
}
