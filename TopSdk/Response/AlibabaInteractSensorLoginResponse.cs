using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorLoginResponse.
    /// </summary>
    public class AlibabaInteractSensorLoginResponse : TopResponse
    {
        /// <summary>
        /// return=0表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
