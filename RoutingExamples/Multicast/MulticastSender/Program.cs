using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastSender
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            using var udp = new UdpClient();
            udp.JoinMulticastGroup(IPAddress.Parse("239.0.0.222")); // Multicast-адреса

            string message = "Привіт, група multicast!";
            byte[] data = Encoding.UTF8.GetBytes(message);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("239.0.0.222"), 9050);

            udp.Send(data, data.Length, endPoint);
            Console.WriteLine("Повідомлення надіслано multicast-групі!");
        }
    }
}
