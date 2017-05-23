using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorMakeupResponse.
    /// </summary>
    public class AlibabaInteractSensorMakeupResponse : TopResponse
    {
        /// <summary>
        /// 非restAPI，为jsapi  result=0
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
