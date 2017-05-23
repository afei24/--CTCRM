using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
    public class CloseOrderLog
    {
        public int LogID { get; set; }

        public string BuyerNick { get; set; }
        public string SellerNick { get; set; }
        public string OrdreNo { get; set; }

        public string CloseReason { get; set; }

        public DateTime CloseTime { get; set; }

        public string CloseResult { get; set; }

        public string FaildReason { get; set; }
    }
}
