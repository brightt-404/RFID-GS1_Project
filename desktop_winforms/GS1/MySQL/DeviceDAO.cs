using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace GS1.MySQL
{
    internal class DeviceDAO
    {
        Database db = new Database();

        // 🔹 Lấy device theo GS1
        public DataRow GetByGS1(string gs1)
        {
            string query = "SELECT * FROM devices WHERE gs1 = @gs1";

            var dt = db.GetData(query,
                new MySqlParameter("@gs1", gs1)
            );

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // 🔹 Update trạng thái thiết bị
        public void UpdateStatus(string gs1, string status, int? userId)
        {
            string query = @"UPDATE devices 
                             SET statusitem = @status, current_user_id = @user
                             WHERE gs1 = @gs1";

            db.Execute(query,
                new MySqlParameter("@status", status),
                //new MySqlParameter("@user", (object)userId ?? DBNull.Value),
                new MySqlParameter("@user", userId.HasValue ? (object)userId.Value : DBNull.Value),
                new MySqlParameter("@gs1", gs1)
            );
        }

        // 🔹 Lấy username theo userId
        public string GetUserName(int userId)
        {
            string query = "SELECT username FROM users WHERE id=@id";

            var result = db.ExecuteScalar(query,
                new MySqlParameter("@id", userId)
            );

            return result?.ToString();
        }
    }
}