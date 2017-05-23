using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CTCRM.DAL
{
   public class PicDAL
    {
       public static Boolean CheckSpace(SavedSpace entity)
       {
           try
           {
               string query = @"SELECT 1 as result FROM SavedSpace WHERE sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",entity.SellerNick)
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

       public static bool AddSpace(SavedSpace entity)
       {
           try
           {
               string query = @"INSERT INTO SavedSpace(totalSavedSpace,sellerNick,createDate)
                                VALUES(@totalSavedSpace,@sellerNick,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@totalSavedSpace",entity.TotalSavedSpace),
                    new SqlParameter("@sellerNick",entity.SellerNick)
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

       public static bool UpdateSpace(SavedSpace entity)
       {
           try
           {
               string query = @"update SavedSpace 
                                set totalSavedSpace = totalSavedSpace + @totalSavedSpace, updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@totalSavedSpace",entity.TotalSavedSpace),
                    new SqlParameter("@sellerNick",entity.SellerNick)
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

       public static Int64 GetToalSavedSpace(string sellerNick)
       {
           try
           {
               string query = @"SELECT totalSavedSpace FROM SavedSpace WHERE sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return Convert.ToInt64(dt.Rows[0]["totalSavedSpace"]);
               }
               return 0;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return 0;
           }
       }
    }
}
