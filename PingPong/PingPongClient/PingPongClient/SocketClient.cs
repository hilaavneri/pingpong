using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPongClient
{
    class SocketClient : ClientBase
    {
        private Socket _socket;
        private IDataReader _dataReader;
        private IDataWriter _dataWriter;
        public SocketClient(string serverIp, int serverPort, IDataReader dataReader, IDataWriter dataWriter) : base(serverIp, serverPort)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;

        }

        public override void CloseConnection()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        public override void ConnectToServer()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = host.AddressList[0];
                IPAddress ip = IPAddress.Parse(serverIp);
                Console.WriteLine(ipAddress.MapToIPv4().ToString());
                Console.WriteLine(ip.ToString());
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5500);

                _socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                _socket.Connect(remoteEP);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public override void Run()
        {
            try
            {
                byte[] bytes = new byte[1024];
                while (true)
                {
                    int bytesSent = _socket.Send(_dataReader.ReadData());
                    int bytesRec = _socket.Receive(bytes);
                    //Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    _dataWriter.Write(bytes, bytesRec);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
