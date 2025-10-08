using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UnicastSender
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int port = 9050;
            UdpClient udp = new UdpClient(port);
            List<IPEndPoint> clients = new List<IPEndPoint>();

            Console.WriteLine("Сервер запущено. Очікування клієнтів...");

            while (true)
            {
                IPEndPoint remoteEP = null;
                byte[] data = udp.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(data);

                if (!clients.Contains(remoteEP))
                {
                    clients.Add(remoteEP); // додаємо нового клієнта
                    Console.WriteLine($"Новий клієнт: {remoteEP.Address}:{remoteEP.Port}");
                }

                // Надсилаємо повідомлення всім **тільки коли клієнтів 4**
                if (clients.Count == 4)
                {
                    string broadcastMsg = $"Всі отримують: {message}";
                    byte[] broadcastData = Encoding.UTF8.GetBytes(broadcastMsg);

                    foreach (var client in clients)
                    {
                        udp.Send(broadcastData, broadcastData.Length, client);
                    }

                    Console.WriteLine("Повідомлення надіслано всім 4 клієнтам!");
                    clients.Clear(); // якщо хочемо збирати нову групу з наступних 4
                }
            }
        }
    }
}
