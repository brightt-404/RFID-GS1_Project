using GS1.Managers;
using GS1.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS1
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            if (!HasAdminAccess())
            {
                DenyAccessAndClose();
            }
        }
        Database db = new Database();

        private static bool HasAdminAccess()
        {
            return string.Equals(Session.Role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        private void DenyAccessAndClose()
        {
            MessageBox.Show("Only Admin can access Users.");
            BeginInvoke((Action)(() => Close()));
        }

        void LoadUsers()
        {
            string query = "SELECT id, username, full_name, role FROM users";
            dataUsers.DataSource = db.GetData(query);

            dataUsers.Columns["id"].Visible = false;
        }
        private void Users_Load(object sender, EventArgs e)
        {
            if (!HasAdminAccess())
                return;

            LoadUsers();
            if (cbRole.Items.Count > 0)
                cbRole.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO users(username, password, full_name, role) 
                     VALUES(@u, @p, @f, @r)";

            db.Execute(query,
                new MySqlParameter("@u", txtUserName.Text),
                new MySqlParameter("@p", txtPassword.Text),
                new MySqlParameter("@f", txtFullName.Text),
                new MySqlParameter("@r", cbRole.Text)
            );

            LoadUsers();
        }

        private void dataUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataUsers.Rows[e.RowIndex];
            txtUserName.Text = Convert.ToString(row.Cells["username"].Value);
            txtFullName.Text = Convert.ToString(row.Cells["full_name"].Value);
            cbRole.Text = Convert.ToString(row.Cells["role"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataUsers.CurrentRow == null)
                return;
            int id = Convert.ToInt32(dataUsers.CurrentRow.Cells["id"].Value);

            string query = @"UPDATE users 
                     SET username=@u, password=@p, full_name=@f, role=@r 
                     WHERE id=@id";

            db.Execute(query,
                new MySqlParameter("@u", txtUserName.Text),
                new MySqlParameter("@p", txtPassword.Text),
                new MySqlParameter("@f", txtFullName.Text),
                new MySqlParameter("@r", cbRole.Text),
                new MySqlParameter("@id", id)
            );

            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataUsers.CurrentRow == null)
                return;
            int id = Convert.ToInt32(dataUsers.CurrentRow.Cells["id"].Value);

            string query = "DELETE FROM users WHERE id=@id";

            db.Execute(query, new MySqlParameter("@id", id));

            LoadUsers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cbRole.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = @"SELECT id, username, full_name, role 
                     FROM users 
                     WHERE username LIKE @s";

            dataUsers.DataSource = db.GetData(query,
                new MySqlParameter("@s", "%" + txtSearch.Text + "%")
            );
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
