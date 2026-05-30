// ===== LibraryManagement.GUI/Forms/Borrowing/frmMatSach.cs =====
using System;
using System.Windows.Forms;
using LibraryManagement.BLL;

namespace LibraryManagement.GUI.Forms.Borrowing
{
    public partial class frmMatSach : Form
    {
        private readonly MatSachBLL _matSachBLL = new MatSachBLL();
        private string _maPhieu;
        private string _maSach;

        public frmMatSach(string maPhieu, string maSach, string tenSach)
        {
            InitializeComponent();
            _maPhieu = maPhieu;
            _maSach = maSach;
            lblTenSach.Text = $"Sách: {tenSach}";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string loai = rbMat.Checked ? "Mat" : "HuHong";
            if (!decimal.TryParse(txtMucBoiThuong.Text, out decimal mucBoiThuong))
            {
                UIHelper.ShowToast(this, "Mức bồi thường không hợp lệ!", "Error");
                return;
            }

            string error = _matSachBLL.GhiNhanMatSach(_maPhieu, _maSach, loai, mucBoiThuong);
            if (error == null)
            {
                UIHelper.ShowToast(this, "Ghi nhận sự cố thành công!", "Success");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                UIHelper.ShowToast(this, error, "Error");
            }
        }

        private void rbMat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMat.Checked) txtMucBoiThuong.Text = "200000";
        }

        private void rbHuHong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHuHong.Checked) txtMucBoiThuong.Text = "50000";
        }
    }
}
