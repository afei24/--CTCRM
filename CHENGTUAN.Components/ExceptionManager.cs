using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace CHENGTUAN.Components
{
    public class ExceptionManager : BaseExceptionManager
    {
        /// <summary>
        /// 程序发生错误的时候发送邮件，
        /// 此方法只针对QQ邮箱地址
        /// </summary>
        /// <param name="entity">错误信息</param>
        /// <returns>返回结果,true表示成功，false表示失败。</returns>
        public override bool SendMsg(CHENGTUAN.Entity.ExceptionInfo entity)
        {
            //发送邮件
            MailMessage mailMessage = null;
            SmtpClient smtpClient = null;
            EventLog eventlog = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("========================================/n");
                sb.Append("时间:              " + DateTime.Now.ToString() + "/n");
                sb.Append("错误号:            " + entity.Num.ToString() + "/n");
                sb.Append("标题:              " + entity.Title + "/n");
                sb.Append("内容:              " + entity.Body + "/n");
                sb.Append("出现错误的位置     " + entity.ExceptionPosition + "/n");
                sb.Append("重要级别:          " + entity.ExceptionRank.ToString() + "/n");
                sb.Append("========================================/n");
                mailMessage = new MailMessage(ConfigurationManager.AppSettings["From"].ToString(),
                    ConfigurationManager.AppSettings["To"].ToString(), entity.Title, sb.ToString());
                smtpClient = new SmtpClient(ConfigurationManager.AppSettings["Host"].ToString(),
                    int.Parse(ConfigurationManager.AppSettings["Port"]));
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["From"].ToString(), ConfigurationManager.AppSettings["QQPassWord"].ToString());
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                eventlog = new EventLog();
                WriteLog(entity);
                return false;
            }


        }
        /*定义日志文件命名规则*/

        public readonly string

            fileName = Units.MapPath("/Files/Log/") + "TBApplySystemLog" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

        public override bool WriteLog(CHENGTUAN.Entity.ExceptionInfo entity)
        {
            if (entity == null)
            {
                return false;
            }
            TextWriter wirter = null;
            FileStream stream = null;
            try
            {
                //判断文件是否存在,如果不存在创建完文件 
                if (!File.Exists(fileName))
                {
                    FileInfo fileinfo = new FileInfo(fileName);
                    stream = fileinfo.Create();
                    stream.Dispose();
                }
                wirter = new StreamWriter(fileName, true);
                StringBuilder sb = new StringBuilder();
                wirter.WriteLine();
                wirter.WriteLine("===================================");
                wirter.WriteLine("时间:           " + DateTime.Now.ToString());
                wirter.WriteLine("错误号:         " + entity.Num.ToString());
                wirter.WriteLine("标题:           " + entity.Title.Trim());
                wirter.WriteLine("内容:           " + entity.Body.Trim());
                wirter.WriteLine("出现错误的位置: " + entity.ExceptionPosition);
                wirter.WriteLine("错误级别:       " + entity.ExceptionRank);
                wirter.WriteLine("=====================================");  
                wirter.Flush();
                wirter.Close();
                wirter.Dispose();
                /*
                 * 通过记事本的方式保存日志文件.
                 * 业务逻辑:
                 * 1.定义日志文件命名
                 * 1.查看今天是否创建日志文件
                 * 2.如果没有创建文件，并写入相应的日志。
                 * 3.否则写入日志
                 */
            }
            catch (System.Exception ex)
            {
                if (stream != null) { stream.Dispose(); }
                if (wirter != null)
                {
                    wirter.Close();
                    wirter.Dispose();
                }
                ex.ToString();
                //throw ex;
            }
            return true;
        }

        public override bool WriteFileLog(string fileNames, string dingdan, string newBuyer)
        {
            fileNames = @"D:\log\" + fileNames + ".txt";
            TextWriter wirter = null;
            FileStream stream = null;
            try
            {
                //判断文件是否存在,如果不存在创建完文件 
                if (!File.Exists(fileNames))
                {
                    FileInfo fileinfo = new FileInfo(fileNames);
                    stream = fileinfo.Create();
                    stream.Dispose();
                }
                wirter = new StreamWriter(fileNames, true);
                StringBuilder sb = new StringBuilder();
                wirter.WriteLine();
                wirter.WriteLine("===================================");
                wirter.WriteLine("时间:           " + DateTime.Now.ToString());
                wirter.WriteLine("交易量:         " + dingdan);
                wirter.WriteLine("新增买家量:           " + newBuyer);
                wirter.WriteLine("=====================================");
                wirter.Flush();
                wirter.Close();
                wirter.Dispose();
                /*
                 * 通过记事本的方式保存日志文件.
                 * 业务逻辑:
                 * 1.定义日志文件命名
                 * 1.查看今天是否创建日志文件
                 * 2.如果没有创建文件，并写入相应的日志。
                 * 3.否则写入日志
                 */
            }
            catch (System.Exception ex)
            {
                if (stream != null) { stream.Dispose(); }
                if (wirter != null)
                {
                    wirter.Close();
                    wirter.Dispose();
                }
                ex.ToString();
                //throw ex;
            }
            return true;
        }
    }
}
