using System;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketListener sl = new SocketListener(5500);
            sl.Connect();
            sl.AcceptClients(new ClientSocketHandler(new EchoStringDataWriter())).GetAwaiter().GetResult();
        }
    }
}
