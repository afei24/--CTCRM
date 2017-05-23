using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class CloseAddressConfig
    {
        public string Id { get; set; }
        public string SellerNick { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string Phone { get; set; }
        public string MatchType { get; set; }
        public string Memo { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
