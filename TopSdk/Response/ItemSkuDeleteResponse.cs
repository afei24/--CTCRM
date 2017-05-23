using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSkuDeleteResponse.
    /// </summary>
    public class ItemSkuDeleteResponse : TopResponse
    {
        /// <summary>
        /// Sku结构
        /// </summary>
        [XmlElement("sku")]
        public Top.Api.Domain.Sku Sku { get; set; }

    }
}
