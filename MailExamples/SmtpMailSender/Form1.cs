using System.Net;
using System.Net.Mail;

namespace SmtpMailSender
{
    public partial class MailSenderForm : Form
    {
        public MailSenderForm()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress(FromTB.Text);
            var toAddress = new MailAddress(ToTB.Text);
            // пароль від акаунта не підійде - потрібно генерувати AppPassword
            var passwd = PasswdTB.Text.Replace(" ", "");
            var subject = SubjectTB.Text;
            var msg = MessageTB.Text;

            using var smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential(fromAddress.Address, passwd);
            smtp.EnableSsl = true;

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = msg
            };

            // Додаємо вкладення
            if (!string.IsNullOrWhiteSpace(AttachmentsTB.Text))
            {
                var files = AttachmentsTB.Lines.Where(l => !string.IsNullOrWhiteSpace(l));
                foreach (var file in files)
                    message.Attachments.Add(new Attachment(file));
            }

            smtp.Send(message);
            MessageBox.Show($"Лист надіслано!");
        }

        private void AttachBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; // можна вибирати кілька файлів
            ofd.Title = "Виберіть файли для вкладення";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    // додаємо файл у TextBox для показу (опційно)
                    AttachmentsTB.AppendText(file + Environment.NewLine);
                }
            }
        }
    }
}
