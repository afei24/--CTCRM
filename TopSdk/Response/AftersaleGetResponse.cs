using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AftersaleGetResponse.
    /// </summary>
    public class AftersaleGetResponse : TopResponse
    {
        /// <summary>
        /// 售后服务返回对象
        /// </summary>
        [XmlArray("after_sales")]
        [XmlArrayItem("after_sale")]
        public List<Top.Api.Domain.AfterSale> AfterSales { get; set; }

    }
}
