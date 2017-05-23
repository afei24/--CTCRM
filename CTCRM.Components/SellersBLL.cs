using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Components.TopCRM;
using CTCRM.Entity;
using CTCRM.DAL;
using System.Data;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.Components
{
  public  class SellersBLL
    {
      public static DataTable GetBuyerExport()
      {
          return SellersDAL.GetBuyerExport();
      }

      public static string CheckSeller()
      {
          //把用户信息写入数据库
         string result = TBManager.WriteUserInfoToCookies();
         return result;
      }
      public static DataTable GetSellers()
      {
          return SellersDAL.GetSellers();
      }
      public static Boolean CheckSellerIsExit(string sellerNick)
      {
          return SellersDAL.CheckSellerIsExit(sellerNick);
      }
      public static string GetSellerIdByNick(string strNick)
      {
          return SellersDAL.GetSellerIdByNick(strNick);
      }
      public static bool AddSellerExportAuth(string sellerNick)
      {
          return SellersDAL.AddSellerExportAuth(sellerNick);
      }
      public static bool DeleteSeller(string strNick)
      {
          return SellersDAL.DeleteSeller(strNick);
      }

      public static DataTable GetSellerCountHavePhone(string sellerNick)
      {
          return SellersDAL.GetSellerCountHavePhone(sellerNick);
      }

      public static bool SearchBuyers(DataTable dataSource,string buyerNick)
      {
          
          if (dataSource != null && dataSource.Rows.Count > 0)
          {
              try
              {
                  for (int i = 0; i < dataSource.Rows.Count; i++)
                  {
                      if (dataSource.Rows[i]["buyer_nick"].Equals(buyerNick))
                      {
                          dataSource.Rows.RemoveAt(i);
                          return true;
                      }
                  }
              }
              catch (Exception ex)
              {
                  ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                  return false;
              }
          }
          return false;
      }

      public static bool SetSyncTradeFlag(string strNick, int flag)
      {
          return SellersDAL.SetSyncTradeFlag(strNick, flag);
      }
      public static Boolean UpdateTradeFlag(string strNick)
      {
          return SellersDAL.UpdateTradeFlag(strNick);
      }

      public static string GetSellerSessionKey(string SELLER_ID)
      {
          return SellersDAL.GetSellerSessionKey(SELLER_ID);
      }
      public static bool UpdateSellerSYNData(string SELLER_ID)
      {
          return SellersDAL.UpdateSellerSYNData(SELLER_ID);
      }
      public static DataRow GetSelerOrderDate(string sellerNick)
      {
          return SellersDAL.GetSelerOrderDate(sellerNick);
      }
      public static DataRow GetOrderVersion(string strNick)
      {
          return SellersDAL.GetOrderVersion(strNick);
      }

      public static Boolean GetTradeFlag(string strNick)
      {
          return SellersDAL.GetTradeFlag(strNick);
      }
      public static Boolean GetHasSynFlag(string strNick)
      {
          return SellersDAL.GetHasSynFlag(strNick);
      }   
      public static DataTable GetTop10Sales(string sellerNick)
      {
          return TradeDAL.GetTop10Sales(sellerNick);
      }
      public static bool DeleteSellersInfo(string SELLER_ID)
      {
          return SellersDAL.DeleteSellersInfo(SELLER_ID);
      }
      public static int GetSyncMem(string strNick)
      {
          return SellersDAL.GetSyncMem(strNick);
      }
      public static bool SetSyncMem(string sellerNick)
      {
          return SellersDAL.SetSyncMem(sellerNick, "");
      }
      public static bool SetSyncMem(string sellerNick, string strTimespan)
      {
          return SellersDAL.SetSyncMem(sellerNick, strTimespan);
      }
      public static bool SetSyncProcess(string strNick, int nProcess)
      {
          return SellersDAL.SetSyncProcess(strNick, nProcess);
      }
      public static bool UpdateSellerSynDate(Sellers entity)
      {
          return SellersDAL.UpdateSellerSynDate(entity);
      }
      /// <summary>
      /// 返回商家订购软件的天数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static int GetSellerOrderdDays(string sellerNick)
      {
          return SellersDAL.GetSellerOrderdDays(sellerNick);
      }
      /// <summary>
      /// 获取卖家上次同步数据的时间
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static string GetSellerSynDate(string sellerNick)
      {
          DataTable tb = SellersDAL.GetSellerSynDate(sellerNick);
          if (tb != null && tb.Rows.Count > 0)
          {
              return tb.Rows[0]["synDate"].ToString();
          }
          return "";

      }

      /// <summary>
      /// 后台设置卖家不可用，同时将其短信账户清0：对于卖家退款的情况比较有用
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static bool UpdateSellerStatus(string sellerID)
      {
          if (SellersDAL.UpdateSellerStatus(sellerID))
          {
              string sellerNick = SellersDAL.GetSellerNickById(sellerID);
              return SellersDAL.UpdateSellerMsgStatus(sellerNick);
          }
          return false;
      }

      public static Boolean GetList(Sellers entity)
      {
          return SellersDAL.GetList(entity);
      }
      public static Boolean HasShop(Sellers entity)
      {
          return SellersDAL.HasShop(entity);
      }
      public static Boolean UpdateExportDataStatus(string sellerNick)
      {
          return SellersDAL.UpdateExportDataStatus(sellerNick);
      }

      public static DataTable GetSellerMsgAccount(string sellerNick, string startDate, string endDate)
      {
          return SellersDAL.GetSellerMsgAccount(sellerNick, startDate, endDate);
      }

      public static DataTable GetSellerReminderStatus(string sellerNick, string startDate, string endDate,string type)
      {
          return SellersDAL.GetSellerReminderStatus(sellerNick, startDate, endDate,type);
      }
      public static DataTable GetSellerReminderCusAduit(string sellerNick, string startDate, string endDate)
      {
          return SellersDAL.GetSellerReminderCusAduit(sellerNick, startDate, endDate);
      }

      public static DataTable GetUnUsedMsgAccount()
      {
          return SellersDAL.GetUnUsedMsgAccount();
      }

      public static Boolean UpdateMsgAccount(string sellerNick, string msgCount)
      {
          return SellersDAL.UpdateMsgAccount(sellerNick, msgCount);
      }

      public static Boolean UpdateReminderUnConfirmType(string sellerNick, string unConfirmType)
      {
          return SellersDAL.UpdateReminderUnConfirmType(sellerNick, unConfirmType);
      }
      public static Boolean UpdateReminderUnPayType(string sellerNick, string unPayType)
      {
          return SellersDAL.UpdateReminderUnPayType(sellerNick, unPayType);
      }
      public static Boolean UpdateReminderShippingType(string sellerNick, string shippingType)
      {
          return SellersDAL.UpdateReminderShippingType(sellerNick, shippingType);
      }
      public static Boolean UpdateReminderArrivedType(string sellerNick, string arrivedType)
      {
          return SellersDAL.UpdateReminderArrivedType(sellerNick, arrivedType);
      }
      public static Boolean UpdateReminderSignType(string sellerNick, string signType)
      {
          return SellersDAL.UpdateReminderSignType(sellerNick, signType);
      }
      public static Boolean UpdateReminderHuiZJType(string sellerNick, string type)
      {
          return SellersDAL.UpdateReminderHuiZJType(sellerNick, type);
      }
      public static Boolean UpdateReminderDelayShipType(string sellerNick, string delayShipType)
      {
          return SellersDAL.UpdateReminderDelayShipType(sellerNick, delayShipType);
      }
      public static DataTable GetExportDataSeller(string sellerNick, string startDate, string endDate, string auditSatus)
      {
          return SellersDAL.GetExportDataSeller(sellerNick, startDate, endDate, auditSatus);
      }

      /// <summary>
      /// 查询数据库中已经过期的卖家
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="startDate"></param>
      /// <param name="endDate"></param>
      /// <param name="auditSatus"></param>
      /// <returns></returns>
      public static DataTable GetEndDateSellers(string sellerNick, string startDate, string endDate)
      {
          return SellersDAL.GetEndDateSellers(sellerNick, startDate, endDate);
      }

      public static bool SetShopName(Sellers obj)
      {
          return SellersDAL.SetShopName(obj);
      }
      public static string GetAppendID(Sellers entity)
      {
          return SellersDAL.GetAppendID(entity);
      }
      public static string GetMAXAppendID()
      {
          return SellersDAL.GetMAXAppendID();
      }
      public static string GetMAXAppendID(Sellers entity)
      {
          return SellersDAL.GetMAXAppendID(entity);
      }
    
     
      public static string GetSellerPhone(string nick)
      {
          return SellersDAL.GetSellerPhone(nick); 
      }
      public static string GetSignName(string nick)
      {
          string name = SellersDAL.GetShopName(nick);
          if (string.IsNullOrEmpty(name) || name.Equals("undefined"))
          {
              return nick;
          }
          return name;
      }

      public static DataTable getAppID()
      {
          return SellersDAL.getAppID();
      }
      public static bool UpdateAppID(Sellers obj)
      {
          return SellersDAL.UpdateAppID(obj);
      }

      public static string getSellerAppID(string nick)
      {
          DataTable tb = SellersDAL.getSellerAppID(nick);
          if(tb!=null && tb.Rows.Count > 0)
          {
              return tb.Rows[0]["Appendid"].ToString();
            
          }
          return "";
      }
      public static DataTable GetSellersAppendID(string sellerNick, string startDate, string endDate)
      {
          return SellersDAL.GetSellersAppendID(sellerNick, startDate, endDate);
      }

      /// <summary>
      /// 获取卖家code
      /// </summary>
      /// <param name="nick"></param>
      /// <returns></returns>
      public static DataTable GetSellersCode(string nick)
      {
          return SellersDAL.GetSellersCode(nick);
      }


      /// <summary>
      /// 添加卖家code
      /// </summary>
      /// <param name="nick"></param>
      /// <param name="code"></param>
      /// <returns></returns>
      public static bool AddSellersCode(string nick, string code)
      {
          return SellersDAL.AddSellersCode(nick, code);
      }

      /// <summary>
      /// 更新卖家code
      /// </summary>
      /// <param name="nick"></param>
      /// <param name="code"></param>
      /// <returns></returns>
      public static bool UpdateSellersCode(string nick, string code)
      {
          return SellersDAL.UpdateSellersCode(nick,code);
      }

      /// <summary>
      /// 更新卖家营销短信发送百分比
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="sendPrecent"></param>
      /// <returns></returns>
      public static int UpdateSellerMsgsendPrecent(string sellerNick, int sendPrecent)
      {
          return SellersDAL.UpdateSellerMsgsendPrecent(sellerNick,sendPrecent);
      }


      /// <summary>
      /// 更新卖家的到期时间
      /// </summary>
      /// <param name="time"></param>
      /// <param name="userNick"></param>
      /// <returns></returns>
      public static Boolean UpdateUnUseDate(string time,string userNick)
      {
          return SellersDAL.UpdateUnUseDate(time, userNick);
      }

      public static DataTable GetSellerRecords(string sellernick, string startDate, string endDate)
      {
          return SellersDAL.GetSellerRecords(sellernick,  startDate,  endDate);
      }
  }
}
