using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QLVuonNhan
{
    public partial class FrmLoVuonEdit : Form
    {
        private readonly int? _maLo;

        // ====== Auto center group ======
        private bool _centerInited = false;
        private readonly Dictionary<Control, Point> _basePos = new Dictionary<Control, Point>();
        private Rectangle _baseBounds;
        private Control[] _centerControls = new Control[0];
        private Label _headerLabel;

        public FrmLoVuonEdit(int? maLo)
        {
            InitializeComponent();
            _maLo = maLo;

            this.Load -= FrmLoVuonEdit_Load;
            this.Load += FrmLoVuonEdit_Load;
        }

        private void FrmLoVuonEdit_Load(object sender, EventArgs e)
        {
            // Theme
            EditTheme.Apply(this, btnSave, btnCancel);

            string title = _maLo.HasValue ? "Sửa lô vườn" : "Thêm lô vườn";
            this.Text = title;

            // tìm đúng label tiêu đề (quét đệ quy), tránh bắt nhầm label "Ghi chú:"
            _headerLabel = FindHeaderLabelDeep(this);
            if (_headerLabel != null) _headerLabel.Text = title;

            if (_maLo.HasValue) LoadOne(_maLo.Value);

            InitCentering();
        }

        // ====== FIND HEADER LABEL (FIX BẮT NHẦM) ======
        private IEnumerable<Control> GetAllControls(Control root)
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
            // label dạng "Tên lô:" "Ghi chú:" thường kết thúc bằng ":" hoặc ngắn
            string t = (lb.Text ?? "").Trim();
            if (t.EndsWith(":")) return true;
            return false;
        }

        private Label FindHeaderLabelDeep(Control root)
        {
            var labels = GetAllControls(root).OfType<Label>().ToList();
            if (labels.Count == 0) return null;

            // ưu tiên theo Name
            string[] preferNames = { "lblTitle", "lblHeader", "lblTieuDe", "lblTieuDeForm" };
            foreach (string n in preferNames)
            {
                var lb = labels.FirstOrDefault(x => string.Equals(x.Name, n, StringComparison.OrdinalIgnoreCase));
                if (lb != null) return lb;
            }

            // ưu tiên label tiêu đề: không phải field label, nằm phía trên, chữ to, thường căn giữa
            var candidates = labels
                .Where(lb => lb.Visible)
                .Where(lb => !IsFieldLabel(lb))
                .Where(lb => lb.Top <= 120) // tiêu đề thường ở trên
                .ToList();

            if (candidates.Count == 0) candidates = labels.Where(lb => lb.Visible && !IsFieldLabel(lb)).ToList();
            if (candidates.Count == 0) return null;

            // chọn cái "giống tiêu đề" nhất
            return candidates
                .OrderByDescending(lb => lb.Font != null ? lb.Font.Size : 0f)
                .ThenByDescending(lb => lb.Width)
                .ThenBy(lb => lb.Top)
                .FirstOrDefault();
        }

        // ====== CENTER GROUP ======
        private void InitCentering()
        {
            if (_centerInited) return;

            // chỉ center các control dạng input/label/button ở tầng top-level (form này mày đang để top-level)
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
            foreach (var c in _centerControls)
                _basePos[c] = c.Location;

            this.Resize -= FrmLoVuonEdit_Resize;
            this.Resize += FrmLoVuonEdit_Resize;

            _centerInited = true;
            CenterGroup();
        }

        private void FrmLoVuonEdit_Resize(object sender, EventArgs e) => CenterGroup();

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
                if (!_basePos.ContainsKey(c)) continue;
                var baseP = _basePos[c];
                c.Location = new Point(baseP.X + offsetX, baseP.Y + offsetY);
            }
        }

        // ====== LOAD ======
        private void LoadOne(int maLo)
        {
            try
            {
                using (SqlConnection con = Db.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TenLo, DienTich, ViTri, GhiChu
                    FROM dbo.LoVuon
                    WHERE MaLo=@id
                ", con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = maLo;

                    con.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Không tìm thấy lô vườn.");
                            this.Close();
                            return;
                        }

                        txtTenLo.Text = rd["TenLo"].ToString();
                        txtDienTich.Text = rd["DienTich"].ToString();
                        txtViTri.Text = rd["ViTri"] == DBNull.Value ? "" : rd["ViTri"].ToString();
                        txtGhiChu.Text = rd["GhiChu"] == DBNull.Value ? "" : rd["GhiChu"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu:\n" + ex.Message);
            }
        }

        private bool TryGetInputs(out string tenLo, out decimal dienTich, out string viTri, out string ghiChu)
        {
            tenLo = (txtTenLo.Text ?? "").Trim();
            viTri = (txtViTri.Text ?? "").Trim();
            ghiChu = (txtGhiChu.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(tenLo))
            {
                MessageBox.Show("Tên lô không được trống.");
                dienTich = 0;
                return false;
            }

            string raw = (txtDienTich.Text ?? "").Trim().Replace(',', '.');
            if (!decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out dienTich) || dienTich < 0)
            {
                MessageBox.Show("Diện tích không hợp lệ.");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenLo, viTri, ghiChu;
            decimal dienTich;

            if (!TryGetInputs(out tenLo, out dienTich, out viTri, out ghiChu))
                return;

            try
            {
                using (SqlConnection con = Db.CreateConnection())
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    if (_maLo.HasValue)
                    {
                        cmd.CommandText = @"
                            UPDATE dbo.LoVuon
                            SET TenLo=@ten, DienTich=@dt, ViTri=@vt, GhiChu=@gc
                            WHERE MaLo=@id
                        ";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = _maLo.Value;
                    }
                    else
                    {
                        cmd.CommandText = @"
                            INSERT INTO dbo.LoVuon(TenLo, DienTich, ViTri, GhiChu)
                            VALUES (@ten, @dt, @vt, @gc)
                        ";
                    }

                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenLo;

                    var pDt = cmd.Parameters.Add("@dt", SqlDbType.Decimal);
                    pDt.Precision = 18;
                    pDt.Scale = 2;
                    pDt.Value = dienTich;

                    cmd.Parameters.Add("@vt", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(viTri) ? (object)DBNull.Value : viTri;

                    cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                        string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu:\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        // giữ để Designer khỏi báo thiếu event nếu lỡ có trỏ
        private void txtGhiChu_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
 