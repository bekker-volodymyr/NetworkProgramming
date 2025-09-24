using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TaskAsyncServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 5000));
            listener.Listen(10);
            Console.WriteLine("Сервер запущений...");

            while (true) // Цикл прийому підключень
            {
                Socket client = listener.Accept(); // блокуючий виклик

                // Стартуємо окремий таск
                Task.Run(() => HandleClient(client));
            }
        }

        private static void HandleClient(Socket client)
        {
            try
            {
                var buffer = new byte[1024];
                while (true)
                {
                    int bytes = client.Receive(buffer); // блокуюче читання
                    if (bytes == 0) break; // клієнт закрив з'єднання
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {msg}");
                    // Відправляємо echo-відповідь
                    client.Send(Encoding.UTF8.GetBytes("Echo: " + msg));
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
