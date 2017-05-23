using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FuwuPurchaseOrderConfirmResponse.
    /// </summary>
    public class FuwuPurchaseOrderConfirmResponse : TopResponse
    {
        /// <summary>
        /// 下单页面url
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

    }
}
