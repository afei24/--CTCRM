using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorGcanvasResponse.
    /// </summary>
    public class AlibabaInteractSensorGcanvasResponse : TopResponse
    {
        /// <summary>
        /// result=0
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
