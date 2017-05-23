using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
    public class Buyer_export
    {
        public int ID { set; get; }

        public string buyer_SellerId { get; set; }
        public string buyer_nick { get; set; }    
        public string export_time { get; set; }
        public int export_status { get; set; }

    
    }
}
