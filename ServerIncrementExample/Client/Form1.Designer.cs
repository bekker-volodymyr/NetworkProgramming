namespace Client
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
            ConnectBtn = new Button();
            IncrementBtn = new Button();
            DisconnectBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 23F);
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(370, 48);
            textBox1.TabIndex = 0;
            // 
            // ConnectBtn
            // 
            ConnectBtn.Font = new Font("Segoe UI", 21F);
            ConnectBtn.Location = new Point(12, 83);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(370, 46);
            ConnectBtn.TabIndex = 1;
            ConnectBtn.Text = "Приєднатись";
            ConnectBtn.UseVisualStyleBackColor = true;
            ConnectBtn.Click += ConnectBtn_Click;
            // 
            // IncrementBtn
            // 
            IncrementBtn.Font = new Font("Segoe UI", 21F);
            IncrementBtn.Location = new Point(12, 135);
            IncrementBtn.Name = "IncrementBtn";
            IncrementBtn.Size = new Size(370, 45);
            IncrementBtn.TabIndex = 2;
            IncrementBtn.Text = "Інкремент";
            IncrementBtn.UseVisualStyleBackColor = true;
            IncrementBtn.Click += IncrementBtn_Click;
            // 
            // DisconnectBtn
            // 
            DisconnectBtn.Font = new Font("Segoe UI", 21F);
            DisconnectBtn.Location = new Point(12, 186);
            DisconnectBtn.Name = "DisconnectBtn";
            DisconnectBtn.Size = new Size(370, 45);
            DisconnectBtn.TabIndex = 3;
            DisconnectBtn.Text = "Від'єднатись";
            DisconnectBtn.UseVisualStyleBackColor = true;
            DisconnectBtn.Click += DisconnectBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 250);
            Controls.Add(DisconnectBtn);
            Controls.Add(IncrementBtn);
            Controls.Add(ConnectBtn);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button ConnectBtn;
        private Button IncrementBtn;
        private Button DisconnectBtn;
    }
}
