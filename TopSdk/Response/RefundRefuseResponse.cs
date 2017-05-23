using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RefundRefuseResponse.
    /// </summary>
    public class RefundRefuseResponse : TopResponse
    {
        /// <summary>
        /// 拒绝退款操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 拒绝退款成功后，会返回Refund数据结构中的refund_id, status, modified字段
        /// </summary>
        [XmlElement("refund")]
        public Top.Api.Domain.Refund Refund { get; set; }

    }
}
