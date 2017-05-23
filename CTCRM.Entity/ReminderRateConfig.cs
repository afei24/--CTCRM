using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class ReminderRateConfig
    {
        public int Id { get; set; }
        public string SellerNick { get; set; }
        public string ReminderPhone { get; set; }
        public string ReminderMsgContent { get; set; }
        public bool IsSendMsgToBuyer { get; set; }
        public string BuyerMsgContent { get; set; }
        public string PreReminderPhone { get; set; }
        public string PreReminderMsgContent { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
