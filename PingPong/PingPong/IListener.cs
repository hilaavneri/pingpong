using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    public interface IListener<T>
    {
        void Connect();
    }
}
