using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class SellerReminderMaster
    {
       public string SellerNick { get; set; }
       public string UnpayOpen { get; set; }
       public string ShippingOpen { get; set; }
       public string ArrivedOpen { get; set; }
       public string SignOpen { get; set; }
       public string DelayShipingOpen { get; set; }
       public string PayOpen { get; set; }
       public string ConfirmPayOpen { get; set; }
       public string RateOpen { get; set; }
       public string ReturnGoodsOpen { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime UpdateDate { get; set; }
    }
}
