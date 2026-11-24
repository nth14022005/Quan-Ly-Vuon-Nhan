using System.Drawing;
using System.Windows.Forms;

namespace QLVuonNhan
{
    internal static class UiTheme
    {
        // Màu chủ đạo kiểu "vườn nhãn"
        private static readonly Color Green = Color.FromArgb(46, 125, 50);     // xanh lá
        private static readonly Color LightBg = Color.FromArgb(245, 247, 250); // nền sáng
        private static readonly Color AltRow = Color.FromArgb(250, 250, 250);  // dòng xen kẽ
        private static readonly Color SelBg = Color.FromArgb(205, 229, 214);   // chọn dòng
        private static readonly Font BaseFont = new Font("Segoe UI", 10f, FontStyle.Regular);
        private static readonly Font HeaderFont = new Font("Segoe UI", 10f, FontStyle.Bold);

        public static void ApplyForm(Form f)
        {
            if (f == null) return;
            f.Font = BaseFont;
            f.BackColor = LightBg;
        }

        public static void ApplyGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Green;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 34;

            dgv.DefaultCellStyle.Font = BaseFont;
            dgv.DefaultCellStyle.SelectionBackColor = SelBg;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = AltRow;
            dgv.RowTemplate.Height = 28;

            // Tắt highlight cell lẻ (nhìn sạch hơn)
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        public static void ApplySearch(TextBox txt)
        {
            if (txt == null) return;
            txt.Font = BaseFont;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyTitle(Label lbl)
        {
            if (lbl == null) return;
            lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lbl.ForeColor = Green;
        }

        public static void ApplyButtons(params Button[] buttons)
        {
            if (buttons == null) return;

            foreach (var b in buttons)
            {
                if (b == null) continue;
                b.Font = BaseFont;
                b.Height = 34;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                b.BackColor = Color.White;
                b.Cursor = Cursors.Hand;
            }
        }

        // Nút chính (Thêm/Lưu) nhìn nổi hơn
        public static void MakePrimary(Button b)
        {
            if (b == null) return;
            b.BackColor = Green;
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = Green;
        }
    }
}
