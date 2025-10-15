namespace SmtpMailSender
{
    partial class MailSenderForm
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
            FromLbl = new Label();
            ToLbl = new Label();
            PasswdLbl = new Label();
            SubjectLbl = new Label();
            MessageLbl = new Label();
            SendBtn = new Button();
            FromTB = new TextBox();
            ToTB = new TextBox();
            PasswdTB = new TextBox();
            SubjectTB = new TextBox();
            MessageTB = new TextBox();
            AttachBtn = new Button();
            AttachmentsTB = new TextBox();
            SuspendLayout();
            // 
            // FromLbl
            // 
            FromLbl.AutoSize = true;
            FromLbl.Location = new Point(12, 9);
            FromLbl.Name = "FromLbl";
            FromLbl.Size = new Size(38, 15);
            FromLbl.TabIndex = 0;
            FromLbl.Text = "From:";
            // 
            // ToLbl
            // 
            ToLbl.AutoSize = true;
            ToLbl.Location = new Point(12, 53);
            ToLbl.Name = "ToLbl";
            ToLbl.Size = new Size(23, 15);
            ToLbl.TabIndex = 1;
            ToLbl.Text = "To:";
            // 
            // PasswdLbl
            // 
            PasswdLbl.AutoSize = true;
            PasswdLbl.Location = new Point(12, 97);
            PasswdLbl.Name = "PasswdLbl";
            PasswdLbl.Size = new Size(60, 15);
            PasswdLbl.TabIndex = 2;
            PasswdLbl.Text = "Password:";
            // 
            // SubjectLbl
            // 
            SubjectLbl.AutoSize = true;
            SubjectLbl.Location = new Point(12, 141);
            SubjectLbl.Name = "SubjectLbl";
            SubjectLbl.Size = new Size(49, 15);
            SubjectLbl.TabIndex = 3;
            SubjectLbl.Text = "Subject:";
            // 
            // MessageLbl
            // 
            MessageLbl.AutoSize = true;
            MessageLbl.Location = new Point(418, 9);
            MessageLbl.Name = "MessageLbl";
            MessageLbl.Size = new Size(56, 15);
            MessageLbl.TabIndex = 4;
            MessageLbl.Text = "Message:";
            // 
            // SendBtn
            // 
            SendBtn.Location = new Point(744, 188);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(75, 23);
            SendBtn.TabIndex = 5;
            SendBtn.Text = "Send";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // FromTB
            // 
            FromTB.Location = new Point(12, 27);
            FromTB.Name = "FromTB";
            FromTB.Size = new Size(400, 23);
            FromTB.TabIndex = 6;
            // 
            // ToTB
            // 
            ToTB.Location = new Point(12, 71);
            ToTB.Name = "ToTB";
            ToTB.Size = new Size(400, 23);
            ToTB.TabIndex = 7;
            // 
            // PasswdTB
            // 
            PasswdTB.Location = new Point(12, 115);
            PasswdTB.Name = "PasswdTB";
            PasswdTB.PasswordChar = '*';
            PasswdTB.Size = new Size(400, 23);
            PasswdTB.TabIndex = 8;
            PasswdTB.UseSystemPasswordChar = true;
            // 
            // SubjectTB
            // 
            SubjectTB.Location = new Point(12, 159);
            SubjectTB.Name = "SubjectTB";
            SubjectTB.Size = new Size(400, 23);
            SubjectTB.TabIndex = 9;
            // 
            // MessageTB
            // 
            MessageTB.Location = new Point(418, 27);
            MessageTB.Multiline = true;
            MessageTB.Name = "MessageTB";
            MessageTB.ScrollBars = ScrollBars.Vertical;
            MessageTB.Size = new Size(400, 155);
            MessageTB.TabIndex = 10;
            // 
            // AttachBtn
            // 
            AttachBtn.Location = new Point(663, 188);
            AttachBtn.Name = "AttachBtn";
            AttachBtn.Size = new Size(75, 23);
            AttachBtn.TabIndex = 11;
            AttachBtn.Text = "Attach";
            AttachBtn.UseVisualStyleBackColor = true;
            AttachBtn.Click += AttachBtn_Click;
            // 
            // AttachmentsTB
            // 
            AttachmentsTB.Location = new Point(418, 188);
            AttachmentsTB.Name = "AttachmentsTB";
            AttachmentsTB.ReadOnly = true;
            AttachmentsTB.Size = new Size(239, 23);
            AttachmentsTB.TabIndex = 12;
            // 
            // MailSenderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 228);
            Controls.Add(AttachmentsTB);
            Controls.Add(AttachBtn);
            Controls.Add(MessageTB);
            Controls.Add(SubjectTB);
            Controls.Add(PasswdTB);
            Controls.Add(ToTB);
            Controls.Add(FromTB);
            Controls.Add(SendBtn);
            Controls.Add(MessageLbl);
            Controls.Add(SubjectLbl);
            Controls.Add(PasswdLbl);
            Controls.Add(ToLbl);
            Controls.Add(FromLbl);
            Name = "MailSenderForm";
            Text = "Mail Sender";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FromLbl;
        private Label ToLbl;
        private Label PasswdLbl;
        private Label SubjectLbl;
        private Label MessageLbl;
        private Button SendBtn;
        private TextBox FromTB;
        private TextBox ToTB;
        private TextBox PasswdTB;
        private TextBox SubjectTB;
        private TextBox MessageTB;
        private Button AttachBtn;
        private TextBox AttachmentsTB;
    }
}
