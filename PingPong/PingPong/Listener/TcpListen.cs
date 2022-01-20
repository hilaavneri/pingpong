using PingPong.SendReieve;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Listener
{
    class TcpListen : IListener
    {
        private TcpListener _server;
        private readonly int _port;

        public TcpListen(int port)
        {
            _port = port;
        }

        public void AcceptClients(ClientHandlerBase clientHandler)
        {
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = _server.AcceptTcpClient();
                Task.Run(() => clientHandler.HandleClient(new TcpListenerSendRecv(client.GetStream())));
            }

       }

        public void Connect()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                _server = new TcpListener(localAddr, _port);
                _server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
