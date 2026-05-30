namespace LibraryManagement.GUI.Forms.Borrowing
{
    partial class frmTraSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSearch = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTimPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongPhiPhat = new System.Windows.Forms.Label();
            this.dgvDetails = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhiPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.lblTenDocGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXacNhanTra = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuyPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSearch.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderRadius = 12;
            this.pnlSearch.Controls.Add(this.btnTimPhieu);
            this.pnlSearch.Controls.Add(this.txtMaPhieu);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Location = new System.Drawing.Point(23, 23);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(854, 88);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnTimPhieu
            // 
            this.btnTimPhieu.BorderRadius = 8;
            this.btnTimPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnTimPhieu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTimPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTimPhieu.Location = new System.Drawing.Point(401, 31);
            this.btnTimPhieu.Name = "btnTimPhieu";
            this.btnTimPhieu.Size = new System.Drawing.Size(65, 36);
            this.btnTimPhieu.TabIndex = 2;
            this.btnTimPhieu.Text = "🔍";
            this.btnTimPhieu.Click += new System.EventHandler(this.btnTimPhieu_Click);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.BorderRadius = 8;
            this.txtMaPhieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPhieu.DefaultText = "";
            this.txtMaPhieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.txtMaPhieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaPhieu.Location = new System.Drawing.Point(145, 31);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.PasswordChar = '\0';
            this.txtMaPhieu.PlaceholderText = "Nhập mã phiếu mượn";
            this.txtMaPhieu.SelectedText = "";
            this.txtMaPhieu.Size = new System.Drawing.Size(250, 36);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÌM PHIẾU MƯỢN";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderRadius = 12;
            this.pnlInfo.Controls.Add(this.lblTongPhiPhat);
            this.pnlInfo.Controls.Add(this.dgvDetails);
            this.pnlInfo.Controls.Add(this.lblTinhTrang);
            this.pnlInfo.Controls.Add(this.lblHanTra);
            this.pnlInfo.Controls.Add(this.lblNgayMuon);
            this.pnlInfo.Controls.Add(this.lblTenDocGia);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Location = new System.Drawing.Point(23, 131);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(854, 431);
            this.pnlInfo.TabIndex = 1;
            this.pnlInfo.Visible = false;
            // 
            // lblTongPhiPhat
            // 
            this.lblTongPhiPhat.AutoSize = true;
            this.lblTongPhiPhat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongPhiPhat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTongPhiPhat.Location = new System.Drawing.Point(544, 386);
            this.lblTongPhiPhat.Name = "lblTongPhiPhat";
            this.lblTongPhiPhat.Size = new System.Drawing.Size(227, 25);
            this.lblTongPhiPhat.TabIndex = 6;
            this.lblTongPhiPhat.Text = "Tổng tiền phạt: 0.000 đ";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.ColumnHeadersHeight = 35;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenSach,
            this.colSoLuong,
            this.colPhiPhat});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.EnableHeadersVisualStyles = false;
            this.dgvDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetails.Location = new System.Drawing.Point(25, 142);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(804, 222);
            this.dgvDetails.TabIndex = 5;
            this.dgvDetails.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetails.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetails.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            // 
            // colTenSach
            // 
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.Name = "colTenSach";
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colPhiPhat
            // 
            this.colPhiPhat.HeaderText = "Phí phạt";
            this.colPhiPhat.Name = "colPhiPhat";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTinhTrang.Location = new System.Drawing.Point(545, 102);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(125, 20);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "⚠ QUÁ HẠN 0 NGÀY";
            // 
            // lblHanTra
            // 
            this.lblHanTra.AutoSize = true;
            this.lblHanTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHanTra.Location = new System.Drawing.Point(545, 71);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(61, 19);
            this.lblHanTra.TabIndex = 3;
            this.lblHanTra.Text = "Hạn trả: ";
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayMuon.Location = new System.Drawing.Point(25, 103);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(89, 19);
            this.lblNgayMuon.TabIndex = 2;
            this.lblNgayMuon.Text = "Ngày mượn: ";
            // 
            // lblTenDocGia
            // 
            this.lblTenDocGia.AutoSize = true;
            this.lblTenDocGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenDocGia.Location = new System.Drawing.Point(25, 70);
            this.lblTenDocGia.Name = "lblTenDocGia";
            this.lblTenDocGia.Size = new System.Drawing.Size(107, 21);
            this.lblTenDocGia.TabIndex = 1;
            this.lblTenDocGia.Text = "Tên độc giả: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "THÔNG TIN PHIẾU";
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.BorderRadius = 8;
            this.btnXacNhanTra.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnXacNhanTra.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanTra.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanTra.Location = new System.Drawing.Point(627, 577);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(250, 45);
            this.btnXacNhanTra.TabIndex = 2;
            this.btnXacNhanTra.Text = "✓ XÁC NHẬN TRẢ";
            this.btnXacNhanTra.Visible = false;
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BorderRadius = 8;
            this.btnHuyPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnHuyPhieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuyPhieu.ForeColor = System.Drawing.Color.White;
            this.btnHuyPhieu.Location = new System.Drawing.Point(471, 577);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(150, 45);
            this.btnHuyPhieu.TabIndex = 3;
            this.btnHuyPhieu.Text = "🚫 HỦY PHIẾU";
            this.btnHuyPhieu.Visible = false;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.btnHuyPhieu);
            this.Controls.Add(this.btnXacNhanTra);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTraSach";
            this.Text = "Trả Sách";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhieu;
        private Guna.UI2.WinForms.Guna2Button btnTimPhieu;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenDocGia;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.Label lblTinhTrang;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetails;
        private System.Windows.Forms.Label lblTongPhiPhat;
        private Guna.UI2.WinForms.Guna2Button btnXacNhanTra;
        private Guna.UI2.WinForms.Guna2Button btnHuyPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhiPhat;
    }
}
