using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Security.AccessControl;
using System.IO;

namespace CRMService
{
    public partial class Service1 : ServiceBase
    {
        Timer MsTimer;
        MemSync memsync;
        Object mslockobj = new Object();
        //记录日期（每天只同步一次）
        string date = "";

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            memsync = new MemSync();
            //#if DEBUG
            //MsTimer = new Timer(new TimerCallback(MsTimerEvent), null, 20 * 1000, 0);
            //#else
            MsTimer = new Timer(new TimerCallback(MsTimerEvent), null, 0, 60 * 60 * 1000);
            //#endif
        }

        protected override void OnStop()
        {
        }

        void MsTimerEvent(object sender)
        {

            int syncStartTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncStartTime"]);
            int syncEndTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncEndTime"]);
            MsTimer.Change(0, System.Threading.Timeout.Infinite);
            
            int nowHour = DateTime.Now.Hour;
            //判断是否现在是同步时间  以及通过日期判断今天是否已同步
            if (nowHour < syncStartTime || nowHour >= syncEndTime || date == DateTime.Now.Date.ToString())
            {
                return;
            }

            try
            {
                date = DateTime.Now.Date.ToString();
                File.WriteAllText(@"D:\date.txt", date, Encoding.Default);
                memsync.DoExec();
                Thread.Sleep(10000);

            }
            catch (Exception err)
            {
                ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
            }
            finally {
                MsTimer.Change(0, 60*1000);
            }

            #region 旧代码
            //if (Monitor.TryEnter(mslockobj))
            //{
            //    try
            //    {
            //        EventWaitHandleSecurity eventSecurity = new EventWaitHandleSecurity();
            //        EventWaitHandleAccessRule rule = new EventWaitHandleAccessRule("SYSTEM", EventWaitHandleRights.FullControl, AccessControlType.Allow);
            //        eventSecurity.AddAccessRule(rule);
            //        rule = new EventWaitHandleAccessRule("NETWORK SERVICE", EventWaitHandleRights.FullControl, AccessControlType.Allow);
            //        eventSecurity.AddAccessRule(rule);
            //        bool createdNew;
            //        EventWaitHandle ew = new EventWaitHandle(true, EventResetMode.AutoReset, "Global\\ShopAide_MemSync_Event", out createdNew, eventSecurity);
            //        ew.Set();

            //        while (true)
            //        {
            //            try
            //            {
            //                //SqlData.WriteSysLog("会员同步就绪");
            //                ew.WaitOne();
            //                memsync.DoExec();
            //            }
            //            catch (Exception err)
            //            {
            //                ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
            //                Thread.Sleep(10000);
            //            }
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
            //    }
            //    finally
            //    {
            //        Monitor.Exit(mslockobj);
            //    }
            #endregion

            
        }
    }
}
