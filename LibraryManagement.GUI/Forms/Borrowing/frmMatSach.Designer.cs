namespace LibraryManagement.GUI.Forms.Borrowing
{
    partial class frmMatSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.rbMat = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbHuHong = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMucBoiThuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(440, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(118, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "GHI NHẬN SỰ CỐ SÁCH";
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenSach.Location = new System.Drawing.Point(30, 75);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(74, 19);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Sách: (---)";
            // 
            // rbMat
            // 
            this.rbMat.AutoSize = true;
            this.rbMat.Checked = true;
            this.rbMat.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMat.CheckedState.BorderThickness = 0;
            this.rbMat.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMat.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbMat.CheckedState.InnerOffset = -4;
            this.rbMat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMat.Location = new System.Drawing.Point(34, 115);
            this.rbMat.Name = "rbMat";
            this.rbMat.Size = new System.Drawing.Size(78, 21);
            this.rbMat.TabIndex = 2;
            this.rbMat.TabStop = true;
            this.rbMat.Text = "Mất sách";
            this.rbMat.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbMat.UncheckedState.BorderThickness = 2;
            this.rbMat.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbMat.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbMat.CheckedChanged += new System.EventHandler(this.rbMat_CheckedChanged);
            // 
            // rbHuHong
            // 
            this.rbHuHong.AutoSize = true;
            this.rbHuHong.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbHuHong.CheckedState.BorderThickness = 0;
            this.rbHuHong.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbHuHong.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbHuHong.CheckedState.InnerOffset = -4;
            this.rbHuHong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHuHong.Location = new System.Drawing.Point(140, 115);
            this.rbHuHong.Name = "rbHuHong";
            this.rbHuHong.Size = new System.Drawing.Size(77, 21);
            this.rbHuHong.TabIndex = 3;
            this.rbHuHong.Text = "Hư hỏng";
            this.rbHuHong.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbHuHong.UncheckedState.BorderThickness = 2;
            this.rbHuHong.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbHuHong.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbHuHong.CheckedChanged += new System.EventHandler(this.rbHuHong_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mức bồi thường (VNĐ)";
            // 
            // txtMucBoiThuong
            // 
            this.txtMucBoiThuong.BorderRadius = 8;
            this.txtMucBoiThuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMucBoiThuong.DefaultText = "200000";
            this.txtMucBoiThuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMucBoiThuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMucBoiThuong.Location = new System.Drawing.Point(34, 184);
            this.txtMucBoiThuong.Name = "txtMucBoiThuong";
            this.txtMucBoiThuong.PasswordChar = '\0';
            this.txtMucBoiThuong.PlaceholderText = "";
            this.txtMucBoiThuong.SelectedText = "";
            this.txtMucBoiThuong.Size = new System.Drawing.Size(370, 36);
            this.txtMucBoiThuong.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGhiChu.Location = new System.Drawing.Point(31, 235);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(262, 15);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Bồi thường sẽ được trừ vào tài khoản độc giả";
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(194, 269);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 36);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 8;
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(304, 269);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(100, 36);
            this.btnXacNhan.TabIndex = 8;
            this.btnXacNhan.Text = "✓ Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // frmMatSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 320);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtMucBoiThuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbHuHong);
            this.Controls.Add(this.rbMat);
            this.Controls.Add(this.lblTenSach);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMatSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ghi Nhận Sự Cố";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTenSach;
        private Guna.UI2.WinForms.Guna2RadioButton rbMat;
        private Guna.UI2.WinForms.Guna2RadioButton rbHuHong;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtMucBoiThuong;
        private System.Windows.Forms.Label lblGhiChu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
    }
}
