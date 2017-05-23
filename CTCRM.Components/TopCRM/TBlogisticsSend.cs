using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
  public  class TBlogisticsSend
  {
      public static Boolean orderBatchSending(string tid,string yundanID,string companyCode)
      {
          try
          {
              ITopClient client = TBManager.GetClient();
              LogisticsOfflineSendRequest req = new LogisticsOfflineSendRequest();
              req.Tid = Convert.ToInt64(tid);
              //req.SubTid = "1,2,3";
              //req.IsSplit = 0L;
              req.OutSid = yundanID;
              req.CompanyCode = companyCode;
              LogisticsOfflineSendResponse response = client.Execute(req,Users.SessionKey);
              return  response.Shipping.IsSuccess;

          }
          catch (Exception ex)
          {
              CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
              return false;
          }
      }

  }
}
