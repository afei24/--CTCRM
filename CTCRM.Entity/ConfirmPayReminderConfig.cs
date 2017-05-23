using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class ConfirmPayReminderConfig
    {
        public string SellerNick { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string ZhouQi { get; set; }
        public string AmountFrom { get; set; }
        public string AmountTo { get; set; }
        public string MsgContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IsOpen { get; set; }
    }
}
