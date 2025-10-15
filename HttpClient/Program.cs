namespace HttpExample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Створюємо HttpClient
            using HttpClient client = new HttpClient();

            try
            {
                // Робимо GET-запит
                HttpResponseMessage response = await client.GetAsync("https://example.com");

                // Перевіряємо успіх запиту
                response.EnsureSuccessStatusCode();

                // Читаємо тіло відповіді як рядок
                string responseBody = await response.Content.ReadAsStringAsync();

                // Виводимо відповідь
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Помилка запиту: {e.Message}");
            }
        }
    }
}
