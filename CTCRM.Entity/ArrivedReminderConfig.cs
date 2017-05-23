using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class ArrivedReminderConfig
    {
        public string SellerNick { get; set; }
        public string AmountFrom { get; set; }
        public string AmountTo { get; set; }     
        /// <summary>
        /// 0:所有卖家都不屏蔽
        /// 1:屏蔽卖家标记 1,2,3,4,5
        /// </summary>
        public string Flag { get; set; }
        public string IsAddBlackList { get; set; }
        public string MsgContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IsOpen { get; set; }
    }
}
