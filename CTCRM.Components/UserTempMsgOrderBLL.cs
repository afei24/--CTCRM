using CTCRM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CTCRM.Components
{
    public class UserTempMsgOrderBLL
    {
        public static bool Add(string orderId, string nick, string FW_GOODS)
        {
            return UserTempMsgOrderDAL.Add(orderId,  nick,  FW_GOODS);
        }
        public static DataTable GetBuyerNick(string nick, string CreateDate)
        {
            return UserTempMsgOrderDAL.GetBuyerNick(nick, CreateDate);
        }
        public static DataTable GetBuyerNick(string nick)
        {
            return UserTempMsgOrderDAL.GetBuyerNick(nick);
        }

        public static bool Delete(string nick)
        {
            return UserTempMsgOrderDAL.Delete(nick);
        }
    }
}
