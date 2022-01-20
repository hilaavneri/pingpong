using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong.SendReieve
{
    class TcpListenerSendRecv : ISendRecv
    {
        private NetworkStream _stream;

        public TcpListenerSendRecv(NetworkStream stream)
        {
            _stream = stream;
        }

        public void CloseConnection()
        {
            _stream.Close();
        }

        public (int, byte[]) ReadData()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = _stream.Read(bytes, 0, bytes.Length);
            return (bytesRec, bytes);
        }

        public void WriteData(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
    }
}
