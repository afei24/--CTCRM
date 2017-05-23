using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbTradeorderGetResponse.
    /// </summary>
    public class WlbTradeorderGetResponse : TopResponse
    {
        /// <summary>
        /// 物流宝订单对象
        /// </summary>
        [XmlArray("wlb_order_list")]
        [XmlArrayItem("wlb_order")]
        public List<Top.Api.Domain.WlbOrder> WlbOrderList { get; set; }

    }
}
