using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RefundRefusereasonGetResponse.
    /// </summary>
    public class RefundRefusereasonGetResponse : TopResponse
    {
        /// <summary>
        /// 是否存在下一页
        /// </summary>
        [XmlElement("has_next")]
        public bool HasNext { get; set; }

        /// <summary>
        /// 卖家拒绝原因对象
        /// </summary>
        [XmlArray("reasons")]
        [XmlArrayItem("reason")]
        public List<Top.Api.Domain.Reason> Reasons { get; set; }

        /// <summary>
        /// 原因个数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
