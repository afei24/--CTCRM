using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class PrintProduct
    {
        public string num_iid { get; set; }
        public string outer_id { get; set; }
        public string goods_code { get; set; }
        public string model_code { get; set; }
        public string bar_code { get; set; }
        public string price { get; set; }
        public string weight { get; set; }
        public string seller_cids { get; set; }
        public string title { get; set; }
        public string pic_path { get; set; }
    }
}
