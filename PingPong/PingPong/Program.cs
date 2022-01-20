using PingPong.Listener;
using System;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListen tl = new TcpListen(5500);
            tl.Connect();
            tl.AcceptClients(new ClientHandler(new EchoStringDataWriter()));
        }
    }
}
