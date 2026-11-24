using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLVuonNhan.Data;

namespace QLVuonNhan
{
    public partial class FrmGiongNhanEdit : Form
    {
        private readonly int? _maGiong;

        // ====== Auto center group ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = new Control[0];
        private Label _headerLabel;

        public FrmGiongNhanEdit()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmGiongNhanEdit(int maGiong) : this()
        {
            _maGiong = maGiong;
        }

        private void WireEvents()
        {
            this.Load -= FrmGiongNhanEdit_Load;
            this.Load += FrmGiongNhanEdit_Load;

            if (btnSave != null)
            {
                btnSave.Click -= btnSave_Click;
                btnSave.Click += btnSave_Click;
            }

            if (btnCancel != null)
            {
                btnCancel.Click -= btnCancel_Click;
                btnCancel.Click += btnCancel_Click;
            }

            this.Resize -= FrmGiongNhanEdit_Resize;
            this.Resize += FrmGiongNhanEdit_Resize;
        }

        private void FrmGiongNhanEdit_Load(object sender, EventArgs e)
        {
            // Apply theme giống LoVuonEdit
            EditTheme.Apply(this, btnSave, btnCancel);

            string title = (_maGiong == null) ? "Thêm giống nhãn" : "Sửa giống nhãn";
            this.Text = title;

            // tìm label tiêu đề và set text cho đúng (tránh bắt nhầm label "Tên giống:")
            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            if (_maGiong != null)
                LoadOne(_maGiong.Value);

            InitCentering();

            // tiện sử dụng
            if (btnSave != null) this.AcceptButton = btnSave;
            if (btnCancel != null) this.CancelButton = btnCancel;
        }

        private void LoadOne(int maGiong)
        {
            DataRow r = GiongNhanRepo.GetById(maGiong);
            if (r == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                Close();
                return;
            }

            if (txtTenGiong != null)
                txtTenGiong.Text = r["TenGiong"] == DBNull.Value ? "" : r["TenGiong"].ToString();

            if (txtMoTa != null)
                txtMoTa.Text = r["MoTa"] == DBNull.Value ? "" : r["MoTa"].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ten = (txtTenGiong != null ? txtTenGiong.Text : "").Trim();
            string moTa = (txtMoTa != null ? txtMoTa.Text : "").Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên giống không được trống.");
                if (txtTenGiong != null) txtTenGiong.Focus();
                return;
            }

            if (ten.Length > 100)
            {
                MessageBox.Show("Tên giống tối đa 100 ký tự.");
                return;
            }

            if (moTa.Length > 200)
            {
                MessageBox.Show("Mô tả tối đa 200 ký tự.");
                return;
            }

            try
            {
                if (_maGiong == null) GiongNhanRepo.Insert(ten, moTa);
                else GiongNhanRepo.Update(_maGiong.Value, ten, moTa);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        // ================== AUTO CENTER ==================
        private void FrmGiongNhanEdit_Resize(object sender, EventArgs e)
        {
            CenterGroup();
        }

        private void InitCentering()
        {
            if (_centerInited) return;

            // center các control top-level (tránh Panel/GroupBox để khỏi lệch)
            _centerControls = this.Controls.Cast<Control>()
                .Where(c => c.Visible)
                .Where(c => c.Dock == DockStyle.None)
                .Where(c => !(c is Panel) && !(c is GroupBox))
                .Where(c => !ReferenceEquals(c, _headerLabel))
                .ToArray();

            if (_centerControls.Length == 0) return;

            int minX = _centerControls.Min(c => c.Left);
            int minY = _centerControls.Min(c => c.Top);
            int maxX = _centerControls.Max(c => c.Right);
            int maxY = _centerControls.Max(c => c.Bottom);
            _baseBounds = Rectangle.FromLTRB(minX, minY, maxX, maxY);

            _basePos.Clear();
            foreach (var c in _centerControls) _basePos[c] = c.Location;

            _centerInited = true;
            CenterGroup();
        }

        private void CenterGroup()
        {
            if (!_centerInited || _centerControls == null || _centerControls.Length == 0) return;

            int topReserved = this.Controls.Cast<Control>()
                .Where(c => c.Dock == DockStyle.Top)
                .Sum(c => c.Height);

            int usableH = this.ClientSize.Height - topReserved;
            if (usableH < 1) usableH = this.ClientSize.Height;

            int offsetX = (this.ClientSize.Width - _baseBounds.Width) / 2 - _baseBounds.Left;
            int offsetY = topReserved + (usableH - _baseBounds.Height) / 2 - _baseBounds.Top;
            if (offsetY < topReserved + 10) offsetY = topReserved + 10;

            foreach (var c in _centerControls)
            {
                Point baseP;
                if (!_basePos.TryGetValue(c, out baseP)) continue;
                c.Location = new Point(baseP.X + offsetX, baseP.Y + offsetY);
            }
        }

        // ================== FIND HEADER LABEL (KHÔNG BẮT NHẦM LABEL FIELD) ==================
        private System.Collections.Generic.IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (var cc in GetAllControls(c))
                    yield return cc;
            }
        }

        private bool IsFieldLabel(Label lb)
        {
            string t = (lb.Text ?? "").Trim();
            return t.EndsWith(":");
        }

        private Label FindHeaderLabelDeep(Control root)
        {
            var labels = GetAllControls(root).OfType<Label>().ToList();
            if (labels.Count == 0) return null;

            // ưu tiên theo Name nếu mày đặt lblTitle
            string[] preferNames = { "lblTitle", "lblHeader", "lblTieuDe", "lblTieuDeForm" };
            foreach (string n in preferNames)
            {
                var lb = labels.FirstOrDefault(x => string.Equals(x.Name, n, StringComparison.OrdinalIgnoreCase));
                if (lb != null) return lb;
            }

            // ưu tiên tiêu đề: chữ to + ở trên
            var candidates = labels
                .Where(lb => lb.Visible)
                .Where(lb => !IsFieldLabel(lb))
                .Where(lb => lb.Top <= 140)
                .ToList();

            if (candidates.Count == 0) candidates = labels.Where(lb => lb.Visible && !IsFieldLabel(lb)).ToList();
            if (candidates.Count == 0) return null;

            return candidates
                .OrderByDescending(lb => lb.Font != null ? lb.Font.Size : 0f)
                .ThenByDescending(lb => lb.Width)
                .ThenBy(lb => lb.Top)
                .FirstOrDefault();
        }
    }
}
