using System.Net;
using System.Text;

namespace HttpServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо HttpListener
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Сервер запущено на http://localhost:8080/");

            while (true)
            {
                // Очікуємо запит
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;

                // Виводимо URL запиту
                Console.WriteLine($"Отримано запит: {request.Url}");

                // Формуємо відповідь
                string responseString = "<h1>Hello, HTTP!</h1>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                HttpListenerResponse response = context.Response;
                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html; charset=utf-8";

                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
            }
        }
    }
}
