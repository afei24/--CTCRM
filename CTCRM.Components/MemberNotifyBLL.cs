using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CTCRM.DAL;
using CTCRM.Entity;

namespace CTCRM.Components
{
   public class MemberNotifyBLL
    {
       public static DataTable GetUnpayNotifyByNick(string startDate, string endDate, string buyerNick)
       {
           return MemberNotifyDAL.GetUnpayNotifyByNick(startDate, endDate, buyerNick, Users.Nick);
       }

       public static bool AddMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.AddMsgConfig(o);
       }

       public static bool UpdateMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateMsgConfig(o);
       }

       public static bool UpdateOtherParm(MsgSendConfig o)
       {
           //return MemberNotifyDAL.(o);
         return  MemberNotifyDAL.UpdateOtherParm(o);
       }

       public static bool UpdatePayMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdatePayMsgConfig(o);
       }
       public static bool UpdateShippingMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateShippingMsgConfig(o);
       }
       public static bool UpdateUnPayMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateUnPayMsgConfig(o);
       }
       public static bool UpdateArrivedMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateArrivedMsgConfig(o);
       }
       public static Boolean CheckMsgConfigIsExit(MsgSendConfig o)
       {
           return MemberNotifyDAL.CheckMsgConfigIsExit(o);
       }
       public static bool UpdateDelayShippingMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateDelayShippingMsgConfig(o);
       }
       public static bool UpdateReturnGoodsMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateReturnGoodsMsgConfig(o);
       }
       public static bool UpdateSignMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateSignMsgConfig(o);
       }
       
       public static bool UpdateHuiZJMsgConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.UpdateHuiZJMsgConfig(o);
       }
       public static DataTable GetMsgConfigByBuyerSellerNick(MsgSendConfig entity)
       {
           return MemberNotifyDAL.GetMsgConfigByBuyerSellerNick(entity);
       }

       public static DataTable GetConfirmNotifyByNick(string startDate, string endDate, string buyerNick)
       {
           return MemberNotifyDAL.GetConfirmNotifyByNick(startDate, endDate, buyerNick, Users.Nick);
       }

       public static bool updateWarn(MsgSendConfig o)
       {
           return MemberNotifyDAL.updateWarn(o);
       }

       public static bool addWarnConfig(MsgSendConfig o)
       {
           return MemberNotifyDAL.addWarnConfig(o);
       }

       public static bool CheckMsgConfigTypeIsExit(MsgSendConfig o)
       {
           return MemberNotifyDAL.CheckMsgConfigTypeIsExit(o);
       }

       public static DataTable getWarnInfo(string selleNick, string warnType)
       {
           return MemberNotifyDAL.getWarnInfo(selleNick, warnType);
       }
    }
}
