using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PingPongClient
{
    class ConsolePersonDataReader : IDataReader
    {
        public byte[] ReadData()
        {
            Console.WriteLine("Please enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("please enter age");
            int age = int.Parse(Console.ReadLine());
            Person person = new Person(name, age);
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, person);
            return fs.ToArray();
        }
    }
}
