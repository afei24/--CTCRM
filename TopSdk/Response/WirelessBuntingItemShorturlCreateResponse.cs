using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WirelessBuntingItemShorturlCreateResponse.
    /// </summary>
    public class WirelessBuntingItemShorturlCreateResponse : TopResponse
    {
        /// <summary>
        /// 短地址
        /// </summary>
        [XmlElement("shorturl")]
        public string Shorturl { get; set; }

    }
}
