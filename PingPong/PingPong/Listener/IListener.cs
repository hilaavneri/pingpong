using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public interface IListener
    {
        void Connect();
        void AcceptClients(ClientHandlerBase clientHandler);
    }
}
