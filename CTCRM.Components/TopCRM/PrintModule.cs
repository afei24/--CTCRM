using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
   public class PrintModule
    {

       /// <summary>
        /// 查询卖家地址库
       /// </summary>
       /// <param name="strSessionKey"></param>
       /// <param name="buyerNick"></param>
       /// <returns></returns>
       public static List<AddressResult> GetSellerAddress(string strSessionKey)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               LogisticsAddressSearchRequest req = new LogisticsAddressSearchRequest();
               req.Rdef = "get_def";
               LogisticsAddressSearchResponse rsp = client.Execute(req, strSessionKey);
               return rsp.Addresses;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

       /// <summary>
       /// 获取单笔交易的详细信息
       /// </summary>
       /// <param name="strSessionKey"></param>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static Trade GetTradeByTid(string strSessionKey,string tid)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
               req.Fields = @"tid,type,buyer_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,
               receiver_mobile,receiver_phone,receiver_zip,buyer_area,post_fee,created,seller_nick,payment,status,shipping_type,pay_time,modified,
orders.outer_iid,orders.discount_fee,orders.payment,orders.refund_status,orders.status,orders.pic_path,orders.sku_properties_name,orders.adjust_fee,
orders.outer_sku_id,orders.cid,orders.refund_id,orders.item_meal_name,orders.num,orders.title,orders.price,orders.oid,orders.total_fee,orders.num_iid,orders.sku_id,orders.seller_type";
               req.Tid = long.Parse(tid);
               TradeFullinfoGetResponse rsp = client.Execute(req, strSessionKey);
               return rsp.Trade;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

      /// <summary>
       /// 订单按日期下载
      /// </summary>
      /// <param name="strSessionKey"></param>
      /// <param name="startTime"></param>
      /// <param name="endTime"></param>
      /// <param name="pageNo"></param>
      /// <param name="pageSize"></param>
      /// <param name="hasNext"></param>
      /// <returns></returns>
       public static List<Trade> GetTradeByDate(string strSessionKey, string startTime, string endTime, string pageNo, string pageSize,
           string buyer_nick,string type,ref Boolean hasNext)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradesSoldGetRequest req = new TradesSoldGetRequest();
               req.Fields = @"tid,type,buyer_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,
               receiver_mobile,receiver_phone,receiver_zip,buyer_area,post_fee,created,seller_nick,payment,status,shipping_type,pay_time,modified,
orders.outer_iid,orders.discount_fee,orders.payment,orders.refund_status,orders.status,orders.pic_path,orders.sku_properties_name,orders.adjust_fee,
orders.outer_sku_id,orders.cid,orders.refund_id,orders.item_meal_name,orders.num,orders.title,orders.price,orders.oid,orders.total_fee,orders.num_iid,orders.sku_id,orders.seller_type";
               req.StartCreated = Convert.ToDateTime(startTime);
               req.EndCreated = Convert.ToDateTime(endTime);
               req.PageSize = Convert.ToInt64(pageSize);
               req.PageNo = Convert.ToInt64(pageNo);
               if (!string.IsNullOrEmpty(buyer_nick))
               {
                   req.BuyerNick = buyer_nick;
               }
               if (!string.IsNullOrEmpty(type))
               {
                   req.Type = type;
               }
               TradesSoldGetResponse rsp = client.Execute(req, strSessionKey);
               hasNext = rsp.HasNext;
               return rsp.Trades;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

       /// <summary>
       /// 订单增量下载
       /// </summary>
       /// <param name="strSessionKey"></param>
       /// <param name="startTime"></param>
       /// <param name="endTime"></param>
       /// <param name="pageNo"></param>
       /// <param name="pageSize"></param>
       /// <param name="buyer_nick"></param>
       /// <param name="type"></param>
       /// <param name="hasNext"></param>
       /// <returns></returns>
       public static List<Trade> GetBuyerTradeIncrement(string strSessionKey, string startTime, string endTime, string pageNo, string pageSize,
          string buyer_nick, string type, ref Boolean hasNext)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradesSoldIncrementGetRequest req = new TradesSoldIncrementGetRequest();
               req.Fields = @"tid,type,buyer_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,
               receiver_mobile,receiver_phone,receiver_zip,buyer_area,post_fee,created,seller_nick,payment,status,shipping_type,pay_time,modified,
orders.outer_iid,orders.discount_fee,orders.payment,orders.refund_status,orders.status,orders.pic_path,orders.sku_properties_name,orders.adjust_fee,
orders.outer_sku_id,orders.cid,orders.refund_id,orders.item_meal_name,orders.num,orders.title,orders.price,orders.oid,orders.total_fee,orders.num_iid,orders.sku_id,orders.seller_type";
               req.StartModified = Convert.ToDateTime(startTime);
               req.EndModified = Convert.ToDateTime(endTime);
               req.PageSize = Convert.ToInt64(pageSize);
               req.PageNo = Convert.ToInt64(pageNo);
               if (!string.IsNullOrEmpty(buyer_nick))
               {
                   req.BuyerNick = buyer_nick;
               }
               if (!string.IsNullOrEmpty(type))
               {
                   req.Type = type;
               }
               TradesSoldIncrementGetResponse rsp = client.Execute(req, strSessionKey);
               hasNext = rsp.HasNext;
               return rsp.Trades;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

      /// <summary>
       /// 获取当前会话用户出售中的商品列表
      /// </summary>
      /// <param name="strSessionKey"></param>
      /// <returns></returns>
       public static List<Item> GetItemsOnSale(string strSessionKey, string pageSize, string pageNo)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
               req.Fields = @"num_iid,outer_id,bar_code,price,seller_cids,pic_url,title";
               req.PageNo = long.Parse(pageNo);
               req.PageSize = long.Parse("200");
               ItemsOnsaleGetResponse rsp = client.Execute(req, strSessionKey);
               return rsp.Items;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }


      /// <summary>
       /// 自己联系物流（线下物流）发货
      /// </summary>
      /// <param name="strSessionKey"></param>
      /// <param name="tid"></param>
      /// <param name="outSid"></param>
      /// <param name="companyCode"></param>
      /// <returns></returns>
       public static Boolean LogisticsOfflineSend(string strSessionKey, string tid, string outSid, string companyCode)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               LogisticsOfflineSendRequest req = new LogisticsOfflineSendRequest();
               req.Tid = long.Parse(tid);
               req.OutSid = outSid;
               req.CompanyCode = companyCode;
               LogisticsOfflineSendResponse rsp = client.Execute(req, strSessionKey);
               return rsp.Shipping.IsSuccess;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return false;
           }
       }




    }
}
