
namespace Server
{
    partial class ControlScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.bttStart = new System.Windows.Forms.Button();
            this.logClientHistory = new System.Windows.Forms.TextBox();
            this.txtSendBox = new System.Windows.Forms.TextBox();
            this.clientDataGridView = new System.Windows.Forms.DataGridView();
            this.IDentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttClearDisplayChat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.TextBox();
            this.LogChatManager = new System.Windows.Forms.Label();
            this.bttSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port:";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(87, 22);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(127, 22);
            this.txtAdress.TabIndex = 4;
            this.txtAdress.Text = "127.0.0.1";
            this.txtAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(87, 66);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(127, 22);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(301, 25);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(115, 22);
            this.port.TabIndex = 6;
            this.port.Text = "9000";
            this.port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(301, 66);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(115, 22);
            this.txtKey.TabIndex = 7;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttStart
            // 
            this.bttStart.Location = new System.Drawing.Point(430, 22);
            this.bttStart.Name = "bttStart";
            this.bttStart.Size = new System.Drawing.Size(160, 64);
            this.bttStart.TabIndex = 8;
            this.bttStart.Text = "START";
            this.bttStart.UseVisualStyleBackColor = true;
            this.bttStart.Click += new System.EventHandler(this.bttStart_Click);
            // 
            // logClientHistory
            // 
            this.logClientHistory.Location = new System.Drawing.Point(12, 137);
            this.logClientHistory.Multiline = true;
            this.logClientHistory.Name = "logClientHistory";
            this.logClientHistory.ReadOnly = true;
            this.logClientHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logClientHistory.Size = new System.Drawing.Size(578, 264);
            this.logClientHistory.TabIndex = 9;
            this.logClientHistory.TabStop = false;
            // 
            // txtSendBox
            // 
            this.txtSendBox.Location = new System.Drawing.Point(12, 407);
            this.txtSendBox.Multiline = true;
            this.txtSendBox.Name = "txtSendBox";
            this.txtSendBox.Size = new System.Drawing.Size(463, 46);
            this.txtSendBox.TabIndex = 10;
            this.txtSendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendBox_KeyDown);
            // 
            // clientDataGridView
            // 
            this.clientDataGridView.AllowUserToAddRows = false;
            this.clientDataGridView.AllowUserToDeleteRows = false;
            this.clientDataGridView.AllowUserToResizeColumns = false;
            this.clientDataGridView.AllowUserToResizeRows = false;
            this.clientDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.clientDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.clientDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.clientDataGridView.ColumnHeadersHeight = 24;
            this.clientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.clientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDentifier,
            this.name});
            this.clientDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clientDataGridView.EnableHeadersVisualStyles = false;
            this.clientDataGridView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.clientDataGridView.Location = new System.Drawing.Point(607, 22);
            this.clientDataGridView.MultiSelect = false;
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.ReadOnly = true;
            this.clientDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.clientDataGridView.RowHeadersVisible = false;
            this.clientDataGridView.RowHeadersWidth = 40;
            this.clientDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.clientDataGridView.RowTemplate.Height = 24;
            this.clientDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientDataGridView.ShowCellErrors = false;
            this.clientDataGridView.ShowCellToolTips = false;
            this.clientDataGridView.ShowEditingIcon = false;
            this.clientDataGridView.ShowRowErrors = false;
            this.clientDataGridView.Size = new System.Drawing.Size(397, 407);
            this.clientDataGridView.TabIndex = 11;
            this.clientDataGridView.TabStop = false;
            // 
            // IDentifier
            // 
            this.IDentifier.HeaderText = "ID";
            this.IDentifier.MaxInputLength = 25;
            this.IDentifier.MinimumWidth = 6;
            this.IDentifier.Name = "IDentifier";
            this.IDentifier.ReadOnly = true;
            this.IDentifier.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IDentifier.Width = 80;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Name";
            this.name.MaxInputLength = 25;
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bttClearDisplayChat
            // 
            this.bttClearDisplayChat.Location = new System.Drawing.Point(415, 108);
            this.bttClearDisplayChat.Name = "bttClearDisplayChat";
            this.bttClearDisplayChat.Size = new System.Drawing.Size(175, 23);
            this.bttClearDisplayChat.TabIndex = 12;
            this.bttClearDisplayChat.Text = "Clear History Chat";
            this.bttClearDisplayChat.UseVisualStyleBackColor = true;
            this.bttClearDisplayChat.Click += new System.EventHandler(this.bttClearDisplayChat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(606, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total Online:";
            // 
            // totalLabel
            // 
            this.totalLabel.BackColor = System.Drawing.SystemColors.Control;
            this.totalLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalLabel.Location = new System.Drawing.Point(701, 438);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(51, 15);
            this.totalLabel.TabIndex = 15;
            // 
            // LogChatManager
            // 
            this.LogChatManager.AutoSize = true;
            this.LogChatManager.Location = new System.Drawing.Point(262, 117);
            this.LogChatManager.Name = "LogChatManager";
            this.LogChatManager.Size = new System.Drawing.Size(65, 17);
            this.LogChatManager.TabIndex = 16;
            this.LogChatManager.Text = "Log Chat";
            // 
            // bttSend
            // 
            this.bttSend.Location = new System.Drawing.Point(482, 408);
            this.bttSend.Name = "bttSend";
            this.bttSend.Size = new System.Drawing.Size(108, 45);
            this.bttSend.TabIndex = 17;
            this.bttSend.Text = "SEND MESSAGE";
            this.bttSend.UseVisualStyleBackColor = true;
            this.bttSend.Click += new System.EventHandler(this.bttSend_Click);
            // 
            // ControlScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 465);
            this.Controls.Add(this.bttSend);
            this.Controls.Add(this.LogChatManager);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bttClearDisplayChat);
            this.Controls.Add(this.clientDataGridView);
            this.Controls.Add(this.txtSendBox);
            this.Controls.Add(this.logClientHistory);
            this.Controls.Add(this.bttStart);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.port);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ControlScreen";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button bttStart;
        private System.Windows.Forms.TextBox logClientHistory;
        private System.Windows.Forms.TextBox txtSendBox;
        private System.Windows.Forms.DataGridView clientDataGridView;
        private System.Windows.Forms.Button bttClearDisplayChat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox totalLabel;
        private System.Windows.Forms.Label LogChatManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button bttSend;
    }
}

