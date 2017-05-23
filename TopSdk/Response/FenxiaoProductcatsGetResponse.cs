using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoProductcatsGetResponse.
    /// </summary>
    public class FenxiaoProductcatsGetResponse : TopResponse
    {
        /// <summary>
        /// 产品线列表。返回 ProductCat 包含的字段信息。
        /// </summary>
        [XmlArray("productcats")]
        [XmlArrayItem("product_cat")]
        public List<Top.Api.Domain.ProductCat> Productcats { get; set; }

        /// <summary>
        /// 查询结果记录数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
