namespace LibraryManagement.GUI.Forms.Borrowing
{
    partial class frmMuonSach
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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.dgvSelectedBooks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.dateHanTra = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblThongBaoSach = new System.Windows.Forms.Label();
            this.btnThemSach = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaSach = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoDangMuon = new System.Windows.Forms.Label();
            this.lblTenDocGia = new System.Windows.Forms.Label();
            this.btnTimDocGia = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaDocGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBooks)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 640);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.btnReset);
            this.pnlRight.Controls.Add(this.btnTaoPhieu);
            this.pnlRight.Controls.Add(this.lblTongSach);
            this.pnlRight.Controls.Add(this.dgvSelectedBooks);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(400, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(500, 640);
            this.pnlRight.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 8;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(23, 569);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 45);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "🔄 RESET";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BorderRadius = 8;
            this.btnTaoPhieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoPhieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(149, 569);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(328, 45);
            this.btnTaoPhieu.TabIndex = 2;
            this.btnTaoPhieu.Text = "✓ TẠO PHIẾU MƯỢN";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSach.Location = new System.Drawing.Point(19, 20);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(117, 21);
            this.lblTongSach.TabIndex = 1;
            this.lblTongSach.Text = "Số sách chọn: 0";
            // 
            // dgvSelectedBooks
            // 
            this.dgvSelectedBooks.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvSelectedBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSelectedBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSelectedBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectedBooks.ColumnHeadersHeight = 35;
            this.dgvSelectedBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSach,
            this.colTenSach,
            this.colAction});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectedBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelectedBooks.EnableHeadersVisualStyles = false;
            this.dgvSelectedBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSelectedBooks.Location = new System.Drawing.Point(23, 56);
            this.dgvSelectedBooks.Name = "dgvSelectedBooks";
            this.dgvSelectedBooks.RowHeadersVisible = false;
            this.dgvSelectedBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedBooks.Size = new System.Drawing.Size(454, 496);
            this.dgvSelectedBooks.TabIndex = 0;
            this.dgvSelectedBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSelectedBooks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSelectedBooks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSelectedBooks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSelectedBooks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSelectedBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSelectedBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSelectedBooks.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvSelectedBooks.ThemeStyle.ReadOnly = false;
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.Height = 22;
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSelectedBooks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSelectedBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedBooks_CellContentClick);
            // 
            // colMaSach
            // 
            this.colMaSach.HeaderText = "Mã sách";
            this.colMaSach.Name = "colMaSach";
            this.colMaSach.ReadOnly = true;
            // 
            // colTenSach
            // 
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.FillWeight = 50F;
            this.colAction.HeaderText = "Xóa";
            this.colAction.Name = "colAction";
            this.colAction.Text = "×";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlLeft.Controls.Add(this.lblSoNgay);
            this.pnlLeft.Controls.Add(this.dateHanTra);
            this.pnlLeft.Controls.Add(this.label5);
            this.pnlLeft.Controls.Add(this.lblThongBaoSach);
            this.pnlLeft.Controls.Add(this.btnThemSach);
            this.pnlLeft.Controls.Add(this.txtMaSach);
            this.pnlLeft.Controls.Add(this.label4);
            this.pnlLeft.Controls.Add(this.lblSoDangMuon);
            this.pnlLeft.Controls.Add(this.lblTenDocGia);
            this.pnlLeft.Controls.Add(this.btnTimDocGia);
            this.pnlLeft.Controls.Add(this.txtMaDocGia);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLeft.Size = new System.Drawing.Size(400, 640);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSoNgay.Location = new System.Drawing.Point(23, 535);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Size = new System.Drawing.Size(84, 17);
            this.lblSoNgay.TabIndex = 11;
            this.lblSoNgay.Text = "Số ngày: --";
            // 
            // dateHanTra
            // 
            this.dateHanTra.BorderRadius = 8;
            this.dateHanTra.Checked = true;
            this.dateHanTra.FillColor = System.Drawing.Color.White;
            this.dateHanTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateHanTra.Location = new System.Drawing.Point(23, 492);
            this.dateHanTra.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateHanTra.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateHanTra.Name = "dateHanTra";
            this.dateHanTra.Size = new System.Drawing.Size(354, 36);
            this.dateHanTra.TabIndex = 10;
            this.dateHanTra.Value = new System.DateTime(2026, 5, 30, 0, 0, 0, 0);
            this.dateHanTra.ValueChanged += new System.EventHandler(this.dateHanTra_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(23, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "HẠN TRẢ";
            // 
            // lblThongBaoSach
            // 
            this.lblThongBaoSach.AutoSize = true;
            this.lblThongBaoSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblThongBaoSach.Location = new System.Drawing.Point(23, 396);
            this.lblThongBaoSach.Name = "lblThongBaoSach";
            this.lblThongBaoSach.Size = new System.Drawing.Size(12, 15);
            this.lblThongBaoSach.TabIndex = 8;
            this.lblThongBaoSach.Text = "..";
            // 
            // btnThemSach
            // 
            this.btnThemSach.BorderRadius = 8;
            this.btnThemSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemSach.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnThemSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSach.ForeColor = System.Drawing.Color.White;
            this.btnThemSach.Location = new System.Drawing.Point(267, 348);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(110, 36);
            this.btnThemSach.TabIndex = 7;
            this.btnThemSach.Text = "+ Thêm";
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // txtMaSach
            // 
            this.txtMaSach.BorderRadius = 8;
            this.txtMaSach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaSach.DefaultText = "";
            this.txtMaSach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaSach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaSach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.txtMaSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaSach.Location = new System.Drawing.Point(23, 348);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.PasswordChar = '\0';
            this.txtMaSach.PlaceholderText = "Nhập mã sách";
            this.txtMaSach.SelectedText = "";
            this.txtMaSach.Size = new System.Drawing.Size(238, 36);
            this.txtMaSach.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(23, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "DANH SÁCH SÁCH";
            // 
            // lblSoDangMuon
            // 
            this.lblSoDangMuon.AutoSize = true;
            this.lblSoDangMuon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDangMuon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblSoDangMuon.Location = new System.Drawing.Point(23, 154);
            this.lblSoDangMuon.Name = "lblSoDangMuon";
            this.lblSoDangMuon.Size = new System.Drawing.Size(104, 17);
            this.lblSoDangMuon.TabIndex = 4;
            this.lblSoDangMuon.Text = "Đang mượn: --";
            // 
            // lblTenDocGia
            // 
            this.lblTenDocGia.AutoSize = true;
            this.lblTenDocGia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDocGia.Location = new System.Drawing.Point(23, 124);
            this.lblTenDocGia.Name = "lblTenDocGia";
            this.lblTenDocGia.Size = new System.Drawing.Size(130, 20);
            this.lblTenDocGia.TabIndex = 3;
            this.lblTenDocGia.Text = "Tên độc giả: (Chưa)";
            // 
            // btnTimDocGia
            // 
            this.btnTimDocGia.BorderRadius = 8;
            this.btnTimDocGia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimDocGia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimDocGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimDocGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimDocGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnTimDocGia.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnTimDocGia.ForeColor = System.Drawing.Color.White;
            this.btnTimDocGia.Location = new System.Drawing.Point(323, 76);
            this.btnTimDocGia.Name = "btnTimDocGia";
            this.btnTimDocGia.Size = new System.Drawing.Size(54, 36);
            this.btnTimDocGia.TabIndex = 2;
            this.btnTimDocGia.Text = "🔍";
            this.btnTimDocGia.Click += new System.EventHandler(this.btnTimDocGia_Click);
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.BorderRadius = 8;
            this.txtMaDocGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaDocGia.DefaultText = "";
            this.txtMaDocGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaDocGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaDocGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDocGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDocGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.txtMaDocGia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDocGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaDocGia.Location = new System.Drawing.Point(23, 76);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.PasswordChar = '\0';
            this.txtMaDocGia.PlaceholderText = "Mã độc giả";
            this.txtMaDocGia.SelectedText = "";
            this.txtMaDocGia.Size = new System.Drawing.Size(294, 36);
            this.txtMaDocGia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN BẠN ĐỌC";
            // 
            // frmMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMuonSach";
            this.Text = "Mượn Sách";
            this.Load += new System.EventHandler(this.frmMuonSach_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBooks)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaDocGia;
        private Guna.UI2.WinForms.Guna2Button btnTimDocGia;
        private System.Windows.Forms.Label lblTenDocGia;
        private System.Windows.Forms.Label lblSoDangMuon;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtMaSach;
        private Guna.UI2.WinForms.Guna2Button btnThemSach;
        private System.Windows.Forms.Label lblThongBaoSach;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateHanTra;
        private System.Windows.Forms.Label lblSoNgay;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSelectedBooks;
        private System.Windows.Forms.Label lblTongSach;
        private Guna.UI2.WinForms.Guna2Button btnTaoPhieu;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
    }
}
