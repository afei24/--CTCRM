using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TTNI.Framework.Dao;

namespace CTCRM.DAL
{
    public class PrintDAL
    {

        public static DataTable GetSellerNickById(string SELLER_ID)
        {
            try
            {
                string query = @"select SESSKEY,NICK,endDate,Refresh_Token from Seller where SELLER_ID = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@SELLER_ID",SELLER_ID)
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
