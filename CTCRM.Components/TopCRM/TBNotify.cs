using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
   public class TBNotify
    {

       public static void StartNotify()
       {
           if (!AppCusBLL.CheckAppCusIsExit(Users.Nick))
           {
               ITopClient client = TBManager.GetClient();
               TmcUserPermitRequest req = new TmcUserPermitRequest();
               TmcUserPermitResponse response = client.Execute(req, Users.SessionKey);
               AppCustomer appCus = null;
               if (response.IsSuccess)
               {
                   appCus = new AppCustomer();
                   appCus.Status = "1";
                   appCus.Nick = Users.Nick;
                   appCus.Created = DateTime.Now.ToShortDateString();
                   AppCusBLL.AddAppCus(appCus);
               }
           }        
       }

       public static void StopNotify()
       {
           if (!RemainderDAL.CheckSellerNofityForUnpay(Users.Nick))
           {
               ITopClient client = TBManager.GetClient();
               TmcUserCancelRequest req = new TmcUserCancelRequest();
               req.Nick = Users.Nick;
               TmcUserCancelResponse response = client.Execute(req);
               if (response.IsSuccess)
               {
                   AppCusBLL.DeleteSellerNifty(Users.Nick);
               }
           }

       }
    }
}
