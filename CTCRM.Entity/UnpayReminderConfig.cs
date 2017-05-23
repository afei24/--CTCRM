using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class UnpayReminderConfig
    {
       public string SellerNick { get; set; }
       public string FromTime { get; set; }
       public string ToTime { get; set; }
       public string Swichs { get; set; }//时间范围内提醒：1；超出次日提醒：0
       public string AmountFrom { get; set; }
       public string AmountTo { get; set; }
       public string Zhouqi { get; set; }
       /// <summary>
       /// 0:所有卖家都不屏蔽
       /// 1:屏蔽卖家标记 1,2,3,4,5
       /// </summary>
       public string Flag { get; set; }
       public string IsAddBlackList { get; set; }
       public string MsgContent { get; set; }
       public string TestPhone { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime UpdateDate { get; set; }
       public string IsOpen { get; set; }
    }
}
