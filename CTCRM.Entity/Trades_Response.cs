using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class Trades_Response
    {
        public List<PrintTrade> trades { get; set; }

        /// <summary>
        /// 搜索到的交易信息总数
        /// </summary>
        public string total_results { get; set; }
    }
}
