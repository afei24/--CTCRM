using System;
using System.Collections.Generic;
using System.Text;

namespace CHENGTUAN.Components
{
    public abstract class BaseExceptionManager : IExceptionManager
    {

        #region IExceptionManager 成员

        public abstract bool SendMsg(CHENGTUAN.Entity.ExceptionInfo entity);

        public abstract bool WriteLog(CHENGTUAN.Entity.ExceptionInfo extity);
        public abstract bool WriteFileLog(string fileNames, string dingdan, string newBuyer);

        #endregion
    }
}
