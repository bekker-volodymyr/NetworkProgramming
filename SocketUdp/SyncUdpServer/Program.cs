using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SyncUdpServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо сокет
            Socket server = new Socket(AddressFamily.InterNetwork,
                                   SocketType.Dgram,
                                   ProtocolType.Udp);
            // Зв'язуємо з адресою та портом
            server.Bind(new IPEndPoint(IPAddress.Any, 5000));
            Console.WriteLine("UDP сервер запущено...");

            byte[] buffer = new byte[1024];
            // Створюємо EP для збереження адреси та порта клієнта
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                // Отримуємо дані від клієнта
                int received = server.ReceiveFrom(buffer, ref clientEP);
                string msg = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine($"Отримано від {clientEP}: {msg}");
                // Імітуємо довгу обробку
                Thread.Sleep(5000); // 5 секунд
                // Відправляємо echo
                byte[] reply = Encoding.UTF8.GetBytes("Echo: " + msg);
                server.SendTo(reply, clientEP);
            }
        }
    }
}
