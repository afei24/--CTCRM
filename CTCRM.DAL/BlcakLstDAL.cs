using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data.SqlClient;
using System.Data;


namespace CTCRM.DAL
{
   public class BlcakLstDAL
    {
       public static bool ChekBlaklist(BlakList obj)
       {
           try
           {
               string query = "select 1 from BlakList where sellerNick = @sellerNick and blakName = @blakName";
               // 设置SQL参数
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",obj.SellerNick),
                 new SqlParameter("@blakName",obj.BlakName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt.Rows.Count > 0;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }  
       }

       public static bool ChekWhitelist(WhiteList obj)
       {
           try
           {
               string query = "select 1 from WhiteList where sellerNick = @sellerNick ";
               // 设置SQL参数
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",obj.SellerNick) 
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt.Rows.Count > 0;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }
 
       public static DataTable GetBlaklist(string sellerNick)
       {
           try
           {
               string query = "select blakListID,blakName,operType,createDate from BlakList where sellerNick = @sellerNick";
               // 设置SQL参数
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

       public static DataTable GetWhitelist()
       {
           try
           {
               string query = "select * from WhiteList";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static DataTable GetWhitelistForMarket()
       {
           try
           {
               string query = "select * from MsgSendBLK";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static DataTable GetWhitelistForCKJ()
       {
           try
           {
               string query = "select * from MsgChannel";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static bool AddBlaklist(BlakList obj)
       {
           try
           {
               string query = "insert into BlakList(sellerNick,blakName,operType,createDate)values(@sellerNick,@blakName,@operType,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@blakName",obj.BlakName),
                    new SqlParameter("@operType",obj.OperType)
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

       public static bool AddWhitelist(WhiteList obj)
       {
           try
           {
               string query = "insert into WhiteList(sellerNick,createDate)values(@sellerNick,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
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
      
       public static bool DeleteBlaklist(string blakListID)
       {
           try
           {
               string query = "delete from BlakList where blakListID = @blakListID";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@blakListID",blakListID) 
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

       public static bool DeleteWhitelist(string sellerNick)
       {
           try
           {
               string query = "delete from WhiteList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
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
    }
}
