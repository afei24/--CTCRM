using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CTCRM.DAL;
using System.Data.SqlClient;

namespace CTCRM.Components
{
   public class ReportBLL
    {

       public static DataTable GetNewCusByMonth(string sellerNick, string year, bool week, bool month, bool ji)
       {
           return ReportDAL.GetNewCusByMonth(sellerNick,year, week, month, ji);
       }

       public static DataTable GetOldCusByMonth(string sellerNick, string year, bool week, bool month, bool ji)
       {
           return ReportDAL.GetOldCusByMonth(sellerNick,year, week, month, ji);
       }
       public static DataTable GetBuyerProviceReport(string sellerNick, string startDate, string endDate)
       {
           return ReportDAL.GetBuyerProviceReport(sellerNick, startDate, endDate);
       }
    }
}
