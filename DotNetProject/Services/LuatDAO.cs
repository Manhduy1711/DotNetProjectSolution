using DotNetProject.Models;
using System.Data.SqlClient;

namespace DotNetProject.Services
{
    public class LuatDAO
    {
        string connectionString = @"Data Source=.;Initial Catalog=DotNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<DataModel> FetchAll()
        {
            List<DataModel> list = new List<DataModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "select * from dbo.luat";
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new DataModel
                        {
                            Chuong = (string)reader[0],
                            NoiDungChuong = (string)reader[1],
                            Muc = (Convert.IsDBNull(reader[2]) ? null : (int?)reader[2]),
                            NoiDungMuc = (Convert.IsDBNull(reader[3]) ? null : (string?)reader[3]),
                            Dieu = (int)reader[4],
                            NoiDungDieu = (string)reader[5],
                            Khoan = (Convert.IsDBNull(reader[6]) ? null : (int?)reader[6]),
                            NoiDung = (string)reader[7],
                            MucPhatDuoi = (Convert.IsDBNull(reader[8]) ? null : (int?)reader[8]),
                            MucPhatTren = (Convert.IsDBNull(reader[9]) ? null : (int?)reader[9]),
                            Id = (int)reader[10]
                        });
                    }
                }

            }
            return list;
        }
        public DataModel FetchOne(int id)
        {
            DataModel detail = new DataModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "select * from dbo.luat where Id = @id";
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        detail = new DataModel
                        {
                            Chuong = (string)reader[0],
                            NoiDungChuong = (string)reader[1],
                            Muc = (Convert.IsDBNull(reader[2]) ? null : (int?)reader[2]),
                            NoiDungMuc = (Convert.IsDBNull(reader[3]) ? null : (string?)reader[3]),
                            Dieu = (int)reader[4],
                            NoiDungDieu = (string)reader[5],
                            Khoan = (Convert.IsDBNull(reader[6]) ? null : (int?)reader[6]),
                            NoiDung = (string)reader[7],
                            MucPhatDuoi = (Convert.IsDBNull(reader[8]) ? null : (int?)reader[8]),
                            MucPhatTren = (Convert.IsDBNull(reader[9]) ? null : (int?)reader[9]),
                            Id = (int)reader[10]
                        };
                    }
                }

            }
            return detail;
        }
        public int CreateOrUpdate(DataModel dataModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "";
                if (dataModel.Id <= 0)
                {
                    SqlQuery = "insert into dbo.luat values(@Chuong,@NoiDungChuong, @Muc, @NoiDungMuc,@Dieu, @NoiDungDieu,@Khoan, @NoiDung,@MucPhatDuoi,@MucPhatTren)";
                }
                else
                {
                    SqlQuery = "update dbo.luat set [Chương] = @Chuong, [Nội dung Chương] = @NoiDungChuong, [Mục] = @Muc, [Nội dung mục] = @NoiDungMuc," +
                        "[Điều] = @Dieu, [Nội dung điều] = @NoiDungDieu, [Khoản] = @Khoan, [Nội dung] = @NoiDung, [Mức phạt dưới] = @MucPhatDuoi, [Mức phạt trên] = @MucPhatTren " +
                        "where Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.Add("@Chuong", System.Data.SqlDbType.NVarChar, 255).Value = dataModel.Chuong;
                cmd.Parameters.Add("@NoiDungChuong", System.Data.SqlDbType.NVarChar, 255).Value = dataModel.NoiDungChuong;
                cmd.Parameters.Add("@Muc", System.Data.SqlDbType.Int).Value = dataModel.Muc;
                cmd.Parameters.Add("@NoiDungMuc", System.Data.SqlDbType.NVarChar, 255).Value = dataModel.NoiDungMuc;
                cmd.Parameters.Add("@Dieu", System.Data.SqlDbType.Int).Value = dataModel.Dieu;
                cmd.Parameters.Add("@NoiDungDieu", System.Data.SqlDbType.NVarChar, 255).Value = dataModel.NoiDungDieu;
                cmd.Parameters.Add("@Khoan", System.Data.SqlDbType.Int).Value = dataModel.Khoan;
                cmd.Parameters.Add("@NoiDung", System.Data.SqlDbType.NVarChar, 255).Value = dataModel.NoiDung;
                cmd.Parameters.Add("@MucPhatDuoi", System.Data.SqlDbType.Int).Value = dataModel.MucPhatDuoi;
                cmd.Parameters.Add("@MucPhatTren", System.Data.SqlDbType.Int).Value = dataModel.MucPhatTren;
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = dataModel.Id;
                connection.Open();
                int newId = cmd.ExecuteNonQuery();
                return newId;
            }

        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "delete from dbo.luat where Id = @Id";
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                int deleteId = cmd.ExecuteNonQuery();
                return deleteId;
            }

        }
        public List<DataModel> Search(string searchText)
        {
            List<DataModel> list = new List<DataModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "select * from dbo.luat where [Nội dung] like @searchText";
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.AddWithValue("searchText", "%" +searchText + "%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows && searchText != null)
                {
                    while (reader.Read())
                    {
                        list.Add(new DataModel
                        {
                            Chuong = (string)reader[0],
                            NoiDungChuong = (string)reader[1],
                            Muc = (Convert.IsDBNull(reader[2]) ? null : (int?)reader[2]),
                            NoiDungMuc = (Convert.IsDBNull(reader[3]) ? null : (string?)reader[3]),
                            Dieu = (int)reader[4],
                            NoiDungDieu = (string)reader[5],
                            Khoan = (Convert.IsDBNull(reader[6]) ? null : (int?)reader[6]),
                            NoiDung = (string)reader[7],
                            MucPhatDuoi = (Convert.IsDBNull(reader[8]) ? null : (int?)reader[8]),
                            MucPhatTren = (Convert.IsDBNull(reader[9]) ? null : (int?)reader[9]),
                            Id = (int)reader[10]
                        });
                    }
                }

            }
            return list;
        }
        public List<DataModel> Filter(string chuong)
        {
            List<DataModel> list = new List<DataModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "select * from dbo.luat where [Chương] = @chuong";
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.AddWithValue("chuong", chuong);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new DataModel
                        {
                            Chuong = (string)reader[0],
                            NoiDungChuong = (string)reader[1],
                            Muc = (Convert.IsDBNull(reader[2]) ? null : (int?)reader[2]),
                            NoiDungMuc = (Convert.IsDBNull(reader[3]) ? null : (string?)reader[3]),
                            Dieu = (int)reader[4],
                            NoiDungDieu = (string)reader[5],
                            Khoan = (Convert.IsDBNull(reader[6]) ? null : (int?)reader[6]),
                            NoiDung = (string)reader[7],
                            MucPhatDuoi = (Convert.IsDBNull(reader[8]) ? null : (int?)reader[8]),
                            MucPhatTren = (Convert.IsDBNull(reader[9]) ? null : (int?)reader[9]),
                            Id = (int)reader[10]
                        });
                    }
                }

            }
            return list;
        }
    }
}
