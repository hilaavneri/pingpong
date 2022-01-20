using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PingPongClient
{
    class ObjectDataWriter : IDataWriter
    {
        public void Write(byte[] bytes, int bytesRec)
        {
            BinaryFormatter formattor = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(bytes);
            object obj = formattor.Deserialize(ms);
            Console.WriteLine(obj.ToString());

        }
    }
}
