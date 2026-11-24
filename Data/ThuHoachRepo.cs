using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class ThuHoachRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT  th.MaThuHoach,
                        th.MaLo,
                        lv.TenLo,
                        th.MaNguoiDung,
                        nd.HoTen AS NguoiGhiNhan,
                        th.NgayThuHoach,
                        th.SanLuong,
                        th.PhanLoai,
                        th.GhiChu
                FROM dbo.ThuHoach th
                INNER JOIN dbo.LoVuon lv ON lv.MaLo = th.MaLo
                LEFT JOIN dbo.NguoiDung nd ON nd.MaNguoiDung = th.MaNguoiDung
                ORDER BY th.MaThuHoach ASC
            ", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maThuHoach)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT  th.MaThuHoach,
                        th.MaLo,
                        th.MaNguoiDung,
                        th.NgayThuHoach,
                        th.SanLuong,
                        th.PhanLoai,
                        th.GhiChu
                FROM dbo.ThuHoach th
                WHERE th.MaThuHoach = @id
            ", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maThuHoach;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static DataTable GetLoVuonForCombo()
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

        public static int Insert(int maLo, int maNguoiDung, DateTime ngayThuHoach, decimal sanLuong, string phanLoai, string ghiChu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.ThuHoach(MaLo, MaNguoiDung, NgayThuHoach, SanLuong, PhanLoai, GhiChu)
                VALUES (@malo, @mand, @ngay, @sl, @pl, @gc);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@mand", SqlDbType.Int).Value = maNguoiDung;
                cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = ngayThuHoach.Date;
                cmd.Parameters.Add("@sl", SqlDbType.Decimal).Value = sanLuong;

                cmd.Parameters.Add("@pl", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(phanLoai) ? (object)DBNull.Value : phanLoai.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maThuHoach, int maLo, DateTime ngayThuHoach, decimal sanLuong, string phanLoai, string ghiChu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.ThuHoach
                SET MaLo=@malo,
                    NgayThuHoach=@ngay,
                    SanLuong=@sl,
                    PhanLoai=@pl,
                    GhiChu=@gc
                WHERE MaThuHoach=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maThuHoach;
                cmd.Parameters.Add("@malo", SqlDbType.Int).Value = maLo;
                cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = ngayThuHoach.Date;
                cmd.Parameters.Add("@sl", SqlDbType.Decimal).Value = sanLuong;

                cmd.Parameters.Add("@pl", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(phanLoai) ? (object)DBNull.Value : phanLoai.Trim();

                cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maThuHoach)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.ThuHoach WHERE MaThuHoach=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maThuHoach;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
