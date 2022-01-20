using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class ClientSocketHandler : ClientHandlerBase
    {

        private IDataWriter _writer;

        public ClientSocketHandler(IDataWriter writer)
        {
            _writer = writer;
        }

        protected override void CloseConnection()
        {
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }


        public  override void HandleClient(Socket clientSocket)
        {
            Console.WriteLine("start");
                try
                {
                    ClientSocket = clientSocket;
                    string data = "";
                byte[] bytes = null;
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec =  ClientSocket.Receive(bytes);
                    string msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Console.WriteLine(msg);
                    clientSocket.Send(_writer.GetData(bytesRec, bytes));
                        if (data.Equals("exit"))
                        {
                            break;
                        }
                    }
                    CloseConnection();
                }
                catch (Exception e)
                {
                    CloseConnection();
                    Console.WriteLine(e.Message);
                }
           
            
        }
    }
    

    
}
