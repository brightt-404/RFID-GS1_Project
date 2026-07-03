namespace GS1
{
    partial class Logs
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Logsss = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dataLogs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGS1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.Logsss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLogs)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
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
            this.panel3.TabIndex = 35;
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            // 
            // Logsss
            // 
            this.Logsss.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Logsss.Controls.Add(this.dataLogs);
            this.Logsss.Controls.Add(this.txtSearch);
            this.Logsss.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logsss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Logsss.Location = new System.Drawing.Point(10, 77);
            this.Logsss.Name = "Logsss";
            this.Logsss.Size = new System.Drawing.Size(933, 399);
            this.Logsss.TabIndex = 45;
            this.Logsss.Text = "Logs List";
            // 
            // dataLogs
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataLogs.ColumnHeadersHeight = 4;
            this.dataLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle6.Format = "f";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataLogs.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataLogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLogs.Location = new System.Drawing.Point(19, 60);
            this.dataLogs.Name = "dataLogs";
            this.dataLogs.ReadOnly = true;
            this.dataLogs.RowHeadersVisible = false;
            this.dataLogs.RowHeadersWidth = 51;
            this.dataLogs.RowTemplate.Height = 24;
            this.dataLogs.Size = new System.Drawing.Size(894, 322);
            this.dataLogs.TabIndex = 38;
            this.dataLogs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataLogs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataLogs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataLogs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataLogs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataLogs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataLogs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLogs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataLogs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataLogs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLogs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataLogs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataLogs.ThemeStyle.HeaderStyle.Height = 4;
            this.dataLogs.ThemeStyle.ReadOnly = true;
            this.dataLogs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataLogs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataLogs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLogs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataLogs.ThemeStyle.RowsStyle.Height = 24;
            this.dataLogs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataLogs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataLogs_CellClick);
            this.dataLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataLogs_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtSearch.Location = new System.Drawing.Point(661, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(252, 32);
            this.txtSearch.TabIndex = 40;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dtFrom
            // 
            this.dtFrom.AutoRoundedCorners = true;
            this.dtFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtFrom.BorderColor = System.Drawing.Color.Gray;
            this.dtFrom.Checked = true;
            this.dtFrom.FillColor = System.Drawing.Color.White;
            this.dtFrom.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtFrom.Location = new System.Drawing.Point(337, 23);
            this.dtFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(268, 36);
            this.dtFrom.TabIndex = 47;
            this.dtFrom.Value = new System.DateTime(2026, 4, 9, 15, 39, 54, 904);
            this.dtFrom.ValueChanged += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtTo
            // 
            this.dtTo.AutoRoundedCorners = true;
            this.dtTo.BorderColor = System.Drawing.Color.Gray;
            this.dtTo.Checked = true;
            this.dtTo.FillColor = System.Drawing.Color.White;
            this.dtTo.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtTo.Location = new System.Drawing.Point(660, 23);
            this.dtTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(268, 36);
            this.dtTo.TabIndex = 48;
            this.dtTo.Value = new System.DateTime(2026, 4, 9, 15, 39, 54, 904);
            this.dtTo.ValueChanged += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "To:";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2GroupBox1.Controls.Add(this.btnReset);
            this.guna2GroupBox1.Controls.Add(this.txtLocation);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.txtGS1);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.txtAction);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.txtDateTime);
            this.guna2GroupBox1.Controls.Add(this.label9);
            this.guna2GroupBox1.Controls.Add(this.txtUser);
            this.guna2GroupBox1.Controls.Add(this.txtDevice);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(9, 491);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(933, 204);
            this.guna2GroupBox1.TabIndex = 46;
            this.guna2GroupBox1.Text = "Logs Details";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // btnReset
            // 
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(791, 135);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 45);
            this.btnReset.TabIndex = 41;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLocation.Location = new System.Drawing.Point(526, 152);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(229, 32);
            this.txtLocation.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(403, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 25);
            this.label7.TabIndex = 32;
            this.label7.Text = "Location:";
            // 
            // txtGS1
            // 
            this.txtGS1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtGS1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtGS1.Location = new System.Drawing.Point(526, 55);
            this.txtGS1.Name = "txtGS1";
            this.txtGS1.ReadOnly = true;
            this.txtGS1.Size = new System.Drawing.Size(229, 32);
            this.txtGS1.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(403, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "GS1:";
            // 
            // txtAction
            // 
            this.txtAction.BackColor = System.Drawing.Color.White;
            this.txtAction.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtAction.Location = new System.Drawing.Point(526, 104);
            this.txtAction.Name = "txtAction";
            this.txtAction.ReadOnly = true;
            this.txtAction.Size = new System.Drawing.Size(229, 32);
            this.txtAction.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(403, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "Action:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Device:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(28, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 25);
            this.label8.TabIndex = 26;
            this.label8.Text = "User:";
            // 
            // txtDateTime
            // 
            this.txtDateTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDateTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDateTime.Location = new System.Drawing.Point(151, 55);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(232, 32);
            this.txtDateTime.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(28, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "DataTime:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtUser.Location = new System.Drawing.Point(151, 107);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(232, 32);
            this.txtUser.TabIndex = 23;
            // 
            // txtDevice
            // 
            this.txtDevice.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDevice.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDevice.Location = new System.Drawing.Point(151, 155);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.Size = new System.Drawing.Size(232, 32);
            this.txtDevice.TabIndex = 17;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.guna2GroupBox1);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.dtTo);
            this.panelMain.Controls.Add(this.dtFrom);
            this.panelMain.Controls.Add(this.Logsss);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 66);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1440, 758);
            this.panelMain.TabIndex = 36;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 824);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Logs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.LogsForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Logsss.ResumeLayout(false);
            this.Logsss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLogs)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GroupBox Logsss;
        private Guna.UI2.WinForms.Guna2DataGridView dataLogs;
        private System.Windows.Forms.TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGS1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.Panel panelMain;
    }
}