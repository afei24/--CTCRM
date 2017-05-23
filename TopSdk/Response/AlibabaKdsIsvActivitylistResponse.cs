using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaKdsIsvActivitylistResponse.
    /// </summary>
    public class AlibabaKdsIsvActivitylistResponse : TopResponse
    {
        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("unnamed")]
        public string Unnamed { get; set; }

    }
}
