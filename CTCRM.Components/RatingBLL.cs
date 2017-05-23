using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CTCRM.DAL;
using CTCRM.Entity;
using Top.Api.Domain;
using CTCRM.Components.TopCRM;

namespace CTCRM.Components
{
   public class RatingBLL
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
       public RatingBLL()
        {
            List<TradeRate> TotalPoolRates = null;
            PageNo = 0;
            CurrentPage = 1;
            PageSize = 100;
        }

        #endregion

       Int64 CurrentPage
       {
           get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["CurrentPage"]); }
           set { System.Web.HttpContext.Current.Session["CurrentPage"] = value; }
       }

       Int64 PageNo
       {
           get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["PageNo"]); }
           set { System.Web.HttpContext.Current.Session["PageNo"] = value; }
       }
       Int64 PageSize
       {
           get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["PageSize"]); }
           set { System.Web.HttpContext.Current.Session["PageSize"] = value; }
       }

       List<TradeRateChild> TotalPoolRates
       {
           get { return (List<TradeRateChild>)System.Web.HttpContext.Current.Session["TotalPoolRates"]; }
           set { System.Web.HttpContext.Current.Session["TotalPoolRates"] = value; }
       }

       Int64 total = 0;


       /// <summary>
       /// 查询卖家最近半年获得的中差评
       /// 修改人：LU
       /// 日期：20160909
       /// </summary>
       /// <param name="startDate"></param>
       /// <param name="endDate"></param>
       /// <returns></returns>
       public List<TradeRateChild> GetSellerRate(String startDate, String endDate, string sellerNick)
       {
           RatingTop rateObj = new RatingTop();
           TBTrade objTrade = new TBTrade();
           RatingDAL objDal = new RatingDAL();
           
           List<TradeRate> lstTradeRate = new List<TradeRate>();
           //检查商家设置：是否开通半年内差评和退款的买家加入黑名单
           DataRow drCfg = objDal.CheckIsOpenAddBlakList(sellerNick);
           if (drCfg != null)
           {
               //调用接口搜索评价信息:只能获取距今180天内的评价记录(只支持查询卖家给出或得到的评价)
               lstTradeRate = rateObj.GetTradeRate(CurrentPage, PageSize, startDate, endDate, ref total);
           }

           if (lstTradeRate != null && lstTradeRate.Count > 0)
           {
               TradeRateChild objRate = null;
               foreach (TradeRate rate in lstTradeRate)
               {
                   if (TotalPoolRates == null)
                   {
                       TotalPoolRates = new List<TradeRateChild>();
                   }
                   if (!rate.Result.Equals("good"))//将好评过滤掉
                   {
                       if (rate.Result.Equals("neutral"))
                       {
                           rate.Result = "中评";
                       }
                       if (rate.Result.Equals("bad"))
                       {
                           rate.Result = "差评";
                       }
                       objRate = new TradeRateChild();
                       objRate.Nick = rate.Nick;
                       objRate.Content = rate.Content;
                       objRate.ItemTitle = rate.ItemTitle;
                       objRate.Result = rate.Result;
                       Trade objContact = objTrade.GetBuyerInfoByTid(rate.Tid);
                       objRate.Cellphone = objContact == null ? "" : objContact.ReceiverMobile;
                       objRate.RealName = objContact == null ? "" : objContact.ReceiverName;
                       objRate.Created = rate.Created;
                       TotalPoolRates.Add(objRate);
                   }

                   #region 判断黑名单加入条件

                   if (drCfg != null)
                   {
                       if (Convert.ToInt32(drCfg["atuoAddBlackListBadRate"]) > 0)
                       { //开通将半年内差评用户加入黑名单
                           if (!rate.Result.Equals("good"))
                           {
                               //中差评 加入黑名单
                               BlakList objList = new BlakList();
                               objList.SellerNick = sellerNick;
                               objList.BlakName = rate.Nick;
                               if (!objDal.ChekBlaklist(objList))
                               {
                                   objDal.AddBlaklist(objList);
                               }
                           }
                       }
                       if (Convert.ToInt32(drCfg["atuoAddBlackListTuiKuan"]) > 0)
                       {   //开通将半年内退款用户加入黑名单

                           // 获取单笔交易的部分信息:查询该笔订单是否有退货
                           string buyerNick = objTrade.GetBuyerTradeByTid(rate.Tid);
                           if (!string.IsNullOrEmpty(buyerNick))
                           {
                               //中差评 加入黑名单
                               BlakList objList = new BlakList();
                               objList.SellerNick = sellerNick;
                               objList.BlakName = buyerNick;
                               if (!objDal.ChekBlaklist(objList))
                               {
                                   objDal.AddBlaklist(objList);
                               }
                           }
                       }
                   }

                   #endregion

               }
           }
           PageNo = PageNo + PageSize;
           if (PageNo < total)
           {
               CurrentPage = CurrentPage + 1;
               GetSellerRate(startDate, endDate, sellerNick);
           }
           PageNo = 0;
           CurrentPage = 1;
           PageSize = 100;
           return TotalPoolRates;
       }


       /// <summary>
       /// 差评拦截黑名单
       /// </summary>
       /// <param name="startDate"></param>
       /// <param name="endDate"></param>
       /// <param name="sellerNick"></param>
       /// <returns></returns>
       public Boolean GetSellerRateCloseOrder(String startDate, String endDate, string sellerNick)
       {
           RatingTop rateObj = new RatingTop();
           TBTrade objTrade = new TBTrade();
           List<TradeRate> lstTradeRate = rateObj.GetTradeRate(CurrentPage, PageSize, startDate, endDate, ref total);

           if (lstTradeRate != null && lstTradeRate.Count > 0)
           {
               foreach (TradeRate rate in lstTradeRate)
               {
                   if (!rate.Result.Equals("good"))//将好评过滤掉
                   {
                       if (rate.Result.Equals("neutral") || rate.Result.Equals("bad"))
                       {
                           //中差评 加入黑名单
                           BlakList objList = new BlakList();
                           objList.SellerNick = sellerNick;
                           objList.BlakName = rate.Nick;
                           RatingDAL objDal = new RatingDAL();
                           if (!ChekBlaklistCloseOrder(objList))
                           {
                               AddBlaklistCloseOrder(objList);
                           }
                       }

                   }
               }
           }
           PageNo = PageNo + PageSize;
           if (PageNo < total)
           {
               CurrentPage = CurrentPage + 1;
               GetSellerRateCloseOrder(startDate, endDate, sellerNick);
           }
           PageNo = 0;
           CurrentPage = 1;
           PageSize = 100;
           return true;
       }
       public bool ChekBlaklistCloseOrder(BlakList obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.ChekBlaklistCloseOrder(obj);
       }
       public bool AddBlaklistCloseOrder(BlakList obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.AddBlaklistCloseOrder(obj);

       }
       public bool UpdateRateConfig(RateConfig obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.UpdateRateConfig(obj);
       }
       public Boolean UpdateAutoRatingStatus(string sellerNick, int openStatus)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.UpdateAutoRatingStatus(sellerNick, openStatus);
       }

       public  DataTable GetRateConfigByNick(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetRateConfigByNick(sellerNick);
       }
       public  Boolean CheckIsAutoCloseOrder(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.CheckIsAutoCloseOrder(sellerNick);
       }
       public  Boolean CheckRateConfigIsExit(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.CheckRateConfigIsExit(sellerNick);
       }
       public  bool AddRateConfig(RateConfig obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.AddRateConfig(obj);
       }
       public Boolean CheckAppCusIsExit(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.CheckAppCusIsExit(sellerNick);
       }
       public bool AddAppCus(AppCustomer obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.AddAppCus(obj);
       }
       public bool DeleteSellerNifty(String sellerID)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.DeleteSellerNifty(sellerID);
       }
       public DataTable GetBlakListByNick(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetBlakListByNick(sellerNick);
       }
       public DataTable GetCloseOrderLogByNick(string buerNick, string orderNo, string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetCloseOrderLogByNick(buerNick,orderNo,sellerNick);
       }
       public bool DeleteBlaklist(string blakListID)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.DeleteBlaklist(blakListID);
       }

       public int GetBlakListCount(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetBlakListCount(sellerNick);
       }
       public bool ChekBlaklist(BlakList obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.ChekBlaklist(obj);
       }
       public bool AddBlaklist(BlakList obj)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.AddBlaklist(obj);
       }
       public DataTable GetAutoRateListByNick(string sellerNick, string startDate, string endRateDate)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetAutoRateListByNick(sellerNick, startDate, endRateDate);
       }
       public DataTable GetAutoRateListByNick(string sellerNick, string startDate, string endRateDate, string rateType)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetAutoRateListByNick(sellerNick, startDate, endRateDate, rateType);
       }
       public Boolean DeleteRatingLog(string startDate, string endDate)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.DeleteRatingLog(startDate, endDate);
       }
       public DataTable GetSellerRateConfig(string sellerNick, string startDate, string endRateDate)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.GetSellerRateConfig(sellerNick, startDate, endRateDate);
       }
       public Boolean ManageRateStatus(string sellerNick, string isAutoRating)
       {
           RatingDAL objDal = new RatingDAL();
           return objDal.ManageRateStatus(sellerNick, isAutoRating);
       }

       /// <summary>
       /// 判断卖家是不是天猫
       /// </summary>
       /// <param name="sellerNick"></param>
       /// <returns></returns>
       public static Boolean isBshop(string sellerNick)
       {
           RatingDAL objDal = new RatingDAL();
           DataTable tb = objDal.GetShopTypeByNick(sellerNick);
           if (tb != null && tb.Rows.Count > 0)
           {
               if (tb.Rows[0]["shopType"].ToString().Equals("B"))
               {
                   return true;
               }
               return false;
           }
           return false;
       }

    }
}
