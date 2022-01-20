using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    public interface IDataWriter
    {
        byte[] GetData(int data, byte[] bytes);
    }
}
