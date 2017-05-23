using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;

namespace CTCRM.Entity
{
  public  class PrintTrade
    {
        public PrintTrade()
        {

        }

        public string tid { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string type { get; set; }

        public string buyer_nick { get; set; }

        public string receiver_name { get; set; }
        /// <summary>
        /// 收货人的所在省份
        /// </summary>
        public string receiver_state { get; set; }

        public string receiver_city { get; set; }
        /// <summary>
        /// 收货人的所在地区
        /// </summary>
        public string receiver_district { get; set; }

        public string receiver_address { get; set; }

        public string receiver_phone { get; set; }
        public string receiver_mobile { get; set; }
        public string receiver_zip { get; set; }
        /// <summary>
        /// 买家下单的地区
        /// </summary>
        public string buyer_area { get; set; }
        /// <summary>
        /// 交易创建时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string created { get; set; }

        public string seller_nick { get; set; }
        /// <summary>
        /// 实付金额。精确到2位小数;单位:元。如:200.07，表示:200元7分
        /// </summary>
        public string payment { get; set; }
        /// <summary>
        /// 订单状态，用户定义enum
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 创建交易时的物流方式可选值：free(卖家包邮),post(平邮),express(快递),ems(EMS),virtual(虚拟发货)，25(次日必达)，26(预约配送)
        /// </summary>
        public string shipping_type { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public string pay_time { get; set; }
        /// <summary>
        /// 交易修改时间(用户对订单的任何修改都会更新此字段)。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string modified { get; set; }

        public printOrder orders { get; set; }

        public List<PromotionDetail> promotion_details { get; set; }

        /// <summary>
        /// 邮费。精确到2位小数;单位:元。如:200.07
        /// </summary>
        public string post_fee { get; set; }

    }
}
