using GS1.Managers;
using GS1.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GS1
{
    public partial class Scan : Form
    {
        private bool isShuttingDown = false;

        public Scan()
        {
            InitializeComponent();
            UpdateButtonState();
            FormClosed += Scan_FormClosed;
        }

        private async void Scan_Load(object sender, EventArgs e)
        {
            StartRfidInput();
            await TryLoadLatestGs1FromServerAsync();
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await ShutdownAsync();
            Login login = new Login();
            login.Show();
            this.Close();
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // thoát chương trình
        }

        DeviceDAO deviceDAO = new DeviceDAO();
        LogDAO logDAO = new LogDAO();
        Database db = new Database();
        readonly MqttService mqttService = new MqttService();
        readonly Timer rfidPollTimer = new Timer();

        DataRow currentDevice;
        string lastScannedGs1 = string.Empty;
        DateTime lastScanAt = DateTime.MinValue;
        long lastRfidLogId = -1;
        bool rfidServerErrorNotified = false;
        
        private async Task StartMqttAsync()
        {
            
            try
            {
                await mqttService.ConnectAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối MQTT để nhận RFID: " + ex.Message);
            }
        }

        private async void Scan_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                await ShutdownAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ShutdownAsync()
        {
            if (isShuttingDown)
                return;
            isShuttingDown = true;

            try
            {
                rfidPollTimer.Stop();
                rfidPollTimer.Tick -= RfidPollTimer_Tick;
            }
            catch { }

            try
            {
                mqttService.OnMessageReceived -= MqttService_OnMessageReceived;
            }
            catch { }

            try
            {
                await mqttService.DisconnectAsync();
            }
            catch { }
        }

        private void StartRfidInput()
        {
            // Chọn nguồn GS1 trong App.config: Server | Mqtt | Both
            string mode = (ConfigurationManager.AppSettings["RfidInputMode"] ?? "Server").Trim().ToLower();
            bool useServer = mode == "server" || mode == "both";
            bool useMqtt = mode == "mqtt" || mode == "both";

            if (useServer)
                StartRfidServerPolling();

            if (useMqtt)
            {
                mqttService.OnMessageReceived += MqttService_OnMessageReceived;
                _ = StartMqttAsync();
            }
        }


        private void StartRfidServerPolling()
        {
            int intervalMs = 1000;
            int.TryParse(ConfigurationManager.AppSettings["RfidPollMs"], out intervalMs);
            if (intervalMs < 300) intervalMs = 300;

            rfidPollTimer.Interval = intervalMs;
            rfidPollTimer.Tick += RfidPollTimer_Tick;
            rfidPollTimer.Start();
        }

        private bool isLoadingGs1 = false;
        private async Task TryLoadLatestGs1FromServerAsync()
        {
            if (isLoadingGs1) return;
            isLoadingGs1 = true;

            try
            {
                string query = "SELECT id, gs1_code, scan_time FROM asset_scans ORDER BY scan_time DESC, id DESC LIMIT 1";

                DataTable dt = await Task.Run(() => db.GetData(query));

                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];
                string gs1 = Convert.ToString(row["gs1_code"])?.Trim();

                if (string.IsNullOrWhiteSpace(gs1))
                    return;

                long logId = -1;
                long.TryParse(Convert.ToString(row["id"]), out logId);

                // 🔥 tránh load lại dữ liệu cũ
                if (logId == lastRfidLogId)
                    return;

                lastRfidLogId = logId;

                ApplyIncomingGs1(gs1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isLoadingGs1 = false;
            }
        }

        private async void RfidPollTimer_Tick(object sender, EventArgs e)
        {
            //TryLoadLatestGs1FromServer();
            await TryLoadLatestGs1FromServerAsync();
        }
        private void MqttService_OnMessageReceived(string payload)
        {
            if (IsDisposed || Disposing)
                return;

            string gs1 = ExtractGs1(payload);
            if (string.IsNullOrWhiteSpace(gs1))
                return;

            ApplyIncomingGs1(gs1);
        }

        private void ApplyIncomingGs1(string gs1)
        {
            if (IsDisposed || Disposing)
                return;

            // Chống spam khi đầu đọc gửi lặp liên tục cùng 1 mã trong thời gian ngắn.
            if (gs1.Equals(lastScannedGs1, StringComparison.OrdinalIgnoreCase)
                && (DateTime.Now - lastScanAt).TotalMilliseconds < 1000)
            {
                return;
            }
            lastScannedGs1 = gs1;
            lastScanAt = DateTime.Now;

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

        private void txtGS1_TextChanged(object sender, EventArgs e)
        {
            LoadDevice(txtGS1.Text);
        }
        private void LoadDevice(string gs1)
        {
            gs1 = (gs1 ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(gs1))
            {
                ClearDeviceInfo();
                return;
            }

            currentDevice = deviceDAO.GetByGS1(gs1);

            if (currentDevice == null)
            {
                // Không popup để tránh làm phiền khi scanner đang quét liên tục.
                ClearDeviceInfo();
                return;
            }

            txtName.Text = currentDevice["name_item"].ToString();
            txtStatus.Text = currentDevice["statusitem"].ToString();
            txtLocation.Text = currentDevice["location"].ToString();

            if (currentDevice["current_user_id"] != DBNull.Value)
            {
                int userId = Convert.ToInt32(currentDevice["current_user_id"]);
                txtUser.Text = deviceDAO.GetUserName(userId);
            }
            else
            {
                txtUser.Text = "";
            }

            LoadLog();

            UpdateButtonState();
        }

        private void ClearDeviceInfo()
        {
            currentDevice = null;
            txtName.Clear();
            txtStatus.Clear();
            txtLocation.Clear();
            txtUser.Clear();
            dataLog.DataSource = null;
            btnBorrow.Enabled = false;
            btnReturn.Enabled = false;
            btnMaintenance.Enabled = false;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (currentDevice == null || !IsValidAction("Borrow")) return;
            int userId = Session.UserID;
            string gs1 = txtGS1.Text;

            deviceDAO.UpdateStatus(gs1, "Using", userId);
            logDAO.Insert(Convert.ToInt32(currentDevice["id"]), userId, "Borrow");

            MessageBox.Show("Mượn thành công");

            LoadDevice(gs1); // 🔥 tự update lại trạng thái + button
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (currentDevice == null || !IsValidAction("Return")) return;
            int userId = Session.UserID;
            string gs1 = txtGS1.Text;

            deviceDAO.UpdateStatus(gs1, "Available", null);
            logDAO.Insert(Convert.ToInt32(currentDevice["id"]), userId, "Return");

            MessageBox.Show("Đã trả thiết bị");

            LoadDevice(gs1);
        }
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            if (currentDevice == null || !IsValidAction("Maintenance")) return;
            int userId = Session.UserID;
            string gs1 = txtGS1.Text;

            deviceDAO.UpdateStatus(gs1, "Maintenance", null);
            logDAO.Insert(Convert.ToInt32(currentDevice["id"]), userId, "Maintenance");

            MessageBox.Show("Đã chuyển bảo trì");

            LoadDevice(gs1);
        }
        private void LoadLog()
        {
            if (currentDevice == null) return;

            int deviceId = Convert.ToInt32(currentDevice["id"]);

            DataTable dt = logDAO.GetByDevice(deviceId);

            dataLog.DataSource = dt;

            // format STT
            dataLog.Columns["STT"].DefaultCellStyle.Format = "0";
        }
        private void UpdateButtonState()
        {
            if (currentDevice == null) return;

            string status = currentDevice["statusitem"].ToString();
            string role = (Session.Role ?? string.Empty).Trim().ToLower();

            int currentUserId = -1;
            if (currentDevice["current_user_id"] != DBNull.Value)
                currentUserId = Convert.ToInt32(currentDevice["current_user_id"]);

            // ✔ Borrow: chỉ khi Available
            btnBorrow.Enabled = (status == "Available");

            // ✔ Return: chỉ khi In Use và đúng người
            btnReturn.Enabled =(status == "Using" && currentUserId == Session.UserID)|| status == "Maintenance";

            // ✔ Maintenance: chỉ Admin
            btnMaintenance.Enabled = role == "admin" && status == "Available";
        }
        private bool IsValidAction(string action)
        {
            string status = currentDevice["statusitem"].ToString();
            string role = (Session.Role ?? string.Empty).Trim().ToLower();

            int currentUserId = -1;
            if (currentDevice["current_user_id"] != DBNull.Value)
                currentUserId = Convert.ToInt32(currentDevice["current_user_id"]);

            switch (action)
            {
                case "Borrow":
                    if (status != "Available")
                    {
                        MessageBox.Show("Thiết bị không khả dụng");
                        return false;
                    }
                    return true;

                case "Return":
                    if (status == "Maintenance")
                    {
                        return true; // cho phép trả từ bảo trì
                    }

                    if (status != "Using" || currentUserId != Session.UserID)
                    {
                        MessageBox.Show("Bạn không thể trả thiết bị này");
                         return false;
                    }
                    return true;

                case "Maintenance":
                    if (role != "admin")
                    {
                        MessageBox.Show("Chỉ Admin mới được bảo trì");
                        return false;
                    }

                    if (status == "Maintenance")
                    {
                        MessageBox.Show("Thiết bị đang bảo trì rồi");
                        return false;
                    }

                    return true;

                default:
                    return false;
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
