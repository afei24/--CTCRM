using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSkuGetResponse.
    /// </summary>
    public class ItemSkuGetResponse : TopResponse
    {
        /// <summary>
        /// Sku
        /// </summary>
        [XmlElement("sku")]
        public Top.Api.Domain.Sku Sku { get; set; }

    }
}
