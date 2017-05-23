using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemDeleteResponse.
    /// </summary>
    public class ItemDeleteResponse : TopResponse
    {
        /// <summary>
        /// 被删除商品的相关信息
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
