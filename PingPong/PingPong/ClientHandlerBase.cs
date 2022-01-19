using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong
{
    abstract class ClientHandlerBase
    {
        private readonly Socket _clientSocket;

        protected ClientHandlerBase(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public abstract void HandleClient();
    }
}
