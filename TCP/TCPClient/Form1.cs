using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        TcpClient client = null!;
        NetworkStream stream = null!;
        CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void connectBtn_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                MessageBox.Show("Ти вже підключений!");
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 10000));
                stream = client.GetStream();
                cts = new CancellationTokenSource();

                _ = ListenServerAsync(cts.Token); // запуск слухача

                MessageBox.Show("Підключення успішне!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ListenServerAsync(CancellationToken token)
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (!token.IsCancellationRequested)
                {
                    int read = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                    if (read == 0) // сервер закрив з’єднання
                    {
                        Invoke(() =>
                        {
                            MessageBox.Show("Сервер закрив з’єднання");
                            stream.Close();
                            client.Close();
                            textBox1.Text = "";
                        });
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buffer, 0, read);
                    Invoke(() => textBox1.Text = msg);
                }
            }
            catch (Exception)
            {
                if (!token.IsCancellationRequested)
                {
                    Invoke(() => MessageBox.Show("З’єднання втрачено"));
                }
            }
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Ти не підключений!");
                return;
            }

            try
            {
                byte[] msg = Encoding.UTF8.GetBytes("Привіт, серевере!");

                await stream.WriteAsync(msg, 0, msg.Length);

                byte[] buf = new byte[1024];
                int bytesRead = await stream.ReadAsync(buf, 0, buf.Length);
                string answ = Encoding.UTF8.GetString(buf, 0, bytesRead);
                textBox1.Text = answ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            stream?.Close();
            client?.Close();
        }
    }
}
