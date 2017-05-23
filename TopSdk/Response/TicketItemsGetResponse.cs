using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TicketItemsGetResponse.
    /// </summary>
    public class TicketItemsGetResponse : TopResponse
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        [XmlArray("ticket_items")]
        [XmlArrayItem("ticket_item")]
        public List<Top.Api.Domain.TicketItem> TicketItems { get; set; }

    }
}
