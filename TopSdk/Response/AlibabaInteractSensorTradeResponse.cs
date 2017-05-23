using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorTradeResponse.
    /// </summary>
    public class AlibabaInteractSensorTradeResponse : TopResponse
    {
        /// <summary>
        /// result=1
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
