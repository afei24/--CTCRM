using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeesageAtuoSendService
{
    class Program
    {
        public static void Main(string[] args)
        {
            ThreadManager tm = new ThreadManager();
            tm.StartCTCRMListenThread();
        }
    }
}
