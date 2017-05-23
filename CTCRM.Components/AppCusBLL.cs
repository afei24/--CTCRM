using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.DAL;
using Top.Api.Domain;
using System.Data;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;
using System.Collections;
using CTCRM.Entity;

namespace CTCRM.Components
{
   public class AppCusBLL
    {
       //public static List<AppCustomer> GetSellerAppCus(string nick)
       //{
       //    List<AppCustomer> lstAppCus = TBAPPCus.GetAllAppCuss(nick);
       //    return lstAppCus;
       //}

       public static Boolean CheckAppCusIsExit(string sellerNick)
       {
           return AppCusDAL.CheckAppCusIsExit(sellerNick);
       }
       public static Boolean DeleteDataByDateTime(string datetime)
       {
           return AppCusDAL.DeleteDataByDateTime(datetime);
       }
       public static DataTable GetNoMsgData()
       {
           return AppCusDAL.GetNoMsgData();
       }
       public static Boolean DeleteDataByNick(string nick)
       {
           return AppCusDAL.DeleteDataByNick(nick);
       }
       public static DataTable GetNotifyData(string nick)
       {
           return AppCusDAL.GetNotifyData(nick);
       }

       public static bool AddAppCus(AppCustomer obj)
       {
           return AppCusDAL.AddAppCus(obj);
       }

       public static bool DeleteSellerNifty(String sellerID)
       {
           return AppCusDAL.DeleteSellerNifty(sellerID);
       }

       public static bool UpdateSellerNifty(string sellerID)
       {
           return AppCusDAL.UpdateSellerNifty(sellerID);
       }

       public static DataTable GetAppCus(String nick,string startDate, String endDate,string status)
       {
           return AppCusDAL.GetAppCus(nick, startDate, endDate, status);
       }

       public static String GetSellerNickByID(string id)
       {
           return AppCusDAL.GetSellerNickByID(id);
       }
    }
}
