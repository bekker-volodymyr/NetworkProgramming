using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (_socket.Connected)
            {
                MessageBox.Show("Ти вже підключений до серверу!", "Помилка");
                return;
            }

            try
            {
                _socket.Connect(IPAddress.Loopback, 5000); // підключення до локального сервера

                MessageBox.Show("Підключення успішне!", "Успіх");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void IncrementBtn_Click(object sender, EventArgs e)
        {
            if (_socket.Connected)
            {
                byte[] request = Encoding.UTF8.GetBytes("INC");
                _socket.Send(request);

                byte[] buffer = new byte[1024];
                int recieved = _socket.Receive(buffer);
                string value = Encoding.UTF8.GetString(buffer);
                textBox1.Text = value;
            }
            else
            {
                MessageBox.Show("Ти не з'єднаний з сервером!", "Помилка");
            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            if (_socket.Connected)
            {
                byte[] request = Encoding.UTF8.GetBytes("DIS");
                _socket.Send(request);
                _socket.Disconnect(true);
                textBox1.Text = "";
                MessageBox.Show("Від'єднались від серверу!", "Успіх");
            }
            else
            {
                MessageBox.Show("Ти не з'єднаний з сервером!", "Помилка");
            }
        }
    }
}
