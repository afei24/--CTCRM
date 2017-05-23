using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorAudioResponse.
    /// </summary>
    public class AlibabaInteractSensorAudioResponse : TopResponse
    {
        /// <summary>
        /// result=0表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
