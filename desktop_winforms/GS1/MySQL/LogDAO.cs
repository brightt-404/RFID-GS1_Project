using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace GS1.MySQL
{
    internal class LogDAO
    {
        Database db = new Database(); // ✅ sửa ở đây

        // 🔹 Ghi log
        public void Insert(int deviceId, int userId, string action)
        {
            string query = @"INSERT INTO logs(device_id, user_id, action_type, time_action)
                             VALUES (@d, @u, @a, NOW())";

            db.Execute(query,
                new MySqlParameter("@d", deviceId),
                new MySqlParameter("@u", userId),
                new MySqlParameter("@a", action)
            );
        }

        // 🔹 Lấy log theo thiết bị
        public DataTable GetByDevice(int deviceId)
        {
            string query = @"SELECT 
                users.full_name AS `Full Name`, 
                logs.action_type AS `Action`, 
                logs.time_action AS `Date&Time`
                FROM logs
                JOIN users ON logs.user_id = users.id
                WHERE logs.device_id = @id
                ORDER BY logs.time_action DESC";

            DataTable dt = db.GetData(query,
                new MySqlParameter("@id", deviceId)
            );

            // 🔹 Thêm STT
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }

            dt.Columns["STT"].SetOrdinal(0);

            return dt;
        }

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
                new MySqlParameter("@user", userId.HasValue ? (object)userId.Value : DBNull.Value),
                new MySqlParameter("@gs1", gs1)
            );
        }
    }
}