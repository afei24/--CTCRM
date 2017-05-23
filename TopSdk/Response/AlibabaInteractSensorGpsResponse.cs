using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorGpsResponse.
    /// </summary>
    public class AlibabaInteractSensorGpsResponse : TopResponse
    {
        /// <summary>
        /// succ
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
