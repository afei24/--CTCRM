using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorGravityResponse.
    /// </summary>
    public class AlibabaInteractSensorGravityResponse : TopResponse
    {
        /// <summary>
        /// 0表示成功呢
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
