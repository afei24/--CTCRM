using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderstatusGetResponse.
    /// </summary>
    public class WlbOrderstatusGetResponse : TopResponse
    {
        /// <summary>
        /// 订单流转信息状态列表
        /// </summary>
        [XmlArray("wlb_order_status")]
        [XmlArrayItem("wlb_process_status")]
        public List<Top.Api.Domain.WlbProcessStatus> WlbOrderStatus { get; set; }

    }
}
