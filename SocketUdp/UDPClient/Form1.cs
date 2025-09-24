using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SyncUDPClient
{
    public partial class Form1 : Form
    {
        Socket _client;
        EndPoint _serverEP;

        public Form1()
        {
            InitializeComponent();

            _client = new Socket(AddressFamily.InterNetwork,
                                 SocketType.Dgram,
                                 ProtocolType.Udp);

            _serverEP = new IPEndPoint(IPAddress.Loopback, 5000);
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = msgTB.Text;
                byte[] data = Encoding.UTF8.GetBytes(msg);

                // Відправка на сервер
                _client.SendTo(data, _serverEP);

                // Отримання відповіді (блокуюче)
                byte[] buffer = new byte[1024];
                int received = _client.ReceiveFrom(buffer, ref _serverEP);

                string reply = Encoding.UTF8.GetString(buffer, 0, received);
                answerTB.Text = reply;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private async void sendAsyncBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = msgTB.Text;
                byte[] data = Encoding.UTF8.GetBytes(msg);

                // Відправка на сервер
                await _client.SendToAsync(data, _serverEP);

                // Отримання відповіді (блокуюче)
                byte[] buffer = new byte[1024];
                SocketReceiveFromResult result = await _client.ReceiveFromAsync(buffer, SocketFlags.None, _serverEP);

                string reply = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);
                answerTB.Text = reply;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
    }
}
