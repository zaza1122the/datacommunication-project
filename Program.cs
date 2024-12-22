using System;
using System.Net.Sockets;
using System.Text;

class Client
{

    private const int PORT = 5000;

    static void Main()
    {
        try
        {
            TcpClient client = new TcpClient("127.0.0.1", PORT);
            Console.WriteLine("Connected to Server");

            NetworkStream stream = client.GetStream();

            while(true)
            {
                Console.Write("Enter message:");
                string message = Console.ReadLine() ?? string.Empty;

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data);

                byte[] response = new byte[1024];
                int byteRead = stream.Read(response, 0 ,response.Length);
                
                string messageFromServer = Encoding.UTF8.GetString(response, 0, byteRead);
                Console.WriteLine(messageFromServer);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: "+ ex.Message);
        }
    }
}