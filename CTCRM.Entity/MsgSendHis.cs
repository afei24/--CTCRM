using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class MsgSendHis
    {
       public string TransNumber { get; set; }

       public string SellerNick { get; set; }

       public string Buyer_nick { get; set; }

       public string CellPhone { get; set; }

       public DateTime SendDate { get; set; }

       public string SendType { get; set; }

       public string SendStatus { get; set; }

       public string Count { get; set; }

       public string MsgContent { get; set; }

       public string HelpSellerNick { get; set; }

       public string MsgChannel { get; set; }
    }
}
