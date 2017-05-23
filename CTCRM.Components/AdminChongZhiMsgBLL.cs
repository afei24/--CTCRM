using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CTCRM.DAL;

namespace CTCRM.Components
{
    public class AdminChongZhiMsgBLL
    {
        public static bool AddAdminChongZhiMsg(string MsgCount, decimal Price)
        {
            return AdminChongZhiMsgDAl.AddAdminChongZhiMsg(MsgCount,  Price);
        }

        public static DataTable GetAdminChongZhiMsg(string startDate, string endDate)
        {
            return AdminChongZhiMsgDAl.GetAdminChongZhiMsg(startDate,  endDate);
        }
        public static bool DeleteAdminChongZhiMsg(string Date)
        {
            return AdminChongZhiMsgDAl.DeleteAdminChongZhiMsg(Date);
        }
    }
}
