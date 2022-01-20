using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPongClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var socketClient = new SocketClient("223.225.13.37", 5500, new SimpleConsoleDataReader());
                //socketClient.ConnectToServer();
                //socketClient.Run();
                //socketClient.CloseConnection();
                var tcpClient = new ClientUsingTcpClient("127.0.0.1", 5500, new ConsolePersonDataReader(), new ObjectDataWriter());
                tcpClient.ConnectToServer();
                tcpClient.Run();
                tcpClient.CloseConnection();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

