using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CTCRM.Components
{
   public class RemainderBLL
   {
       #region unpay
       public static Boolean CheckUnPayIsExit(string sellerNick)
       {
           return RemainderDAL.CheckUnPayIsExit(sellerNick);
       }

       public static bool UpdateUnPayBasic(UnpayReminderConfig obj)
       {
           return RemainderDAL.UpdateUnPayBasic(obj);
       }

       public static bool AddUnPayBasic(UnpayReminderConfig obj)
       {
           return RemainderDAL.AddUnPayBasic(obj);
       }
       public static DataTable GetUnPayBasicByNick(string sellerNick)
       {
           return RemainderDAL.GetUnPayBasicByNick(sellerNick);
       }
       public static bool AddUnPayTop(UnpayReminderConfig obj)
       {
           return RemainderDAL.AddUnPayTop(obj);
       }
       public static bool UpdateUnPayTop(UnpayReminderConfig obj)
       {
           return RemainderDAL.UpdateUnPayTop(obj);
       }
       public static bool AddUnPayMsg(UnpayReminderConfig obj)
       {
           return RemainderDAL.AddUnPayMsg(obj);
       }
       public static bool UpdateUnPayMsg(UnpayReminderConfig obj)
       {
           return RemainderDAL.UpdateUnPayMsg(obj);
       }
       public static bool AddUnPay(UnpayReminderConfig obj)
       {
           return RemainderDAL.AddUnPay(obj);
       }
       public static Boolean CheckConfigMasterIsExit(string sellerNick)
       {
           return RemainderDAL.CheckConfigMasterIsExit(sellerNick);
       }
       public static bool AddSellerReminderMasterForUnpay(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForUnpay(obj);
       }
       public static DataTable GetMaster(string sellerNick)
       {
           return RemainderDAL.GetMaster(sellerNick);
       }
       public static bool UpdateUnPayMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdateUnPayMaster(obj);
       }
       public static bool UpdateUnPayBasicIsOpen(UnpayReminderConfig obj)
       {
           return RemainderDAL.UpdateUnPayBasicIsOpen(obj);
       }

       #endregion

       #region Shipping
       public static Boolean CheckShippingIsExit(string sellerNick)
       {
           return RemainderDAL.CheckShippingIsExit(sellerNick);
       }
       public static bool UpdateShippingBasic(ShippingReminderConfig obj)
       {
           return RemainderDAL.UpdateShippingBasic(obj);
       }
       public static bool UpdateShippingTop(ShippingReminderConfig obj)
       {
           return RemainderDAL.UpdateShippingTop(obj);
       }
       public static bool UpdateShippingMsg(ShippingReminderConfig obj)
       {
           return RemainderDAL.UpdateShippingMsg(obj);
       }
       public static bool UpdateShippingMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdateShippingMaster(obj);
       }
       public static bool UpdateShippingBasicIsOpen(ShippingReminderConfig obj)
       {
           return RemainderDAL.UpdateShippingBasicIsOpen(obj);

       }
       public static bool AddShipping(ShippingReminderConfig obj)
       {
           return RemainderDAL.AddShipping(obj);
       }
       public static bool AddShippingBasic(ShippingReminderConfig obj)
       {
           return RemainderDAL.AddShippingBasic(obj);
       }
       public static bool AddShippingTop(ShippingReminderConfig obj)
       {
           return RemainderDAL.AddShippingTop(obj);
       }
       public static bool AddShippingMsg(ShippingReminderConfig obj)
       {
           return RemainderDAL.AddShippingMsg(obj);
       }
       public static bool AddSellerReminderMasterForShipping(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForShipping(obj);
       }
       public static DataTable GetShippingByNick(string sellerNick)
       {
           return RemainderDAL.GetShippingByNick(sellerNick);
       }
       #endregion

       #region Arrived
       public static Boolean CheckArrivedIsExit(string sellerNick)
       {
           return RemainderDAL.CheckArrivedIsExit(sellerNick);
       }
       public static bool UpdateArrivedBasic(ArrivedReminderConfig obj)
       {
           return RemainderDAL.UpdateArrivedBasic(obj);
       }
       public static bool UpdateArrivedTop(ArrivedReminderConfig obj)
       {
           return RemainderDAL.UpdateArrivedTop(obj);
       }
       public static bool UpdateArrivedMsg(ArrivedReminderConfig obj)
       {
           return RemainderDAL.UpdateArrivedMsg(obj);
       }
       public static bool UpdateArrivedMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdateArrivedMaster(obj);
       }
       public static bool UpdateArrivedBasicIsOpen(ArrivedReminderConfig obj)
       {
           return RemainderDAL.UpdateArrivedBasicIsOpen(obj);
       }
       public static bool AddArrived(ArrivedReminderConfig obj)
       {
           return RemainderDAL.AddArrived(obj);
       }
       public static bool AddArrivedBasic(ArrivedReminderConfig obj)
       {
           return RemainderDAL.AddArrivedBasic(obj);
       }
       public static bool AddArrivedTop(ArrivedReminderConfig obj)
       {
           return RemainderDAL.AddArrivedTop(obj);
       }
       public static bool AddArrivedMsg(ArrivedReminderConfig obj)
       {
           return RemainderDAL.AddArrivedMsg(obj);
       }
       public static bool AddSellerReminderMasterForArrived(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForArrived(obj);
       }
       public static DataTable GetArrivedByNick(string sellerNick)
       {
           return RemainderDAL.GetArrivedByNick(sellerNick);
       }
       #endregion

       #region Sign

       public static Boolean CheckSignIsExit(string sellerNick)
       {
           return RemainderDAL.CheckSignIsExit(sellerNick);
       }
       public static bool UpdateSignBasic(SignReminderConfig obj)
       {
           return RemainderDAL.UpdateSignBasic(obj);
       }
       public static bool UpdateSignTop(SignReminderConfig obj)
       {
           return RemainderDAL.UpdateSignTop(obj);
       }
       public static bool UpdateSignMsg(SignReminderConfig obj)
       {
           return RemainderDAL.UpdateSignMsg(obj);
       }
       public static bool UpdateSignMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdateSignMaster(obj);
       }
       public static bool UpdateSignBasicIsOpen(SignReminderConfig obj)
       {
           return RemainderDAL.UpdateSignBasicIsOpen(obj);
       }
       public static bool AddSign(SignReminderConfig obj)
       {
           return RemainderDAL.AddSign(obj);
       }
       public static bool AddSignBasic(SignReminderConfig obj)
       {
           return RemainderDAL.AddSignBasic(obj);
       }
       public static bool AddSignTop(SignReminderConfig obj)
       {
           return RemainderDAL.AddSignTop(obj);
       }
       public static bool AddSignMsg(SignReminderConfig obj)
       {
           return RemainderDAL.AddSignMsg(obj);
       }
       public static bool AddSellerReminderMasterForSign(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForSign(obj);
       }
       public static DataTable GetSignByNick(string sellerNick)
       {
           return RemainderDAL.GetSignByNick(sellerNick);
       }
       #endregion

       #region DelaySipping

       public static Boolean CheckDelaySippingIsExit(string sellerNick)
       {
           return RemainderDAL.CheckDelaySippingIsExit(sellerNick);
       }
       public static bool UpdateDelaySippingBasic(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.UpdateDelaySippingBasic(obj);
       }
       public static bool UpdateDelaySippingTop(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.UpdateDelaySippingTop(obj);
       }
       public static bool UpdateDelaySippingMsg(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.UpdateDelaySippingMsg(obj);
       }
       public static bool UpdateDelaySippingMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdateDelaySippingMaster(obj);
       }
       public static bool UpdateDelaySippingBasicIsOpen(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.UpdateDelaySippingBasicIsOpen(obj);
       }
       public static bool AddDelaySipping(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.AddDelaySipping(obj);

       }
       public static bool AddDelaySippingBasic(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.AddDelaySippingBasic(obj);
       }
       public static bool AddDelaySippingTop(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.AddDelaySippingTop(obj);
       }
       public static bool AddDelaySippingMsg(DelaySippingReminderConfig obj)
       {
           return RemainderDAL.AddDelaySippingMsg(obj);
       }
       public static bool AddSellerReminderMasterForDelayShipping(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForDelayShipping(obj);
       }
       public static DataTable GetDelaySippingByNick(string sellerNick)
       {
           return RemainderDAL.GetDelaySippingByNick(sellerNick);
       }
       #endregion

       #region Pay

       public static Boolean CheckPayIsExit(string sellerNick)
       {
           return RemainderDAL.CheckPayIsExit(sellerNick);
       }
       public static bool UpdatePayBasic(PayReminderConfig obj)
       {
           return RemainderDAL.UpdatePayBasic(obj);
       }
       public static bool UpdatePayMsg(PayReminderConfig obj)
       {
           return RemainderDAL.UpdatePayMsg(obj);
       }
       public static bool UpdatePayMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdatePayMaster(obj);
       }
       public static bool UpdatePayBasicIsOpen(PayReminderConfig obj)
       {
           return RemainderDAL.UpdatePayBasicIsOpen(obj);
       }
       public static bool AddPay(PayReminderConfig obj)
       {
           return RemainderDAL.AddPay(obj);
       }
       public static bool AddPayBasic(PayReminderConfig obj)
       {
           return RemainderDAL.AddPayBasic(obj);
       }
       public static bool AddPayMsg(PayReminderConfig obj)
       {
           return RemainderDAL.AddPayMsg(obj);
       }
       public static bool AddSellerReminderMasterForPay(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForPay(obj);
       }
       public static DataTable GetPayByNick(string sellerNick)
       {
           return RemainderDAL.GetPayByNick(sellerNick);
       }
       #endregion

       #region PayConfirm
       public static Boolean CheckConfirmPayIsExit(string sellerNick)
       {
           return RemainderDAL.CheckConfirmPayIsExit(sellerNick);
       }
       public static bool UpdateConfirmPayBasic(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.UpdateConfirmPayBasic(obj);
       }
       public static bool UpdateConfirmPayMsg(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.UpdateConfirmPayMsg(obj);
       }
       public static bool UpdatePayConfirmMaster(SellerReminderMaster obj)
       {
           return RemainderDAL.UpdatePayConfirmMaster(obj);
       }
       public static bool UpdatePayConfirmBasicIsOpen(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.UpdatePayConfirmBasicIsOpen(obj);
       }
       public static bool AddPayConfirm(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.AddPayConfirm(obj);
       }
       public static bool AddPayConfirmBasic(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.AddPayConfirmBasic(obj);
       }
       public static bool AddPayConfirmMsg(ConfirmPayReminderConfig obj)
       {
           return RemainderDAL.AddPayConfirmMsg(obj);
       }
       public static bool AddSellerReminderMasterForPayConfrim(SellerReminderMaster obj)
       {
           return RemainderDAL.AddSellerReminderMasterForPayConfrim(obj);
       }
       public static DataTable GetPayConfirmByNick(string sellerNick)
       {
           return RemainderDAL.GetPayConfirmByNick(sellerNick);
       }
       #endregion

       #region MsgSendHis

       public static DataTable GetMsgReminderHis(string sellerNick, string buyerNick, string startDate, string endDate, string cellPhone, string sendType)
       {
           return RemainderDAL.GetMsgReminderHis(sellerNick, buyerNick, startDate, endDate, cellPhone, sendType);
       }

       #endregion

       #region GetReport
       public static string GetMsgHisReport(string sellerNick, string sendType)
       {
           return RemainderDAL.GetMsgHisReport(sellerNick,sendType);
       }
       #endregion
   }
}
