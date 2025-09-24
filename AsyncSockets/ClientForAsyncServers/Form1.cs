using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientForAsyncServers
{
    public partial class Form1 : Form
    {
        private Socket _socket;

        public Form1()
        {
            InitializeComponent();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private async void connectBtn_ClickAsync(object sender, EventArgs e)
        {
            if (_socket.Connected)
            {
                MessageBox.Show("Вже підключений!");
                return;
            }

            try
            {
                await _socket.ConnectAsync(IPAddress.Loopback, 5000);
                MessageBox.Show("Підключення успішне");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка підключення");
            }
        }

        private async void sendBtn_ClickAsync(object sender, EventArgs e)
        {
            if (!_socket.Connected)
            {
                MessageBox.Show("Ти не підключений до серверу!");
                return;
            }

            try
            {
                byte[] msg = Encoding.UTF8.GetBytes(msgTB.Text);
                await _socket.SendAsync(msg);

                byte[] buffer = new byte[1024];
                int received = await _socket.ReceiveAsync(buffer);

                string answer = Encoding.UTF8.GetString(buffer, 0, received);
                serverMsgTB.Text = answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void disconnectBtn_ClickAsync(object sender, EventArgs e)
        {
            if (!_socket.Connected)
            {
                MessageBox.Show("Ти і так не підключений!");
            }

            try
            {
                await _socket.DisconnectAsync(true);
                MessageBox.Show("Відключено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка відключення");
            }
        }
    }
}
