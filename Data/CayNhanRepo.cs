using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class CayNhanRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT 
    c.MaCay, c.MaSoCay, c.NamTrong, c.TinhTrang, c.GhiChu,
    c.MaLo, lv.TenLo,
    c.MaGiong, gn.TenGiong
FROM dbo.CayNhan c
JOIN dbo.LoVuon lv ON lv.MaLo = c.MaLo
JOIN dbo.GiongNhan gn ON gn.MaGiong = c.MaGiong
ORDER BY c.MaCay ASC;", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable Search(string keyword)
        {
            keyword = (keyword ?? "").Trim();
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT 
    c.MaCay, c.MaSoCay, c.NamTrong, c.TinhTrang, c.GhiChu,
    c.MaLo, lv.TenLo,
    c.MaGiong, gn.TenGiong
FROM dbo.CayNhan c
JOIN dbo.LoVuon lv ON lv.MaLo = c.MaLo
JOIN dbo.GiongNhan gn ON gn.MaGiong = c.MaGiong
WHERE 
    c.MaSoCay LIKE @kw
    OR lv.TenLo LIKE @kw
    OR gn.TenGiong LIKE @kw
    OR ISNULL(c.TinhTrang,'') LIKE @kw
    OR ISNULL(c.GhiChu,'') LIKE @kw
ORDER BY c.MaCay DESC;", con))
            {
                da.SelectCommand.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" + keyword + "%";
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maCay)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT MaCay, MaSoCay, NamTrong, TinhTrang, GhiChu, MaLo, MaGiong
FROM dbo.CayNhan
WHERE MaCay=@id;", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maCay;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(string maSoCay, short? namTrong, string tinhTrang, string ghiChu, int maLo, int maGiong)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO dbo.CayNhan(MaSoCay, NamTrong, TinhTrang, GhiChu, MaLo, MaGiong)
VALUES (@ms, @nam, @tt, @gc, @malo, @magiong);
SELECT CAST(SCOPE_IDENTITY() AS int);", con))
            {
                cmd.Parameters.Add("@ms", SqlDbType.NVarChar, 30).Value = maSoCay.Trim();
                cmd.Parameters.Add("@nam", SqlDbType.SmallInt).Value = namTrong.HasValue ? (object)namTrong.Value : DBNull.Value;

                cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 30).Value =
                    string.IsNullOrWhiteSpace(tinhTrang) ? (object)DBNull.Value : tinhTrang.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@magiong", SqlDbType.Int).Value = maGiong;

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maCay, string maSoCay, short? namTrong, string tinhTrang, string ghiChu, int maLo, int maGiong)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
UPDATE dbo.CayNhan
SET 
    MaSoCay=@ms,
    NamTrong=@nam,
    TinhTrang=@tt,
    GhiChu=@gc,
    MaLo=@malo,
    MaGiong=@magiong
WHERE MaCay=@id;", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maCay;
                cmd.Parameters.Add("@ms", SqlDbType.NVarChar, 30).Value = maSoCay.Trim();
                cmd.Parameters.Add("@nam", SqlDbType.SmallInt).Value = namTrong.HasValue ? (object)namTrong.Value : DBNull.Value;

                cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 30).Value =
                    string.IsNullOrWhiteSpace(tinhTrang) ? (object)DBNull.Value : tinhTrang.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@magiong", SqlDbType.Int).Value = maGiong;

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maCay)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.CayNhan WHERE MaCay=@id;", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maCay;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Combo data
        public static DataTable GetLoVuonCombo()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaLo, TenLo FROM dbo.LoVuon ORDER BY TenLo;", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetGiongNhanCombo()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaGiong, TenGiong FROM dbo.GiongNhan ORDER BY TenGiong;", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
