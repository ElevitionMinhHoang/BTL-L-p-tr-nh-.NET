namespace LibraryManagement.GUI
{
    partial class frmMain
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

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.btnQuanLySach = new System.Windows.Forms.Button();
            this.btnQuanLyDocGia = new System.Windows.Forms.Button();
            this.btnMuonSach = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.btnMuonTra = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTop.Controls.Add(this.lblUser);
            this.panelTop.Controls.Add(this.btnDangXuat);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(750, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Xin chào:";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.Location = new System.Drawing.Point(900, 15);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(80, 30);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(248, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "QUẢN LÝ THƯ VIỆN BTL";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.LightSlateGray;
            this.panelMenu.Controls.Add(this.btnQuanLyTaiKhoan);
            this.panelMenu.Controls.Add(this.btnQuanLySach);
            this.panelMenu.Controls.Add(this.btnQuanLyDocGia);
            this.panelMenu.Controls.Add(this.btnMuonSach);
            this.panelMenu.Controls.Add(this.btnTraSach);
            this.panelMenu.Controls.Add(this.btnMuonTra);
            this.panelMenu.Controls.Add(this.btnBaoCao);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 60);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 540);
            this.panelMenu.TabIndex = 1;
            // 
            // btnQuanLyTaiKhoan
            // 
            this.btnQuanLyTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.btnQuanLyTaiKhoan.Name = "btnQuanLyTaiKhoan";
            this.btnQuanLyTaiKhoan.Size = new System.Drawing.Size(190, 45);
            this.btnQuanLyTaiKhoan.TabIndex = 0;
            this.btnQuanLyTaiKhoan.Text = "Quản lý Tài khoản";
            this.btnQuanLyTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQuanLyTaiKhoan.Click += new System.EventHandler(this.btnQuanLyTaiKhoan_Click);
            // 
            // btnQuanLySach
            // 
            this.btnQuanLySach.Location = new System.Drawing.Point(3, 54);
            this.btnQuanLySach.Name = "btnQuanLySach";
            this.btnQuanLySach.Size = new System.Drawing.Size(190, 45);
            this.btnQuanLySach.TabIndex = 1;
            this.btnQuanLySach.Text = "Quản lý Sách";
            this.btnQuanLySach.UseVisualStyleBackColor = true;
            // 
            // btnQuanLyDocGia
            // 
            this.btnQuanLyDocGia.Location = new System.Drawing.Point(3, 105);
            this.btnQuanLyDocGia.Name = "btnQuanLyDocGia";
            this.btnQuanLyDocGia.Size = new System.Drawing.Size(190, 45);
            this.btnQuanLyDocGia.TabIndex = 2;
            this.btnQuanLyDocGia.Text = "Quản lý Độc giả";
            this.btnQuanLyDocGia.UseVisualStyleBackColor = true;
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.Location = new System.Drawing.Point(3, 156);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Size = new System.Drawing.Size(190, 45);
            this.btnMuonSach.TabIndex = 5;
            this.btnMuonSach.Text = "Mượn sách";
            this.btnMuonSach.UseVisualStyleBackColor = true;
            this.btnMuonSach.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(3, 207);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(190, 45);
            this.btnTraSach.TabIndex = 6;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnMuonTra
            // 
            this.btnMuonTra.Location = new System.Drawing.Point(3, 258);
            this.btnMuonTra.Name = "btnMuonTra";
            this.btnMuonTra.Size = new System.Drawing.Size(190, 45);
            this.btnMuonTra.TabIndex = 3;
            this.btnMuonTra.Text = "Danh sách mượn";
            this.btnMuonTra.UseVisualStyleBackColor = true;
            this.btnMuonTra.Click += new System.EventHandler(this.btnMuonTra_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(3, 309);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(190, 45);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "Báo cáo thống kê";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 540);
            this.panelContent.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Thư viện";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel panelMenu;
        private System.Windows.Forms.Button btnQuanLyTaiKhoan;
        private System.Windows.Forms.Button btnQuanLySach;
        private System.Windows.Forms.Button btnQuanLyDocGia;
        private System.Windows.Forms.Button btnMuonSach;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnMuonTra;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnDangXuat;
    }
}
