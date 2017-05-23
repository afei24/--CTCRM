using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TraderateAddResponse.
    /// </summary>
    public class TraderateAddResponse : TopResponse
    {
        /// <summary>
        /// 返回tid、oid、create
        /// </summary>
        [XmlElement("trade_rate")]
        public Top.Api.Domain.TradeRate TradeRate { get; set; }

    }
}
