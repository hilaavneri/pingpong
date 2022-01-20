using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongClient
{
    public abstract class ClientBase
    {
        protected string serverIp;
        protected int serverPort;

        protected ClientBase(string serverIp, int serverPort)
        {
            this.serverIp = serverIp;
            this.serverPort = serverPort;
        }

        public abstract void ConnectToServer();
        public abstract void Run();
        public abstract void CloseConnection();

    }
}
