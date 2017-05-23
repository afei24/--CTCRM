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
   public class ShortLinkDAL
    {
       public static bool AddShortLink(SellerShortLink entity)
       {
           try
           {
               string query = @"INSERT INTO SellerShortLink(sellerNick,linkType,linkUrl,createDate,memo)
                                VALUES(@sellerNick,@linkType,@linkUrl,getdate(),@memo)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",entity.SellerNick),
                    new SqlParameter("@linkType",entity.LinkType),
                    new SqlParameter("@linkUrl",entity.LinkUrl),
                    new SqlParameter("@memo",entity.Memo)
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

       public static DataTable GetShortLinkByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from SellerShortLink where sellerNick = @sellerNick order by createDate desc ";
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



    }
}
