using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderPageGetResponse.
    /// </summary>
    public class WlbOrderPageGetResponse : TopResponse
    {
        /// <summary>
        /// 物流宝订单对象
        /// </summary>
        [XmlArray("order_list")]
        [XmlArrayItem("wlb_order")]
        public List<Top.Api.Domain.WlbOrder> OrderList { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

    }
}
