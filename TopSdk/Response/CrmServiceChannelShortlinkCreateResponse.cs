using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CrmServiceChannelShortlinkCreateResponse.
    /// </summary>
    public class CrmServiceChannelShortlinkCreateResponse : TopResponse
    {
        /// <summary>
        /// 返回的淘短链。
        /// </summary>
        [XmlElement("short_link")]
        public string ShortLink { get; set; }

    }
}
