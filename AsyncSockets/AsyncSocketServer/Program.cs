using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AsyncSocketServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 5000));
            listener.Listen(10);
            Console.WriteLine("Сервер запущений...");

            while (true) // асинхронно приймаємо клієнтів
            {
                Socket client = await listener.AcceptAsync();
                Console.WriteLine("Новий клієнт підключився");
                _ = HandleClientAsync(client); // запускаємо окрему задачу
            }
        }

        private static async Task HandleClientAsync(Socket client)
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytes = await client.ReceiveAsync(buffer, SocketFlags.None);
                    if (bytes == 0) break; // клієнт закрив з’єднання

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Console.WriteLine($"[{Environment.CurrentManagedThreadId}] {msg}");

                    byte[] echo = Encoding.UTF8.GetBytes("Echo: " + msg);
                    await client.SendAsync(echo, SocketFlags.None);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Помилка сокету: {ex.Message}");
            }
            finally
            {
                client.Close();
                Console.WriteLine("Клієнт відключився");
            }
        }
    }
}
