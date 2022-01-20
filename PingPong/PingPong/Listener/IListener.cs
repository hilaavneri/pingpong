using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public interface IListener<T>
    {
        void Connect();
        void AcceptClients(ClientHandlerBase clientHandler);
    }
}
