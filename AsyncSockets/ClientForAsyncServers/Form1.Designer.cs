namespace ClientForAsyncServers
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            msgTB = new TextBox();
            serverMsgTB = new TextBox();
            clientMsgLabel = new Label();
            serverMsgLabel = new Label();
            connectBtn = new Button();
            sendBtn = new Button();
            disconnectBtn = new Button();
            SuspendLayout();
            // 
            // msgTB
            // 
            msgTB.Font = new Font("Segoe UI", 21F);
            msgTB.Location = new Point(23, 64);
            msgTB.Name = "msgTB";
            msgTB.Size = new Size(344, 45);
            msgTB.TabIndex = 0;
            // 
            // serverMsgTB
            // 
            serverMsgTB.Font = new Font("Segoe UI", 21F);
            serverMsgTB.Location = new Point(23, 162);
            serverMsgTB.Name = "serverMsgTB";
            serverMsgTB.ReadOnly = true;
            serverMsgTB.Size = new Size(344, 45);
            serverMsgTB.TabIndex = 1;
            // 
            // clientMsgLabel
            // 
            clientMsgLabel.AutoSize = true;
            clientMsgLabel.Font = new Font("Segoe UI", 21F);
            clientMsgLabel.Location = new Point(23, 23);
            clientMsgLabel.Name = "clientMsgLabel";
            clientMsgLabel.Size = new Size(202, 38);
            clientMsgLabel.TabIndex = 2;
            clientMsgLabel.Text = "Повідомлення";
            // 
            // serverMsgLabel
            // 
            serverMsgLabel.AutoSize = true;
            serverMsgLabel.Font = new Font("Segoe UI", 21F);
            serverMsgLabel.Location = new Point(23, 121);
            serverMsgLabel.Name = "serverMsgLabel";
            serverMsgLabel.Size = new Size(138, 38);
            serverMsgLabel.TabIndex = 3;
            serverMsgLabel.Text = "Відповідь";
            // 
            // connectBtn
            // 
            connectBtn.Font = new Font("Segoe UI", 18F);
            connectBtn.Location = new Point(23, 224);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(344, 43);
            connectBtn.TabIndex = 4;
            connectBtn.Text = "Підключитись";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_ClickAsync;
            // 
            // sendBtn
            // 
            sendBtn.Font = new Font("Segoe UI", 18F);
            sendBtn.Location = new Point(23, 273);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(344, 45);
            sendBtn.TabIndex = 5;
            sendBtn.Text = "Надіслати";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_ClickAsync;
            // 
            // disconnectBtn
            // 
            disconnectBtn.Font = new Font("Segoe UI", 18F);
            disconnectBtn.Location = new Point(23, 324);
            disconnectBtn.Name = "disconnectBtn";
            disconnectBtn.Size = new Size(344, 38);
            disconnectBtn.TabIndex = 6;
            disconnectBtn.Text = "Від'єднатись";
            disconnectBtn.UseVisualStyleBackColor = true;
            disconnectBtn.Click += disconnectBtn_ClickAsync;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 374);
            Controls.Add(disconnectBtn);
            Controls.Add(sendBtn);
            Controls.Add(connectBtn);
            Controls.Add(serverMsgLabel);
            Controls.Add(clientMsgLabel);
            Controls.Add(serverMsgTB);
            Controls.Add(msgTB);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox msgTB;
        private TextBox serverMsgTB;
        private Label clientMsgLabel;
        private Label serverMsgLabel;
        private Button connectBtn;
        private Button sendBtn;
        private Button disconnectBtn;
    }
}
