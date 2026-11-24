using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class CongViecChamSocRepo
    {
        // ===== LIST (role-based) =====
        // role=1 Chủ vườn: thấy hết
        // role!=1 Nhân công: chỉ thấy việc của chính mình (MaNguoiDung)
        public static DataTable GetList(string keyword, int role, int maNguoiDung)
        {
            string kw = "%" + (keyword ?? "").Trim() + "%";

            string sql = @"
SELECT
    cv.MaCV,
    cv.NgayThucHien,
    lv.TenLo AS LoVuon,
    cv.LoaiCongViec,
    cv.NoiDung,
    cv.TrangThai,
    cv.MaCay,
    nd.HoTen AS NguoiLam
FROM dbo.CongViecChamSoc cv
JOIN dbo.LoVuon lv ON lv.MaLo = cv.MaLo
LEFT JOIN dbo.NguoiDung nd ON nd.MaNguoiDung = cv.MaNguoiDung
WHERE
(
    CAST(cv.MaCV AS nvarchar(20)) LIKE @kw
    OR ISNULL(lv.TenLo,'') LIKE @kw
    OR ISNULL(cv.LoaiCongViec,'') LIKE @kw
    OR ISNULL(cv.NoiDung,'') LIKE @kw
    OR ISNULL(cv.TrangThai,'') LIKE @kw
    OR ISNULL(nd.HoTen,'') LIKE @kw
    OR CAST(ISNULL(cv.MaCay,0) AS nvarchar(20)) LIKE @kw
)
AND
(
    @role = 1 OR cv.MaNguoiDung = @uid
)
ORDER BY cv.MaCV ASC;";

            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.Parameters.Add("@kw", SqlDbType.NVarChar, 220).Value = kw;
                da.SelectCommand.Parameters.Add("@role", SqlDbType.Int).Value = role;
                da.SelectCommand.Parameters.Add("@uid", SqlDbType.Int).Value = maNguoiDung;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ===== CRUD =====
        public static DataRow GetById(int maCV)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT TOP 1 *
FROM dbo.CongViecChamSoc
WHERE MaCV=@id
", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maCV;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(DateTime ngay, string loaiCV, string noiDung, string trangThai, string ghiChu,
                                 int maLo, object maCayOrNull, object maNguoiDungOrNull)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO dbo.CongViecChamSoc(NgayThucHien, LoaiCongViec, NoiDung, TrangThai, GhiChu, MaLo, MaCay, MaNguoiDung)
VALUES (@ngay, @loai, @nd, @tt, @gc, @malo, @macay, @mand);
SELECT CAST(SCOPE_IDENTITY() AS int);
", con))
            {
                cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay.Date;
                cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 50).Value = (loaiCV ?? "").Trim();
                cmd.Parameters.Add("@nd", SqlDbType.NVarChar, 200).Value = string.IsNullOrWhiteSpace(noiDung) ? (object)DBNull.Value : noiDung.Trim();
                cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 20).Value = (trangThai ?? "").Trim();
                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value = string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();
                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@macay", SqlDbType.Int).Value = (maCayOrNull == null) ? (object)DBNull.Value : maCayOrNull;
                cmd.Parameters.Add("@mand", SqlDbType.Int).Value = (maNguoiDungOrNull == null) ? (object)DBNull.Value : maNguoiDungOrNull;

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maCV, DateTime ngay, string loaiCV, string noiDung, string trangThai, string ghiChu,
                                 int maLo, object maCayOrNull, object maNguoiDungOrNull)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
UPDATE dbo.CongViecChamSoc
SET NgayThucHien=@ngay,
    LoaiCongViec=@loai,
    NoiDung=@nd,
    TrangThai=@tt,
    GhiChu=@gc,
    MaLo=@malo,
    MaCay=@macay,
    MaNguoiDung=@mand
WHERE MaCV=@id
", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maCV;
                cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay.Date;
                cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 50).Value = (loaiCV ?? "").Trim();
                cmd.Parameters.Add("@nd", SqlDbType.NVarChar, 200).Value = string.IsNullOrWhiteSpace(noiDung) ? (object)DBNull.Value : noiDung.Trim();
                cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 20).Value = (trangThai ?? "").Trim();
                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value = string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();
                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@macay", SqlDbType.Int).Value = (maCayOrNull == null) ? (object)DBNull.Value : maCayOrNull;
                cmd.Parameters.Add("@mand", SqlDbType.Int).Value = (maNguoiDungOrNull == null) ? (object)DBNull.Value : maNguoiDungOrNull;

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maCV)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.CongViecChamSoc WHERE MaCV=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maCV;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // ===== LOOKUPs (2 hàm mày bị thiếu) =====
        public static DataTable GetNguoiDungNhanCongLookup()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT MaNguoiDung, HoTen
FROM dbo.NguoiDung
WHERE MaVaiTro = 2 AND TrangThai = N'HoatDong'
ORDER BY HoTen
", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetCayNhanByLo(int maLo)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT MaCay, ISNULL(MaSoCay, CAST(MaCay AS nvarchar(20))) AS MaSoCay
FROM dbo.CayNhan
WHERE MaLo = @malo
ORDER BY MaCay DESC
", con))
            {
                da.SelectCommand.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetLoVuonLookup()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT MaLo, TenLo
FROM dbo.LoVuon
ORDER BY TenLo
", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
