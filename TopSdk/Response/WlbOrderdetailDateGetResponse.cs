using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderdetailDateGetResponse.
    /// </summary>
    public class WlbOrderdetailDateGetResponse : TopResponse
    {
        /// <summary>
        /// 物流宝订单，并且包含订单详情
        /// </summary>
        [XmlArray("order_detail_list")]
        [XmlArrayItem("wlb_order_detail")]
        public List<Top.Api.Domain.WlbOrderDetail> OrderDetailList { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

    }
}
