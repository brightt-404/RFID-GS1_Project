using GS1.Managers;
using GS1.MySQL;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace GS1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Database db = new Database();

        private void Login_Load(object sender, EventArgs e)
        {
        }
        public DataRow CheckLogin(string user, string pass)
        {
            string query = "SELECT * FROM users WHERE username=@u AND password=@p";

            MySqlParameter[] p =
            {
        new MySqlParameter("@u", user),
        new MySqlParameter("@p", pass)
    };

            DataTable dt = db.GetData(query, p);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // thoát chương trình
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            DataRow row = null;
            try
            {
                row = CheckLogin(user, pass);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Cannot connect to database right now. Please try again in a moment.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
                return;
            }

            if (row == null)
            {
                MessageBox.Show("Incorrect username or password!");
            }
            else
            {
                // 🔥 LƯU SESSION ĐÚNG
                Session.UserID = Convert.ToInt32(row["id"]);
                Session.Username = row["username"].ToString();
                Session.Role = row["role"].ToString();

                MainApp main = new MainApp();
                main.Show();

                this.Hide(); // Ẩn login
            }
        }
    }
}
