using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVuonNhan.Data
{
    internal static class VatTuRepo
    {
        public static DataTable GetAll()
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT MaVatTu, TenVatTu, LoaiVatTu, DonViTinh, SoLuongTon, DonGia
                  FROM dbo.VatTu
                  ORDER BY MaVatTu ASC", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetById(int maVatTu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT MaVatTu, TenVatTu, LoaiVatTu, DonViTinh, SoLuongTon, DonGia
                  FROM dbo.VatTu
                  WHERE MaVatTu=@id", con))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = maVatTu;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static int Insert(string tenVatTu, string loaiVatTu, string donViTinh, decimal soLuongTon, decimal donGia)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO dbo.VatTu(TenVatTu, LoaiVatTu, DonViTinh, SoLuongTon, DonGia)
                VALUES (@ten, @loai, @dvt, @ton, @gia);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ", con))
            {
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenVatTu.Trim();

                cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(loaiVatTu) ? (object)DBNull.Value : loaiVatTu.Trim();

                cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 20).Value =
                    string.IsNullOrWhiteSpace(donViTinh) ? (object)DBNull.Value : donViTinh.Trim();

                cmd.Parameters.Add("@ton", SqlDbType.Decimal).Value = soLuongTon;
                cmd.Parameters.Add("@gia", SqlDbType.Decimal).Value = donGia;

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int Update(int maVatTu, string tenVatTu, string loaiVatTu, string donViTinh, decimal soLuongTon, decimal donGia)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.VatTu
                SET TenVatTu=@ten, LoaiVatTu=@loai, DonViTinh=@dvt, SoLuongTon=@ton, DonGia=@gia
                WHERE MaVatTu=@id
            ", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maVatTu;
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenVatTu.Trim();

                cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(loaiVatTu) ? (object)DBNull.Value : loaiVatTu.Trim();

                cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 20).Value =
                    string.IsNullOrWhiteSpace(donViTinh) ? (object)DBNull.Value : donViTinh.Trim();

                cmd.Parameters.Add("@ton", SqlDbType.Decimal).Value = soLuongTon;
                cmd.Parameters.Add("@gia", SqlDbType.Decimal).Value = donGia;

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Delete(int maVatTu)
        {
            using (SqlConnection con = Db.CreateConnection())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.VatTu WHERE MaVatTu=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maVatTu;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
