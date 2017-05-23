using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSkuPriceUpdateResponse.
    /// </summary>
    public class ItemSkuPriceUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品SKU信息（只包含num_iid和modified）
        /// </summary>
        [XmlElement("sku")]
        public Top.Api.Domain.Sku Sku { get; set; }

    }
}
