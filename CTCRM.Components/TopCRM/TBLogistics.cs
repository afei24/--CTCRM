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
   public class TBLogistics
    {
       public static List<LogisticsCompany> GetTBLogistics()
       {
           try
           {

               ITopClient client = TBManager.GetClient();
               LogisticsCompaniesGetRequest req = new LogisticsCompaniesGetRequest();
               req.Fields = "code,name"; 
               LogisticsCompaniesGetResponse response = client.Execute(req);
               return response.LogisticsCompanies;
             
           }
           catch (Exception ex)
           {
               CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
               return null;
           }
       }

    }
}
