using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
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

            while (true) // Цикл очікування під'єднань
            {
                // 4. Приймаємо клієнта (синхронно)
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("Клієнт підключився!");

                int counter = 0;

                while (true) // Цикл роботи з підключеним клієнтом
                {

                    byte[] buffer = new byte[1024];
                    int recieved = clientSocket.Receive(buffer);
                    string request = Encoding.UTF8.GetString(buffer, 0, recieved);

                    if (request == "INC")
                    {
                        counter++;
                        byte[] respond = Encoding.UTF8.GetBytes(counter.ToString());
                        Console.WriteLine($"Запит на збільшення. Нове значення: {counter}");
                        clientSocket.Send(respond);
                    }
                    else
                    {
                        clientSocket.Close();
                        break;
                    }
                }

                Console.Write("Клієнт від'єднався. Продовжити роботу серверу? (Т/Н) ");
                string? answ = Console.ReadLine();

                if (answ?.ToUpper() == "Н")
                {
                    break;
                }
            }

            Console.WriteLine("Вимикаємо сервер!");

            // 6. Закриваємо з'єднання
            serverSocket.Close();
        }
    }
}
