using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemPriceUpdateResponse.
    /// </summary>
    public class ItemPriceUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品结构里的num_iid，modified
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
