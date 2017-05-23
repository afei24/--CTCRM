using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoDiscountsGetResponse.
    /// </summary>
    public class FenxiaoDiscountsGetResponse : TopResponse
    {
        /// <summary>
        /// 折扣数据结构
        /// </summary>
        [XmlArray("discounts")]
        [XmlArrayItem("discount")]
        public List<Top.Api.Domain.Discount> Discounts { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
