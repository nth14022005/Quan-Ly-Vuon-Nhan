using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class VaiTroRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaVaiTro, TenVaiTro FROM dbo.VaiTro ORDER BY MaVaiTro ASC", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaVaiTro, TenVaiTro FROM dbo.VaiTro WHERE MaVaiTro=@id", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maVaiTro;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(string tenVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.VaiTro(TenVaiTro)
                VALUES (@ten);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50).Value = tenVaiTro.Trim();
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maVaiTro, string tenVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.VaiTro
                SET TenVaiTro=@ten
                WHERE MaVaiTro=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maVaiTro;
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50).Value = tenVaiTro.Trim();
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maVaiTro)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.VaiTro WHERE MaVaiTro=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maVaiTro;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Đổ vào ComboBox (Form Người Dùng sẽ xài)
        public static DataTable GetLookup()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaVaiTro, TenVaiTro FROM dbo.VaiTro ORDER BY MaVaiTro", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
