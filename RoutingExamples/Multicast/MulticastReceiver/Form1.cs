using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastReceiver
{
    public partial class Form1 : Form
    {
        private UdpClient udp = null!;
        private const int port = 9050;
        private const string multicastIp = "239.0.0.222";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartListening();
        }

        private void StartListening()
        {
            udp = new UdpClient();
            udp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udp.ExclusiveAddressUse = false;

            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, port);
            udp.Client.Bind(localEp);
            udp.JoinMulticastGroup(IPAddress.Parse(multicastIp));

            Task.Run(() =>
            {
                IPEndPoint remoteEP = null;
                while (true)
                {
                    byte[] data = udp.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);

                    textBox1.AppendText($"[{remoteEP.Address}]: {message}\n");
                }
            });
        }
    }
}
