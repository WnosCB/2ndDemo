
namespace Client
{
    partial class ChatForm
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logChatHistory = new System.Windows.Forms.TextBox();
            this.bttConnect = new System.Windows.Forms.Button();
            this.txtSendBox = new System.Windows.Forms.TextBox();
            this.bttSend = new System.Windows.Forms.Button();
            this.bttClearDisplayChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(316, 62);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(115, 22);
            this.txtKey.TabIndex = 15;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(316, 21);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(115, 22);
            this.txtPort.TabIndex = 14;
            this.txtPort.Text = "9000";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 62);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(127, 22);
            this.txtUsername.TabIndex = 13;
            this.txtUsername.Text = "Client";
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(102, 18);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(127, 22);
            this.txtAdress.TabIndex = 12;
            this.txtAdress.Text = "127.0.0.1";
            this.txtAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP Address: ";
            // 
            // logChatHistory
            // 
            this.logChatHistory.Location = new System.Drawing.Point(13, 123);
            this.logChatHistory.Multiline = true;
            this.logChatHistory.Name = "logChatHistory";
            this.logChatHistory.Size = new System.Drawing.Size(775, 272);
            this.logChatHistory.TabIndex = 16;
            // 
            // bttConnect
            // 
            this.bttConnect.Location = new System.Drawing.Point(505, 19);
            this.bttConnect.Name = "bttConnect";
            this.bttConnect.Size = new System.Drawing.Size(154, 65);
            this.bttConnect.TabIndex = 17;
            this.bttConnect.Text = "CONNECT";
            this.bttConnect.UseVisualStyleBackColor = true;
            this.bttConnect.Click += new System.EventHandler(this.bttConnect_Click);
            // 
            // txtSendBox
            // 
            this.txtSendBox.Location = new System.Drawing.Point(13, 401);
            this.txtSendBox.Multiline = true;
            this.txtSendBox.Name = "txtSendBox";
            this.txtSendBox.Size = new System.Drawing.Size(646, 37);
            this.txtSendBox.TabIndex = 18;
            this.txtSendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendBox_KeyDown);
            // 
            // bttSend
            // 
            this.bttSend.Location = new System.Drawing.Point(666, 402);
            this.bttSend.Name = "bttSend";
            this.bttSend.Size = new System.Drawing.Size(122, 36);
            this.bttSend.TabIndex = 19;
            this.bttSend.Text = "SEND";
            this.bttSend.UseVisualStyleBackColor = true;
            this.bttSend.Click += new System.EventHandler(this.bttSend_Click);
            // 
            // bttClearDisplayChat
            // 
            this.bttClearDisplayChat.Location = new System.Drawing.Point(15, 94);
            this.bttClearDisplayChat.Name = "bttClearDisplayChat";
            this.bttClearDisplayChat.Size = new System.Drawing.Size(185, 23);
            this.bttClearDisplayChat.TabIndex = 20;
            this.bttClearDisplayChat.Text = "Clear History Chat";
            this.bttClearDisplayChat.UseVisualStyleBackColor = true;
            this.bttClearDisplayChat.Click += new System.EventHandler(this.bttClearDisplayChat_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttClearDisplayChat);
            this.Controls.Add(this.bttSend);
            this.Controls.Add(this.txtSendBox);
            this.Controls.Add(this.bttConnect);
            this.Controls.Add(this.logChatHistory);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChatForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logChatHistory;
        private System.Windows.Forms.Button bttConnect;
        private System.Windows.Forms.TextBox txtSendBox;
        private System.Windows.Forms.Button bttSend;
        private System.Windows.Forms.Button bttClearDisplayChat;
    }
}

