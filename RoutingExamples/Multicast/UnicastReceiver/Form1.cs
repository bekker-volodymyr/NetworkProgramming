using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UnicastReceiver
{
    public partial class Form1 : Form
    {
        private UdpClient udp;
        private IPEndPoint serverEP;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartClient();
        }

        private void StartClient()
        {
            udp = new UdpClient(); // 0 = будь-який вільний порт
            serverEP = new IPEndPoint(IPAddress.Loopback, 9050); // IP сервера

            // Надсилаємо повідомлення серверу, щоб зареєструвати свій порт
            string registerMsg = "Привіт сервер, це клієнт!";
            byte[] data = Encoding.UTF8.GetBytes(registerMsg);
            udp.Send(data, data.Length, serverEP);

            // Слухаємо сервер
            Task.Run(() =>
            {
                IPEndPoint remoteEP = null;
                while (true)
                {
                    byte[] receivedData = udp.Receive(ref remoteEP);
                    string msg = Encoding.UTF8.GetString(receivedData);

                    Invoke((Action)(() =>
                    {
                        textBox1.AppendText($"{msg}{Environment.NewLine}");
                    }));
                }
            });
        }
    }
}
