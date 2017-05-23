using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorBlowResponse.
    /// </summary>
    public class AlibabaInteractSensorBlowResponse : TopResponse
    {
        /// <summary>
        /// return=0 表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
