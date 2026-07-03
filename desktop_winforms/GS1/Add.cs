using MySql.Data.MySqlClient;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Text.RegularExpressions;

namespace GS1
{
    public partial class Add : Form
    {
        // Dùng để check trùng GS1 trước khi lưu.
        readonly DeviceDAO deviceDAO = new DeviceDAO();
        readonly MqttService mqttService = new MqttService();

        public Add()
        {
            InitializeComponent();
            textDate.Text = DateTime.Now.ToString("dddd, yyyy-MM-dd, HH:mm");
            FormClosed += Add_FormClosed;
        }


        readonly Timer rfidTimer = new Timer();
        private long lastScanId = -1;
        private bool isLoading = false;
        private void AddItem_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width - 50,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height
            );

            if (cbType.Items.Count > 0) cbType.SelectedIndex = 0;
            if (cbLocation.Items.Count > 0) cbLocation.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;

            // MQTT
            mqttService.OnMessageReceived += MqttService_OnMessageReceived;
            _ = StartMqttAsync();

            // 🔥 DB polling backup
            StartAutoLoadFromServer();
        }

        private void StartAutoLoadFromServer()
        {
            rfidTimer.Interval = 1000; // 1s
            rfidTimer.Tick += async (s, e) => await LoadLatestGs1FromServer();
            rfidTimer.Start();
        }
        private async Task LoadLatestGs1FromServer()
        {
            if (isLoading) return;
            isLoading = true;

            try
            {
                Database db = new Database();

                string query = @"SELECT id, gs1_code, scan_time 
                         FROM asset_scans 
                         ORDER BY scan_time DESC, id DESC 
                         LIMIT 1";

                DataTable dt = await Task.Run(() => db.GetData(query));

                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];
                string gs1 = Convert.ToString(row["gs1_code"])?.Trim();

                if (string.IsNullOrWhiteSpace(gs1))
                    return;

                long id = Convert.ToInt64(row["id"]);

                // 🔥 tránh lặp lại
                if (id == lastScanId)
                    return;

                lastScanId = id;

                BeginInvoke((Action)(() =>
                {
                    txtGS1.Text = gs1;
                    txtGS1.SelectionStart = txtGS1.Text.Length;
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }
        private async Task StartMqttAsync()
        {
            try
            {
                await mqttService.ConnectAsync();
            }
            catch
            {
               
            }
        }

        private async void Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            mqttService.OnMessageReceived -= MqttService_OnMessageReceived;
            await mqttService.DisconnectAsync();
        }

        private void MqttService_OnMessageReceived(string payload)
        {
            if (IsDisposed || Disposing)
                return;

            string gs1 = ExtractGs1(payload);
            if (string.IsNullOrWhiteSpace(gs1))
                return;

            BeginInvoke((Action)(() =>
            {
                txtGS1.Text = gs1;
                txtGS1.SelectionStart = txtGS1.Text.Length;
            }));
        }

        private string ExtractGs1(string payload)
        {
            string text = payload?.Trim();
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var match = Regex.Match(text, @"(?i)\bgs1\b\s*[:=]\s*([A-Za-z0-9\-_]+)");
            if (match.Success)
                return match.Groups[1].Value.Trim();

            return text;
        }

        private bool ValidateBeforeSave()
        {
            string gs1 = txtGS1.Text.Trim();
            if (string.IsNullOrWhiteSpace(gs1))
            {
                MessageBox.Show("Vui lòng nhập hoặc quét GS1.");
                txtGS1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị.");
                txtName.Focus();
                return false;
            }

            // Đảm bảo mỗi thiết bị có GS1 duy nhất.
            if (deviceDAO.GetByGS1(gs1) != null)
            {
                MessageBox.Show("GS1 đã tồn tại. Vui lòng dùng GS1 khác.");
                txtGS1.Focus();
                txtGS1.SelectAll();
                return false;
            }

            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string query = @"INSERT INTO devices
(name_item, type_item, location, gs1, statusitem, current_user_id, note, import_date)
VALUES
(@name, @type, @location, @gs1, @status, @user, @note, @date)";
            Database db = new Database();
            db.Execute(query,
                new MySqlParameter("@name", txtName.Text),
                new MySqlParameter("@type", cbType.Text),
                new MySqlParameter("@location", cbLocation.Text),
                new MySqlParameter("@gs1", txtGS1.Text),
                new MySqlParameter("@status", cbStatus.Text),
                new MySqlParameter("@user", DBNull.Value),
                new MySqlParameter("@note", txtNote.Text),
                new MySqlParameter("@date", MySqlDbType.DateTime) { Value = DateTime.Now }
            );

            MessageBox.Show("Lưu thành công!");
            this.Close();
        }
    }
}
