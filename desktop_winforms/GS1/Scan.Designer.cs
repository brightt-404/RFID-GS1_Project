namespace GS1
{
    partial class Scan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblExit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnMaintenance = new Guna.UI2.WinForms.Guna2Button();
            this.btnReturn = new Guna.UI2.WinForms.Guna2Button();
            this.dataLog = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnBorrow = new Guna.UI2.WinForms.Guna2Button();
            this.dataDevice = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGS1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLog)).BeginInit();
            this.dataDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.White;
            this.lblExit.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Red;
            this.lblExit.Location = new System.Drawing.Point(1394, 15);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(34, 34);
            this.lblExit.TabIndex = 27;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(259, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "HA NOI UNIVERSITY OF SCIENCE AND TECHNOLOGY";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.lblExit);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 66);
            this.panel3.TabIndex = 27;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnMaintenance);
            this.panelMain.Controls.Add(this.btnReturn);
            this.panelMain.Controls.Add(this.dataLog);
            this.panelMain.Controls.Add(this.btnBorrow);
            this.panelMain.Controls.Add(this.dataDevice);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 66);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1440, 758);
            this.panelMain.TabIndex = 28;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaintenance.FillColor = System.Drawing.Color.OrangeRed;
            this.btnMaintenance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Location = new System.Drawing.Point(661, 325);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(180, 45);
            this.btnMaintenance.TabIndex = 38;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturn.FillColor = System.Drawing.Color.DarkOrange;
            this.btnReturn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(363, 325);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(180, 45);
            this.btnReturn.TabIndex = 37;
            this.btnReturn.Text = "Return";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dataLog
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataLog.ColumnHeadersHeight = 4;
            this.dataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.Format = "f";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataLog.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLog.Location = new System.Drawing.Point(53, 420);
            this.dataLog.Name = "dataLog";
            this.dataLog.ReadOnly = true;
            this.dataLog.RowHeadersVisible = false;
            this.dataLog.RowHeadersWidth = 51;
            this.dataLog.RowTemplate.Height = 24;
            this.dataLog.Size = new System.Drawing.Size(874, 246);
            this.dataLog.TabIndex = 36;
            this.dataLog.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataLog.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataLog.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataLog.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataLog.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLog.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataLog.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataLog.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLog.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataLog.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataLog.ThemeStyle.HeaderStyle.Height = 4;
            this.dataLog.ThemeStyle.ReadOnly = true;
            this.dataLog.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataLog.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataLog.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLog.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataLog.ThemeStyle.RowsStyle.Height = 24;
            this.dataLog.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLog.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnBorrow
            // 
            this.btnBorrow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBorrow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBorrow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBorrow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBorrow.FillColor = System.Drawing.Color.LimeGreen;
            this.btnBorrow.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Location = new System.Drawing.Point(77, 325);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(180, 45);
            this.btnBorrow.TabIndex = 35;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // dataDevice
            // 
            this.dataDevice.Controls.Add(this.txtUser);
            this.dataDevice.Controls.Add(this.label8);
            this.dataDevice.Controls.Add(this.txtLocation);
            this.dataDevice.Controls.Add(this.label7);
            this.dataDevice.Controls.Add(this.txtStatus);
            this.dataDevice.Controls.Add(this.label4);
            this.dataDevice.Controls.Add(this.txtName);
            this.dataDevice.Controls.Add(this.txtGS1);
            this.dataDevice.Controls.Add(this.label6);
            this.dataDevice.Controls.Add(this.label3);
            this.dataDevice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dataDevice.Location = new System.Drawing.Point(50, 93);
            this.dataDevice.Name = "dataDevice";
            this.dataDevice.Size = new System.Drawing.Size(877, 200);
            this.dataDevice.TabIndex = 34;
            this.dataDevice.Text = "Device Info";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUser.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtUser.Location = new System.Drawing.Point(712, 115);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(128, 32);
            this.txtUser.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(708, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "User";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLocation.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtLocation.Location = new System.Drawing.Point(547, 115);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(128, 32);
            this.txtLocation.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(542, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Location";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtStatus.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtStatus.Location = new System.Drawing.Point(365, 115);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(128, 32);
            this.txtStatus.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtName.Location = new System.Drawing.Point(193, 115);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(128, 32);
            this.txtName.TabIndex = 7;
            // 
            // txtGS1
            // 
            this.txtGS1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtGS1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtGS1.Location = new System.Drawing.Point(27, 115);
            this.txtGS1.Name = "txtGS1";
            this.txtGS1.Size = new System.Drawing.Size(128, 32);
            this.txtGS1.TabIndex = 3;
            this.txtGS1.TextChanged += new System.EventHandler(this.txtGS1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "GS1";
            // 
            // Scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 824);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Scan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "scan";
            this.Load += new System.EventHandler(this.Scan_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLog)).EndInit();
            this.dataDevice.ResumeLayout(false);
            this.dataDevice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2Button btnMaintenance;
        private Guna.UI2.WinForms.Guna2Button btnReturn;
        private Guna.UI2.WinForms.Guna2DataGridView dataLog;
        private Guna.UI2.WinForms.Guna2Button btnBorrow;
        private Guna.UI2.WinForms.Guna2GroupBox dataDevice;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGS1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}