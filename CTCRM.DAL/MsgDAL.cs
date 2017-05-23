using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;

namespace CTCRM.DAL
{
  public class MsgDAL
    {
      public static bool AddMsgPackage(MsgPackage obj)
      {
          try
          {
              string query = @"insert into MsgPackage(packageName,[type],price,perPrice,rank,sellerNick,orderDate,payStatus)
values(@packageName,@type,@price,@perPrice,@rank,@sellerNick,@orderDate,@payStatus)";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@packageName",obj.PackageName),
                    new SqlParameter("@type",obj.Type),
                    new SqlParameter("@price",obj.Price),
                    new SqlParameter("@perPrice",obj.PerPrice),
                    new SqlParameter("@rank",obj.Rank),
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@orderDate",obj.OrderDate),
                    new SqlParameter("@payStatus",obj.PayStatus)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      public static DataTable GetMsgReminderHisBySellerNick(string sellerNick, string starteDate, string endDate)
      {
          string query = @"select transNumber,buyerMemberId,sendDate,sendType,msgContent from MsgSendHisForReminder where 1= 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(starteDate))
          {
              query += " AND sendDate >= @startDate ";
              SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(starteDate));
              list.Add(P2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND sendDate <= @endDate ";
              SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
              list.Add(P3);
          }
          query += " order by sendDate desc";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }
      public static DataTable GetMsgReminderHisBySellerNick(string sellerNick, string starteDate, string endDate,string type)
      {
          string query = @"select transNumber,buyerMemberId,sendDate,sendType,msgContent from MsgSendHisForReminder where 1= 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(starteDate))
          {
              query += " AND sendDate >= @startDate ";
              SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(starteDate));
              list.Add(P2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND sendDate <= @endDate ";
              SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
              list.Add(P3);
          }
          if (!string.IsNullOrEmpty(type))
          {
              query += " AND sendType = @sendType ";
              SqlParameter P4 = new SqlParameter("@sendType", type);
              list.Add(P4);
          }
          query += " order by sendDate desc";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }

      /// <summary>
      /// 获取当前天卖家发送的号码
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static bool SellerSendPhoneYes(string sellerNick, string cellPhone)
      {
          try
          {
              string query = @"select 1 from SellerTestPhone where sellerNick = @sellerNick and testPhone = @cellPhone";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@cellPhone",cellPhone)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return true;
              }
              return false;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 记录卖家的移动电话号码
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      public static bool AddSellerYDNumber(string nick,string number)
      {
          try
          {
              string query = @"insert into SellerYDNNumber(sellerNick,ydNumber,sendDate)values(@sellerNick,@ydNumber,getdate())";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",nick),
                    new SqlParameter("@ydNumber",number)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      public static DataTable GetSellerYDNumbers(string sellerNick,string startDate,string endDate)
      {
          string query = @"select * from SellerYDNNumber where 1 = 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(startDate))
          {
              query += " AND sendDate >= @startDate ";
              SqlParameter p2 = new SqlParameter("@startDate", startDate);
              list.Add(p2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND sendDate <= @endDate";
              SqlParameter p3 = new SqlParameter("@endDate", endDate);
              list.Add(p3);
          }
          query += " order by sendDate desc";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }

      public static DataTable GetMsgHisByNick(string sellerNick)
      {
          try
          {
              string query = @"select packageName,[type],cast(useDays as nvarchar(50))+' 天' as useDays,cast(price as nvarchar(50)) + '元' as price,perPrice,rank,sellerNick,orderDate,endDate from MsgPackage where sellerNick = @sellerNick and payStatus = 1 order by orderDate desc ";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetMsgHis(string sellerNick, string satrtOrderDate, string endOrderDate, string rank)
      {
          try
          {
              string query = @"select packageName,[type],cast(useDays as nvarchar(50))+' 天' as useDays,cast(price as nvarchar(50)) + '元' as price,perPrice,rank,sellerNick,orderDate,endDate from MsgPackage where 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellerNick))
              {
                  query += " AND sellerNick = @sellerNick ";
                  SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(satrtOrderDate))
              {
                  query += " AND orderDate >= @startDate ";
                  SqlParameter p2 = new SqlParameter("@startDate", satrtOrderDate);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(endOrderDate))
              {
                  query += " AND orderDate <= @endDate";
                  SqlParameter p3 = new SqlParameter("@endDate", endOrderDate);
                  list.Add(p3);
              }
              if (!rank.Equals("---全部---"))
              {
                  query += " AND rank = @rank";
                  SqlParameter p6 = new SqlParameter("@rank", rank);
                  list.Add(p6);
              }

              query += "  order by orderDate desc ";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }


      public static string  CheckSellerMsgTransIsExit(string sellerNick)
      {
          try
          {
              string query = @"SELECT serviceStatus FROM MsgTrans WHERE sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt!=null && dt.Rows.Count > 0)
              {
                  return dt.Rows[0]["serviceStatus"].ToString();
              }
              return null;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      /// <summary>
      /// 获取卖家短信事务明细
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetSellerMsgTrans(string sellerNick)
      {
          try
          {
              string query = @"SELECT * FROM MsgTrans WHERE sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return dt;
              }
              return null;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static bool AddMsgTrans(MsgPackage obj)
      {
          try
          {
              string query = @"insert into MsgTrans(packageName,canUseStartDate,msgCanUseCount,msgTotalCount,rank,serviceStatus,sellerNick)
                               values(@packageName,@canUseStartDate,@msgCanUseCount,@msgTotalCount,@rank,@serviceStatus,@sellerNick)";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@packageName",obj.PackageName),
                    new SqlParameter("@canUseStartDate",obj.CanUseStartDate),
                    new SqlParameter("@msgCanUseCount",obj.MsgCanUseCount),
                    new SqlParameter("@msgTotalCount",obj.MsgTotalCount),
                    new SqlParameter("@rank",obj.Rank),
                    new SqlParameter("@serviceStatus",obj.ServiceStatus),
                    new SqlParameter("@sellerNick",obj.SellerNick)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }


      public static bool UpdateMsgTrans(MsgPackage o)
      {
          try
          {
              string query = @"update MsgTrans 
                                set canUseStartDate = @canUseStartDate,
                                msgCanUseCount=@msgCanUseCount,
                                msgTotalCount=@msgTotalCount,
                                serviceStatus = @serviceStatus 
                                where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                     new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@canUseStartDate",o.CanUseStartDate),
                    new SqlParameter("@msgCanUseCount",o.MsgCanUseCount),
                    new SqlParameter("@msgTotalCount",o.MsgTotalCount),
                    new SqlParameter("@serviceStatus",true)
                };
              DataBase.ExecuteSql(query, param);

              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }

      }

     /// <summary>
     /// 短信营销和智能营销时保存卖家上次发送的短信内容！
     /// </summary>
     /// <param name="sellerNick"></param>
     /// <param name="msgContent"></param>
     /// <returns></returns>
      public static bool UpdateSellerCusMsgContent(string sellerNick,string msgContent)
      {
          try
          {
              string query = @"update MsgSendConfig 
                                set lastestMsgConent = @lastestMsgConent 
                                where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                     new SqlParameter("@lastestMsgConent",msgContent),
                    new SqlParameter("@sellerNick",sellerNick)
                };
              DataBase.ExecuteSql(query, param);

              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }

      }



      /// <summary>
      /// 卖家第二次进行短信套餐订购时更新
      /// </summary>
      /// <param name="o"></param>
      /// <returns></returns>
      public static bool UpdateMsgTransForSecond(MsgPackage o)
      {
          try
          {
              string query = @"update MsgTrans set
                                msgCanUseCount = msgCanUseCount + @msgCanUseCount,
                                msgTotalCount = msgTotalCount + @msgTotalCount,
                                serviceStatus = @serviceStatus 
                                where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                     new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@msgCanUseCount",o.MsgCanUseCount),
                    new SqlParameter("@msgTotalCount",o.MsgTotalCount),
                    new SqlParameter("@serviceStatus",true)
                };
              DataBase.ExecuteSql(query, param);

              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }

      }

      /// <summary>
      /// 更新卖家短信账户状态
      /// </summary>
      /// <param name="o"></param>
      /// <returns></returns>
      public static bool UpdateMsgTransServiceStatus(string sellerNick, Boolean serviceStatus)
      {
          try
          {
              string query = @"update MsgTrans set serviceStatus = @serviceStatus,msgTotalCount = 0 where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@serviceStatus",serviceStatus)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 短信清零
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="serviceStatus"></param>
      /// <returns></returns>
      //public static bool UpdateMsgClearCount(string sellerNick)
      //{
      //    try
      //    {
      //        string query = @"update MsgTrans set msgCanUseCount = 0,msgTotalCount = 0,serviceStatus = 0 where sellerNick = @sellerNick";

      //        SqlParameter[] param = new SqlParameter[] 
      //          {
      //              new SqlParameter("@sellerNick",sellerNick)  
      //          };
      //        DataBase.ExecuteSql(query, param);
      //        return true;
      //    }
      //    catch (Exception ex)
      //    {
      //        ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
      //        return false;
      //    }
      //}

      public static bool UpdateMsgTransUseCount(string sellerNick, int perMsgCount)
      {
          try
          {
              string query = @"update MsgTrans set msgCanUseCount = msgCanUseCount - @perMsgCount where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@perMsgCount",perMsgCount)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }


    /// <summary>
      /// 删除卖家的短信发送历史记录
    /// </summary>
    /// <param name="transNumber"></param>
    /// <returns></returns>
      public static bool DeleteMsgHis(string transNumber)
      {
          try
          { 
              string query = @"delete from MsgSendHis where transNumber = @transNumber";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",transNumber)  
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetMoreYiWanMsg()
      {
          string query = @"select * from 
            (select sellerNick, count(sellerNick) as msgCount from MsgSendHis group by sellerNick ) M where M.msgCount>10";
          DataTable dt =   DataBase.ExecuteDt(query);
          if (dt == null)
          { return null; }
          return dt;
      }

      public static bool DeleteMsgHisForReminder(string transNumber)
      {
          try
          {
              string query = @"delete from MsgSendHisForReminder where transNumber = @transNumber";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",transNumber)  
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      public static DataTable GetSellerMsgStatus(string sellerNick)
      {
          try
          {
              string query = @"SELECT msgCanUseCount FROM MsgTrans WHERE sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      /// <summary>
      /// 获得给卖家设置的发送百分之几
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetSellerMsgSendPrecent(string sellerNick)
      {
          try
          {
              string query = @"SELECT sendPrecent FROM MsgTrans WHERE sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      /// <summary>
      /// 查询卖家保存的短信内容：短信群发和智能营销
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static String GetSellerSendMsgCusContent(string sellerNick)
      {
          try
          {
              string query = @"select lastestMsgConent from MsgSendConfig where  sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0) {
                  return dt.Rows[0]["lastestMsgConent"].ToString();
              }
              return "";
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return "";
          }
      }


      public static bool AddMsgTemp(MsgTemp obj)
      {
          try
          {
              string query = @"insert into MsgTemp(title,msgContent,createDate,sellerNick)values(@title,@msgContent,@createDate,@sellerNick)";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@title",obj.Title),
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@createDate",DateTime.Now),
                    new SqlParameter("@sellerNick",obj.SellerNick)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }


      public static bool DeleteMsgTemp(string tempId)
      {
          try
          {
              string query = @"delete from MsgTemp where tempId = @tempId";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tempId",tempId)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }


      public static DataTable GetMsgTempByNick(string sellerNick)
      {
          try
          {
              string query = @"select tempId,title,msgContent,createDate,sellerNick,case [type] when 0 then '系统创建' when 1 then sellerNick + '创建' end as [type] from MsgTemp where sellerNick = @sellerNick or type = 0 order by createDate desc ";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      /// <summary>
      /// 查询短信发送内容
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgContentByTransID(string transNumber)
      {
          try
          {
              string query = @"select msgContent from MsgSendHis where transNumber = @transNumber ";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@transNumber",transNumber)
                };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetSellerMsgUnuseDateByNick(string sellerNick)
      {
          try
          {
              string query = @"select unUseDate from MsgTrans where sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }


      public static string GetMsgTempContentByID(string tempId)
      {
          try
          {
              string query = @"select msgContent from MsgTemp where tempId = @tempId";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@tempId",tempId)
                };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0) {
                  return dt.Rows[0]["msgContent"].ToString();
              }
              return "";

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return "";
          }
      }



      public static Boolean CheckSellerMsgTempIsExit(string title, string sellerNick)
      {
          try
          {
              string query = @"SELECT 1 FROM MsgTemp WHERE title=@title and sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@title",title),
                 new SqlParameter("@sellerNick",sellerNick)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return true;
              }
              return false;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 返回需要审核的短信套餐包
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="startDate"></param>
      /// <param name="endDate"></param>
      /// <returns></returns>
      public static DataTable GetAuditMessage(string sellerNick, string startDate, string endDate, string auditSatus)
      {
          string query = @"select id,packageName,useDays,price,sellerNick,orderDate,endDate,case payStatus when 1 then '通过' when 0 then '未通过' end payStatus from  MsgPackage where 1 = 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(startDate))
          {
              query += " AND orderDate >= @startDate ";
              SqlParameter p2 = new SqlParameter("@startDate", startDate);
              list.Add(p2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND endDate <= @endDate";
              SqlParameter p3 = new SqlParameter("@endDate", endDate);
              list.Add(p3);
          }
          if (!string.IsNullOrEmpty(auditSatus))
          {
              query += " AND payStatus = @auditSatus";
              SqlParameter p4 = new SqlParameter("@auditSatus", auditSatus);
              list.Add(p4);
          }
          query += " order by orderDate desc";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }

      /// <summary>
      /// 删除用户未付款的短信包
      /// </summary>
      /// <param name="tempId"></param>
      /// <returns></returns>
      public static bool DeleteMsgPakage(string tempId)
      {
          try
          {
              string query = @"delete from MsgPackage where id = @tempId";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tempId",tempId)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetSellerMsgSendHisForReminder(string sellerNick, string startDate, string endDate, string sendType, string helpSellerNick, string buyerPhone)
      {
          try
          {
              string query = @"select transNumber,sellerNick,sendStatus,buyerMemberId,cellPhone,sendDate,
                                sendType,msgContent,helpSellerNick from MsgSendHisForReminder WHERE 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellerNick))
              {
                  query += " AND sellerNick = @sellerNick ";
                  SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND sendDate >= @startDate ";
                  SqlParameter p2 = new SqlParameter("@startDate", startDate);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND sendDate <= @endDate";
                  SqlParameter p3 = new SqlParameter("@endDate", endDate);
                  list.Add(p3);
              }
              if (!sendType.Equals("---全部---"))
              {
                  query += " AND sendType = @sendType";
                  SqlParameter p6 = new SqlParameter("@sendType", sendType);
                  list.Add(p6);
              }
              if (!string.IsNullOrEmpty(helpSellerNick))
              {
                  query += " AND helpSellerNick = @helpSellerNick";
                  SqlParameter p23 = new SqlParameter("@helpSellerNick", helpSellerNick);
                  list.Add(p23);
              }
              if (!string.IsNullOrEmpty(buyerPhone))
              {
                  query += " AND cellPhone = @buyerPhone";
                  SqlParameter p26 = new SqlParameter("@buyerPhone", buyerPhone);
                  list.Add(p26);
              }
              query += " order by sendDate desc";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }


      /// <summary>
      /// 查询卖家的短信发送历史记录
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetSellerMsgSendHis(string sellerNick, string startDate, string endDate, string sendType, string helpSellerNick, string buyerPhone, string sendStatus)
      {
          try
          {
              string query = @"select transNumber,sellerNick,sendStatus,buyer_nick,cellPhone,sendDate,sendType,msgContent,helpSellerNick,msgChannel,sendStatus from MsgSendHis WHERE 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellerNick))
              {
                  query += " AND sellerNick = @sellerNick ";
                  SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND sendDate >= @startDate ";
                  SqlParameter p2 = new SqlParameter("@startDate", startDate);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND sendDate <= @endDate";
                  SqlParameter p3 = new SqlParameter("@endDate", endDate);
                  list.Add(p3);
              }
              if (!sendType.Equals("---全部---"))
              {
                  query += " AND sendType = @sendType";
                  SqlParameter p6 = new SqlParameter("@sendType", sendType);
                  list.Add(p6);
              }
              if (!sendStatus.Equals("---全部---"))
              {
                  if (sendStatus.Equals("发送成功"))
                  {
                      query += " AND (sendStatus = 0 or sendStatus = 100)";
                  }
                  else if (sendStatus.Equals("未发送"))
                  {
                      query += " AND (sendStatus = 99)";
                  }
                  
                  SqlParameter p6 = new SqlParameter("@sendStatus", sendStatus);
                  list.Add(p6);
              }
              if (!string.IsNullOrEmpty(helpSellerNick))
              {
                  query += " AND helpSellerNick = @helpSellerNick";
                  SqlParameter p23 = new SqlParameter("@helpSellerNick", helpSellerNick);
                  list.Add(p23);
              }
              if (!string.IsNullOrEmpty(buyerPhone))
              {
                  query += " AND cellPhone = @buyerPhone";
                  SqlParameter p26 = new SqlParameter("@buyerPhone", buyerPhone);
                  list.Add(p26);
              }
              query += " order by sendDate desc";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetSellerMsgSendHis(string startDate, string endDate)
      {
          try
          {
              string query = @"select distinct sellerNick,1 as transNumber,1 as buyer_nick,1 as cellPhone,1 as sendDate,1 as sendType, 1 as msgContent,1 as helpSellerNick,1 as sendStatus from MsgSendHis WHERE 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND sendDate >= @startDate ";
                  SqlParameter p2 = new SqlParameter("@startDate", startDate);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND sendDate <= @endDate";
                  SqlParameter p3 = new SqlParameter("@endDate", endDate);
                  list.Add(p3);
              }
              query += " AND (sendType = '短信促销' or sendType = '智能营销'or sendType = '手工发送')";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static bool UpdateMsgPakage(string id)
      {
          try
          {
              string query = @"update MsgPackage set payStatus = 1 where id = @id";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }


      public static DataTable GetMsgPakageByID(string id)
      {
          string query = @"select id,packageName,rank,useDays,price,sellerNick,orderDate,endDate, payStatus from  MsgPackage where id = @id ";

          SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id)
                };
          DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
          return dt;
      }

      /// <summary>
      /// 获取卖家发送的短信明细
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DataTable GetMsgTransBySellerNick(string sellerNick,string starteDate,string endDate)
      {
          //string query = @"select transNumber,buyer_nick,cellPhone,sendDate,sendType from MsgSendHis where sendStatus = 1 and sellerNick = @sellerNick  order by sendDate desc";
          string query = @"select transNumber,buyer_nick,sendDate,sendType,msgContent from MsgSendHis where 1= 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(starteDate))
          {
              query += " AND sendDate >= @startDate ";
              SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(starteDate));
              list.Add(P2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND sendDate <= @endDate ";
              SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
              list.Add(P3);
          }
          query += " order by sendDate desc"; 
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }


      /// <summary>
      /// 用于短信商那边每月对账后清零重新开始统计
      /// </summary>
      /// <returns></returns>
      public static bool ClearMsgCountForCT()
      {
          try
          {
              string query = @"update MyMsgStatic set successCount = 0 ,failedCount = 0, createDate = getdate(), updateDate = getdate()";
              DataBase.ExecuteSql(query);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 累计发送失败的条数
      /// </summary>
      /// <returns></returns>
      public static bool CountFailedMsgSend()
      {
          try
          {
              string query = @"update MyMsgStatic set failedCount = failedCount + 1, updateDate = getdate()";
              DataBase.ExecuteSql(query);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 统计发送失败的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static string GetFailedCount()
      {
          string query = @"select failedCount from MyMsgStatic";
          DataTable dt = DataBase.ExecuteDt(query);
          if (dt != null && dt.Rows.Count > 0) {
              return dt.Rows[0]["failedCount"].ToString();
          }
          return "0";
      }

      /// <summary>
      /// 统计物流发送的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendHisForReminderCount(string seller)
      {
          string query = @"select sellerNick,count(sellerNick) as msgCount from MsgSendHisForReminder ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(seller))
          {
              query += " where sellerNick = @sellerNick ";
              SqlParameter P3 = new SqlParameter("@sellerNick", seller);
              list.Add(P3);
          }
          query += "group by sellerNick";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          if (dt != null && dt.Rows.Count > 0)
          {
              return dt;
          }
          return null;
      }

      /// <summary>
      /// 统计营销发送的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendHisCount(string seller)
      {
          string query = @"select sellerNick,count(sellerNick) as msgCount from MsgSendHis ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(seller))
          {
              query += " where sellerNick = @sellerNick ";
              SqlParameter P3 = new SqlParameter("@sellerNick", seller);
              list.Add(P3);
          }
          query += "group by sellerNick";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          if (dt != null && dt.Rows.Count > 0)
          {
              return dt;
          }
          return null;
      }

      /// <summary>
      /// 统计发送的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendCount(string startTime, string endTime)
      {
          string query = @" select * from (
              select sellernick ,count(sellernick)as msgCount  from dbo.MsgSendHis where 1= 1 
              ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(startTime))
          {
              query += " and sendDate > @startTime ";
              SqlParameter P1 = new SqlParameter("@startTime", startTime);
              list.Add(P1);
          }
          if (!string.IsNullOrEmpty(endTime))
          {
              query += " and sendDate < @endTime ";
              SqlParameter P2 = new SqlParameter("@endTime", endTime);
              list.Add(P2);
          }
          query += @"group by sellernick
                    union all 
                    select sellernick ,count(sellernick)as msgCount  from dbo.MsgSendHisForReminder where 1= 1 ";
          if (!string.IsNullOrEmpty(startTime))
          {
              query += " and sendDate > @startTime ";
          }
          if (!string.IsNullOrEmpty(endTime))
          {
              query += " and sendDate < @endTime ";
          }
          query += @"group by sellernick) as msgs";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          if (dt != null && dt.Rows.Count > 0)
          {
              return dt;
          }
          return null;
      }

      /// <summary>
      /// 清空上次积分情况
      /// </summary>
      /// <returns></returns>
      public static bool DeleteMsgRecords()
      {
          try
          {
              string query = @"delete from  MsgRecords";
              DataBase.ExecuteSql(query);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static bool InsertMsgRecords(string sellernick, string msgCount, string Price, string evPrice)
      {
          try
          {
              string query = @"INSERT INTO [MsgRecords]
                   ([sellernick]
                   ,[msgCount]
                   ,[Price]
                   ,[evPrice]
                   ,[dateTime]
                   ,[note])
             VALUES
                   (@sellernick
                   ,@msgCount
                   ,@Price
                   ,@evPrice
                   ,@dateTime
                   ,@note)";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellernick",sellernick),
                    new SqlParameter("@msgCount",Convert.ToInt32( msgCount)),
                    new SqlParameter("@dateTime",DateTime.Now),
                    new SqlParameter("@evPrice",evPrice),
                    new SqlParameter("@note",""),
                    new SqlParameter("@Price",Convert.ToDecimal( Price))
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 获取订购二十万条短信卖家短信信息
      /// </summary>
      /// <param name="sellernick"></param>
      /// <param name="msgCount"></param>
      /// <param name="Price"></param>
      /// <param name="evPrice"></param>
      /// <returns></returns>
      public static DataTable GetTwo()
      {
          try
          {
             // string query = @"select * from MsgTrans where  sellerNick in( select sellerNick from dbo.MsgPackage where packageName='店铺管家短信套餐(淘宝)200000条')";
              string query = @" select * from dbo.MsgTrans where packageName='店铺管家短信套餐(淘宝)200000条'";
             DataTable dt =  DataBase.ExecuteDt(query);
             if (dt != null || dt.Rows.Count > 0)
             {
                 return dt;
             }
             return null;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetMsgRecords(string sellernick)
      {
          try
          {
              // string query = @"select * from MsgTrans where  sellerNick in( select sellerNick from dbo.MsgPackage where packageName='店铺管家短信套餐(淘宝)200000条')";
              string query = @" SELECT [sellernick]
                  ,[msgCount]
                  ,[Price]
                  ,[evPrice]
                  ,[dateTime]
                  ,[note]
              FROM MsgRecords";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellernick))
              {
                  query += " where sellernick = @sellernick ";
                  SqlParameter P1 = new SqlParameter("@sellernick", sellernick);
                  list.Add(P1);
              }
             
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              if (dt != null || dt.Rows.Count > 0)
              {
                  return dt;
              }
              return null;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetMsgRecordsSum()
      {
          try
          {
              // string query = @"select * from MsgTrans where  sellerNick in( select sellerNick from dbo.MsgPackage where packageName='店铺管家短信套餐(淘宝)200000条')";
              string query = @"   select SUM(msgCount) as msg_count,SUM(Price) as msg_Price   FROM MsgRecords";
              DataTable dt = DataBase.ExecuteDt(query);
              if (dt != null || dt.Rows.Count > 0)
              {
                  return dt;
              }
              return null;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

    }
}
