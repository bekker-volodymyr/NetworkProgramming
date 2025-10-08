using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPChat
{
    public class Program
    {
        static int RemotePort; // порт куди відправляємо
        static IPAddress RemoteIPAddr = null!; // IP куди відправляємо
        static int LocalPort; // наш порт

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Chat";

            Console.Write("Введіть IP отримувача: ");
            RemoteIPAddr = IPAddress.Parse(Console.ReadLine() ?? "127.0.0.1");

            Console.Write("Введіть порт отримувача: ");
            RemotePort = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть локальний порт: ");
            LocalPort = Convert.ToInt32(Console.ReadLine());

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();

            Console.ForegroundColor = ConsoleColor.Blue;
            while (true)
            {
                SendData(Console.ReadLine() ?? "");
            }
        }

        private static void ReceiveData()
        {
            try
            {
                while (true)
                {
                    // Підключення
                    UdpClient uClient = new UdpClient(LocalPort);
                    IPEndPoint ipEnd = null!;

                    // Отримання
                    byte[] responce = uClient.Receive(ref ipEnd);

                    // Обробка та вивід
                    string strResult = Encoding.Unicode.GetString(responce);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(strResult);
                    Console.ForegroundColor = ConsoleColor.Blue;

                    // Закриття клієнта
                    uClient.Close();
                }
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Помилка сокета: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка : " + ex.Message);
            }
        }

        private static void SendData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            UdpClient uClient = new UdpClient();

            // Підключення
            IPEndPoint ipEnd = new IPEndPoint(RemoteIPAddr, RemotePort);
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(data);
                uClient.Send(bytes, bytes.Length, ipEnd);
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Помилка сокета: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка : " + ex.Message);
            }
            finally
            {
                // Закриття
                uClient.Close();
            }
        }
    }
}
