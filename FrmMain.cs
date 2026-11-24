using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLVuonNhan
{
    public partial class FrmMain : Form
    {
        // ===== user info =====
        private int _maNguoiDung;
        private int _maVaiTro;
        private string _hoTen;
        private string _tenVaiTro;
        private string _tenDangNhap;

        // ===== UI =====
        private Panel _topBar;
        private Panel _nav;
        private FlowLayoutPanel _navList;
        private Button _btnAccount;

        private ContextMenuStrip _accMenu;

        // MDI
        private MdiClient _mdi;

        // dashboard form (MDI child)
        private FrmDashboard _dashboard;

        // ctor cho Designer
        public FrmMain()
        {
            InitializeComponent();

            this.Load -= FrmMain_Load;
            this.Load += FrmMain_Load;

            this.FormClosed -= FrmMain_FormClosed;
            this.FormClosed += FrmMain_FormClosed;

            this.IsMdiContainer = true;
        }

        // ctor chạy thật (Login gọi)
        public FrmMain(int maNguoiDung, int maVaiTro, string hoTen, string tenVaiTro, string tenDangNhap) : this()
        {
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
            _hoTen = hoTen ?? "";
            _tenVaiTro = tenVaiTro ?? "";
            _tenDangNhap = tenDangNhap ?? "";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BuildShell();
            ApplyRoleNav();

            // lấy MdiClient & chỉnh size để KHÔNG đè lên nav/topbar
            HookMdiClient();
            LayoutMdiClient();

            this.Resize -= FrmMain_Resize;
            this.Resize += FrmMain_Resize;

            // dashboard
            ShowDashboard();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            LayoutMdiClient();
        }

        private void BuildShell()
        {
            // nếu designer có MenuStrip thì ẩn (vì dùng nav trái)
            foreach (var ms in this.Controls.OfType<MenuStrip>())
                ms.Visible = false;

            this.Text = "QL Vườn Nhãn";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // ===== TopBar =====
            _topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = MainTheme.GreenDark
            };
            this.Controls.Add(_topBar);

            var lbl = new Label
            {
                AutoSize = true,
                Text = "QL VƯỜN NHÃN",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                Location = new Point(12, 12)
            };
            _topBar.Controls.Add(lbl);

            _btnAccount = new Button
            {
                Text = $"{_hoTen} ({_tenVaiTro}) ▼",
                AutoSize = true,
                Height = 28,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            _btnAccount.Location = new Point(_topBar.Width - _btnAccount.Width - 12, 9);
            _topBar.Controls.Add(_btnAccount);

            _topBar.Resize += (s, e) =>
            {
                _btnAccount.Left = _topBar.Width - _btnAccount.Width - 12;
            };

            // style theo MainTheme
            MainTheme.Apply(this, null, _btnAccount);

            // menu tài khoản
            _accMenu = new ContextMenuStrip();
            _accMenu.Items.Add("Trang chủ", null, (s, e) => ShowDashboard());
            _accMenu.Items.Add("Đăng xuất", null, (s, e) => this.Close());
            _accMenu.Items.Add("Thoát", null, (s, e) => Application.Exit());

            _btnAccount.Click -= btnAccount_Click;
            _btnAccount.Click += btnAccount_Click;

            // ===== Nav trái =====
            _nav = new Panel
            {
                Dock = DockStyle.Left,
                Width = 230,
                BackColor = MainTheme.Beige
            };
            this.Controls.Add(_nav);
            _nav.BringToFront();

            var navTitle = new Label
            {
                Text = "CHỨC NĂNG",
                AutoSize = true,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = MainTheme.GreenDark,
                Location = new Point(14, 14)
            };
            _nav.Controls.Add(navTitle);

            _navList = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(12, 44, 12, 12),
                BackColor = MainTheme.Beige
            };
            _nav.Controls.Add(_navList);

            // buttons (tạo hết, lát role sẽ ẩn bớt)
            AddNavButton("🏠 Trang chủ", (s, e) => ShowDashboard());
            AddNavButton("🧩 Lô vườn", (s, e) => OpenChild(new FrmLoVuonList()));
            AddNavButton("🌱 Giống nhãn", (s, e) => OpenChild(new FrmGiongNhanList()));
            AddNavButton("🌳 Cây nhãn", (s, e) => OpenChild(new FrmCayNhanList()));
            AddNavButton("🧪 Vật tư", (s, e) => OpenChild(new FrmVatTuList()));
            AddNavButton("🧺 Thu hoạch", (s, e) => OpenChild(new FrmThuHoachList(_maNguoiDung)));
            AddNavButton("🛠 Công việc chăm sóc", (s, e) => OpenChild(new FrmCongViecChamSocList(_maNguoiDung, _maVaiTro)));
            AddNavButton("👤 Người dùng", (s, e) => OpenChild(new FrmNguoiDungList()));
            AddNavButton("🔐 Vai trò", (s, e) => OpenChild(new FrmVaiTroList()));
            AddNavButton("🚪 Đăng xuất", (s, e) => this.Close());

            // đưa topbar lên trước MDI
            _topBar.BringToFront();
        }

        private void AddNavButton(string text, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = 190,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(40, 40, 40),
                Margin = new Padding(0, 0, 0, 10)
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            btn.FlatAppearance.BorderSize = 1;

            btn.Click += onClick;
            _navList.Controls.Add(btn);
        }

        private void ApplyRoleNav()
        {
            bool isChuVuon = (_maVaiTro == 1);

            // Nhân công: chỉ cho Trang chủ + Công việc chăm sóc + Đăng xuất
            if (!isChuVuon)
            {
                foreach (Control c in _navList.Controls)
                {
                    var t = (c as Button)?.Text ?? "";
                    bool keep =
                        t.Contains("Trang chủ") ||
                        t.Contains("Công việc chăm sóc") ||
                        t.Contains("Đăng xuất");
                    c.Visible = keep;
                }
            }
        }

        private void HookMdiClient()
        {
            _mdi = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (_mdi == null) return;

            // bỏ dock fill mặc định để tự canh theo nav/topbar
            _mdi.Dock = DockStyle.None;
            _mdi.BackColor = MainTheme.Beige2;
          
        }

        private void LayoutMdiClient()
        {
            if (_mdi == null) _mdi = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (_mdi == null) return;

            int left = _nav?.Width ?? 0;
            int top = _topBar?.Height ?? 0;

            _mdi.Location = new Point(left, top);
            _mdi.Size = new Size(this.ClientSize.Width - left, this.ClientSize.Height - top);
            _mdi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (_accMenu == null) return;
            _accMenu.Show(_btnAccount, new Point(0, _btnAccount.Height));
        }

        private void ShowDashboard()
        {
            CloseAllChildren();

            if (_dashboard == null || _dashboard.IsDisposed)
                _dashboard = new FrmDashboard(_hoTen, _tenVaiTro);

            _dashboard.MdiParent = this;
            _dashboard.WindowState = FormWindowState.Maximized;
            _dashboard.Show();
            _dashboard.BringToFront();
        }

        private void CloseAllChildren()
        {
            foreach (var f in this.MdiChildren.ToList())
            {
                try { f.Close(); } catch { }
            }
        }

        private void OpenChild(Form f)
        {
            if (f == null) return;

            // đóng dashboard trước
            if (_dashboard != null && !_dashboard.IsDisposed)
            {
                try { _dashboard.Close(); } catch { }
            }

            // đóng form khác nếu muốn 1 màn hình 1 form
            foreach (var ch in this.MdiChildren.ToList())
            {
                try { ch.Close(); } catch { }
            }

            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            f.BringToFront();
        }

        // nếu Designer đang wire event này thì để lại
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // không làm gì ở đây, Login đã hook FormClosed để hiện lại
        }

        // ====== nếu Designer của mày còn đang trỏ mấy event cũ thì để stub cho khỏi lỗi ======
        private void mnuVatTu_Click(object sender, EventArgs e) => OpenChild(new FrmVatTuList());
        private void mnuNguoiDung_Click(object sender, EventArgs e) => OpenChild(new FrmNguoiDungList());
        private void mnuLoVuon_Click(object sender, EventArgs e) => OpenChild(new FrmLoVuonList());
        private void mnuGiongNhan_Click(object sender, EventArgs e) => OpenChild(new FrmGiongNhanList());
        private void mnuCayNhan_Click(object sender, EventArgs e) => OpenChild(new FrmCayNhanList());
        private void mnuCongViecChamSoc_Click(object sender, EventArgs e) => OpenChild(new FrmCongViecChamSocList(_maNguoiDung, _maVaiTro));
        private void btnAccount_Click_Designer(object sender, EventArgs e) => btnAccount_Click(sender, e);
    }
}
