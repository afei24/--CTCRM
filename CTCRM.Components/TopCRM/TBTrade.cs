using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api;
using Top.Api.Response;
using CTCRM.DAL;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.IO;

namespace CTCRM.Components.TopCRM
{
   public class TBTrade
    {
       /// <summary>
        /// 只能获取到三个月以内的交易信息
        /// TradesSoldGetRequest 获取单笔交易的详细信息 
       /// </summary>
       /// <param name="sellerNick">根据买家昵称获取交易信息</param>
       /// <param name="buyerNick"></param>
       /// <returns></returns>
       public List<Trade> GetBuyerTrade(string strSessionKey,string buyerNick)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradesSoldGetRequest req = new TradesSoldGetRequest();
               req.Fields = @"tid,buyer_nick,seller_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_mobile,buyer_email";
               req.BuyerNick = buyerNick;
               TradesSoldGetResponse response = client.Execute(req, strSessionKey);
               return response.Trades;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

       /// <summary>
       /// 优化为一次性读取卖家最近3个月的交易数据
       /// </summary>
       /// <param name="strSessionKey"></param>
       /// <param name="pageNum"></param>
       /// <param name="hasNext"></param>
       /// <returns></returns>
       public List<Trade> GetBuyerTrades(string strSessionKey,Int64 pageNum, ref bool hasNext)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradesSoldGetRequest req = new TradesSoldGetRequest();
               req.Fields = @"tid,buyer_nick,seller_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_mobile,buyer_email";
               req.PageNo = pageNum;
               req.StartCreated = Convert.ToDateTime(DateTime.Now.AddMonths(-3));
               req.EndCreated = Convert.ToDateTime(DateTime.Now);
               req.UseHasNext = true;
               req.PageSize = 100L;
               TradesSoldGetResponse response = client.Execute(req, strSessionKey);
               hasNext = response.HasNext;//是否有下一页
               return response.Trades;//返回信息数组，数组对象的属性为fields的参数
               
           }
           catch (Exception ex)
           {
               File.WriteAllText(@"D:\log\" + strSessionKey + ".txt", ex.Message, Encoding.Default);
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }
       public Trade GetBuyerInfoByTid(long tid)
       {
           try
           {

               ITopClient client = TBManager.GetClient();
               TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
               req.Fields = "receiver_name,receiver_mobile,status";
               req.Tid = tid;
               TradeFullinfoGetResponse response = client.Execute(req, Users.SessionKey);
               return response.Trade;
           }
           catch (Exception ex)
           {
               CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
               return null;
           }
       }


       /// <summary>
       /// 获取单笔交易的部分信息:查询该笔订单是否有退货
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public string GetBuyerTradeByTid(long tid)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradeGetRequest req = new TradeGetRequest();
               req.Fields = "orders.buyer_nick,orders.refund_status";
               req.Tid = tid;
               TradeGetResponse response = client.Execute(req, Users.SessionKey);
               Trade trade = response.Trade;
               string buyerNick = "";
               if (trade != null)
               {
                   if (trade.Orders.Count > 0)
                   {
                       foreach (Order o in trade.Orders)
                       {//查询该笔交易，如果有订单退款马上返回该买家
                           if (o.RefundStatus.Equals("SUCCESS"))
                               buyerNick = o.BuyerNick;
                           break;
                       }
                   }
               }
               return buyerNick;
           }
           catch (Exception ex)
           {
               CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
               return "";
           }
       }

       /// <summary>
       /// 订单关闭
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="reason"></param>
       /// <returns></returns>
       public Trade CloseOrderByTradeID(long tid, string reason)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradeCloseRequest req = new TradeCloseRequest();
               req.Tid = tid;
               req.CloseReason = reason;
               TradeCloseResponse response = client.Execute(req, Users.SessionKey);
               return response.Trade;
           }
           catch (Exception ex)
           {
               CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
               return null;
           }
       }


    }
}
