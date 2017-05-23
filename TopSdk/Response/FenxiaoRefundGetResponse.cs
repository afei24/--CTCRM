using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoRefundGetResponse.
    /// </summary>
    public class FenxiaoRefundGetResponse : TopResponse
    {
        /// <summary>
        /// 退款详情
        /// </summary>
        [XmlElement("refund_detail")]
        public Top.Api.Domain.RefundDetail RefundDetail { get; set; }

    }
}
