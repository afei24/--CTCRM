using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace CHENGTUAN.Components
{
    public class ExceptionReporter
    {

        private static readonly string REPORT_CLASS = "ExceptionReportClass";

        public static IExceptionManager CreateExceptionManager()
        {
            try
            {
                return (IExceptionManager)Assembly.Load("CHENGTUAN.Components").CreateInstance("CHENGTUAN.Components." + ConfigurationManager.AppSettings[REPORT_CLASS]);
            }
            catch (Exception ex)
            {
                throw new Exception("请检查您的WEB.CONFIG里是否已经配置ExceptionReportClass值，并且确保其正确性！", ex);
            }
        }
        public static void SendMsg(string Msg, Exception ex, CHENGTUAN.Entity.ExceptionPostion position, CHENGTUAN.Entity.ExceptionRank rank, int num)
        {
            IExceptionManager manage = CreateExceptionManager();
            IExceptionManager manager = CreateExceptionManager();
            CHENGTUAN.Entity.ExceptionInfo info = new CHENGTUAN.Entity.ExceptionInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(ex.Message + "\r\n");
            sb.Append(ex.Source + "\r\n");
            sb.Append(ex.StackTrace + "\r\n");
            info.Body = sb.ToString();
            info.ExceptionPosition = position;
            info.ExceptionRank = rank;
            info.Num = num;
            info.Title = Msg;
            manager.SendMsg(info);

        }
        public static void WriteLog(string msg, Exception ex, CHENGTUAN.Entity.ExceptionPostion position, CHENGTUAN.Entity.ExceptionRank rank, int num)
        {
            IExceptionManager manager = CreateExceptionManager();
            CHENGTUAN.Entity.ExceptionInfo info = new CHENGTUAN.Entity.ExceptionInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(ex.Message + "\r\n");
            sb.Append(ex.Source + "\r\n");
            sb.Append(ex.StackTrace + "\r\n");
            info.Body = sb.ToString();
            info.ExceptionPosition = position;
            info.ExceptionRank = rank;
            info.Num = num;
            info.Title = msg;
            manager.WriteLog(info);
        }

        public static void WriteLog(string msg, CHENGTUAN.Entity.ExceptionPostion position, CHENGTUAN.Entity.ExceptionRank rank)
        {
            IExceptionManager manager = CreateExceptionManager();
            CHENGTUAN.Entity.ExceptionInfo info = new CHENGTUAN.Entity.ExceptionInfo();
            StringBuilder sb = new StringBuilder();
            info.Body = msg;
            info.ExceptionPosition = position;
            info.ExceptionRank = rank;
            info.Num = 1;
            info.Title = msg;
            manager.WriteLog(info);
        }
        /// <summary>
        /// 常用日志操作
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string msg, Exception ex, CHENGTUAN.Entity.ExceptionPostion position, CHENGTUAN.Entity.ExceptionRank rank)
        {
            WriteLog(msg, ex, position, rank, 1000);
        }

        /// <summary>
        /// 非常严重日志操作
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex, CHENGTUAN.Entity.ExceptionPostion position)
        {
            WriteLog(ex.Message, ex, position, CHENGTUAN.Entity.ExceptionRank.urgency);
        }
    }
}
