using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderitemPageGetResponse.
    /// </summary>
    public class WlbOrderitemPageGetResponse : TopResponse
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("wlb_order_item")]
        public List<Top.Api.Domain.WlbOrderItem> OrderItemList { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

    }
}
