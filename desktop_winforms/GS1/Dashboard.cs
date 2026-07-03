using GS1.Managers;
using GS1.MySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GS1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            FormClosing += Dashboard_FormClosing;
            FormClosed += Dashboard_FormClosed;
        }

        Database db = new Database();

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Tick -= AutoReloadTick;
            t.Dispose();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadChart();
            LoadRecentLogs();
            StartAutoReload();
        }

        private readonly Timer t = new Timer();

        void StartAutoReload()
        {
            t.Interval = 5000;
            t.Tick += AutoReloadTick;
            t.Start();
        }

        private void AutoReloadTick(object sender, EventArgs e)
        {
            LoadStats();
            LoadChart();
            LoadRecentLogs();
        }

        static string ScalarToString(object value)
        {
            return Convert.ToString(value) ?? "0";
        }

        static int ScalarToInt32(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToInt32(value);
        }

        void LoadStats()
        {
            lblTotal.Text = ScalarToString(db.ExecuteScalar("SELECT COUNT(*) FROM devices"));
            lblUsing.Text = ScalarToString(db.ExecuteScalar(
                "SELECT COUNT(*) FROM devices WHERE statusitem='Using'"));
            lblMaintenance.Text = ScalarToString(db.ExecuteScalar(
                "SELECT COUNT(*) FROM devices WHERE statusitem='Maintenance'"));
        }

        void LoadChart()
        {
            chartDevices.Series.Clear();
            chartDevices.Titles.Clear();

            var chartArea = chartDevices.ChartAreas[0];
            chartArea.BackColor = Color.Transparent;

            var legend = chartDevices.Legends[0];
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Verdana", 9F, FontStyle.Regular);

            var series = chartDevices.Series.Add("DeviceStatus");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.White;
            series.Font = new Font("Verdana", 9F, FontStyle.Bold);
            series["PieLabelStyle"] = "Inside";
            series["DoughnutRadius"] = "55";
            series["PieLineColor"] = "White";
            series["PieDrawingStyle"] = "SoftEdge";

            int usingCount = ScalarToInt32(db.ExecuteScalar(
                "SELECT COUNT(*) FROM devices WHERE statusitem='Using'"));

            int maintainCount = ScalarToInt32(db.ExecuteScalar(
                "SELECT COUNT(*) FROM devices WHERE statusitem='Maintenance'"));


            var usingPoint = series.Points.AddXY("Using", usingCount);
            var maintainPoint = series.Points.AddXY("Maintenance", maintainCount);

            series.Points[usingPoint].Color = Color.FromArgb(46, 204, 113);
            series.Points[maintainPoint].Color = Color.FromArgb(243, 156, 18);

            foreach (DataPoint point in series.Points)
                point.Label = point.YValues[0] <= 0 ? string.Empty : "#PERCENT{P0}";

            chartDevices.Titles.Add("Device Status");
            chartDevices.Titles[0].Font = new Font("Verdana", 10F, FontStyle.Bold);
            chartDevices.Titles[0].ForeColor = Color.FromArgb(52, 73, 94);
        }
        void LoadRecentLogs()
        {
            string query = @"
        SELECT 
            u.full_name,
            l.action_type,
            l.time_action
        FROM logs l
        JOIN users u ON l.user_id = u.id
        WHERE l.user_id = @uid
        ORDER BY l.time_action DESC
        LIMIT 10";

            dataRecent.DataSource = db.GetData(query, new MySql.Data.MySqlClient.MySqlParameter("@uid", Session.UserID));
            dataRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // thoát chương trình
        }

        private void dataRecent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
