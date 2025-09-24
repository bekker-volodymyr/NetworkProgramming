namespace SyncUDPClient
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
            sendBtn = new Button();
            msgTB = new TextBox();
            answerTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            sendAsyncBtn = new Button();
            SuspendLayout();
            // 
            // sendBtn
            // 
            sendBtn.Font = new Font("Segoe UI", 18F);
            sendBtn.Location = new Point(12, 186);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(316, 42);
            sendBtn.TabIndex = 0;
            sendBtn.Text = "Надіслати";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // msgTB
            // 
            msgTB.Font = new Font("Segoe UI", 19F);
            msgTB.Location = new Point(12, 50);
            msgTB.Name = "msgTB";
            msgTB.Size = new Size(316, 41);
            msgTB.TabIndex = 1;
            // 
            // answerTB
            // 
            answerTB.Font = new Font("Segoe UI", 19F);
            answerTB.Location = new Point(12, 135);
            answerTB.Name = "answerTB";
            answerTB.ReadOnly = true;
            answerTB.Size = new Size(316, 41);
            answerTB.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 38);
            label1.TabIndex = 3;
            label1.Text = "Повідомлення";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21F);
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(138, 38);
            label2.TabIndex = 4;
            label2.Text = "Відповідь";
            // 
            // sendAsyncBtn
            // 
            sendAsyncBtn.Font = new Font("Segoe UI", 18F);
            sendAsyncBtn.Location = new Point(12, 234);
            sendAsyncBtn.Name = "sendAsyncBtn";
            sendAsyncBtn.Size = new Size(316, 38);
            sendAsyncBtn.TabIndex = 5;
            sendAsyncBtn.Text = "Надіслати асинхронно";
            sendAsyncBtn.UseVisualStyleBackColor = true;
            sendAsyncBtn.Click += sendAsyncBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 281);
            Controls.Add(sendAsyncBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(answerTB);
            Controls.Add(msgTB);
            Controls.Add(sendBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendBtn;
        private TextBox msgTB;
        private TextBox answerTB;
        private Label label1;
        private Label label2;
        private Button sendAsyncBtn;
    }
}
