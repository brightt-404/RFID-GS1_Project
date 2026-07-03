using GS1.Managers;
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
    public partial class MainApp : Form
    {
        private FormManager formManager;
        private UIManager uiManager;

        public MainApp()
        {
            InitializeComponent();

            // 🔥 Full màn hình
            this.WindowState = FormWindowState.Maximized;

            // 🔥 Init manager
            formManager = new FormManager(panelMain);
            uiManager = new UIManager(btnDashBoard, btnDevices, btnScan, btnLogs, btnUsers);

            // Mở form con sau khi MainApp đã hiển thị — tránh child Form (TopLevel=false)
            // bị xử lý sai handle/z-order khi gọi Show() trong constructor.
            Shown += MainApp_FirstShown;

            ApplyRolePermissions();
        }

        private bool IsAdmin()
        {
            return string.Equals(Session.Role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        private void ApplyRolePermissions()
        {
            bool isAdmin = IsAdmin();
            btnLogs.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
        }

        private void MainApp_FirstShown(object sender, EventArgs e)
        {
            Shown -= MainApp_FirstShown;
            formManager.OpenForm(new Dashboard());
            uiManager.SetActiveButton(btnDashBoard);
        }

        // ================= BUTTON MENU =================

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            uiManager.SetActiveButton(btnDashBoard);
            formManager.OpenForm(new Dashboard());
        }

        private void btnDevices_Click(object sender, EventArgs e)
        {
            uiManager.SetActiveButton(btnDevices);
            formManager.OpenForm(new Devices());
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show("Only Admin can access Logs.");
                return;
            }

            uiManager.SetActiveButton(btnLogs);
            formManager.OpenForm(new Logs());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show("Only Admin can access Users.");
                return;
            }

            uiManager.SetActiveButton(btnUsers);
            formManager.OpenForm(new Users());
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            uiManager.SetActiveButton(btnScan);
            formManager.OpenForm(new Scan());
        }

        // ================= LOGOUT =================

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        // ================= EXIT =================

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}