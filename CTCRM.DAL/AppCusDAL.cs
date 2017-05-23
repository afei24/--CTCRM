using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
using CTCRM.Entity;

namespace CTCRM.DAL
{
  public  class AppCusDAL
    {
      public static bool AddAppCus(AppCustomer obj)
      {
          try
          {
              string query = @"insert into CusPermitConfig (nick,created,[status])values(@nick,@created,@status)";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",obj.Nick),
                    new SqlParameter("@created",obj.Created),
                    new SqlParameter("@status",obj.Status)
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
      /// 设置卖家的主动通知为不可用
      /// </summary>
      /// <param name="sellerID"></param>
      /// <returns></returns>
      public static bool UpdateSellerNifty(String sellerID)
      {
          try
          {
              string query = @"update CusPermitConfig set status = 0 where id = @id";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",sellerID)
            };
            return  DataBase.ExecuteSql(query,param) > 0;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      
      }

      /// <summary>
      /// 删除卖家的主动通知消息
      /// </summary>
      /// <param name="sellerID"></param>
      /// <returns></returns>
      public static bool DeleteSellerNifty(String sellerID)
      {
          try
          {
              string query = @"delete from CusPermitConfig where nick = @nick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nick",sellerID)
            };
              return DataBase.ExecuteSql(query, param) > 0;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }

      }



      public static Boolean CheckAppCusIsExit(string sellerNick)
      {
          try
          {
              string query = @"SELECT 1 FROM CusPermitConfig WHERE nick = @nick";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nick",sellerNick)
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


      public static String GetSellerNickByID(string id)
      {
          try
          {
              string query = @"SELECT nick FROM CusPermitConfig WHERE id = @id";
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return dt.Rows[0]["nick"].ToString();
              }
              return "";
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return "";
          }
      }


      public static DataTable GetAppCus(String nick, string startDate, String endDate,string status)
      {
          try
          {
              string query = @"select C.id,C.nick,C.created,M.msgCanUseCount,(case when (C.status = '0') then '未开通' when (C.status = '1') then '已开通' else '未知状态' end) as status  
from CusPermitConfig C inner join MsgTrans M on C.nick = M.sellerNick where 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(nick))
              {
                  query += " AND C.nick = @nick ";
                  SqlParameter p1 = new SqlParameter("@nick", nick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(status))
              {
                  query += " AND C.status = @status ";
                  SqlParameter p2 = new SqlParameter("@status", status);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND C.created >= @startDate ";
                  SqlParameter P5 = new SqlParameter("@startDate", Convert.ToDateTime(startDate));
                  list.Add(P5);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND C.created <= @endDate ";
                  SqlParameter P6 = new SqlParameter("@endDate", Convert.ToDateTime(endDate));
                  list.Add(P6);
              }

              query += " order by C.created desc ";
              SqlParameter[] strParam = list.ToArray();
              DataTable ds = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return ds;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }


      public static DataTable GetNotifyData(string nick)
      {
          try
          {
              string query = @"select * from NotifyTrade where 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(nick))
              {
                  query += " AND nick = @nick ";
                  SqlParameter p1 = new SqlParameter("@nick", nick);
                  list.Add(p1);
              }
              query += " order by createDate desc ";
              SqlParameter[] strParam = list.ToArray();
              DataTable ds = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return ds;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }


         
      }

      public static DataTable GetNoMsgData()
      {
          try
          {
              string query = @"select M.sellerNick,M.serviceStatus,M.msgCanUseCount from MsgTrans M
inner join MsgSendConfig S ON M.sellerNick = S.sellerNick AND
M.msgCanUseCount <= 0 AND (S.unPayType = 1 OR unConfirmType = 1 OR shippingType = 1 OR arrivedType = 1) ";
              DataTable ds = DataBase.ExecuteDt(query);
              return ds;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }


      public static Boolean DeleteDataByDateTime(string datetime)
      {
          try
          {
              string query = @"delete from NotifyTrade where CONVERT(varchar, createDate, 112 ) = @datetime";
              SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@datetime",datetime)
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

      public static Boolean DeleteDataByNick(string nick)
      {
          try
          {
              string query = @"delete from NotifyTrade where nick = @nick";
              SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@nick",nick)
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

    }
}
