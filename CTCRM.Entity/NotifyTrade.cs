using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class NotifyTrade
    {
       public string Tid { get; set; }
       public string BuyerNick { get; set; }
       public string SellerNick { get; set; }
       public string Status { get; set; }
       public string Oid { get; set; }
       public string Payment { get; set; }
    }
}
