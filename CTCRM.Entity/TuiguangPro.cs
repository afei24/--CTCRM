using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class TuiguangPro
    {
       public string ItemNo { get; set; }
       public string SellerNick { get; set; }
       public string ItemPicUrl { get; set; }
       public string ItemTitle { get; set; }
       public string ItemUrl { get; set; }
       public string Price { get; set; }
       public string Inventory { get; set; }
       public string TuiStatus { get; set; }
       public string TuiAddress { get; set; }
       public DateTime CreateTime { get; set; }
       public DateTime UpdateTime { get; set; }
       public string EndUseTime { get; set; }
       public string Memo { get; set; }
       public string OpenId { get; set; }
    }
}
