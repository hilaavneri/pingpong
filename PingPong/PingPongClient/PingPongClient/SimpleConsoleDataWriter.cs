using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongClient
{
    class SimpleConsoleDataWriter : IDataWriter
    {
        public void Write(byte[] bytes, int bytesRec)
        {
            Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
        }
    }
}
