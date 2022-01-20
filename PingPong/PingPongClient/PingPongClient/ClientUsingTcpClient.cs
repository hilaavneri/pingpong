using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPongClient
{
    public class ClientUsingTcpClient : ClientBase
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private IDataReader _dataReader;

        public ClientUsingTcpClient(string serverIp, int serverPort, IDataReader dataReader) : base(serverIp, serverPort)
        {
            _dataReader = dataReader;
        }

        public override void CloseConnection()
        {
            _stream.Close();
            _client.Close();
        }

        public override void ConnectToServer()
        {
            try

            {
                _client = new TcpClient(serverIp, serverPort);
                _stream = _client.GetStream();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public override void Run()
        {
            try
            {
                
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    byte[] data = _dataReader.ReadData();
                    _stream.Write(data, 0, data.Length);
                    int bytesRec = _stream.Read(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
