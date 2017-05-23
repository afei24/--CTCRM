using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Components.TopCRM
{
   public class TBPrint
    {

       public static IDictionary<string, string> GetParas(string paras)
       {
           try
           {
               string[] values = paras.Split('&');
               IDictionary<string, string> pars = new Dictionary<string, string>();
               foreach (string vale in values)
               {
                   string[] singVal = vale.Split('=');
                   pars.Add(singVal[0].Trim(), singVal[1].Trim());
               }
               return pars;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }







    }
}
