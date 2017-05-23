using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class MsgPackage
    {
       public string PackageName { get; set; }
       public string Type { get; set; }
       public int Price { get; set; }
       public string PerPrice { get; set; }
       public string Rank { get; set; }
       public string SellerNick { get; set; }
       public string EndDate { get; set; }
       public DateTime OrderDate { get; set; }
       public Boolean PayStatus { get; set; }
       public DateTime CanUseStartDate { get; set; }
       public DateTime UnUseDate { get; set; }
       public int MsgCanUseCount { get; set; }
       public int MsgTotalCount { get; set; }
       public Boolean ServiceStatus { get; set; } 
    }
}
