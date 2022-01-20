using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public abstract class ClientHandlerBase
    {
        protected Socket ClientSocket;
        protected abstract void CloseConnection();
        public abstract void HandleClient(ISendRecv sendRecv);
    }
}
