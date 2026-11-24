using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class NguoiDungRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT 
                    nd.MaNguoiDung,
                    nd.TenDangNhap,
                    nd.HoTen,
                    nd.SDT,
                    nd.TrangThai,
                    nd.MaVaiTro,
                    vt.TenVaiTro
                FROM dbo.NguoiDung nd
                LEFT JOIN dbo.VaiTro vt ON vt.MaVaiTro = nd.MaVaiTro
                ORDER BY nd.MaNguoiDung ASC

            ", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maNguoiDung)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT MaNguoiDung, TenDangNhap, MatKhau, HoTen, SDT, TrangThai, MaVaiTro
                FROM dbo.NguoiDung
                WHERE MaNguoiDung = @id
            ", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maNguoiDung;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        // Lookup Vai trò (ComboBox)
        public static DataTable GetVaiTroLookup()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT MaVaiTro, TenVaiTro
                FROM dbo.VaiTro
                ORDER BY MaVaiTro
            ", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Check trùng tên đăng nhập (khi thêm/sửa)
        public static bool ExistsTenDangNhap(string tenDangNhap, int? excludeMaNguoiDung)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(1)
                FROM dbo.NguoiDung
                WHERE TenDangNhap = @u
                  AND (@ex IS NULL OR MaNguoiDung <> @ex)
            ", con))
            {
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = tenDangNhap.Trim();
                cmd.Parameters.Add("@ex", SqlDbType.Int).Value = (object)excludeMaNguoiDung ?? DBNull.Value;

                con.Open();
                int c = Convert.ToInt32(cmd.ExecuteScalar());
                return c > 0;
            }
        }

        public static int Insert(string tenDangNhap, string matKhau, string hoTen, object sdtOrDbNull, string trangThai, int maVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.NguoiDung(TenDangNhap, MatKhau, HoTen, SDT, TrangThai, MaVaiTro)
                VALUES (@u, @p, @name, @sdt, @stt, @role);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = tenDangNhap.Trim();
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 255).Value = matKhau.Trim();
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = hoTen.Trim();
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 15).Value = sdtOrDbNull ?? (object)DBNull.Value;
                cmd.Parameters.Add("@stt", SqlDbType.NVarChar, 20).Value = trangThai.Trim();
                cmd.Parameters.Add("@role", SqlDbType.Int).Value = maVaiTro;

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Update có 2 kiểu:
        // - update không đổi mật khẩu
        // - update có đổi mật khẩu
        public static int UpdateNoPassword(int maNguoiDung, string tenDangNhap, string hoTen, object sdtOrDbNull, string trangThai, int maVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.NguoiDung
                SET TenDangNhap=@u,
                    HoTen=@name,
                    SDT=@sdt,
                    TrangThai=@stt,
                    MaVaiTro=@role
                WHERE MaNguoiDung=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maNguoiDung;
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = tenDangNhap.Trim();
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = hoTen.Trim();
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 15).Value = sdtOrDbNull ?? (object)DBNull.Value;
                cmd.Parameters.Add("@stt", SqlDbType.NVarChar, 20).Value = trangThai.Trim();
                cmd.Parameters.Add("@role", SqlDbType.Int).Value = maVaiTro;

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int UpdateWithPassword(int maNguoiDung, string tenDangNhap, string matKhau, string hoTen, object sdtOrDbNull, string trangThai, int maVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.NguoiDung
                SET TenDangNhap=@u,
                    MatKhau=@p,
                    HoTen=@name,
                    SDT=@sdt,
                    TrangThai=@stt,
                    MaVaiTro=@role
                WHERE MaNguoiDung=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maNguoiDung;
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = tenDangNhap.Trim();
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 255).Value = matKhau.Trim();
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = hoTen.Trim();
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 15).Value = sdtOrDbNull ?? (object)DBNull.Value;
                cmd.Parameters.Add("@stt", SqlDbType.NVarChar, 20).Value = trangThai.Trim();
                cmd.Parameters.Add("@role", SqlDbType.Int).Value = maVaiTro;

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maNguoiDung)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.NguoiDung WHERE MaNguoiDung=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maNguoiDung;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
