using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.DAL;
using CTCRM.Entity;
using System.Data;

namespace CTCRM.Components
{
    public class JifenConfigBLL
    {
        public static bool AddJifenConfig(JifenConfig jifens)
        {
            return JifenDAL.AddJifenConfig(jifens);
        }

        public static DataTable GetJifenConfigByNick(string sellerNick)
        {
            return JifenDAL.GetJifenConfigByNick(sellerNick);

        }

        public static bool UpdateJifenConfigStauts(JifenConfig o)
        {
            o.SellerNick = Users.Nick;
            return JifenDAL.UpdateJifenConfigStauts(o);
        }
    }
}
