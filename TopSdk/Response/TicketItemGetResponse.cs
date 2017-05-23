using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TicketItemGetResponse.
    /// </summary>
    public class TicketItemGetResponse : TopResponse
    {
        /// <summary>
        /// 参见TicketItem数据结构文档
        /// </summary>
        [XmlElement("ticket_item")]
        public Top.Api.Domain.TicketItem TicketItem { get; set; }

    }
}
