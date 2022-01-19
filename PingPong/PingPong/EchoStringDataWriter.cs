using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class EchoStringDataWriter : IDataWriter
    {
        public byte[] GetData(int data)
        {
            byte[] bytes = new byte[1024];
            string msg = Encoding.ASCII.GetString(bytes, 0, data);
            return Encoding.ASCII.GetBytes(msg);

        }
    }
}
