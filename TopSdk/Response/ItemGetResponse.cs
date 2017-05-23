using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemGetResponse.
    /// </summary>
    public class ItemGetResponse : TopResponse
    {
        /// <summary>
        /// 获取的商品 具体字段根据权限和设定的fields决定
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
