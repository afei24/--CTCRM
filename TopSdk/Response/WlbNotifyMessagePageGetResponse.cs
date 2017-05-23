using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbNotifyMessagePageGetResponse.
    /// </summary>
    public class WlbNotifyMessagePageGetResponse : TopResponse
    {
        /// <summary>
        /// 2000-01-01 00:00:00
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 通道消息
        /// </summary>
        [XmlArray("wlb_messages")]
        [XmlArrayItem("wlb_message")]
        public List<Top.Api.Domain.WlbMessage> WlbMessages { get; set; }

    }
}
