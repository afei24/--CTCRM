using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class CloseOrderConfig
    {
        public int Id { get; set; }
        public string SellerNick { get; set; }
        public int IsAutoCloseOrder { get; set; }
        public string BuyerRegDays { get; set; }
        public string BuyerCreditFen { get; set; }
        public string TotalBadRateCount { get; set; }
        public string TotalTuiKuanCount { get; set; }
        public int UnCertify { get; set; }
        public int CellPhoneClose { get; set; }
        public string UnpayMinutesClose { get; set; }
        public int PayQuikAddMemo { get; set; }
        public string CloseStartDate { get; set; }
        public string CloseEndDate { get; set; }
        public string OrderGreaterThan { get; set; }
        public string CloseReason { get; set; }
        public int DangerBuyerCloseAndMemo { get; set; }
        public int DangerBuyerNotCloseAddMemo { get; set; }
        public string MemoQiZhi { get; set; }
        public string MemoContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
