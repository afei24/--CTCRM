using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemAddResponse.
    /// </summary>
    public class ItemAddResponse : TopResponse
    {
        /// <summary>
        /// 商品结构,仅有numIid和created返回
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
