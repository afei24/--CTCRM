using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorNetworkstatusResponse.
    /// </summary>
    public class AlibabaInteractSensorNetworkstatusResponse : TopResponse
    {
        /// <summary>
        /// return=0表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
