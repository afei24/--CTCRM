using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSellerGetResponse.
    /// </summary>
    public class ItemSellerGetResponse : TopResponse
    {
        /// <summary>
        /// 商品详细信息
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
