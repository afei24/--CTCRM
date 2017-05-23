using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHENGTUAN.Components
{
    public interface IExceptionManager
    {
        Boolean SendMsg(CHENGTUAN.Entity.ExceptionInfo entity);
        Boolean WriteLog(CHENGTUAN.Entity.ExceptionInfo extity);
        bool WriteFileLog(string fileNames, string dingdan, string newBuyer);
    }
}
