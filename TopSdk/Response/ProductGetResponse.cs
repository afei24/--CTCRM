using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ProductGetResponse.
    /// </summary>
    public class ProductGetResponse : TopResponse
    {
        /// <summary>
        /// 返回具体信息为入参fields请求的字段信息
        /// </summary>
        [XmlElement("product")]
        public Top.Api.Domain.Product Product { get; set; }

    }
}
