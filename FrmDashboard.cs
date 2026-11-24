using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLVuonNhan
{
    // Code-only Form: KHÔNG cần Designer, KHÔNG có InitializeComponent
    public class FrmDashboard : Form
    {
        private readonly string _hoTen;
        private readonly string _tenVaiTro;

        public FrmDashboard(string hoTen, string tenVaiTro)
        {
            _hoTen = hoTen ?? "";
            _tenVaiTro = tenVaiTro ?? "";

            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // Dashboard dạng "home" trong MDI
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = "";
            this.BackColor = MainTheme.Beige2;
            this.Font = new Font("Segoe UI", 10f);
            this.Dock = DockStyle.Fill;

            this.Controls.Clear();

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = MainTheme.Beige2
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var title = new Label
            {
                AutoSize = true,
                Text = "🍈 HỆ THỐNG QUẢN LÝ VƯỜN NHÃN",
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                ForeColor = MainTheme.Green,
                Anchor = AnchorStyles.None
            };

            var sub = new Label
            {
                AutoSize = true,
                Text = "Chọn chức năng bên trái để bắt đầu.",
                ForeColor = Color.FromArgb(80, 80, 80),
                Anchor = AnchorStyles.None
            };

            var box = new Panel
            {
                Anchor = AnchorStyles.Top,
                BackColor = Color.White,
                Padding = new Padding(18),
                Size = new Size(900, 260),
                BorderStyle = BorderStyle.FixedSingle
            };

            var info = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text =
                    $"👤 Xin chào: {_hoTen} ({_tenVaiTro})\n\n" +
                    "• Chủ vườn: quản lý toàn bộ dữ liệu\n" +
                    "• Nhân công: chỉ xem + tìm công việc chăm sóc\n\n" +
                    "Tip: mở nhanh bằng menu/nút bên trái.",
                Font = new Font("Segoe UI", 11f),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            box.Controls.Add(info);

            root.Controls.Add(title, 0, 0);
            root.Controls.Add(sub, 0, 1);

            var holder = new Panel { Dock = DockStyle.Fill, BackColor = MainTheme.Beige2 };
            holder.Controls.Add(box);
            box.Location = new Point((holder.Width - box.Width) / 2, 20);
            holder.Resize += (s, e2) =>
            {
                box.Location = new Point((holder.Width - box.Width) / 2, 20);
            };

            root.Controls.Add(holder, 0, 2);
            this.Controls.Add(root);
        }
    }
}
