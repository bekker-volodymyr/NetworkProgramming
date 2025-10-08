using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BroadcastSender
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            using UdpClient udpClient = new UdpClient();

            udpClient.EnableBroadcast = true;

            string msg = "Привіт, broadcast!";
            byte[] buffer = Encoding.UTF8.GetBytes(msg);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 9050);

            udpClient.Send(buffer, buffer.Length, endPoint);

            Console.WriteLine("Broadcast-повідомлення надіслано!");
        }
    }
}
