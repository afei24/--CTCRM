using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TraderateListAddResponse.
    /// </summary>
    public class TraderateListAddResponse : TopResponse
    {
        /// <summary>
        /// 返回的评论的信息，仅返回tid和created字段
        /// </summary>
        [XmlElement("trade_rate")]
        public Top.Api.Domain.TradeRate TradeRate { get; set; }

    }
}
