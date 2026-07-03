using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace GS1.MySQL
{
    public class UserService
    {
        Database db = new Database();

        // 🔐 Hash password bằng SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // 🔹 Đăng ký
        public void Register(string username, string password)
        {
            string query = "INSERT INTO users(username, password) VALUES (@user, @pass)";

            db.Execute(query,
                new MySqlParameter("@user", username),
                new MySqlParameter("@pass", HashPassword(password))
            );
        }

        // 🔹 Đăng nhập
        public bool CheckLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username=@user AND password=@pass";

            int count = Convert.ToInt32(
                db.ExecuteScalar(query,
                    new MySqlParameter("@user", username),
                    new MySqlParameter("@pass", HashPassword(password))
                )
            );

            return count > 0;
        }

        // 🔹 Lấy userId (rất quan trọng cho Log)
        public int? GetUserId(string username, string password)
        {
            string query = "SELECT id FROM users WHERE username=@user AND password=@pass";

            object result = db.ExecuteScalar(query,
                new MySqlParameter("@user", username),
                new MySqlParameter("@pass", HashPassword(password))
            );

            return result != null ? Convert.ToInt32(result) : (int?)null;
        }
    }
}