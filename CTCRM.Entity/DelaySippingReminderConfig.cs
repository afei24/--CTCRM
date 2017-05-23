using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class DelaySippingReminderConfig
    {
        public string SellerNick { get; set; }
       /// <summary>
        /// 1:立即执行  0:周期执行(每天
       /// </summary>
        public string SendType { get; set; }
       /// <summary>
        /// 多少天前已付款未发货
       /// </summary>
        public string Days { get; set; }
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
