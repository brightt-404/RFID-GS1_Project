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
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
            if (!HasAdminAccess())
            {
                DenyAccessAndClose();
                return;
            }

            FormClosing += Logs_FormClosing;
            FormClosed += Logs_FormClosed;
            LoadLogs();

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

        }
        Database db = new Database();

        private const string LogsSelectColumns = @"
        u.full_name,
        l.action_type,
        d.name_item AS device,
        d.gs1,
        d.location,
        l.time_action";

        private readonly Timer t = new Timer();

        private static bool HasAdminAccess()
        {
            return string.Equals(Session.Role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        private void DenyAccessAndClose()
        {
            MessageBox.Show("Only Admin can access Logs.");
            BeginInvoke((Action)(() => Close()));
        }

        // 🔥 Lưu thời gian login (global)
        public static DateTime loginTime;

        private void Logs_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
        }

        private void Logs_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Tick -= AutoReloadTick;
            t.Dispose();
        }

        private void AutoReloadTick(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            LoadLogs();
            StartAutoReload();
        }

        // =============================
        // 🔹 LOAD LOG
        // =============================
        public void LoadLogs()
        {
            string query = $@"
    SELECT 
        {LogsSelectColumns}
    FROM logs l
    JOIN users u ON l.user_id = u.id
    JOIN devices d ON l.device_id = d.id
    WHERE l.time_action BETWEEN @from AND @to
    ORDER BY l.time_action DESC";

            MySqlParameter[] p =
{
    new MySqlParameter("@from", dtFrom.Value.Date),
    new MySqlParameter("@to", dtTo.Value.Date.AddDays(1).AddSeconds(-1))
        };

            BindLogsToGrid(db.GetData(query, p));
        }

        private void BindLogsToGrid(DataTable dt)
        {
            if (dt == null) return;

            if (!dt.Columns.Contains("stt"))
                dt.Columns.Add("stt", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["stt"] = i + 1;

            dt.Columns["stt"].SetOrdinal(0);

            dataLogs.DataSource = dt;
            dataLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ApplyLogsColumnHeaders();
        }

        private void ApplyLogsColumnHeaders()
        {
            if (dataLogs.Columns["stt"] != null)
            {
                var c = dataLogs.Columns["stt"];
                c.HeaderText = "STT";
                c.DisplayIndex = 0;
                c.Width = 56;
                c.DefaultCellStyle.Format = "0";
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataLogs.Columns["full_name"] != null)
                dataLogs.Columns["full_name"].HeaderText ="Full Name";

            if (dataLogs.Columns["action_type"] != null)
                dataLogs.Columns["action_type"].HeaderText = "Action";

            if (dataLogs.Columns["device"] != null)
                dataLogs.Columns["device"].HeaderText = "Device";

            if (dataLogs.Columns["gs1"] != null)
                dataLogs.Columns["gs1"].HeaderText = "GS1 Code";

            if (dataLogs.Columns["location"] != null)
                dataLogs.Columns["location"].HeaderText = "Location";

            if (dataLogs.Columns["time_action"] != null)
                dataLogs.Columns["time_action"].HeaderText = "Date&Time";
        }

        // =============================
        // 🔹 ADD LOG
        // =============================
        public static void AddLog(int userId, string action, int deviceId)
        {
            string query = @"
    INSERT INTO logs(user_id, action_type, device_id, time_action) 
    VALUES(@u, @a, @d, NOW())";

            MySqlParameter[] p =
            {
        new MySqlParameter("@u", userId),
        new MySqlParameter("@a", action),
        new MySqlParameter("@d", deviceId)
    };

            Database db = new Database();
            db.Execute(query, p);
        }

        // =============================
        // 🔹 CELL CLICK → HIỂN THỊ CHI TIẾT
        // =============================

        // =============================
        // 🔹 SEARCH
        // =============================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // ❌ tránh search khi đang là placeholder
            if (keyword == "Search..." || keyword == "")
            {
                LoadLogs();
                return;
            }

            string query = $@"
    SELECT 
        {LogsSelectColumns}
    FROM logs l
    JOIN users u ON l.user_id = u.id
    JOIN devices d ON l.device_id = d.id
    WHERE (u.full_name LIKE @k 
        OR l.action_type LIKE @k 
        OR d.name_item LIKE @k
        OR d.gs1 LIKE @k
        OR d.location LIKE @k)
    AND l.time_action >= @loginTime
    ORDER BY l.time_action DESC";

            MySqlParameter[] p =
            {
        new MySqlParameter("@k", "%" + keyword + "%"),
        new MySqlParameter("@loginTime", loginTime)
    };

            BindLogsToGrid(db.GetData(query, p));
        }

        // =============================
        // 🔹 FILTER THEO NGÀY
        // =============================
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = $@"
    SELECT 
        {LogsSelectColumns}
    FROM logs l
    JOIN users u ON l.user_id = u.id
    JOIN devices d ON l.device_id = d.id
    WHERE l.time_action BETWEEN @from AND @to
    ORDER BY l.time_action DESC";

            MySqlParameter[] p =
            {
        new MySqlParameter("@from", dtFrom.Value.Date),
        new MySqlParameter("@to", dtTo.Value.Date.AddDays(1).AddSeconds(-1))
    };

            BindLogsToGrid(db.GetData(query, p));
            dataLogs.Refresh();
        }

        // =============================
        // 🔹 AUTO REFRESH
        // =============================
        private void StartAutoReload()
        {
            t.Interval = 5000;
            t.Tick += AutoReloadTick;
            t.Start();
        }

        // =============================
        // 🔹 TÔ MÀU LOG
        // =============================
        //private void dataLogs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    var row = dataLogs.Rows[e.RowIndex];

        //    if (row.Cells["action"].Value == null) return;

        //    string action = row.Cells["action"].Value.ToString();

        //    if (action.ToLower().Contains("error"))
        //        row.DefaultCellStyle.BackColor = Color.LightCoral;

        //    else if (action.ToLower().Contains("login"))
        //        row.DefaultCellStyle.BackColor = Color.LightGreen;

        //    else if (action.ToLower().Contains("scan"))
        //        row.DefaultCellStyle.BackColor = Color.LightBlue;
        //}
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...") 
            { 
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black; 
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) 
            { 
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
                Logs.loginTime = DateTime.Now; 
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            t.Start(); // 🔥 bật lại

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

            dtFrom.Value = new DateTime(2000, 1, 1);
            dtTo.Value = DateTime.Now;

            LoadLogs();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void dataLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataLogs.Rows[e.RowIndex];

                txtUser.Text = row.Cells["full_name"]?.Value?.ToString();
                txtAction.Text = row.Cells["action_type"]?.Value?.ToString();
                txtDevice.Text = row.Cells["device"]?.Value?.ToString();
                txtDateTime.Text = row.Cells["time_action"]?.Value?.ToString();
                txtGS1.Text = row.Cells["gs1"]?.Value?.ToString();
                txtLocation.Text = row.Cells["location"]?.Value?.ToString();
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
