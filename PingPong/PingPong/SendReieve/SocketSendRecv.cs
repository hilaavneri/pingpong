using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong.SendReieve
{
    public class SocketSendRecv : ISendRecv
    {
        private Socket _socket;

        public SocketSendRecv(Socket socket)
        {
            _socket = socket;
        }

        public void CloseConnection()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        public (int, byte[]) ReadData()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = _socket.Receive(bytes);
            return (bytesRec, bytes);
        }

        public void WriteData(byte[] data)
        {
            _socket.Send(data);
        }
    }
}
