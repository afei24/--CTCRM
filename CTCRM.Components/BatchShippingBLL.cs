using CTCRM.Components.TopCRM;
using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Top.Api.Domain;

namespace CTCRM.Components
{
   public class BatchShippingBLL
    {

       public static void CheckOrder(DataTable tbSource, string sellerNick)
       {
           if (tbSource != null && tbSource.Rows.Count > 0)
           {
               TBTrade objTrade = new TBTrade();
               for (int i = 0; i < tbSource.Rows.Count; i++)
               {
                   string orderNo = tbSource.Rows[i]["OrderNo"].ToString();
                   string id = tbSource.Rows[i]["id"].ToString();
                   string company = tbSource.Rows[i]["commpany"].ToString();
                   string code = BatchShippingDAL.GetLogistCodeByName(company);
                   if (!string.IsNullOrEmpty(code)){
                        Trade trade = objTrade.GetBuyerInfoByTid(Convert.ToInt64(orderNo));
                        if (trade != null)
                        {
                            if (trade.Status.Equals("WAIT_SELLER_SEND_GOODS"))//等待卖家发货,即:买家已付款
                            {
                                BatchShippingDAL.UpdateOrderStatus(orderNo, sellerNick, id, "可发货","");
                            }
                            else
                            {
                                BatchShippingDAL.UpdateOrderStatus(orderNo, sellerNick, id, "无效","该订单号无效");
                            }
                        }
                        else
                        {
                            BatchShippingDAL.UpdateOrderStatus(orderNo, sellerNick, id, "无效","该订单号无效");
                        }
                    }
                   else
                   {
                       BatchShippingDAL.UpdateOrderStatus(orderNo, sellerNick, id, "无效", "物流公司名称不正确");
                   }
               }
           }                
       }

       public static bool DeleteOrderByID(string id)
       {
           return BatchShippingDAL.DeleteOrderByID(id);
       }
       public static bool DeleteAllOrder(string sellerNick)
       {
           return BatchShippingDAL.DeleteAllOrder(sellerNick);
       }
       public static string GetLogistCodeByName(string company)
       {
           return BatchShippingDAL.GetLogistCodeByName(company);
       }
       public static bool UpdateOrderInfo(BatchShipping o)
       {
           return BatchShippingDAL.UpdateOrderInfo(o);
       }
       public static bool ClearUnusedOrder(string sellerNick)
       {
           return BatchShippingDAL.ClearUnusedOrder(sellerNick);
       }
       public static DataTable GetBatchOrderDataForSending(string sellerNick)
       {
           return BatchShippingDAL.GetBatchOrderDataForSending(sellerNick);
       }
       public static DataTable GetOrderByID(string id)
       {
           return BatchShippingDAL.GetOrderByID(id);
       }
       public static DataTable GetCompanyLst()
       {
           return BatchShippingDAL.GetCompanyLst();
       }
       public static bool AddBatchShipping(BatchShipping o)
       {
           return BatchShippingDAL.AddBatchShipping(o);
       }
       public static Boolean CheckIsSubOrder(string tradeNo, string sellerNick)
       {
           return BatchShippingDAL.CheckIsSubOrder(tradeNo,sellerNick);
       }
       public static Boolean CheckIsTheSameOrder(string tradeNo, string subOrder, string sellerNick)
       {
           return BatchShippingDAL.CheckIsTheSameOrder(tradeNo, subOrder, sellerNick);
       }
       public static DataTable GetBatchOrderData(string sellerNick)
       {
           return BatchShippingDAL.GetBatchOrderData(sellerNick);
       }
       public static bool AddLogisticCompany()
       {
          LogisticCompany o = null;
          List<LogisticsCompany> lstCpany = TBLogistics.GetTBLogistics();
          if (lstCpany != null && lstCpany.Count > 0)
          {
              for (int i = 0; i < lstCpany.Count; i++)
              {
                  o = new LogisticCompany();
                  o.Code = lstCpany[i].Code;
                  o.CompanyName = lstCpany[i].Name;
                  BatchShippingDAL.AddLogisticCompany(o);
              }
          }
          return true;
       }
      
    }
}
