using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class SocketListener : IListener<string>
    {
        private readonly int _port;
        private  Socket _socket;

        public SocketListener(int port)
        {
            _port = port;
        }

        public void AcceptClients(ClientHandlerBase clientHandler)
        {
            Console.WriteLine("here");
            while (true)
            {
                try
                {
                    Socket ClientSocket = _socket.Accept();
                    Task.Run(()=>clientHandler.HandleClient(ClientSocket));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                    
            }
        }

        public void Connect()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _port);
            _socket = new Socket(ipAddress.AddressFamily,
    SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(localEndPoint);
            _socket.Listen(100);
        }
       
    }
}
