using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Security.AccessControl;
using System.IO;
using System.Timers;

namespace SynMember
{
    class Program
    {
        //static Timer MsTimer;
        static MemSync memsync = new MemSync();
        static Object mslockobj = new Object();

      static  System.Timers.Timer time = new System.Timers.Timer();
        //记录日期（每天只同步一次）
        static string date = "";
        static void Main(string[] args)
        {
            
            Init();
            Console.ReadKey();
        }

        static void Init()
        {
            //MsTimer = new Timer(new TimerCallback(MsTimerEvent), null, 0, 60 * 60 * 1000);
            time.Interval = 1000;
            time.Enabled = true;
            time.Elapsed += new ElapsedEventHandler(MsTimerEvent);
            time.Start();
        }
        static void MsTimerEvent(object sender, ElapsedEventArgs e)
        {
            time.Interval =60*60* 1000;
            time.Enabled = false;
            int syncStartTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncStartTime"]);
            int syncEndTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncEndTime"]);
            ExceptionManager s = new ExceptionManager();
            int nowHour = DateTime.Now.Hour;
            //判断是否现在是同步时间
            if (nowHour < syncStartTime || nowHour >= syncEndTime)
            {
                Console.WriteLine("当前不是同步时间");
                time.Enabled = true;
                return;
            }
            //判断是否现在是同步时间  以及通过日期判断今天是否已同步
            if (date == DateTime.Now.Date.ToString())
            {
                Console.WriteLine("今天已同步");
                time.Enabled = true;
                return;
            }

            try
            {
                date = DateTime.Now.Date.ToString();
                Console.WriteLine("开始同步，日期：" + DateTime.Now.ToString());
                memsync.DoExec();
                Console.WriteLine("今天同步结束，日期：" + DateTime.Now.ToString());
                time.Enabled = true;
                Thread.Sleep(10000);

            }
            catch (Exception err)
            {
                ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
                time.Enabled = true;
            }
            finally
            {
                //MsTimer.Change(0, 60*60 * 1000);
                time.Enabled = true;
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
