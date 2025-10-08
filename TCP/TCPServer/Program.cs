using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // TcpListener listener = new TcpListener(10000); // вказуємо тільки порт - застарілий
            // TcpListener listener = new TcpListener(ip, 10000);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 10000);
            TcpListener listener = new TcpListener(ep);

            listener.Start(); // bind + listen
            Console.WriteLine("Server started. Waiting for clients...");

            try
            {
                while (true)
                {
                    // Socket socket = listener.AcceptSocket();
                    TcpClient client = await listener.AcceptTcpClientAsync(); // блокує виконання
                    Console.WriteLine($"Client is connected! {client.Client.RemoteEndPoint}");

                    _ = Task.Run(async () =>
                    {
                        // TCP - потоковий протокол, API як при роботі з будь яким потоком
                        NetworkStream stream = client.GetStream();

                        try
                        {
                            await HandleClientAsync(stream);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("Помилка вводу/виводу: " + ex.Message);
                        }
                        finally
                        {
                            stream.Close();
                            client.Close();
                            Console.WriteLine("Клієнт відключився.");
                        }
                    });
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Помилка підключення клієнта: " + ex.Message);
            }
        }

        private static async Task HandleClientAsync(NetworkStream stream)
        {
            byte[] buf = new byte[1024];
            int bytesRead = await stream.ReadAsync(buf, 0, buf.Length); // Receive
            string message = Encoding.UTF8.GetString(buf, 0, bytesRead);
            Console.WriteLine(message);

            string response = "Привіт від серверу!";
            byte[] bytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(bytes, 0, bytes.Length); // Send
        }
    }
}
