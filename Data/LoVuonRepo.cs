using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class LoVuonRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT MaLo, TenLo, DienTich, ViTri, GhiChu
                FROM dbo.LoVuon
                ORDER BY MaLo ASC

            ", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable Search(string keyword)
        {
            string kw = (keyword ?? "").Trim();

            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT MaLo, TenLo, DienTich, ViTri, GhiChu
                FROM dbo.LoVuon
                WHERE (@kw = N'' 
                       OR TenLo  LIKE @likeKw
                       OR ISNULL(ViTri,  N'') LIKE @likeKw
                       OR ISNULL(GhiChu, N'') LIKE @likeKw)
                ORDER BY MaLo DESC
            ", con))
            {
                da.SelectCommand.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value = kw;
                da.SelectCommand.Parameters.Add("@likeKw", SqlDbType.NVarChar, 110).Value = "%" + kw + "%";

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maLo)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT MaLo, TenLo, DienTich, ViTri, GhiChu
                FROM dbo.LoVuon
                WHERE MaLo = @id
            ", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maLo;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(string tenLo, decimal dienTich, string viTri, string ghiChu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.LoVuon(TenLo, DienTich, ViTri, GhiChu)
                VALUES (@ten, @dt, @vt, @gc);

                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = (tenLo ?? "").Trim();
                cmd.Parameters.Add("@dt", SqlDbType.Decimal).Value = dienTich;

                // set precision/scale cho decimal (an toàn)
                cmd.Parameters["@dt"].Precision = 18;
                cmd.Parameters["@dt"].Scale = 2;

                cmd.Parameters.Add("@vt", SqlDbType.NVarChar, 100).Value =
                    string.IsNullOrWhiteSpace(viTri) ? (object)DBNull.Value : viTri.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maLo, string tenLo, decimal dienTich, string viTri, string ghiChu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.LoVuon
                SET TenLo   = @ten,
                    DienTich= @dt,
                    ViTri   = @vt,
                    GhiChu  = @gc
                WHERE MaLo  = @id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maLo;

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = (tenLo ?? "").Trim();
                cmd.Parameters.Add("@dt", SqlDbType.Decimal).Value = dienTich;
                cmd.Parameters["@dt"].Precision = 18;
                cmd.Parameters["@dt"].Scale = 2;

                cmd.Parameters.Add("@vt", SqlDbType.NVarChar, 100).Value =
                    string.IsNullOrWhiteSpace(viTri) ? (object)DBNull.Value : viTri.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maLo)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                DELETE FROM dbo.LoVuon
                WHERE MaLo = @id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maLo;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
