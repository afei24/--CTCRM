using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ProductAddResponse.
    /// </summary>
    public class ProductAddResponse : TopResponse
    {
        /// <summary>
        /// 产品结构
        /// </summary>
        [XmlElement("product")]
        public Top.Api.Domain.Product Product { get; set; }

    }
}
