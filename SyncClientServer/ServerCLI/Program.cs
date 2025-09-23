using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // 1. Створюємо сокет
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. Прив'язуємо до порту
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 5000));

            // 3. Слухаємо підключення
            serverSocket.Listen(1);
            Console.WriteLine("Сервер запущено, очікуємо підключення...");

            // 4. Приймаємо клієнта (синхронно)
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Клієнт підключився!");

            // 5. Надсилаємо підтвердження
            string message = "Привіт від сервера!";
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(buffer);

            Console.WriteLine("Надіслано повідомлення клієнту.");

            // 6. Закриваємо з'єднання
            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
