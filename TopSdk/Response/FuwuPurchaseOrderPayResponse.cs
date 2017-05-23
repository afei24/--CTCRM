using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FuwuPurchaseOrderPayResponse.
    /// </summary>
    public class FuwuPurchaseOrderPayResponse : TopResponse
    {
        /// <summary>
        /// 该url用于订单付款
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

    }
}
