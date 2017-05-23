using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CTCRM.DAL;

namespace CTCRM.Components
{
    public class msgSendingBLL
    {
        public static bool Add(string sellerID)
        {
            return msgSendingDAL.Add(sellerID);
        }

        public static bool update(string sellerID, int status, int count)
        {
            return msgSendingDAL.update(sellerID, status, count);
        }

        public static bool update(string sellerID, int status)
        {
            return msgSendingDAL.update(sellerID, status);
        }

        public static DataTable Select(string sellerID)
        {
            return msgSendingDAL.Select(sellerID);
        }
    }
}
