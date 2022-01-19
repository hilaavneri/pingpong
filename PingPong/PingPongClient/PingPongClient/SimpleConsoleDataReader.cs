using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongClient
{
    public class SimpleConsoleDataReader : IDataReader
    {
        public byte[] ReadData()
        {
            string data = Console.ReadLine();
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
