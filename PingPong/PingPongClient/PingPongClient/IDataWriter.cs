using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongClient
{
    public interface IDataWriter
    {
        void Write(byte[] bytes, int bytesRec);
    }
}
