using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class GiongNhanRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaGiong, TenGiong, MoTa FROM dbo.GiongNhan ORDER BY MaGiong ASC", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maGiong)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaGiong, TenGiong, MoTa FROM dbo.GiongNhan WHERE MaGiong=@id", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maGiong;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(string tenGiong, string moTa)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.GiongNhan(TenGiong, MoTa)
                VALUES (@ten, @mota);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenGiong.Trim();
                cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(moTa) ? (object)DBNull.Value : moTa.Trim();

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maGiong, string tenGiong, string moTa)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.GiongNhan
                SET TenGiong=@ten, MoTa=@mota
                WHERE MaGiong=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maGiong;
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenGiong.Trim();
                cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(moTa) ? (object)DBNull.Value : moTa.Trim();

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maGiong)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.GiongNhan WHERE MaGiong=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maGiong;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
