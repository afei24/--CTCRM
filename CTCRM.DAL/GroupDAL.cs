using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
namespace CTCRM.DAL
{
   public class GroupDAL
    {
       public static bool AddGroup(CTCRM.Entity.Group o)
       {
           try
           {
               string query = @"insert into UserGroup(group_name,sellerNick,memo,createDate,openStatus)values(@group_name,@sellerNick,@memo,@createDate,@openStatus)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@group_name",o.Group_name),
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@memo",o.Memo),
                    new SqlParameter("@openStatus",o.OpenStatus),
                    new SqlParameter("@createDate",DateTime.Now)
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


       public static bool AddBuyerGroup(string groupID,string buyerID)
       {
           try
           {
               string query = @"insert into BuyerGroup (groupID,buyerID)values(@groupID,@buyerID)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@groupID",groupID),
                    new SqlParameter("@buyerID",buyerID)
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


       public static Boolean CheckBuyerGroupIsExit(string groupID, string buyerID)
       {
           try
           {
               string query = @"SELECT 1 FROM BuyerGroup WHERE groupID=@groupID and buyerID =@buyerID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@groupID",groupID),
                new SqlParameter("@buyerID",buyerID)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
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


       public static Boolean CheckGroupIsExit(string groupName,string sellerNick)
       {
           try
           {
               string query = @"SELECT 1 FROM UserGroup WHERE group_name=@group_name and sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@group_name",groupName),
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
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



       public static DataTable GetGroupByID(string sellerNick)
       {
           try
           {
               string query = @"select group_name,groupID from UserGroup  WHERE sellerNick=@sellerNick";
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


       public static DataTable GetGroupIDByName(string groupName,string sellerNick)
       {
           try
           {
               string query = @"select groupID from UserGroup  WHERE group_name=@groupName and sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@groupName",groupName),
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

    }
}
