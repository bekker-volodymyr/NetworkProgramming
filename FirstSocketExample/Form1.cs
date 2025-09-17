using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FirstSocketExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Loopback; // 127.0.0.1
                IPEndPoint ep = new IPEndPoint(ip, 8080);

                using Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(ep);

                if (s.Connected)
                {
                    string request = "GET / HTTP/1.1\r\nHost: localhost\r\nConnection: close\r\n\r\n";
                    s.Send(Encoding.ASCII.GetBytes(request));

                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    textBox1.Clear();
                    do
                    {
                        bytesRead = s.Receive(buffer);
                        textBox1.AppendText(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                    } while (bytesRead > 0);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}");
            }
        }
    }
}
