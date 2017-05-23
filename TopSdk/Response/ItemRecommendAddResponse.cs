using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemRecommendAddResponse.
    /// </summary>
    public class ItemRecommendAddResponse : TopResponse
    {
        /// <summary>
        /// 被推荐的商品的信息
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
