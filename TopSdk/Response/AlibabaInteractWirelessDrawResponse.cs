using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractWirelessDrawResponse.
    /// </summary>
    public class AlibabaInteractWirelessDrawResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
