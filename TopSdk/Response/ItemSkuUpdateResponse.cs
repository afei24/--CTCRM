using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSkuUpdateResponse.
    /// </summary>
    public class ItemSkuUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品Sku
        /// </summary>
        [XmlElement("sku")]
        public Top.Api.Domain.Sku Sku { get; set; }

    }
}
