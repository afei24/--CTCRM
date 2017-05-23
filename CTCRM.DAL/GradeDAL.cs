using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;
using System.Data;

namespace CTCRM.DAL
{
   public class GradeDAL
    {
       public static bool AddGrade(Grade o)
       {
           try
           {
               string query = @"insert into Grade(levelID,tradeAmontFrom,tradeAmountTo,sellerNick)values(@levelID,@tradeAmontFrom,
                                @tradeAmountTo,@sellerNick)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@levelID",o.LevelID),
                    new SqlParameter("@tradeAmontFrom",o.TradeAmontFrom),
                    new SqlParameter("@tradeAmountTo",o.TradeAmountTo),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

       public static bool UpdateGrade(Grade o)
       {
           try
           {
               string query = @"update Grade set levelID =@levelID,tradeAmontFrom =@tradeAmontFrom,tradeAmountTo=@tradeAmountTo where id = @id and sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@levelID",o.LevelID),
                    new SqlParameter("@tradeAmontFrom",o.TradeAmontFrom),
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@tradeAmountTo",o.TradeAmountTo),
                    new SqlParameter("@id",o.Id)
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
       public static Boolean CheckSellerGrade(Grade o)
       {
           try
           {
               string query = @"select 1 from Grade where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",o.SellerNick)
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
       public static DataTable GetGradeByID(Grade o)
       {
           try
           {
               string query = @"select id,tradeAmontFrom,tradeAmountTo from Grade where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",o.SellerNick)
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
