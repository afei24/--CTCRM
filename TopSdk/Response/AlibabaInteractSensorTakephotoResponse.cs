using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorTakephotoResponse.
    /// </summary>
    public class AlibabaInteractSensorTakephotoResponse : TopResponse
    {
        /// <summary>
        /// return=0表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
