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
   public class BatchShippingDAL
    {
       public static bool AddBatchShipping(BatchShipping o)
       {
           try
           {
               string query = @"insert into BatchShipping(sellerNick,OrderNo,subOrderNo,yunDanNo,commpany,status,createDate)
                                values(@sellerNick,@OrderNo,@subOrderNo,@yunDanNo,@commpany,@status,@createDate)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@OrderNo",o.OrderNo),
                    new SqlParameter("@subOrderNo",o.SubOrderNo),
                    new SqlParameter("@yunDanNo",o.YunDanNo),
                    new SqlParameter("@commpany",o.Commpany),
                    new SqlParameter("@status",o.Status),
                    new SqlParameter("@createDate",DateTime.Now.ToShortDateString())
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
       /// 同步物流公司
       /// </summary>
       /// <param name="o"></param>
       /// <returns></returns>
       public static bool AddLogisticCompany(LogisticCompany o)
       {
           try
           {
               string query = @"insert into LogisticCompany(code,companyName)values(@code,@companyName)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@code",o.Code),
                    new SqlParameter("@companyName",o.CompanyName)
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
       /// 检查是否是拆分发货订单
       /// </summary>
       /// <param name="tradeNo"></param>
       /// <param name="sellerNick"></param>
       /// <returns></returns>
       public static Boolean CheckIsSubOrder(string tradeNo, string sellerNick)
       {
           try
           {
               string query = @"select 1 from BatchShipping where sellerNick = @sellerNick and OrderNo = @OrderNo";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderNo",tradeNo),
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

       public static DataTable GetBatchOrderData(string sellerNick)
       {
           try
           {
               string query = @"select id,OrderNo,subOrderNo,yunDanNo,commpany,status,memo
                                from BatchShipping where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
            return DataBase.ExecuteDt(query, param, CommandType.Text);
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static DataTable GetBatchOrderDataForSending(string sellerNick)
       {
           try
           {
               string query = @"select id OrderNo,subOrderNo,yunDanNo,commpany from BatchShipping where status = '可发货' and sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
               return DataBase.ExecuteDt(query, param, CommandType.Text); ;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static DataTable GetCompanyLst()
       {
           try
           {
               string query = @"select * from LogisticCompany ";
               return DataBase.ExecuteDt(query);
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static string GetLogistCodeByName(string company)
       {
           try
           {
               string query = @"select code from LogisticCompany where companyName = @company";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@company",company)
            };
               DataTable tb = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (tb != null && tb.Rows.Count == 1)
               {
                   return tb.Rows[0]["code"].ToString();
               }
               return "";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "";
           }
       }


       public static bool UpdateOrderStatus(string orderNo, string sellerNick, string id, string status, string memo)
       {
           try
           {
               string query = @"update BatchShipping 
                                set status = @status,
                                memo = @memo 
                                where OrderNo = @OrderNo and sellerNick = @sellerNick and id = @id";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@OrderNo",orderNo),
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@id",id),
                    new SqlParameter("@status",status),
                    new SqlParameter("@memo",memo)
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

       public static bool DeleteOrderByID(string id)
       {
           try
           {
               string query = @"delete from BatchShipping where id = @id";

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

       public static DataTable GetOrderByID(string id)
       {
           try
           {
               string query = @"select OrderNo,subOrderNo,yunDanNo,commpany from BatchShipping where id = @id";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id)
                };
               DataTable tb = DataBase.ExecuteDt(query, param, CommandType.Text);
               return tb;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static bool UpdateOrderInfo(BatchShipping o)
       {
           try
           {
               string query = @"update BatchShipping 
                                set OrderNo = @OrderNo,subOrderNo = @subOrderNo,yunDanNo = @yunDanNo,commpany = @commpany
                                where id = @id";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@OrderNo",o.OrderNo),
                    new SqlParameter("@subOrderNo",o.SubOrderNo),
                    new SqlParameter("@yunDanNo",o.YunDanNo),
                    new SqlParameter("@commpany",o.Commpany),
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


       public static bool DeleteAllOrder(string sellerNick)
       {
           try
           {
               string query = @"delete from BatchShipping where sellerNick = @sellerNick";

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


       public static bool ClearUnusedOrder(string sellerNick)
       {
           try
           {
               string query = @"delete from BatchShipping where sellerNick = @sellerNick and status='无效'";
               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)   
                };
                int val = DataBase.ExecuteSql(query, param);
                return val > 0;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static Boolean CheckIsTheSameOrder(string tradeNo,string subOrder, string sellerNick)
       {
           try
           {
               string query = @"select 1 from BatchShipping where sellerNick = @sellerNick and OrderNo = @OrderNo and subOrderNo = @subOrderNo";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderNo",tradeNo),
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@subOrderNo",subOrder)
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

    }
}
