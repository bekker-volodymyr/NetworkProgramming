using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BroadcastReceiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            const int port = 9050;

            using var udp = new UdpClient(port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

            Console.WriteLine($"UDP слухач запущено на порту {port}. Очікування повідомлень...");

            while (true)
            {
                byte[] data = udp.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine($"[{remoteEndPoint.Address}] → {message}");
            }
        }
    }
}
