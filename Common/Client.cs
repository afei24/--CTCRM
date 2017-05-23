using System;
using System.Collections.Generic;
using System.Text;
using System.Security.AccessControl;
using System.Threading;

namespace CTCRM.Common
{
   public class Client
    {
       public static void CreateSyncEvent()
       {
           EventWaitHandleSecurity eventSecurity = new EventWaitHandleSecurity();
           EventWaitHandleAccessRule rule = new EventWaitHandleAccessRule("SYSTEM", EventWaitHandleRights.FullControl, AccessControlType.Allow);
           eventSecurity.AddAccessRule(rule);
           rule = new EventWaitHandleAccessRule("NETWORK SERVICE", EventWaitHandleRights.FullControl, AccessControlType.Allow);
           eventSecurity.AddAccessRule(rule);
           bool createdNew;
           EventWaitHandle ew = new EventWaitHandle(true, EventResetMode.AutoReset, "Global\\ShopAide_MemSync_Event", out createdNew, eventSecurity);
           ew.Set();
       }

    }
}
