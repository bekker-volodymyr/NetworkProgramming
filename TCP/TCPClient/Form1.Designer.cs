namespace TCPClient
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
            textBox1 = new TextBox();
            connectBtn = new Button();
            sendBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(243, 23);
            textBox1.TabIndex = 0;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(12, 41);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(243, 23);
            connectBtn.TabIndex = 1;
            connectBtn.Text = "Підключитись";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(12, 70);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(243, 23);
            sendBtn.TabIndex = 2;
            sendBtn.Text = "Надіслати привіт серверу";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 111);
            Controls.Add(sendBtn);
            Controls.Add(connectBtn);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button connectBtn;
        private Button sendBtn;
    }
}
