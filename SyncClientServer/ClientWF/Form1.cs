using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectToServer()
        {
            try
            {
                // 1. Створюємо сокет
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 2. Підключення до серверу
                clientSocket.Connect(IPAddress.Loopback, 5000); // підключення до локального сервера

                byte[] buffer = new byte[1024];
                int received = clientSocket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, received);

                textBox1.Text = message;

                clientSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
    }
}
