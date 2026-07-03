using GS1.Managers;
using GS1.MySQL;
using Guna.UI2.WinForms;
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
    public partial class Devices : Form
    {
        public Devices()
        {
            InitializeComponent();
            CheckAdmin();

            dataDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataDevices.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataDevices.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
       
            LoadData();
        }
        private void Devices_Load(object sender, EventArgs e)
        {
        }
        private void CheckAdmin()
        {
            string role = Session.Role?.Trim().ToLower();
            bool isAdmin = role == "admin";

            btnDelete.Enabled = isAdmin;
            btnAdd.Enabled = isAdmin;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();   
            LoadData();         
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataDevices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the row to delete!");
                return;
            }

            // Lấy id của dòng đang chọn
            int id = Convert.ToInt32(dataDevices.SelectedRows[0].Cells["id"].Value);

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.No) return;

            string query = "DELETE FROM devices WHERE id = @id";
            Database db = new Database();
            db.Execute(query, new MySqlParameter("@id", id));

            MessageBox.Show("Deleted successfully!");
            LoadData();
        }

        private void LoadData()
        {
            Database db = new Database();
            string query = @"
                    SELECT 
                       id,
                       name_item,
                       type_item,
                       location,
                       gs1,
                       statusitem,
                        note,
                       import_date
                        FROM devices
                        ";
            DataTable dtb = db.GetData(query);

                
            // thêm cột STT
            dtb.Columns.Add("stt", typeof(int));

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dtb.Rows[i]["stt"] = i + 1;
            }

            dataDevices.DataSource = dtb;

            // đưa STT lên đầu
            dataDevices.Columns["stt"].DisplayIndex = 0;

            // format số nguyên
            dataDevices.Columns["stt"].DefaultCellStyle.Format = "0";

            // ẩn id
            dataDevices.Columns["id"].Visible = false;

            // căn giữa
            dataDevices.Columns["stt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // width đẹp
            dataDevices.Columns["stt"].Width = 50;
        }
        int selectedId;
        private void dataDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedId = Convert.ToInt32(dataDevices.Rows[e.RowIndex].Cells["id"].Value);
            }
        }

        private void dataDevices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
