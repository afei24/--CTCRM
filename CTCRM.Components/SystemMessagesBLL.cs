using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CTCRM.DAL;

namespace CTCRM.Components
{
    public class SystemMessagesBLL
    {
        public static DataTable QueryAll()
        {
            return SystemMessagesDAL.QueryAll();
        }

        public static bool Delete(string SystemMsgID)
        {
            return SystemMessagesDAL.Delete(SystemMsgID);
        }

        public static bool Insert(string SystemMsg, string SystemLink, int Status)
        {

            return SystemMessagesDAL.Insert(SystemMsg, SystemLink, Status);
        }

        public static bool Update(string SystemMsg, string SystemLink, int Status,string id)
        {

            return SystemMessagesDAL.Update(SystemMsg, SystemLink, Status, id);
        }

        public static DataTable QueryShowMsg()
        {
            return SystemMessagesDAL.QueryShowMsg();
        }
        public static DataTable GetMsgById(string SystemMsgID)
        {
            return SystemMessagesDAL.GetMsgById(SystemMsgID);
        }
    }

     
}
