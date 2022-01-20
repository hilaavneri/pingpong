using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class ClientHandler : ClientHandlerBase
    {

        private IDataWriter _writer;
        

        public ClientHandler(IDataWriter writer)
        {
            _writer = writer;
        }

        protected override void CloseConnection()
        {
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }


        public  override void HandleClient(ISendRecv sender)
        {
            Console.WriteLine("start");
                try
                {
                    string data = "";
                while (true)
                {
                    int bytesRec;
                    byte[] bytes;
                    string msg;
                    (bytesRec, bytes) = sender.ReadData();
                    sender.WriteData(_writer.GetData(bytesRec, bytes));
                        if (data.Equals("exit"))
                        {
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            finally
            {
                sender.CloseConnection();
            }

           
            
        }
    }
    

    
}
