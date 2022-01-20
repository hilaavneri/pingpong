using PingPong.Listener;
using System;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {

            //SocketListener sl = new SocketListener(5500);
            //sl.Connect();
            //sl.AcceptClients(new ClientSocketHandler(new EchoStringDataWriter()));
            TcpListen tl = new TcpListen(5500);
            tl.Connect();
            tl.AcceptClients(new ClientSocketHandler(new EchoStringDataWriter()));
        }
    }
}
