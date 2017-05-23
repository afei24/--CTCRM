using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using Top.Api.Util;

namespace CTCRM.Components
{
   public class PrintBLL
    {
       public static DataTable GetSellerNickById(string userId)
       {
           return PrintDAL.GetSellerNickById(userId);
       }

       #region 交易
       public class parentTrade
       {
           public trades_response trades_response = new trades_response();
       }
       public class trades_response
       {
           public trades trades = new trades();
           public Boolean has_next = false;
       }
       public class trades
       {
           public List<PrintTrade> trade = null;
       }
       #endregion

       #region 商品
       public class parentProduct
       {
           public product_response items = new product_response();
           public Boolean has_next = false;
       }
       public class product_response
       {
           public List<PrintProduct> item = null;
       }
       public static List<PrintProduct> GetYTProdcut(List<Item> lstProducts)
       {
           List<PrintProduct> listPro = new List<PrintProduct>();
           PrintProduct printItem = null;
           product_response response = new product_response();
           if (lstProducts != null & lstProducts.Count > 0)
           {
               response.item = new List<PrintProduct>();
               foreach (Item product in lstProducts)
               {
                   printItem = new PrintProduct();
                   printItem.num_iid = product.NumIid.ToString();//商品编码
                   printItem.outer_id = product.OuterId;//商家编码
                   printItem.goods_code = "";//货号
                   printItem.model_code = "";//品牌型号
                   printItem.bar_code = product.Barcode;//商品条码,编码格式为128码
                   //用货号填充商家编码
                   printItem.price = product.Price;//
                   printItem.weight ="";
                   printItem.seller_cids = product.SellerCids;//商家分类
                   printItem.title = product.Title;
                   printItem.pic_path = product.PicUrl;
                   listPro.Add(printItem);
                   response.item.Add(printItem);
               }
               //response.total_results = listPro.Count.ToString(); 
           }
           return listPro;
       }
       #endregion

       public static List<PrintTrade> GetYTTrade(List<Trade> lstOrder)
       {
           try
           {
               Trades_Response response = new Trades_Response();
               PrintTrade trade = null;
               List<PrintTrade> listTrade = new List<PrintTrade>();
               PrintTradeOrder printOrder = null;
               if (lstOrder != null)
               {
                   response.trades = new List<PrintTrade>();
                   foreach (Trade order in lstOrder)
                   {
                       trade = new PrintTrade();
                       trade.tid = order.Tid.ToString();//
                       trade.type = order.Type.ToString();//交易类型列表
                       trade.buyer_nick = order.BuyerNick; //
                       trade.receiver_name = string.IsNullOrEmpty(order.ReceiverName) ? "" : order.ReceiverName;//
                       trade.receiver_state = string.IsNullOrEmpty(order.ReceiverState) ? "" : order.ReceiverState;//
                       trade.receiver_city = string.IsNullOrEmpty(order.ReceiverCity) ? "" : order.ReceiverCity;//
                       trade.receiver_district = string.IsNullOrEmpty(order.ReceiverDistrict) ? "" : order.ReceiverDistrict;//
                       trade.receiver_address = string.IsNullOrEmpty(order.ReceiverAddress) ? "" : order.ReceiverAddress;//
                       trade.receiver_mobile = string.IsNullOrEmpty(order.ReceiverMobile) ? "" : order.ReceiverMobile;//
                       trade.receiver_phone = string.IsNullOrEmpty(order.ReceiverPhone) ? "" : order.ReceiverPhone;//
                       trade.receiver_zip = string.IsNullOrEmpty(order.ReceiverZip) ? "" : order.ReceiverZip;//
                       trade.buyer_area = order.BuyerArea;
                       trade.post_fee = order.PostFee;
                       trade.promotion_details = order.PromotionDetails;
                       trade.created = order.Created;//
                       trade.seller_nick = order.SellerNick;//
                       trade.payment =order.Payment;//
                       trade.status = order.Status;
                       trade.shipping_type = order.ShippingType;
                       trade.pay_time = order.PayTime == null?"":order.PayTime;//
                       trade.modified = order.Modified ==null?"":order.Modified;//
                       List<Order> lstd = order.Orders;
                       if (lstd != null && lstd.Count > 0)
                       {
                           try
                           {
                               trade.orders = new printOrder();
                               trade.orders.order = new List<PrintTradeOrder>();
                               foreach (Order o in lstd)
                               {
                                   try
                                   {
                                       printOrder = new PrintTradeOrder();
                                       printOrder.outer_iid = o.OuterIid == null ? "" : o.OuterIid;                                       
                                       printOrder.discount_fee = o.DiscountFee;
                                       printOrder.payment = o.Payment;//
                                       printOrder.refund_status =o.RefundStatus;//退款状态
                                       printOrder.status = o.Status;//
                                       printOrder.pic_path = o.PicPath;//
                                       printOrder.sku_properties_name = o.SkuPropertiesName == null ? "" : o.SkuPropertiesName;//
                                       printOrder.adjust_fee = o.AdjustFee;
                                       printOrder.outer_sku_id = o.OuterSkuId == null ? "" : o.OuterSkuId;
                                       printOrder.cid = o.Cid.ToString();
                                       printOrder.refund_id = o.RefundId.ToString();//退款单ID
                                       printOrder.item_meal_name = o.ItemMealName == null ? "" : o.ItemMealName;//
                                       printOrder.num = o.Num.ToString();//
                                       printOrder.title = o.Title;//
                                       printOrder.price = o.Price;//
                                       printOrder.oid = o.Oid.ToString();//
                                       printOrder.total_fee = o.TotalFee;
                                       printOrder.num_iid = o.NumIid.ToString(); //sourceId :商品ID
                                       printOrder.sku_id = o.SkuId == null ? "" : o.SkuId;//
                                       printOrder.seller_type = o.SellerType;
                                       trade.orders.order.Add(printOrder);
                                   }
                                   catch (Exception ex)
                                   {
                                       ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                                       continue;
                                   }
                               }
                           }
                           catch (Exception ex)
                           {
                               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                               continue;
                           }
                       }
                       listTrade.Add(trade);
                       response.trades.Add(trade);
                   }
               }
               return listTrade;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }



    }
}
