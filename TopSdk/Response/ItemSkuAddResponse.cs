using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSkuAddResponse.
    /// </summary>
    public class ItemSkuAddResponse : TopResponse
    {
        /// <summary>
        /// sku
        /// </summary>
        [XmlElement("sku")]
        public Top.Api.Domain.Sku Sku { get; set; }

    }
}
