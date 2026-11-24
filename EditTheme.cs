using System.Drawing;
using System.Windows.Forms;

namespace QLVuonNhan
{
    internal static class EditTheme
    {
        // vibe “vườn nhãn”
        private static readonly Color Bg = Color.FromArgb(255, 248, 231);      // kem
        private static readonly Color Green = Color.FromArgb(46, 125, 50);     // xanh lá
        private static readonly Color Gray = Color.FromArgb(224, 224, 224);    // xám

        public static void Apply(Form f, Button btnSave, Button btnCancel)
        {
            if (f == null) return;

            f.Font = new Font("Segoe UI", 10F);
            f.BackColor = Bg;
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.MaximizeBox = false;
            f.MinimizeBox = false;

            // style nút Lưu
            if (btnSave != null)
            {
                btnSave.BackColor = Green;
                btnSave.ForeColor = Color.White;
                btnSave.FlatStyle = FlatStyle.Flat;
                btnSave.FlatAppearance.BorderSize = 0;
                btnSave.Height = 34;
                f.AcceptButton = btnSave;
            }

            // style nút Hủy/Đóng
            if (btnCancel != null)
            {
                btnCancel.BackColor = Gray;
                btnCancel.ForeColor = Color.Black;
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.FlatAppearance.BorderSize = 0;
                btnCancel.Height = 34;
                f.CancelButton = btnCancel;
            }

            // TextBox/ComboBox nhìn “êm”
            StyleControls(f.Controls);
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.Font = new Font("Segoe UI", 10F);
                }
                else if (c is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 10F);
                    if (cb.DropDownStyle == ComboBoxStyle.DropDown)
                        cb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = Green;
                    gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }

                if (c.HasChildren) StyleControls(c.Controls);
            }
        }
    }
}
