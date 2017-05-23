using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CTCRM.DAL;
using CTCRM.Entity;

namespace CTCRM.Components
{
   public class SmartBLL
    {
       public static DataTable GetNewBuyer10Days(string sellerId)
       {
           return SmartDAL.GetNewBuyer10Days(sellerId);
       }
       public static Boolean UpdateSendStatus(string status, string transNumber)
       {
           return SmartDAL.UpdateSendStatus(status,transNumber);
       }
       public static DataTable GetNewBuyer30Days(string sellerId)
       {
           return SmartDAL.GetNewBuyer30Days(sellerId);
       }
       public static bool AddMsgSendHisIntoTestTable(string sellerNick, string phone)
       {
           return SmartDAL.AddMsgSendHisIntoTestTable(sellerNick, phone);
       }
       public static DataTable GetHuoYueDiGouMaiQiangBuyersCount(string sellerId)
       {
           return SmartDAL.GetHuoYueDiGouMaiQiangBuyersCount(sellerId);
       }
       public static DataTable GetHuoYueBanGouMaiBanBuyersCount(string sellerId)
       {
           return SmartDAL.GetHuoYueBanGouMaiBanBuyersCount(sellerId);
       }
       public static DataTable GetHuoYueGaoGouMaiBanBuyersCount(string sellerId)
       {
           return SmartDAL.GetHuoYueGaoGouMaiBanBuyersCount(sellerId);
       }
       public static DataTable GetHuoYueGaoGouMaiGaoBuyersCount(string sellerId)
       {
           return SmartDAL.GetHuoYueGaoGouMaiGaoBuyersCount(sellerId);
       }
       public static DataTable GetHuoDongBuyersCount(string date,string sellerId,string date2)
       {
           return SmartDAL.GetHuoDongBuyersCount(date, sellerId, date2);
       }
       public static DataTable GetUnPayBuyersCount(string SELLER_ID)
       {
           return SmartDAL.GetUnPayBuyersCount(SELLER_ID);
       }
       public static DataTable GetUnPay7DaysBuyersCount(string SELLER_ID)
       {
           return SmartDAL.GetUnPay7DaysBuyersCount(SELLER_ID);
       }
       public static DataTable GetBaiFangBuyersCount(string SELLER_ID)
       {
           return SmartDAL.GetBaiFangBuyersCount(SELLER_ID);
       }
       public static DataTable GetNanFangBuyersCount(string SELLER_ID)
       {
           return SmartDAL.GetNanFangBuyersCount(SELLER_ID);
       }
       public static DataTable GetBuyersCount(int gradeLevel, string sellerId)
       {
           return SmartDAL.GetBuyersCount(gradeLevel, sellerId);
       }
       public static bool AddMsgSendHis(MsgSendHis o)
       {
           return SmartDAL.AddMsgSendHis(o);
       }
       public static bool AddMsgSendHis(MsgSendHis o, string msgChannel)
       {
           return SmartDAL.AddMsgSendHis(o, msgChannel);
       }
       /// <summary>
       /// 根据省份
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetProvinceBuyersCount(string sellerId, List<string> province)
       {
           return SmartDAL.GetProvinceBuyersCount(sellerId, province);
       }
    }
}
