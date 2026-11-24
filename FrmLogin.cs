using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLVuonNhan
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Enter/Esc
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Hook show password
            chkShowPass.CheckedChanged -= chkShowPass_CheckedChanged;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
        }

        public void ResetFields()
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ApplyTheme();

            txtPass.UseSystemPasswordChar = true;
            txtUser.Focus();
        }

        private void ApplyTheme()
        {
            // Form background
            this.BackColor = Color.FromArgb(245, 246, 248);

            // Top bar
            pnlTop.BackColor = Color.FromArgb(33, 115, 70); // xanh giống main
            lblAppName.ForeColor = Color.White;

            // Card
            pnlCard.BackColor = Color.White;

            // Title
            lblTitle.ForeColor = Color.Black;

            // Textbox style (nhẹ thôi)
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtPass.BorderStyle = BorderStyle.FixedSingle;

            // Login button (nhấn mạnh)
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(46, 125, 50);
            btnLogin.ForeColor = Color.White;

            // Exit button (phụ)
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.BackColor = Color.FromArgb(230, 230, 230);
            btnExit.ForeColor = Color.Black;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = (txtUser.Text ?? "").Trim();
            string pass = txtPass.Text ?? "";

            if (user.Length == 0 || pass.Length == 0)
            {
                MessageBox.Show("Nhập đủ tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                using (SqlConnection con = Db.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 
                        nd.MaNguoiDung,
                        nd.TenDangNhap,
                        nd.HoTen,
                        nd.MaVaiTro,
                        nd.TrangThai,
                        vt.TenVaiTro
                    FROM dbo.NguoiDung nd
                    LEFT JOIN dbo.VaiTro vt ON vt.MaVaiTro = nd.MaVaiTro
                    WHERE nd.TenDangNhap = @u AND nd.MatKhau = @p
                ", con))
                {
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = user;
                    cmd.Parameters.Add("@p", SqlDbType.NVarChar, 255).Value = pass;

                    con.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                            return;
                        }

                        string trangThai = rd["TrangThai"] == DBNull.Value ? "" : rd["TrangThai"].ToString();
                        if (!trangThai.Equals("HoatDong", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Tài khoản đang bị khóa/không hoạt động!");
                            return;
                        }

                        int maNguoiDung = Convert.ToInt32(rd["MaNguoiDung"]);
                        string hoTen = rd["HoTen"] == DBNull.Value ? "" : rd["HoTen"].ToString();
                        int maVaiTro = Convert.ToInt32(rd["MaVaiTro"]);

                        string tenVaiTro = rd["TenVaiTro"] == DBNull.Value ? "" : rd["TenVaiTro"].ToString();
                        if (string.IsNullOrWhiteSpace(tenVaiTro))
                            tenVaiTro = (maVaiTro == 1) ? "ChuVuon" : "NhanCong";

                        string tenDangNhap = user;

                        FrmMain main = new FrmMain(maNguoiDung, maVaiTro, hoTen, tenVaiTro, tenDangNhap);

                        main.FormClosed += (s, args) =>
                        {
                            this.Show();
                            ResetFields();
                        };

                        main.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập:\n" + ex.Message);
            }
        }
    }
}
