
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using LibraryManagement.BLL;
using LibraryManagement.GUI.Helpers;

namespace LibraryManagement.GUI.Forms.Reports
{
    public partial class frmBaoCao : Form
    {
        private readonly BaoCaoBLL _bll = new BaoCaoBLL();
        private readonly string[] _chartColors =
        {
            "#2E75B6", "#22C55E", "#F59E0B", "#EF4444", "#8B5CF6", "#EC4899", "#14B8A6"
        };

        private Guna2ComboBox cboNam;
        private Guna2ComboBox cboThang;
        private Guna2Button btnApDung;
        private Guna2Button btnXuatExcel;
        private Label kpiMuon;
        private Label kpiDangMuon;
        private Label kpiQuaHan;
        private Label kpiTienPhat;
        private LiveCharts.WinForms.PieChart pieChart;
        private LiveCharts.WinForms.CartesianChart barChart;
        private Guna2DataGridView dgvTopSach;
        private Guna2DataGridView dgvSachTon;
        private Guna2DataGridView dgvDoanhThu;

        public frmBaoCao()
        {
            InitializeComponent();
            BuildUi();
            WireEvents();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmBaoCao
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.ResumeLayout(false);

        }

        private void BuildUi()
        {
            SuspendLayout();

            Text = "Báo cáo & Thống kê";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 700);
            MinimumSize = new Size(980, 640);
            BackColor = ColorTranslator.FromHtml("#F0F4F8");
            Font = new Font("Segoe UI", 10f, FontStyle.Regular);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#F0F4F8"),
                Padding = new Padding(18),
                ColumnCount = 1,
                RowCount = 5
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 108));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 48));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 52));

            root.Controls.Add(CreateHeader(), 0, 0);
            root.Controls.Add(CreateFilterBar(), 0, 1);
            root.Controls.Add(CreateKpiRow(), 0, 2);
            root.Controls.Add(CreateChartRow(), 0, 3);
            root.Controls.Add(CreateTableTabs(), 0, 4);

            Controls.Add(root);
            ResumeLayout(false);
        }

        private Control CreateHeader()
        {
            var panel = CreatePanel("#1E2A3A", 12);
            panel.Margin = new Padding(0, 0, 0, 10);

            var title = new Label
            {
                Text = "📊  BÁO CÁO & THỐNG KÊ",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            panel.Controls.Add(title);
            return panel;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {

        }