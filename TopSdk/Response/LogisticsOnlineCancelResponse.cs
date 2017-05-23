using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsOnlineCancelResponse.
    /// </summary>
    public class LogisticsOnlineCancelResponse : TopResponse
    {
        /// <summary>
        /// 成功与失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 重新创建物流订单id
        /// </summary>
        [XmlElement("recreated_order_id")]
        public string RecreatedOrderId { get; set; }

    }
}
