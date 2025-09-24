using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AsyncUdpServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Socket server = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Dgram,
                                       ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Any, 5000));
            Console.WriteLine("UDP сервер запущено...");

            byte[] buffer = new byte[1024];
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                SocketReceiveFromResult received = await server.ReceiveFromAsync(
                    new ArraySegment<byte>(buffer),
                    SocketFlags.None,
                    clientEP
                );

                var remoteEP = received.RemoteEndPoint;

                string msg = Encoding.UTF8.GetString(buffer, 0, received.ReceivedBytes);
                Console.WriteLine($"Отримано від {remoteEP}: {msg}");


                // Асинхронна "довга обробка"
                await Task.Delay(5000);

                byte[] reply = Encoding.UTF8.GetBytes("Echo: " + msg);
                await server.SendToAsync(new ArraySegment<byte>(reply), SocketFlags.None, remoteEP);
            }
        }
    }
}
