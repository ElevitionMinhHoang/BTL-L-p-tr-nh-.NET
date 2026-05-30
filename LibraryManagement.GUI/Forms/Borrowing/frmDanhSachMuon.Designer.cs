namespace LibraryManagement.GUI.Forms.Borrowing
{
    partial class frmDanhSachMuon
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcMain = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.dgvAll = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabQuaHan = new System.Windows.Forms.TabPage();
            this.dgvQuaHan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabChoDuyet = new System.Windows.Forms.TabPage();
            this.dgvChoDuyet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabSuCo = new System.Windows.Forms.TabPage();
            this.dgvSuCo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsHanhDong = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGiaHan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTraSach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGhiMat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHuyPhieu = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDatMuon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDuyet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTuChoi = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tabAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.tabQuaHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).BeginInit();
            this.tabChoDuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoDuyet)).BeginInit();
            this.tabSuCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).BeginInit();
            this.cmsHanhDong.SuspendLayout();
            this.cmsDatMuon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabAll);
            this.tcMain.Controls.Add(this.tabQuaHan);
            this.tcMain.Controls.Add(this.tabChoDuyet);
            this.tcMain.Controls.Add(this.tabSuCo);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(900, 640);
            this.tcMain.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcMain.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcMain.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMain.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcMain.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcMain.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcMain.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.tcMain.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMain.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcMain.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.tcMain.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcMain.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcMain.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMain.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcMain.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcMain.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcMain.TabIndex = 0;
            this.tcMain.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.tcMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.dgvAll);
            this.tabAll.Controls.Add(this.pnlToolbar);
            this.tabAll.Location = new System.Drawing.Point(4, 44);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(892, 592);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "📋 Tất cả phiếu";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.BackgroundColor = System.Drawing.Color.White;
            this.dgvAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAll.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAll.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAll.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAll.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAll.EnableHeadersVisualStyles = false;
            this.dgvAll.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAll.Location = new System.Drawing.Point(3, 73);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.RowHeadersVisible = false;
            this.dgvAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAll.Size = new System.Drawing.Size(886, 516);
            this.dgvAll.TabIndex = 1;
            this.dgvAll.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAll.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAll_CellFormatting);
            this.dgvAll.ContextMenuStrip = this.cmsHanhDong;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.cboTrangThai);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(886, 70);
            this.pnlToolbar.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(448, 17);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 36);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.BorderRadius = 8;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "DangMuon",
            "DaTra",
            "QuaHan",
            "ChoXuLy",
            "DaHuy"});
            this.cboTrangThai.Location = new System.Drawing.Point(232, 17);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 36);
            this.cboTrangThai.StartIndex = 0;
            this.cboTrangThai.TabIndex = 1;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(16, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm theo mã phiếu/tên độc giả";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(200, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tabQuaHan
            // 
            this.tabQuaHan.Controls.Add(this.dgvQuaHan);
            this.tabQuaHan.Location = new System.Drawing.Point(4, 44);
            this.tabQuaHan.Name = "tabQuaHan";
            this.tabQuaHan.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuaHan.Size = new System.Drawing.Size(892, 592);
            this.tabQuaHan.TabIndex = 1;
            this.tabQuaHan.Text = "⏰ Quá hạn";
            this.tabQuaHan.UseVisualStyleBackColor = true;
            // 
            // dgvQuaHan
            // 
            this.dgvQuaHan.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvQuaHan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuaHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuaHan.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuaHan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuaHan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQuaHan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuaHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQuaHan.ColumnHeadersHeight = 35;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuaHan.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvQuaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuaHan.EnableHeadersVisualStyles = false;
            this.dgvQuaHan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQuaHan.Location = new System.Drawing.Point(3, 3);
            this.dgvQuaHan.Name = "dgvQuaHan";
            this.dgvQuaHan.RowHeadersVisible = false;
            this.dgvQuaHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuaHan.Size = new System.Drawing.Size(886, 586);
            this.dgvQuaHan.TabIndex = 0;
            this.dgvQuaHan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuaHan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAll_CellFormatting);
            // 
            // tabChoDuyet
            // 
            this.tabChoDuyet.Controls.Add(this.dgvChoDuyet);
            this.tabChoDuyet.Location = new System.Drawing.Point(4, 44);
            this.tabChoDuyet.Name = "tabChoDuyet";
            this.tabChoDuyet.Size = new System.Drawing.Size(892, 592);
            this.tabChoDuyet.TabIndex = 2;
            this.tabChoDuyet.Text = "🕐 Chờ duyệt";
            this.tabChoDuyet.UseVisualStyleBackColor = true;
            // 
            // dgvChoDuyet
            // 
            this.dgvChoDuyet.AllowUserToAddRows = false;
            this.dgvChoDuyet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChoDuyet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChoDuyet.ColumnHeadersHeight = 35;
            this.dgvChoDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChoDuyet.EnableHeadersVisualStyles = false;
            this.dgvChoDuyet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChoDuyet.Location = new System.Drawing.Point(0, 0);
            this.dgvChoDuyet.Name = "dgvChoDuyet";
            this.dgvChoDuyet.RowHeadersVisible = false;
            this.dgvChoDuyet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoDuyet.Size = new System.Drawing.Size(892, 592);
            this.dgvChoDuyet.TabIndex = 0;
            this.dgvChoDuyet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChoDuyet.ContextMenuStrip = this.cmsDatMuon;
            // 
            // tabSuCo
            // 
            this.tabSuCo.Controls.Add(this.dgvSuCo);
            this.tabSuCo.Location = new System.Drawing.Point(4, 44);
            this.tabSuCo.Name = "tabSuCo";
            this.tabSuCo.Size = new System.Drawing.Size(892, 592);
            this.tabSuCo.TabIndex = 3;
            this.tabSuCo.Text = "🚩 Lịch sử sự cố";
            this.tabSuCo.UseVisualStyleBackColor = true;
            // 
            // dgvSuCo
            // 
            this.dgvSuCo.AllowUserToAddRows = false;
            this.dgvSuCo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuCo.BackgroundColor = System.Drawing.Color.White;
            this.dgvSuCo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSuCo.ColumnHeadersHeight = 35;
            this.dgvSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuCo.EnableHeadersVisualStyles = false;
            this.dgvSuCo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSuCo.Location = new System.Drawing.Point(0, 0);
            this.dgvSuCo.Name = "dgvSuCo";
            this.dgvSuCo.RowHeadersVisible = false;
            this.dgvSuCo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuCo.Size = new System.Drawing.Size(892, 592);
            this.dgvSuCo.TabIndex = 0;
            this.dgvSuCo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            // 
            // cmsHanhDong
            // 
            this.cmsHanhDong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGiaHan,
            this.tsmiTraSach,
            this.tsmiGhiMat,
            this.tsmiHuyPhieu});
            this.cmsHanhDong.Name = "cmsHanhDong";
            this.cmsHanhDong.Size = new System.Drawing.Size(161, 92);
            // 
            // tsmiGiaHan
            // 
            this.tsmiGiaHan.Name = "tsmiGiaHan";
            this.tsmiGiaHan.Size = new System.Drawing.Size(160, 22);
            this.tsmiGiaHan.Text = "Gia hạn (7 ngày)";
            this.tsmiGiaHan.Click += new System.EventHandler(this.tsmiGiaHan_Click);
            // 
            // tsmiTraSach
            // 
            this.tsmiTraSach.Name = "tsmiTraSach";
            this.tsmiTraSach.Size = new System.Drawing.Size(160, 22);
            this.tsmiTraSach.Text = "Trả sách";
            this.tsmiTraSach.Click += new System.EventHandler(this.tsmiTraSach_Click);
            // 
            // tsmiGhiMat
            // 
            this.tsmiGhiMat.Name = "tsmiGhiMat";
            this.tsmiGhiMat.Size = new System.Drawing.Size(160, 22);
            this.tsmiGhiMat.Text = "Ghi nhận sự cố";
            this.tsmiGhiMat.Click += new System.EventHandler(this.tsmiGhiMat_Click);
            // 
            // tsmiHuyPhieu
            // 
            this.tsmiHuyPhieu.Name = "tsmiHuyPhieu";
            this.tsmiHuyPhieu.Size = new System.Drawing.Size(160, 22);
            this.tsmiHuyPhieu.Text = "Hủy phiếu";
            this.tsmiHuyPhieu.Click += new System.EventHandler(this.tsmiHuyPhieu_Click);
            // 
            // cmsDatMuon
            // 
            this.cmsDatMuon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDuyet,
            this.tsmiTuChoi});
            this.cmsDatMuon.Name = "cmsDatMuon";
            this.cmsDatMuon.Size = new System.Drawing.Size(151, 48);
            // 
            // tsmiDuyet
            // 
            this.tsmiDuyet.Name = "tsmiDuyet";
            this.tsmiDuyet.Size = new System.Drawing.Size(150, 22);
            this.tsmiDuyet.Text = "Duyệt yêu cầu";
            this.tsmiDuyet.Click += new System.EventHandler(this.tsmiDuyet_Click);
            // 
            // tsmiTuChoi
            // 
            this.tsmiTuChoi.Name = "tsmiTuChoi";
            this.tsmiTuChoi.Size = new System.Drawing.Size(150, 22);
            this.tsmiTuChoi.Text = "Từ chối";
            this.tsmiTuChoi.Click += new System.EventHandler(this.tsmiTuChoi_Click);
            // 
            // frmDanhSachMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDanhSachMuon";
            this.Text = "Danh Sách Mượn";
            this.Load += new System.EventHandler(this.frmDanhSachMuon_Load);
            this.tcMain.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.tabQuaHan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).EndInit();
            this.tabChoDuyet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoDuyet)).EndInit();
            this.tabSuCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).EndInit();
            this.cmsHanhDong.ResumeLayout(false);
            this.cmsDatMuon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabQuaHan;
        private System.Windows.Forms.TabPage tabChoDuyet;
        private System.Windows.Forms.TabPage tabSuCo;
        private Guna.UI2.WinForms.Guna2Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAll;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuaHan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChoDuyet;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSuCo;
        private System.Windows.Forms.ContextMenuStrip cmsHanhDong;
        private System.Windows.Forms.ToolStripMenuItem tsmiGiaHan;
        private System.Windows.Forms.ToolStripMenuItem tsmiTraSach;
        private System.Windows.Forms.ToolStripMenuItem tsmiGhiMat;
        private System.Windows.Forms.ToolStripMenuItem tsmiHuyPhieu;
        private System.Windows.Forms.ContextMenuStrip cmsDatMuon;
        private System.Windows.Forms.ToolStripMenuItem tsmiDuyet;
        private System.Windows.Forms.ToolStripMenuItem tsmiTuChoi;
    }
}
