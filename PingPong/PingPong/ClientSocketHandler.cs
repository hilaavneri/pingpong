using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong
{
    class ClientSocketHandler : ClientHandlerBase
    {
        public ClientSocketHandler(Socket clientSocket) : base(clientSocket)
        {
        }

        public override void HandleClient()
        {
            throw new NotImplementedException();
        }
    }
}
