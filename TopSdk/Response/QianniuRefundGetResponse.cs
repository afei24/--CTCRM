using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuRefundGetResponse.
    /// </summary>
    public class QianniuRefundGetResponse : TopResponse
    {
        /// <summary>
        /// 返回taobao 表示是淘宝的退款id，如果出错，可能是退款id不存在，或者是天猫退款id
        /// </summary>
        [XmlElement("refund_info")]
        public string RefundInfo { get; set; }

    }
}
