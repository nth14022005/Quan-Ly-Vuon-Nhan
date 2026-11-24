using System.Drawing;
using System.Windows.Forms;

namespace QLVuonNhan
{
    internal static class MainTheme
    {
        public static readonly Color Green = Color.FromArgb(46, 125, 50);
        public static readonly Color GreenDark = Color.FromArgb(27, 94, 32);
        public static readonly Color Beige = Color.FromArgb(253, 248, 235);
        public static readonly Color Beige2 = Color.FromArgb(245, 242, 236);

        public static void Apply(Form f, MenuStrip menu, Control btnAccount)
        {
            f.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            f.BackColor = Beige2;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.WindowState = FormWindowState.Maximized;

            if (menu != null)
            {
                menu.BackColor = GreenDark;
                menu.ForeColor = Color.White;
                menu.Renderer = new MainMenuRenderer();
                StyleMenuItems(menu);
            }

            // Button tài khoản (nếu là Button)
            if (btnAccount is Button b)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Green;
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                b.Padding = new Padding(10, 0, 10, 0);
            }
        }

        private static void StyleMenuItems(MenuStrip menu)
        {
            foreach (ToolStripItem it in menu.Items)
                StyleTopItem(it);
        }

        private static void StyleTopItem(ToolStripItem item)
        {
            item.ForeColor = Color.White;
            item.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            if (item is ToolStripMenuItem mi)
                foreach (ToolStripItem sub in mi.DropDownItems)
                    StyleDropItem(sub);
        }

        private static void StyleDropItem(ToolStripItem item)
        {
            item.ForeColor = Color.Black;
            item.Font = new Font("Segoe UI", 10f, FontStyle.Regular);

            if (item is ToolStripMenuItem mi)
                foreach (ToolStripItem sub in mi.DropDownItems)
                    StyleDropItem(sub);
        }
    }

    internal sealed class MainMenuRenderer : ToolStripProfessionalRenderer
    {
        public MainMenuRenderer() : base(new MainColorTable()) { }
    }

    internal sealed class MainColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => MainTheme.GreenDark;
        public override Color MenuStripGradientEnd => MainTheme.GreenDark;

        public override Color MenuItemSelected => Color.FromArgb(56, 142, 60);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(56, 142, 60);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(56, 142, 60);

        public override Color ToolStripDropDownBackground => Color.White;

        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
    }
}
