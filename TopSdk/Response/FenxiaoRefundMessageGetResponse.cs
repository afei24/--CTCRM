using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoRefundMessageGetResponse.
    /// </summary>
    public class FenxiaoRefundMessageGetResponse : TopResponse
    {
        /// <summary>
        /// 退款留言
        /// </summary>
        [XmlArray("order_messages")]
        [XmlArrayItem("order_message")]
        public List<Top.Api.Domain.OrderMessage> OrderMessages { get; set; }

        /// <summary>
        /// 总留言条数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
