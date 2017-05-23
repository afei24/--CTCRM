using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.MiaoPingServiceV2
{
    class Program
    {
       public static void Main(string[] args)
        {
            MiaoRateService tm = new MiaoRateService();
            tm.StartCTCRMListenThread();
        }
    }
}
