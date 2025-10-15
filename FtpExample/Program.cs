using FluentFTP;

namespace FtpExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new FtpClient("ftp.dlptest.com", "dlpuser", "rNrKYTX9g7z3RgJRmxWuGHbeu");
            client.Connect();

            Console.WriteLine("Підключено до FTP сервера!");

            string remoteFile = "/test.txt";
            string localFile = "test.txt";
            client.DownloadFile(localFile, remoteFile);

            Console.WriteLine("Файл завантажено!");

            client.Disconnect();
            Console.WriteLine("Відключено від сервера.");
        }
    }
}
