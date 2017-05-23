using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace SynMember
{
   public class SqlData
    {

      /// <summary>
      /// 获取需要同步会员的卖家
      /// </summary>
      /// <param name="lsUserName"></param>
      /// <param name="lsSessionKey"></param>
      /// <param name="lsTime"></param>
       public static void GetSyncMemUser(out List<string> lsUserName, out List<string> lsSessionKey, out List<string> lsTime)
       {
           SqlConnection connection = new SqlConnection(DataBaseTool.GetSqlConnection());
           connection.Open();
           lsUserName = new List<string>();
           lsSessionKey = new List<string>();
           lsTime = new List<string>();
           SqlCommand sqlcmd;
           //sqlcmd = new SqlCommand("select [Nick], [SessKey], [SyncTime] from [Seller] where [SyncMem]>0", connection);
           sqlcmd = new SqlCommand("select [Nick], [SessKey], [SyncTime] from [Seller] where( GETDATE() < endDate and GETDATE() >CreatedDate) or endDate=''", connection);
           //sqlcmd.Parameters.Add(new SqlParameter("sTime", DateTime.Now));
           SqlDataReader sdr = sqlcmd.ExecuteReader();
           while (sdr.Read())
           {
               lsUserName.Add(sdr.IsDBNull(0) ? "" : sdr.GetString(0));
               lsSessionKey.Add(sdr.IsDBNull(1) ? "" : sdr.GetString(1));
               lsTime.Add(sdr.IsDBNull(2) ? "" : sdr.GetString(2));
           }
           sdr.Close();
           connection.Close();
       }
       
    }
}
