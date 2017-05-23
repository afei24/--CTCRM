using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorShakeResponse.
    /// </summary>
    public class AlibabaInteractSensorShakeResponse : TopResponse
    {
        /// <summary>
        /// 0
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
